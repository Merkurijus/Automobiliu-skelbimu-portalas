using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automobiliu_skelbimu_portalas.Controllers
{
    public class MakeController : Controller
    {
        // GET: MakeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MakeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MakeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MakeController/Create
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

        // GET: MakeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MakeController/Edit/5
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

        // GET: MakeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MakeController/Delete/5
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
