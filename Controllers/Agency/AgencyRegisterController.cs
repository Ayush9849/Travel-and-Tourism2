using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Travel_and_Tourism.Controllers.Agency
{
    public class AgencyRegisterController : Controller
    {
        // GET: AgencyRegisterController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AgencyRegisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgencyRegisterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgencyRegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgencyRegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgencyRegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgencyRegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgencyRegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
