using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Models;
using Automobiliu_skelbimu_portalas.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Automobiliu_skelbimu_portalas.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ColorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _repo;
        public ColorController(IColorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: ColorController
        public async Task<ActionResult> Index()
        {
            var colors = await _repo.FindAll();
            var model = _mapper.Map<List<Color>, List<ColorVM>>(colors);
            return View(model);
        }

        // GET: ColorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var colors = await _repo.FindById(id);
            var model = _mapper.Map<Color, ColorVM>(colors);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: ColorController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ColorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateColorVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var color = _mapper.Map<Color>(model);
                var isExists = await _repo.isExist(color.Title);
                if (isExists)
                {
                    ModelState.AddModelError("", "This color already exist");
                    return View(model);
                }
                var isSuccess = await _repo.Create(color);
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

        // GET: ColorController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var color = await _repo.FindById(id);
            var model = _mapper.Map<Color, CreateColorVM>(color);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: ColorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateColorVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var color = _mapper.Map<Color>(model);
                var isExists = await _repo.isExist(color.Title);
                if (isExists)
                {
                    ModelState.AddModelError("", "This color already exist");
                    return View(model);
                }
                var isSuccess = await _repo.Update(color);
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

        // GET: ColorController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var color = await _repo.FindById(id);
            var model = _mapper.Map<Color, ColorVM>(color);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: ColorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ColorVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var color = await _repo.FindById(id);
                var isSuccess = await _repo.Delete(color);
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
