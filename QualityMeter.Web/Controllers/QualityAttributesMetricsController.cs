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
    public class QualityAttributesMetricsController : Controller
    {
        private readonly CriteriaService _oCriteriaService = new CriteriaService(new CriteriasRepository(), new DebugLogger());
        private readonly FactorService _oFactorService = new FactorService(new FactorsRepository(), new DebugLogger());
        private readonly SubjectService _oSubjectService = new SubjectService(new SubjectsRepository(), new DebugLogger());
        private readonly QualityAttributesMetricService _oQualityAttributesMetricService = new QualityAttributesMetricService(new QualityAttributesMetricsRepository(), new DebugLogger());



        // GET: QualityAttributesMetrics
        public ActionResult Index(string sort = "name"
            , int page = 1, int pageSize = 10)
        {
            return View(_oQualityAttributesMetricService.GetAll(sort, page, pageSize).ToList());
        }

        // GET: QualityAttributesMetrics/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityAttributesMetric qualityAttributesMetric = _oQualityAttributesMetricService.GetById(id.Value);
            if (qualityAttributesMetric == null)
            {
                return HttpNotFound();
            }
            return View(qualityAttributesMetric);
        }

        // GET: QualityAttributesMetrics/Create
        public ActionResult Create()
        {
            QualityAttributesMetric qualityAttributesMetric = new QualityAttributesMetric();
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.CriteriaId = new SelectList(_oCriteriaService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.AgainstId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name"), "Id", "Name");

            ViewBag.RelatedToId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name"), "Id", "Name");
            return View(qualityAttributesMetric);
        }

        // POST: QualityAttributesMetrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CriteriaId,TypeOfMetric,Quantification,StandardValue,EvaluationValue,RouteBased,RelatedToId,AgainstId,CreationDate,LastUpdated,RowVersion")] QualityAttributesMetric qualityAttributesMetric)
        {
            if (ModelState.IsValid)
            {
                qualityAttributesMetric.Id = Guid.NewGuid();
                _oQualityAttributesMetricService.Add(qualityAttributesMetric);
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.CriteriaId = new SelectList(_oCriteriaService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.AgainstId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name"), "Id", "Name");

            ViewBag.RelatedToId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name"), "Id", "Name");

            return View(qualityAttributesMetric);
        }

        // GET: QualityAttributesMetrics/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityAttributesMetric qualityAttributesMetric = _oQualityAttributesMetricService.GetById(id.Value);
            if (qualityAttributesMetric == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.CriteriaId = new SelectList(_oCriteriaService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.AgainstId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name").Where(x => x.Id != id.Value), "Id", "Name", qualityAttributesMetric.AgainstId);

            ViewBag.RelatedToId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name").Where(x => x.Id != id.Value), "Id", "Name", qualityAttributesMetric.RelatedToId);
            return View(qualityAttributesMetric);
        }

        // POST: QualityAttributesMetrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CriteriaId,TypeOfMetric,Quantification,StandardValue,EvaluationValue,RouteBased,RelatedToId,AgainstId,CreationDate,LastUpdated,RowVersion")] QualityAttributesMetric qualityAttributesMetric)
        {
            if (ModelState.IsValid)
            {
                qualityAttributesMetric.LastUpdated = DateTime.Now;
                _oQualityAttributesMetricService.Update(qualityAttributesMetric);
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.CriteriaId = new SelectList(_oCriteriaService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.AgainstId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name").Where(x => x.Id != qualityAttributesMetric.Id), "Id", "Name", qualityAttributesMetric.AgainstId);

            ViewBag.RelatedToId = new SelectList(_oQualityAttributesMetricService.GetAll(sort: "Name").Where(x => x.Id != qualityAttributesMetric.Id), "Id", "Name", qualityAttributesMetric.RelatedToId);

            return View(qualityAttributesMetric);
        }

        // GET: QualityAttributesMetrics/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityAttributesMetric qualityAttributesMetric = _oQualityAttributesMetricService.GetById(id.Value);
            if (qualityAttributesMetric == null)
            {
                return HttpNotFound();
            }
            return View(qualityAttributesMetric);
        }

        // POST: QualityAttributesMetrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _oQualityAttributesMetricService.Delete(id);
            return RedirectToAction("Index");
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
