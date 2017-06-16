using QualityMeter.Core.Extensions;
using QualityMeter.Core.Interfaces;
using QualityMeter.Core.Interfaces.Repository;
using QualityMeter.Core.Interfaces.Service;
using QualityMeter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace QualityMeter.Core.Services
{
    public class GenericService<T> : IGenericService<T> where T : CommonBaseBusinessEntity
    {
        const int MaxPageSize = Int32.MaxValue;
        protected readonly IGenericRepository<T> _oRepository;
        protected readonly ILog _oLogging;

        public GenericService(IGenericRepository<T> oRepository, ILog oLogging)
        {
            _oRepository = oRepository;
            _oLogging = oLogging;
        }

        public virtual IEnumerable<T> GetAll(string sort = "id"
            , int page = 1, int pageSize = MaxPageSize)
        {
            // ensure the page size isn't larger than the maximum.
            if (pageSize > MaxPageSize)
            {
                pageSize = MaxPageSize;
            }
            var entities = _oRepository.GetAll();

            // calculate data for metadata
            var totalCount = entities.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var request = (HttpRequestMessage)HttpContext.Current.Items["MS_HttpRequestMessage"];
            string actionName = GetActionName(request);
            var urlHelper = new UrlHelper(request);

            var prevLink = page > 1 ? urlHelper.Link(actionName,
                new
                {
                    page = page - 1,
                    pageSize = pageSize,
                    sort = sort
                }) : "";
            var nextLink = page < totalPages ? urlHelper.Link(actionName,
                new
                {
                    page = page + 1,
                    pageSize = pageSize,
                    sort = sort
                }) : "";


            var paginationHeader = new
            {
                currentPage = page,
                pageSize = pageSize,
                totalCount = totalCount,
                totalPages = totalPages,
                previousPageLink = prevLink,
                nextPageLink = nextLink
            };

            HttpContext.Current.Response.Headers.Add("X-Pagination",
            Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));


            var entitiesResult = entities
                .ApplySort(sort)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList()
                .Select(exp => exp);

            return entitiesResult;

        }

        public virtual T GetById(Guid id)
        {
            return _oRepository.FindBy(c => c.Id == id).SingleOrDefault();
        }

        public virtual T Add(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }

                _oRepository.Add(entity);
                _oRepository.Save();

                return GetById(entity.Id);

            }
            catch (Exception ex)
            {
                if (_oLogging.IsErrorEnabled)
                {
                    _oLogging.Error(typeof(T) + ".Add", ex.InnerException ?? ex);
                }
                throw ex.InnerException ?? ex;
            }

        }

        public virtual void Update(T entity)
        {
            try
            {
                _oRepository.Edit(entity);
                _oRepository.Save();
            }
            catch (Exception ex)
            {
                if (_oLogging.IsErrorEnabled)
                {
                    _oLogging.Error(typeof(T) + ".Update", ex.InnerException ?? ex);
                }
                throw ex.InnerException ?? ex;
            }
        }

        public virtual void Delete(Guid id)
        {
            try
            {
                var entity = this.GetById(id);
                if (entity == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                _oRepository.Delete(entity);
                _oRepository.Save();
            }
            catch (Exception ex)
            {
                if (_oLogging.IsErrorEnabled)
                {
                    _oLogging.Error(typeof(T) + ".Delete", ex.InnerException ?? ex);
                }
                throw ex.InnerException ?? ex;
            }
        }

        public void BeginTransaction()
        {
            _oRepository.BeginTransaction();
        }

        public void Commit()
        {
            _oRepository.Commit();
        }

        public void Rollback()
        {
            _oRepository.Rollback();
        }

        string GetActionName(HttpRequestMessage request)
        {

            var config = request.GetConfiguration();
            var routeData = config.Routes.GetRouteData(request);
            var controllerContext = new HttpControllerContext(config, routeData, request);

            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
            controllerContext.RouteData = routeData;
            string actionName = routeData.Values["action"].ToString();
            string controllerName = routeData.Values["controller"].ToString();
            return actionName;
            //// get controller type
            //var controllerDescriptor = new DefaultHttpControllerSelector(config).SelectController(request);
            ////var controllerName = controllerDescriptor.ControllerName;
            //controllerContext.ControllerDescriptor = controllerDescriptor;

            //// get action name
            //var actionMapping = new ApiControllerActionSelector().SelectAction(controllerContext);
            //return actionMapping.ActionName;
        }

    }
}
