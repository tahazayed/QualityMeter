using PagedList;
using QualityMeter.Core.Models;
using QualityMeter.Core.Services;
using QualityMeter.Infrastructure.Common.Services;
using QualityMeter.Infrastructure.Data;
using System;
using System.Net;
using System.Web.Mvc;

namespace QualityMeter.Web.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly SubjectService _oSubjectService = new SubjectService(new SubjectsRepository(), new DebugLogger());


        // GET: Subjects
        public ActionResult Index(int page = 1)
        {

            return View(_oSubjectService.GetAll(sort: "Name").ToPagedList(page, 10));
        }

        // GET: Subjects/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = _oSubjectService.GetById(id.Value);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            Subject subject = new Subject();
            return View(subject);
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreationDate,LastUpdated,RowVersion")] Subject subject)
        {
            if (ModelState.IsValid)
            {

                subject.Id = Guid.NewGuid();

                _oSubjectService.Add(subject);

                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = _oSubjectService.GetById(id.Value);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreationDate,LastUpdated,RowVersion")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.LastUpdated = DateTime.Now;
                _oSubjectService.Update(subject);

                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = _oSubjectService.GetById(id.Value);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _oSubjectService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // oSubjectService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
