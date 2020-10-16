using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Automobiliu_skelbimu_portalas.Models;
using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Automobiliu_skelbimu_portalas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAdRepository _repo;
        private readonly IMakeRepository _makeRepo;
        private readonly IModelRepository _modelRepo;
        private readonly IFuelTypeRepository _fuelTypeRepo;
        private readonly IBodyTypeRepository _bodyTypeRepo;
        private readonly IDamageRepository _damageRepo;
        private readonly IColorRepository _colorRepo;
        private readonly IGearBoxRepository _gearBoxRepo;

        public HomeController(
            IAdRepository repo,
            IMakeRepository makeRepo,
            IModelRepository modelRepo,
            IFuelTypeRepository fuelTypeRepo,
            IBodyTypeRepository bodyTypeRepo,
            IDamageRepository damageRepo,
            IColorRepository colorRepo,
            IGearBoxRepository gearBoxRepo,
            IMapper mapper)
        {
            _repo = repo;

            _makeRepo = makeRepo;
            _modelRepo = modelRepo;
            _fuelTypeRepo = fuelTypeRepo;
            _bodyTypeRepo = bodyTypeRepo;
            _damageRepo = damageRepo;
            _colorRepo = colorRepo;
            _gearBoxRepo = gearBoxRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomepageAdVM();
            var ads = await _repo.FindAll();
            var makeRepo = await _makeRepo.FindAll();
            var modelRepo = await _modelRepo.FindAll();
            var fuelTypeRepo = await _fuelTypeRepo.FindAll();
            var bodyTypeRepo = await _bodyTypeRepo.FindAll();
            var damageRepo = await _damageRepo.FindAll();
            var colorRepo = await _colorRepo.FindAll();
            var gearBoxRepo = await _gearBoxRepo.FindAll();

            var makeItems = makeRepo.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            var modelItems = modelRepo.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            var fuelTypeItems = fuelTypeRepo.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            var bodyTypeItems = bodyTypeRepo.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            var damageItems = damageRepo.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            var colorItems = colorRepo.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            var gearBoxItems = gearBoxRepo.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            var search  = new SearchAdVM
            {
                MakeList = makeItems,
                ModelList = modelItems,
                FuelTypeList = fuelTypeItems,
                BodyTypeList = bodyTypeItems,
                DamageList = damageItems,
                ColorList = colorItems,
                GearBoxList = gearBoxItems

            };
            
            model.Ads = ads;
            model.Search = search;
            return View(model);
        }
        //GET HomeController/Home
        public ActionResult Menu()
        {
            return View();
        }
        //GET HomeController/Marked
        public IActionResult Marked()
        {
            return View();
        }
        //GET HomeController/Searches
        public IActionResult Searches()
        {
            return View();
        }
        //GET HomeController/Viewed
        public IActionResult Viewed()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
