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
    public class FuelTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFuelTypeRepository _repo;
        public FuelTypeController(IFuelTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: FuelTypeController
        public async Task<ActionResult> Index()
        {
            var fuelTypes = await _repo.FindAll();
            var model = _mapper.Map<List<FuelType>, List<FuelTypeVM>>(fuelTypes);
            return View(model);
        }

        // GET: FuelTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var fuelTypes = await _repo.FindById(id);
            var model = _mapper.Map<FuelType, FuelTypeVM>(fuelTypes);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: FuelTypeController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: FuelTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateFuelTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var fuelType = _mapper.Map<FuelType>(model);
                var isSuccess = await _repo.Create(fuelType);
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

        // GET: FuelTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var fuelType = await _repo.FindById(id);
            var model = _mapper.Map<FuelType, CreateFuelTypeVM>(fuelType);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: FuelTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateFuelTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var fuelType = _mapper.Map<FuelType>(model);
                var isSuccess = await _repo.Edit(fuelType);
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

        // GET: FuelTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var fuelType = await _repo.FindById(id);
            var model = _mapper.Map<FuelType, FuelTypeVM>(fuelType);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: FuelTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, FuelTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var fuelTypes = await _repo.FindById(id);
                var isSuccess = await _repo.Delete(fuelTypes);
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
