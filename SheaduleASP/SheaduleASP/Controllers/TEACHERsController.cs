using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SheaduleASP.Controllers
{
    public class TEACHERsController : Controller
    {
        private readonly SheaduleContext db = new SheaduleContext();

        // GET: TEACHERs
        public async Task<ActionResult> Index()
        {
            return View(await db.TEACHER.ToListAsync());
        }

        // GET: TEACHERs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tEACHER = await db.TEACHER.FindAsync(id);
            if (tEACHER == null)
                return HttpNotFound();
            return View(tEACHER);
        }

        // GET: TEACHERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TEACHERs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TEACHER_CODE,TEACHER_NAME")] TEACHER tEACHER)
        {
            if (ModelState.IsValid)
            {
                db.TEACHER.Add(tEACHER);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tEACHER);
        }

        // GET: TEACHERs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tEACHER = await db.TEACHER.FindAsync(id);
            if (tEACHER == null)
                return HttpNotFound();
            return View(tEACHER);
        }

        // POST: TEACHERs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TEACHER_CODE,TEACHER_NAME")] TEACHER tEACHER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEACHER).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tEACHER);
        }

        // GET: TEACHERs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tEACHER = await db.TEACHER.FindAsync(id);
            if (tEACHER == null)
                return HttpNotFound();
            return View(tEACHER);
        }

        // POST: TEACHERs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var tEACHER = await db.TEACHER.FindAsync(id);
            db.TEACHER.Remove(tEACHER);
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