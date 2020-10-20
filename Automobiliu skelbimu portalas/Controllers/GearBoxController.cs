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
    public class GearBoxController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGearBoxRepository _repo;
        public GearBoxController(IGearBoxRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: GearBoxController
        public async Task<ActionResult> Index()
        {
            var gearBoxes = await _repo.FindAll();
            var model = _mapper.Map<List<GearBox>, List<GearBoxVM>>(gearBoxes);
            return View(model);
        }

        // GET: GearBoxController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var gearBox = await _repo.FindById(id);
            var model = _mapper.Map<GearBox, GearBoxVM>(gearBox);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: GearBoxController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: GearBoxController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateGearBoxVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var gearBox = _mapper.Map<GearBox>(model);
                var isExists = await _repo.isExist(gearBox.Title);
                if (isExists)
                {
                    ModelState.AddModelError("", "This gear box already exist");
                    return View(model);
                }
                var isSuccess = await _repo.Create(gearBox);
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

        // GET: GearBoxController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var gearBox = await _repo.FindById(id);
            var model = _mapper.Map<GearBox, CreateGearBoxVM>(gearBox);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: GearBoxController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateGearBoxVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var gearBox = _mapper.Map<GearBox>(model);
                var isExists = await _repo.isExist(gearBox.Title);
                if (isExists)
                {
                    ModelState.AddModelError("", "This gear box already exist");
                    return View(model);
                }
                var isSuccess = await _repo.Update(gearBox);
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

        // GET: GearBoxController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var gearBox = await _repo.FindById(id);
            var model = _mapper.Map<GearBox, GearBoxVM>(gearBox);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: GearBoxController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, GearBoxVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var gearBox = await _repo.FindById(id);
                var isSuccess = await _repo.Delete(gearBox);
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
