using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SheaduleASP.Controllers
{
    public class DISCIPLINEsController : Controller
    {
        private readonly SheaduleContext db = new SheaduleContext();

        // GET: DISCIPLINEs
        public async Task<ActionResult> Index()
        {
            return View(await db.DISCIPLINE.ToListAsync());
        }

        // GET: DISCIPLINEs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var dISCIPLINE = await db.DISCIPLINE.FindAsync(id);
            if (dISCIPLINE == null)
                return HttpNotFound();
            return View(dISCIPLINE);
        }

        // GET: DISCIPLINEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DISCIPLINEs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "DISCIPLINE_CODE,DISCIPLINE_NAME")] DISCIPLINE dISCIPLINE)
        {
            if (ModelState.IsValid)
            {
                db.DISCIPLINE.Add(dISCIPLINE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dISCIPLINE);
        }

        // GET: DISCIPLINEs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var dISCIPLINE = await db.DISCIPLINE.FindAsync(id);
            if (dISCIPLINE == null)
                return HttpNotFound();
            return View(dISCIPLINE);
        }

        // POST: DISCIPLINEs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DISCIPLINE_CODE,DISCIPLINE_NAME")] DISCIPLINE dISCIPLINE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISCIPLINE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dISCIPLINE);
        }

        // GET: DISCIPLINEs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var dISCIPLINE = await db.DISCIPLINE.FindAsync(id);
            if (dISCIPLINE == null)
                return HttpNotFound();
            return View(dISCIPLINE);
        }

        // POST: DISCIPLINEs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var dISCIPLINE = await db.DISCIPLINE.FindAsync(id);
            db.DISCIPLINE.Remove(dISCIPLINE);
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