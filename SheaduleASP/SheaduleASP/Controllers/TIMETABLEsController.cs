using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SheaduleASP;

namespace SheaduleASP.Controllers
{
    public class TIMETABLEsController : Controller
    {
        private SheaduleContext db = new SheaduleContext();

        // GET: TIMETABLEs
        public async Task<ActionResult> Index()
        {
            var tIMETABLE = db.TIMETABLE.Include(t => t.ACTIVITY).Include(t => t.AUDITORIUM).Include(t => t.DISCIPLINE).Include(t => t.GROUPS).Include(t => t.TEACHER).Include(t => t.TIME).Include(t => t.TYPE).Include(t => t.WEEKDAY);
            return View(await tIMETABLE.ToListAsync());
        }

        // GET: TIMETABLEs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIMETABLE tIMETABLE = await db.TIMETABLE.FindAsync(id);
            if (tIMETABLE == null)
            {
                return HttpNotFound();
            }
            return View(tIMETABLE);
        }

        // GET: TIMETABLEs/Create
        public ActionResult Create()
        {
            ViewBag.ACTIVITY_TYPE_CODE = new SelectList(db.ACTIVITY, "ACTIVITY_TYPE_CODE", "ACTIVITY_TYPE_NAME");
            ViewBag.AUDITORIUM_CODE = new SelectList(db.AUDITORIUM, "AUDITORIUM_CODE", "BUILDING");
            ViewBag.DISCIPLINE_CODE = new SelectList(db.DISCIPLINE, "DISCIPLINE_CODE", "DISCIPLINE_NAME");
            ViewBag.GROUP_CODE = new SelectList(db.GROUPS, "GROUP_CODE", "GROUP_NUMBER");
            ViewBag.TEACHER_CODE = new SelectList(db.TEACHER, "TEACHER_CODE", "TEACHER_NAME");
            ViewBag.TIME_CODE = new SelectList(db.TIME, "TIME_CODE", "TIME_START");
            ViewBag.TYPE_CODE = new SelectList(db.TYPE, "TYPE_CODE", "TYPE_NAME");
            ViewBag.WEEKDAY_CODE = new SelectList(db.WEEKDAY, "WEEKDAY_CODE", "WEEKDAY_NAME");
            return View();
        }

        // POST: TIMETABLEs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LESSON_CODE,WEEKDAY_CODE,COURSE_CODE,GROUP_CODE,TEACHER_CODE,DISCIPLINE_CODE,ACTIVITY_TYPE_CODE,AUDITORIUM_CODE,WEEK_NUMBER,TIME_CODE,CROSSES,TYPE_CODE")] TIMETABLE tIMETABLE)
        {
            if (ModelState.IsValid)
            {
                db.TIMETABLE.Add(tIMETABLE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ACTIVITY_TYPE_CODE = new SelectList(db.ACTIVITY, "ACTIVITY_TYPE_CODE", "ACTIVITY_TYPE_NAME", tIMETABLE.ACTIVITY_TYPE_CODE);
            ViewBag.AUDITORIUM_CODE = new SelectList(db.AUDITORIUM, "AUDITORIUM_CODE", "BUILDING", tIMETABLE.AUDITORIUM_CODE);
            ViewBag.DISCIPLINE_CODE = new SelectList(db.DISCIPLINE, "DISCIPLINE_CODE", "DISCIPLINE_NAME", tIMETABLE.DISCIPLINE_CODE);
            ViewBag.GROUP_CODE = new SelectList(db.GROUPS, "GROUP_CODE", "GROUP_NUMBER", tIMETABLE.GROUP_CODE);
            ViewBag.TEACHER_CODE = new SelectList(db.TEACHER, "TEACHER_CODE", "TEACHER_NAME", tIMETABLE.TEACHER_CODE);
            ViewBag.TIME_CODE = new SelectList(db.TIME, "TIME_CODE", "TIME_START", tIMETABLE.TIME_CODE);
            ViewBag.TYPE_CODE = new SelectList(db.TYPE, "TYPE_CODE", "TYPE_NAME", tIMETABLE.TYPE_CODE);
            ViewBag.WEEKDAY_CODE = new SelectList(db.WEEKDAY, "WEEKDAY_CODE", "WEEKDAY_NAME", tIMETABLE.WEEKDAY_CODE);
            return View(tIMETABLE);
        }

        // GET: TIMETABLEs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIMETABLE tIMETABLE = await db.TIMETABLE.FindAsync(id);
            if (tIMETABLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ACTIVITY_TYPE_CODE = new SelectList(db.ACTIVITY, "ACTIVITY_TYPE_CODE", "ACTIVITY_TYPE_NAME", tIMETABLE.ACTIVITY_TYPE_CODE);
            ViewBag.AUDITORIUM_CODE = new SelectList(db.AUDITORIUM, "AUDITORIUM_CODE", "BUILDING", tIMETABLE.AUDITORIUM_CODE);
            ViewBag.DISCIPLINE_CODE = new SelectList(db.DISCIPLINE, "DISCIPLINE_CODE", "DISCIPLINE_NAME", tIMETABLE.DISCIPLINE_CODE);
            ViewBag.GROUP_CODE = new SelectList(db.GROUPS, "GROUP_CODE", "GROUP_NUMBER", tIMETABLE.GROUP_CODE);
            ViewBag.TEACHER_CODE = new SelectList(db.TEACHER, "TEACHER_CODE", "TEACHER_NAME", tIMETABLE.TEACHER_CODE);
            ViewBag.TIME_CODE = new SelectList(db.TIME, "TIME_CODE", "TIME_START", tIMETABLE.TIME_CODE);
            ViewBag.TYPE_CODE = new SelectList(db.TYPE, "TYPE_CODE", "TYPE_NAME", tIMETABLE.TYPE_CODE);
            ViewBag.WEEKDAY_CODE = new SelectList(db.WEEKDAY, "WEEKDAY_CODE", "WEEKDAY_NAME", tIMETABLE.WEEKDAY_CODE);
            return View(tIMETABLE);
        }

        // POST: TIMETABLEs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LESSON_CODE,WEEKDAY_CODE,COURSE_CODE,GROUP_CODE,TEACHER_CODE,DISCIPLINE_CODE,ACTIVITY_TYPE_CODE,AUDITORIUM_CODE,WEEK_NUMBER,TIME_CODE,CROSSES,TYPE_CODE")] TIMETABLE tIMETABLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIMETABLE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ACTIVITY_TYPE_CODE = new SelectList(db.ACTIVITY, "ACTIVITY_TYPE_CODE", "ACTIVITY_TYPE_NAME", tIMETABLE.ACTIVITY_TYPE_CODE);
            ViewBag.AUDITORIUM_CODE = new SelectList(db.AUDITORIUM, "AUDITORIUM_CODE", "BUILDING", tIMETABLE.AUDITORIUM_CODE);
            ViewBag.DISCIPLINE_CODE = new SelectList(db.DISCIPLINE, "DISCIPLINE_CODE", "DISCIPLINE_NAME", tIMETABLE.DISCIPLINE_CODE);
            ViewBag.GROUP_CODE = new SelectList(db.GROUPS, "GROUP_CODE", "GROUP_NUMBER", tIMETABLE.GROUP_CODE);
            ViewBag.TEACHER_CODE = new SelectList(db.TEACHER, "TEACHER_CODE", "TEACHER_NAME", tIMETABLE.TEACHER_CODE);
            ViewBag.TIME_CODE = new SelectList(db.TIME, "TIME_CODE", "TIME_START", tIMETABLE.TIME_CODE);
            ViewBag.TYPE_CODE = new SelectList(db.TYPE, "TYPE_CODE", "TYPE_NAME", tIMETABLE.TYPE_CODE);
            ViewBag.WEEKDAY_CODE = new SelectList(db.WEEKDAY, "WEEKDAY_CODE", "WEEKDAY_NAME", tIMETABLE.WEEKDAY_CODE);
            return View(tIMETABLE);
        }

        // GET: TIMETABLEs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIMETABLE tIMETABLE = await db.TIMETABLE.FindAsync(id);
            if (tIMETABLE == null)
            {
                return HttpNotFound();
            }
            return View(tIMETABLE);
        }

        // POST: TIMETABLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TIMETABLE tIMETABLE = await db.TIMETABLE.FindAsync(id);
            db.TIMETABLE.Remove(tIMETABLE);
            await db.SaveChangesAsync();
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
