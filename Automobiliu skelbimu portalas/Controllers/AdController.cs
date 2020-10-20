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
    [Authorize]
    public class AdController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAdRepository _adRepo;
        private readonly IMakeRepository _makeRepo;
        private readonly IModelRepository _modelRepo;
        private readonly IFuelTypeRepository _fuelTypeRepo;
        private readonly IBodyTypeRepository _bodyTypeRepo;
        private readonly IDamageRepository _damageRepo;
        private readonly IColorRepository _colorRepo;
        private readonly IGearBoxRepository _gearBoxRepo;

        public AdController(
            IAdRepository adRepo,
            IMakeRepository makeRepo,
            IModelRepository modelRepo,
            IFuelTypeRepository fuelTypeRepo,
            IBodyTypeRepository bodyTypeRepo,
            IDamageRepository damageRepo,
            IColorRepository colorRepo,
            IGearBoxRepository gearBoxRepo,
            IMapper mapper)
        {
            _adRepo = adRepo;

            _makeRepo = makeRepo;
            _modelRepo = modelRepo;
            _fuelTypeRepo = fuelTypeRepo;
            _bodyTypeRepo = bodyTypeRepo;
            _damageRepo = damageRepo;
            _colorRepo = colorRepo;
            _gearBoxRepo = gearBoxRepo;
            _mapper = mapper;
        }

        
        // GET: AdController
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        [HttpGet("Ad/Search")]
        public async Task<ActionResult> Search(HomepageAdVM homeModel)
        {
            var modelVM = await _adRepo.GetSearchResults(homeModel.Search);
            var model = _mapper.Map<List<Ad>>(modelVM);
            return View(nameof(Index), model);

        }
            [AllowAnonymous]
        // GET: AdController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var ads = await _adRepo.FindById(id);
            var model = _mapper.Map<Ad, CreateAdVM>(ads);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        
        // GET: AdController/Create
        public async Task<ActionResult> Create()
        {
            var makeItems = await _makeRepo.GetSelectListItem();
            var modelItems = await _modelRepo.GetSelectListItem();
            var fuelTypeItems = await _fuelTypeRepo.GetSelectListItem();
            var bodyTypeItems = await _bodyTypeRepo.GetSelectListItem();
            var damageItems = await _damageRepo.GetSelectListItem();
            var colorItems = await _colorRepo.GetSelectListItem();
            var gearBoxItems = await _gearBoxRepo.GetSelectListItem();

           
            var model = new CreateAdVM
            {
                MakeList = makeItems,
                ModelList = modelItems,
                FuelTypeList = fuelTypeItems,
                BodyTypeList = bodyTypeItems,
                DamageList = damageItems,
                ColorList = colorItems,
                GearBoxList = gearBoxItems

            };
            return View(model);
        }

        // POST: AdController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAdVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var ads = _mapper.Map<Ad>(model);
                var isSuccess = await _adRepo.Create(ads);
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

        // GET: AdController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            
            var ad = await _adRepo.FindById(id);
            var makeItems = await _makeRepo.GetSelectListItem();
            var modelItems = await _modelRepo.GetSelectListItem();
            var fuelTypeItems = await _fuelTypeRepo.GetSelectListItem();
            var bodyTypeItems = await _bodyTypeRepo.GetSelectListItem();
            var damageItems = await _damageRepo.GetSelectListItem();
            var colorItems = await _colorRepo.GetSelectListItem();
            var gearBoxItems = await _gearBoxRepo.GetSelectListItem();

            var model = new CreateAdVM
            {
                MakeList = makeItems,
                CarMakeId = ad.CarMakeId,
                ModelList = modelItems,
                CarModelId = ad.CarModelId,
                Year = ad.Year,
                Price = ad.Price,
                FuelTypeList = fuelTypeItems,
                FuelTypeId = ad.FuelTypeId,
                BodyTypeList = bodyTypeItems,
                EngineCapacity = ad.EngineCapacity,
                Kilometrage = ad.Kilometrage,
                DamageList = damageItems,
                DamageId = ad.DamageId,
                ColorList = colorItems,
                ColorId = ad.ColorId,
                NumberOfSeats = ad.NumberOfSeats,
                GearBoxList = gearBoxItems,
                GearBoxId = ad.GearBoxId,
                SteeringWheel = ad.SteeringWheel

            };

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: AdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AdVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var ad = _mapper.Map<Ad>(model);
                var isSuccess = await _adRepo.Update(ad);
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

        // GET: AdController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var ad = await _adRepo.FindById(id);
            var model = _mapper.Map<Ad, AdVM>(ad);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: BodyTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, AdVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var ad = await _adRepo.FindById(id);
                var isSuccess = await _adRepo.Delete(ad);
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
