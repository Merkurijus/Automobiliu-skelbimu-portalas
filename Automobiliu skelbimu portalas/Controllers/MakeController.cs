using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Automobiliu_skelbimu_portalas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automobiliu_skelbimu_portalas.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MakeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMakeRepository _repo;
        public MakeController(IMapper mapper, IMakeRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        // GET: MakeController
        public async Task<ActionResult> Index()
        {
            var makes = await _repo.FindAll();
            var model = _mapper.Map<List<Make>, List<MakeVM>>(makes);
            return View(model);
        }

        // GET: MakeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var make = await _repo.FindById(id);
            var model = _mapper.Map<Make, MakeVM>(make);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: MakeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MakeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMakeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var make = _mapper.Map<Make>(model);
                var isExists = await _repo.isExist(make.Title);
                if (isExists)
                {
                    ModelState.AddModelError("", "This make already exist");
                    return View(model);
                }
                var isSuccess = await _repo.Create(make);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: MakeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var make = await _repo.FindById(id);
            var model = _mapper.Map<Make, CreateMakeVM>(make);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: MakeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateMakeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var make = _mapper.Map<Make>(model);
                var isExists = await _repo.isExist(make.Title);
                if (isExists)
                {
                    ModelState.AddModelError("", "This make already exist");
                    return View(model);
                }
                var isSuccess = await _repo.Update(make);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: MakeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var make = await _repo.FindById(id);
            var model = _mapper.Map<Make, MakeVM>(make);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: MakeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, MakeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var make = await _repo.FindById(id);
                var isSuccess = await _repo.Delete(make);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
