using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Automobiliu_skelbimu_portalas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automobiliu_skelbimu_portalas.Controllers
{
    public class DamageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDamageRepository _repo;
        public DamageController(IDamageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: DamageController
        public async Task<ActionResult> Index()
        {
            var damages = await _repo.FindAll();
            var model = _mapper.Map<List<Damage>, List<DamageVM>>(damages);
            return View(model);
        }

        // GET: DamageController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var damages = await _repo.FindById(id);
            var model = _mapper.Map<Damage, DamageVM>(damages);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: DamageController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: DamageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDamageVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var damages = _mapper.Map<Damage>(model);
                var isSuccess = await _repo.Create(damages);
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

        // GET: DamageController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var damages = await _repo.FindById(id);
            var model = _mapper.Map<Damage, CreateDamageVM>(damages);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: DamageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateDamageVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var damages = _mapper.Map<Damage>(model);
                var isSuccess = await _repo.Edit(damages);
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

        // GET: DamageController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var damages = await _repo.FindById(id);
            var model = _mapper.Map<Damage, DamageVM>(damages);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: DamageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DamageVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var damages = _mapper.Map<Damage>(model);
                var isSuccess = await _repo.Delete(damages);
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
