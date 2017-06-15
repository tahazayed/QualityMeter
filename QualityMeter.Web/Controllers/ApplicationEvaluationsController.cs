using QualityMeter.Core.Models;
using QualityMeter.Core.Services;
using QualityMeter.Infrastructure.Common.Services;
using QualityMeter.Infrastructure.Data;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QualityMeter.Web.Controllers
{
    public class ApplicationEvaluationsController : Controller
    {
        private readonly ApplicationService _oApplicationService = new ApplicationService(new ApplicationsRepository(), new DebugLogger());
        private readonly ApplicationEvaluationService _oApplicationEvaluationService = new ApplicationEvaluationService(new ApplicationEvaluationsRepository(), new DebugLogger());
        private readonly QualityAttributesMetricService _oQualityAttributesMetricService = new QualityAttributesMetricService(new QualityAttributesMetricsRepository(), new DebugLogger());


        private EfQualityMeterBaseDb db = new EfQualityMeterBaseDb();

        // GET: ApplicationEvaluations
        public ActionResult Index(Guid applicationId)
        {
            ViewBag.applicationId = applicationId;
            return PartialView(_oApplicationEvaluationService.GetAll(sort: "Id").Where(x => x.ApplicationId == applicationId).ToList());
        }

        // GET: ApplicationEvaluations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationEvaluation applicationEvaluation = db.ApplicationEvaluations.Find(id);
            if (applicationEvaluation == null)
            {
                return HttpNotFound();
            }
            return View(applicationEvaluation);
        }

        // GET: ApplicationEvaluations/Create
        public ActionResult Create(Guid applicationId)
        {
            ApplicationEvaluation applicationEvaluation = new ApplicationEvaluation { ApplicationId = applicationId };

            ViewBag.ApplicationId = new SelectList(_oApplicationService.GetAll(sort: "Name").ToList(), "Id", "Name");
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
                db.ApplicationEvaluations.Add(applicationEvaluation);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.ApplicationId = new SelectList(db.Applications, "Id", "Name", applicationEvaluation.ApplicationId);
            ViewBag.QualityAttributesMetricId = new SelectList(db.QualityAttributesMetrics, "Id", "Name", applicationEvaluation.QualityAttributesMetricId);
            return PartialView(applicationEvaluation);
        }

        // GET: ApplicationEvaluations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationEvaluation applicationEvaluation = db.ApplicationEvaluations.Find(id);
            if (applicationEvaluation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationId = new SelectList(db.Applications, "Id", "Name", applicationEvaluation.ApplicationId);
            ViewBag.QualityAttributesMetricId = new SelectList(db.QualityAttributesMetrics, "Id", "Name", applicationEvaluation.QualityAttributesMetricId);
            return View(applicationEvaluation);
        }

        // POST: ApplicationEvaluations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QualityAttributesMetricId,ApplicationId,QualityValue,UserValue,CreationDate,LastUpdated,RowVersion")] ApplicationEvaluation applicationEvaluation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationEvaluation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationId = new SelectList(db.Applications, "Id", "Name", applicationEvaluation.ApplicationId);
            ViewBag.QualityAttributesMetricId = new SelectList(db.QualityAttributesMetrics, "Id", "Name", applicationEvaluation.QualityAttributesMetricId);
            return View(applicationEvaluation);
        }

        // GET: ApplicationEvaluations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationEvaluation applicationEvaluation = db.ApplicationEvaluations.Find(id);
            if (applicationEvaluation == null)
            {
                return HttpNotFound();
            }
            return View(applicationEvaluation);
        }

        // POST: ApplicationEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicationEvaluation applicationEvaluation = db.ApplicationEvaluations.Find(id);
            db.ApplicationEvaluations.Remove(applicationEvaluation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
