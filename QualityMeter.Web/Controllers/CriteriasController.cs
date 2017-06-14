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
    public class CriteriasController : Controller
    {
        private readonly CriteriaService _oCriteriaService = new CriteriaService(new CriteriasRepository(), new DebugLogger());
        private readonly FactorService _oFactorService = new FactorService(new FactorsRepository(), new DebugLogger());
        private readonly SubjectService _oSubjectService = new SubjectService(new SubjectsRepository(), new DebugLogger());


        // GET: Criteria
        public ActionResult Index()
        {
            return View(_oCriteriaService.GetAll(sort: "Name").ToList());
        }

        // GET: Criteria/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criteria criteria = _oCriteriaService.GetById(id.Value);
            if (criteria == null)
            {
                return HttpNotFound();
            }
            return View(criteria);
        }

        // GET: Criteria/Create
        public ActionResult Create()
        {
            Criteria criteria = new Criteria();
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            return View(criteria);
        }

        // POST: Criteria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,FactorId,CreationDate,LastUpdated,RowVersion")] Criteria criteria)
        {
            if (ModelState.IsValid)
            {
                criteria.Id = Guid.NewGuid();
                _oCriteriaService.Add(criteria);
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            return View(criteria);
        }

        // GET: Criteria/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criteria criteria = _oCriteriaService.GetById(id.Value);
            if (criteria == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            return View(criteria);
        }

        // POST: Criteria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,FactorId,CreationDate,LastUpdated,RowVersion")] Criteria criteria)
        {
            if (ModelState.IsValid)
            {
                criteria.LastUpdated = DateTime.Now;
                _oCriteriaService.Update(criteria);
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(_oSubjectService.GetAll(sort: "Name"), "Id", "Name");
            ViewBag.FactorId = new SelectList(_oFactorService.GetAll(sort: "Name"), "Id", "Name");
            return View(criteria);
        }

        // GET: Criteria/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criteria criteria = _oCriteriaService.GetById(id.Value);
            if (criteria == null)
            {
                return HttpNotFound();
            }
            return View(criteria);
        }

        // POST: Criteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _oCriteriaService.Delete(id);
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
