using Automobiliu_skelbimu_portalas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
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
        public Make CarMake { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> MakeList { get; set; }
        public int CarMakeId { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ModelList { get; set; }

        public int CarModelId { get; set; }
        public ModelVM CarModel { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }

        public int FuelTypeId { get; set; }
        public FuelTypeVM FuelType { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BodyTypeList { get; set; }

        public int BodyTypeId { get; set; }
        public BodyTypeVM BodyType { get; set; }
        public int EngineCapacity { get; set; }
        public int Kilometrage { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DamageList { get; set; }

        public int DamageId { get; set; }
        public DamageVM Damage { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ColorList { get; set; }

        public int ColorId { get; set; }
        public ColorVM Color { get; set; }
        public int NumberOfSeats { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> GearBoxList { get; set; }

        public int GearBoxId { get; set; }
        public GearBoxVM GearBox { get; set; }
        public string SteeringWheel { get; set; }

       
    }
    public class CreateAdVM
    {

        [Key]
        public int Id { get; set; }
        public Make CarMake { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> MakeList { get; set; }
        public int CarMakeId { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ModelList { get; set; }

        public int CarModelId { get; set; }
        public ModelVM CarModel { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Price { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }

        public int FuelTypeId { get; set; }
        public FuelTypeVM FuelType { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BodyTypeList { get; set; }

        public int BodyTypeId { get; set; }
        public BodyTypeVM BodyType { get; set; }
        [Required]
        public int EngineCapacity { get; set; }
        [Required]
        public int Kilometrage { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DamageList { get; set; }

        public int DamageId { get; set; }
        public DamageVM Damage { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ColorList { get; set; }

        public int ColorId { get; set; }
        public ColorVM Color { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> GearBoxList { get; set; }

        public int GearBoxId { get; set; }
        public GearBoxVM GearBox { get; set; }
        [Required]
        public string SteeringWheel { get; set; }


    }

}
