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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Automobiliu_skelbimu_portalas.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ModelController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IModelRepository _repo;
        private readonly IMakeRepository _makeRepo;
        public ModelController(IMapper mapper, IModelRepository repo, IMakeRepository makeRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _makeRepo = makeRepo;
        }
        // GET: ModelController
        public async Task<ActionResult> Index()
        {
            var models = await _repo.FindAll();
            var model = _mapper.Map<List<Model>, List<ModelVM>>(models);
            return View(model);
        }

        // GET: ModelController/Details/5
        public async Task<ActionResult> Details(int id)
        {
           
            var carModel = await _repo.FindById(id);
            var model = _mapper.Map<Model, CreateModelVM>(carModel);
            if (model == null)
            {
                return NotFound();
            }
           
            return View(model);
        }

        // GET: ModelController/Create
        public async Task<ActionResult> Create()
        {
            var makes = await _makeRepo.FindAll();
            var makeItems = makes.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            var model = new CreateModelVM
            {
                MakelList = makeItems
            };
            return View(model);
        }

        // POST: ModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateModelVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var carModel = _mapper.Map<Model>(model);
                var isSuccess = await _repo.Create(carModel);
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

        // GET: ModelController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var makes = await _makeRepo.FindAll();
            var makeItems = makes.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
           
            var carModel = await _repo.FindById(id);
            var adModel = _mapper.Map<Model, CreateModelVM>(carModel);

            if (adModel == null)
            {
                return NotFound();
            }
            var model = new CreateModelVM
            {
                Title = adModel.Title,
                MakeId = adModel.Id,
                MakelList = makeItems
            };
            return View(model);
        }

        // POST: ModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateModelVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var carModel = _mapper.Map<Model>(model);
                var isSuccess = await _repo.Update(carModel);
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

        // GET: ModelController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var carModel = await _repo.FindById(id);
            var model = _mapper.Map<Model, ModelVM>(carModel);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: ModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ModelVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var carModel = await _repo.FindById(id);
                var isSuccess = await _repo.Delete(carModel);
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
