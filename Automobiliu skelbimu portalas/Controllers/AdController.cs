using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automobiliu_skelbimu_portalas.Controllers
{
    public class AdController : Controller
    {
        // GET: AdController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdController/Create
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

        // GET: AdController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdController/Edit/5
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

        // GET: AdController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdController/Delete/5
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
