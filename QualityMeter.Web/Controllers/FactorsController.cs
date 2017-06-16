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
    public class FactorsController : Controller
    {
        private readonly FactorService _oFactorService = new FactorService(new FactorsRepository(), new DebugLogger());
        private readonly SubjectService _oSubjectService = new SubjectService(new SubjectsRepository(), new DebugLogger());

        // GET: Factors
        public ActionResult Index(int page = 1)
        {
            return View(_oFactorService.GetAll(sort: "Name").ToPagedList(page, 10));
        }

        // GET: Factors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factor factor = _oFactorService.GetById(id.Value);
            if (factor == null)
            {
                return HttpNotFound();
            }
            return View(factor);
        }

        // GET: Factors/Create
        public ActionResult Create()
        {
            Factor factor = new Factor();
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            return View(factor);
        }

        // POST: Factors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,SubjectId,CreationDate,LastUpdated,RowVersion")] Factor factor)
        {
            if (ModelState.IsValid)
            {
                factor.Id = Guid.NewGuid();
                _oFactorService.Add(factor);

                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name", factor.SubjectId);
            return View(factor);
        }

        // GET: Factors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factor factor = _oFactorService.GetById(id.Value);

            if (factor == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name", factor.SubjectId);
            return View(factor);
        }

        // POST: Factors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,SubjectId,CreationDate,LastUpdated,RowVersion")] Factor factor)
        {
            if (ModelState.IsValid)
            {
                factor.LastUpdated = DateTime.Now;
                _oFactorService.Update(factor);
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name", factor.SubjectId);
            return View(factor);
        }

        // GET: Factors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factor factor = _oFactorService.GetById(id.Value);
            if (factor == null)
            {
                return HttpNotFound();
            }
            return View(factor);
        }

        // POST: Factors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _oFactorService.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetFactors(Guid subjectId)
        {

            return Json(new SelectList(_oFactorService.GetAll(sort: "Name").Where(x => x.SubjectId == subjectId), "Id", "Name"), JsonRequestBehavior.AllowGet);
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
