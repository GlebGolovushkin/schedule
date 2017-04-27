using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SheaduleASP.Controllers
{
    public class GROUPSController : Controller
    {
        private readonly SheaduleContext db = new SheaduleContext();

        // GET: GROUPS
        public async Task<ActionResult> Index()
        {
            var gROUPS = db.GROUPS.Include(g => g.FACULTY);
            return View(await gROUPS.ToListAsync());
        }

        // GET: GROUPS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var gROUPS = await db.GROUPS.FindAsync(id);
            if (gROUPS == null)
                return HttpNotFound();
            return View(gROUPS);
        }

        // GET: GROUPS/Create
        public ActionResult Create()
        {
            ViewBag.FACULTY_CODE = new SelectList(db.FACULTY, "FACULTY_CODE", "FACULTY_NAME");
            return View();
        }

        // POST: GROUPS/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GROUP_CODE,FACULTY_CODE,GROUP_NUMBER")] GROUPS gROUPS)
        {
            if (ModelState.IsValid)
            {
                db.GROUPS.Add(gROUPS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FACULTY_CODE = new SelectList(db.FACULTY, "FACULTY_CODE", "FACULTY_NAME", gROUPS.FACULTY_CODE);
            return View(gROUPS);
        }

        // GET: GROUPS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var gROUPS = await db.GROUPS.FindAsync(id);
            if (gROUPS == null)
                return HttpNotFound();
            ViewBag.FACULTY_CODE = new SelectList(db.FACULTY, "FACULTY_CODE", "FACULTY_NAME", gROUPS.FACULTY_CODE);
            return View(gROUPS);
        }

        // POST: GROUPS/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GROUP_CODE,FACULTY_CODE,GROUP_NUMBER")] GROUPS gROUPS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gROUPS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FACULTY_CODE = new SelectList(db.FACULTY, "FACULTY_CODE", "FACULTY_NAME", gROUPS.FACULTY_CODE);
            return View(gROUPS);
        }

        // GET: GROUPS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var gROUPS = await db.GROUPS.FindAsync(id);
            if (gROUPS == null)
                return HttpNotFound();
            return View(gROUPS);
        }

        // POST: GROUPS/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var gROUPS = await db.GROUPS.FindAsync(id);
            db.GROUPS.Remove(gROUPS);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}