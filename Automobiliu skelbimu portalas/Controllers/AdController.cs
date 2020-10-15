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
        public async Task<ActionResult> Index()
        {
            var ads = await _adRepo.FindAll();
            var model = new HomepageAdVM();
            //var adsModel = _mapper.Map<List<Ad>>(ads);
            model.Ads = ads;
            model.Search = new SearchAdVM();
            
            return View(model);
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
            var makeRepo = await _makeRepo.FindAll();
            var modelRepo = await _modelRepo.FindAll();
            var fuelTypeRepo = await _fuelTypeRepo.FindAll();
            var bodyTypeRepo = await _bodyTypeRepo.FindAll();
            var damageRepo = await _damageRepo.FindAll();
            var colorRepo = await _colorRepo.FindAll();
            var gearBoxRepo = await _gearBoxRepo.FindAll();
            var ad = await _adRepo.FindById(id);
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
                var isSuccess = await _adRepo.Edit(ad);
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
