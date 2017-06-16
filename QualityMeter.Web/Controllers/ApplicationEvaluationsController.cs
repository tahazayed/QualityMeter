using PagedList;
using QualityMeter.Core.Models;
using QualityMeter.Core.Services;
using QualityMeter.Infrastructure.Common.Services;
using QualityMeter.Infrastructure.Data;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QualityMeter.Web.Controllers
{
    public class ApplicationEvaluationsController : Controller
    {

        private readonly ApplicationEvaluationService _oApplicationEvaluationService = new ApplicationEvaluationService(new ApplicationEvaluationsRepository(), new DebugLogger());
        private readonly CriteriaService _oCriteriaService = new CriteriaService(new CriteriasRepository(), new DebugLogger());
        private readonly FactorService _oFactorService = new FactorService(new FactorsRepository(), new DebugLogger());
        private readonly SubjectService _oSubjectService = new SubjectService(new SubjectsRepository(), new DebugLogger());
        private readonly QualityAttributesMetricService _oQualityAttributesMetricService = new QualityAttributesMetricService(new QualityAttributesMetricsRepository(), new DebugLogger());


        // GET: ApplicationEvaluations
        public ActionResult Index(Guid applicationId, int page = 1)
        {
            ViewBag.applicationId = applicationId;
            return PartialView(_oApplicationEvaluationService.GetAll(sort: "Id").Where(x => x.ApplicationId == applicationId).ToPagedList(page, 10));
        }



        // GET: ApplicationEvaluations/Create
        public ActionResult Create(Guid applicationId)
        {
            ApplicationEvaluation applicationEvaluation = new ApplicationEvaluation { ApplicationId = applicationId };
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.CriteriaId = new SelectList(_oCriteriaService.GetAll(sort: "Name"), "Id", "Name");

            ViewBag.QualityAttributesMetricId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name").ToList(), "Id", "Name");
            return PartialView(applicationEvaluation);
        }

        // POST: ApplicationEvaluations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QualityAttributesMetricId,ApplicationId,QualityValue,UserValue,CreationDate,LastUpdated,RowVersion,ApplicationId")] ApplicationEvaluation applicationEvaluation)
        {
            if (ModelState.IsValid)
            {
                applicationEvaluation.Id = Guid.NewGuid();
                _oApplicationEvaluationService.Add(applicationEvaluation);

                return Json(new { success = true });
            }
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.CriteriaId = new SelectList(_oCriteriaService.GetAll(sort: "Name"), "Id", "Name");

            ViewBag.QualityAttributesMetricId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name"), "Id", "Name", applicationEvaluation.QualityAttributesMetricId);

            return PartialView(applicationEvaluation);
        }

        // GET: ApplicationEvaluations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationEvaluation applicationEvaluation = _oApplicationEvaluationService.GetById(id.Value);
            if (applicationEvaluation == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.CriteriaId = new SelectList(_oCriteriaService.GetAll(sort: "Name"), "Id", "Name");

            ViewBag.QualityAttributesMetricId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name"), "Id", "Name", applicationEvaluation.QualityAttributesMetricId);
            return PartialView(applicationEvaluation);
        }

        // POST: ApplicationEvaluations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QualityAttributesMetricId,ApplicationId,QualityValue,UserValue,CreationDate,LastUpdated,RowVersion,ApplicationId")] ApplicationEvaluation applicationEvaluation)
        {
            if (ModelState.IsValid)
            {
                applicationEvaluation.LastUpdated = DateTime.Now;
                _oApplicationEvaluationService.Update(applicationEvaluation);
                return Json(new { success = true });
            }
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.CriteriaId = new SelectList(_oCriteriaService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.QualityAttributesMetricId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name"), "Id", "Name", applicationEvaluation.QualityAttributesMetricId);
            return PartialView(applicationEvaluation);
        }

        [HttpGet]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationEvaluation applicationEvaluation = _oApplicationEvaluationService.GetById(id.Value);
            if (applicationEvaluation == null)
            {
                return HttpNotFound();
            }
            return Json(new { success = true, Message = "" });

        }

        // POST: ApplicationEvaluations/Delete/5
        [HttpPost]

        public ActionResult Delete(Guid id)
        {
            _oApplicationEvaluationService.Delete(id);
            return Json(new { success = true, Message = "" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
