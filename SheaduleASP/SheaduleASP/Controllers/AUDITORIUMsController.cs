using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SheaduleASP.Controllers
{
    public class AUDITORIUMsController : Controller
    {
        private readonly SheaduleContext db = new SheaduleContext();

        // GET: AUDITORIUMs
        public async Task<ActionResult> Index()
        {
            return View(await db.AUDITORIUM.ToListAsync());
        }

        // GET: AUDITORIUMs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var aUDITORIUM = await db.AUDITORIUM.FindAsync(id);
            if (aUDITORIUM == null)
                return HttpNotFound();
            return View(aUDITORIUM);
        }

        // GET: AUDITORIUMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AUDITORIUMs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "AUDITORIUM_CODE,BUILDING,CAPACITY,AUDITORIUM_NUMBER")] AUDITORIUM aUDITORIUM)
        {
            if (ModelState.IsValid)
            {
                db.AUDITORIUM.Add(aUDITORIUM);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aUDITORIUM);
        }

        // GET: AUDITORIUMs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var aUDITORIUM = await db.AUDITORIUM.FindAsync(id);
            if (aUDITORIUM == null)
                return HttpNotFound();
            return View(aUDITORIUM);
        }

        // POST: AUDITORIUMs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(Include = "AUDITORIUM_CODE,BUILDING,CAPACITY,AUDITORIUM_NUMBER")] AUDITORIUM aUDITORIUM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aUDITORIUM).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aUDITORIUM);
        }

        // GET: AUDITORIUMs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var aUDITORIUM = await db.AUDITORIUM.FindAsync(id);
            if (aUDITORIUM == null)
                return HttpNotFound();
            return View(aUDITORIUM);
        }

        // POST: AUDITORIUMs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var aUDITORIUM = await db.AUDITORIUM.FindAsync(id);
            db.AUDITORIUM.Remove(aUDITORIUM);
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