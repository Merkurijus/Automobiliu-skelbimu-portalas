using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automobiliu_skelbimu_portalas.Data;
using Automobiliu_skelbimu_portalas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Automobiliu_skelbimu_portalas.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Automobiliu_skelbimu_portalas.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class BodyTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBodyTypeRepository _repo;
        public BodyTypeController(IBodyTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: BodyTypeController
        public async Task<ActionResult> Index()
        {
            var bodytypes = await _repo.FindAll();
            var model = _mapper.Map<List<BodyType>, List<BodyTypeVM>>(bodytypes);
            return View(model);
        }

        // GET: BodyTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var bodyTypes = await _repo.FindById(id);
            var model = _mapper.Map<BodyType, BodyTypeVM>(bodyTypes);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: BodyTypeController/Create
        public  ActionResult Create()
        {
            
            return View();
        }

        // POST: BodyTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBodyTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var bodyType = _mapper.Map<BodyType>(model);
                var isSuccess = await _repo.Create(bodyType);
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

        // GET: BodyTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var bodyType = await _repo.FindById(id);
            var model = _mapper.Map<BodyType, CreateBodyTypeVM>(bodyType);
            if (model == null)
            {
                return NotFound();
            }
            
            return View(model);
        }

        // POST: BodyTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateBodyTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                
                var bodyType = _mapper.Map<BodyType>(model);
                var isSuccess = await _repo.Edit(bodyType);
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

        // GET: BodyTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var bodyType = await _repo.FindById(id);
            var model = _mapper.Map<BodyType, BodyTypeVM>(bodyType);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: BodyTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, BodyTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var bodyType = await _repo.FindById(id);
                var isSuccess = await _repo.Delete(bodyType);
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
