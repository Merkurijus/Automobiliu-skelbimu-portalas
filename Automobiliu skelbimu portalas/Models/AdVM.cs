using Automobiliu_skelbimu_portalas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Models
{
    public class AdVM
    {

        [Key]
        public int Id { get; set; }
        [DisplayName("Make")]

        public MakeVM CarMake { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> MakeList { get; set; }
        public int CarMakeId { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ModelList { get; set; }
        public int CarModelId { get; set; }
        [DisplayName("Model")]
        public ModelVM CarModel { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }
        [DisplayName("Fuel type")]
        public int FuelTypeId { get; set; }
        public FuelTypeVM FuelType { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BodyTypeList { get; set; }
        [DisplayName("Body type")]
        public int BodyTypeId { get; set; }
        public BodyTypeVM BodyType { get; set; }
        [DisplayName("Engine capacity")]
        public int EngineCapacity { get; set; }
        public int Kilometrage { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DamageList { get; set; }
        [DisplayName("Damage type")]
        public int DamageId { get; set; }
        public DamageVM Damage { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ColorList { get; set; }
        [DisplayName("Color")]
        public int ColorId { get; set; }
        public ColorVM Color { get; set; }
        [DisplayName("Number of seats")]
        public int NumberOfSeats { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> GearBoxList { get; set; }
        [DisplayName("Gear box")]
        public int GearBoxId { get; set; }
        public GearBoxVM GearBox { get; set; }
        [DisplayName("Steering wheel")]
        public string SteeringWheel { get; set; }

       
    }
    public class CreateAdVM
    {

        [Key]
        public int Id { get; set; }
        public Make CarMake { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> MakeList { get; set; }
        [DisplayName("Make")]
        public int CarMakeId { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ModelList { get; set; }
        [DisplayName("Model")]
        public int CarModelId { get; set; }
        public ModelVM CarModel { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }
        [DisplayName("Fuel type")]
        public int FuelTypeId { get; set; }
        public FuelTypeVM FuelType { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BodyTypeList { get; set; }
        [DisplayName("Body type")]
        public int BodyTypeId { get; set; }
        public BodyTypeVM BodyType { get; set; }
        [DisplayName("Engine capacity")]
        public int EngineCapacity { get; set; }
        public int Kilometrage { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DamageList { get; set; }
        [DisplayName("Damage type")]
        public int DamageId { get; set; }
        public DamageVM Damage { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ColorList { get; set; }
        [DisplayName("Color")]
        public int ColorId { get; set; }
        public ColorVM Color { get; set; }
        [DisplayName("Number of seats")]
        public int NumberOfSeats { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> GearBoxList { get; set; }
        [DisplayName("Gear box")]
        public int GearBoxId { get; set; }
        public GearBoxVM GearBox { get; set; }
        [DisplayName("Steering wheel")]
        public string SteeringWheel { get; set; }



    }

    public class SearchAdVM
    {
       
        public Make CarMake { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> MakeList { get; set; }
        [DisplayName("Make")]
        public int CarMakeId { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ModelList { get; set; }
        [DisplayName("Model")]
        public int CarModelId { get; set; }
        public ModelVM CarModel { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }
        [DisplayName("Fuel type")]
        public int FuelTypeId { get; set; }
        public FuelTypeVM FuelType { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BodyTypeList { get; set; }
        [DisplayName("Body type")]
        public int BodyTypeId { get; set; }
        public BodyTypeVM BodyType { get; set; }
        [DisplayName("Engine capacity")]
        public int EngineCapacityFrom { get; set; }
        public int EngineCapacityTo { get; set; }
        public int Kilometrage { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DamageList { get; set; }
        [DisplayName("Damage type")]
        public int DamageId { get; set; }
        public DamageVM Damage { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ColorList { get; set; }
        [DisplayName("Color")]
        public int ColorId { get; set; }
        public ColorVM Color { get; set; }
        [DisplayName("Number of seats")]
        public int NumberOfSeats { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> GearBoxList { get; set; }
        [DisplayName("Gear box")]
        public int GearBoxId { get; set; }
        public GearBoxVM GearBox { get; set; }
        [DisplayName("Steering wheel")]
        public string SteeringWheel { get; set; }
    }
    public class HomepageAdVM
    {
        public List<Ad> Ads { get; set; }
        public SearchAdVM Search { get; set; }
    }

}
