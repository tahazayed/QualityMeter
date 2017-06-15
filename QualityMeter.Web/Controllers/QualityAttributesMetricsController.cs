using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QualityMeter.Core.Models;
using QualityMeter.Infrastructure.Data;

namespace QualityMeter.Web.Controllers
{
    public class QualityAttributesMetricsController : Controller
    {
        private EfQualityMeterBaseDb db = new EfQualityMeterBaseDb();

        // GET: QualityAttributesMetrics
        public ActionResult Index()
        {
            var qualityAttributesMetrics = db.QualityAttributesMetrics.Include(q => q.Aganist).Include(q => q.Criteria).Include(q => q.RelatedTo);
            return View(qualityAttributesMetrics.ToList());
        }

        // GET: QualityAttributesMetrics/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityAttributesMetric qualityAttributesMetric = db.QualityAttributesMetrics.Find(id);
            if (qualityAttributesMetric == null)
            {
                return HttpNotFound();
            }
            return View(qualityAttributesMetric);
        }

        // GET: QualityAttributesMetrics/Create
        public ActionResult Create()
        {
            ViewBag.AganistId = new SelectList(db.QualityAttributesMetrics, "Id", "Name");
            ViewBag.CriteriaId = new SelectList(db.Criterias, "Id", "Name");
            ViewBag.RelatedToId = new SelectList(db.QualityAttributesMetrics, "Id", "Name");
            return View();
        }

        // POST: QualityAttributesMetrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CriteriaId,TypeOfMetric,Quantification,StandardValue,EvaluationValue,RuteBased,RelatedToId,AganistId,CreationDate,LastUpdated,RowVersion")] QualityAttributesMetric qualityAttributesMetric)
        {
            if (ModelState.IsValid)
            {
                qualityAttributesMetric.Id = Guid.NewGuid();
                db.QualityAttributesMetrics.Add(qualityAttributesMetric);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AganistId = new SelectList(db.QualityAttributesMetrics, "Id", "Name", qualityAttributesMetric.AganistId);
            ViewBag.CriteriaId = new SelectList(db.Criterias, "Id", "Name", qualityAttributesMetric.CriteriaId);
            ViewBag.RelatedToId = new SelectList(db.QualityAttributesMetrics, "Id", "Name", qualityAttributesMetric.RelatedToId);
            return View(qualityAttributesMetric);
        }

        // GET: QualityAttributesMetrics/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityAttributesMetric qualityAttributesMetric = db.QualityAttributesMetrics.Find(id);
            if (qualityAttributesMetric == null)
            {
                return HttpNotFound();
            }
            ViewBag.AganistId = new SelectList(db.QualityAttributesMetrics, "Id", "Name", qualityAttributesMetric.AganistId);
            ViewBag.CriteriaId = new SelectList(db.Criterias, "Id", "Name", qualityAttributesMetric.CriteriaId);
            ViewBag.RelatedToId = new SelectList(db.QualityAttributesMetrics, "Id", "Name", qualityAttributesMetric.RelatedToId);
            return View(qualityAttributesMetric);
        }

        // POST: QualityAttributesMetrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CriteriaId,TypeOfMetric,Quantification,StandardValue,EvaluationValue,RuteBased,RelatedToId,AganistId,CreationDate,LastUpdated,RowVersion")] QualityAttributesMetric qualityAttributesMetric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualityAttributesMetric).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AganistId = new SelectList(db.QualityAttributesMetrics, "Id", "Name", qualityAttributesMetric.AganistId);
            ViewBag.CriteriaId = new SelectList(db.Criterias, "Id", "Name", qualityAttributesMetric.CriteriaId);
            ViewBag.RelatedToId = new SelectList(db.QualityAttributesMetrics, "Id", "Name", qualityAttributesMetric.RelatedToId);
            return View(qualityAttributesMetric);
        }

        // GET: QualityAttributesMetrics/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityAttributesMetric qualityAttributesMetric = db.QualityAttributesMetrics.Find(id);
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
            QualityAttributesMetric qualityAttributesMetric = db.QualityAttributesMetrics.Find(id);
            db.QualityAttributesMetrics.Remove(qualityAttributesMetric);
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
