
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class NFlowerController : Controller
    {
        IServiceBouquet bouq;
        IserviceNFlower nf;
        // GET: FlightController
        public NFlowerController(IServiceBouquet bouq, IserviceNFlower nf)
        {
            this.bouq = bouq;
            this.nf = nf;
        }
      
        public ActionResult Index()
        {
          
                return View(nf.GetAll());
        
          
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            ViewBag.bouquets = new SelectList(bouq.GetAll(), "BouquetCode","BouquetType");
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NaturalFlower nff)
        {
            try
            {
              
                nf.Add(nff);
                nf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

     /*   // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.conseillerFk = new SelectList(scons.GetAll(), "conseillerId", "conseillerName");
            return View(sc.GetById(id));
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client collection, IFormFile photo)
        {
            
            try
            {
                if (photo == null || photo.Length == 0)
                {
                    return Content("File not selected");
                }
                if (photo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),

                    "wwwroot", "Uploads", photo.FileName);

                    Stream stream = new FileStream(path, FileMode.Create);
                    photo.CopyTo(stream);
                    collection.photo = photo.FileName;

                }
               
                sc.Update(collection);
                sc.Commit(); 
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sc.GetById(id));
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                sc.Delete(sc.GetById(id));
                sc.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
     */
    }
}
