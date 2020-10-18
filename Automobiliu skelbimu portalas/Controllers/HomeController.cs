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
            
            var year = _repo.GetYearList();
            List<int> price = new List<int>();
            price = _repo.GetPriceList(price);


            var makeItems = await _makeRepo.GetSelectListItem();
            var modelItems = await _modelRepo.GetSelectListItem();
            var fuelTypeItems = await _fuelTypeRepo.GetSelectListItem();
            var bodyTypeItems = await _bodyTypeRepo.GetSelectListItem();
            var damageItems = await _damageRepo.GetSelectListItem();
            var colorItems = await _colorRepo.GetSelectListItem();
            var gearBoxItems = await _gearBoxRepo.GetSelectListItem();
            var yearItems = year.Select(q => new SelectListItem
            {
                Text = q.ToString(),
                Value = q.ToString()
            });
            var priceItems = price.Select(q => new SelectListItem
            {
                Text = q.ToString(),
                Value = q.ToString()
            });
            var search  = new SearchAdVM
            {
                MakeList = makeItems,
                ModelList = modelItems,
                YearFrom = yearItems,
                YearTo = yearItems,
                PriceFrom = priceItems,
                PriceTo = priceItems,
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
