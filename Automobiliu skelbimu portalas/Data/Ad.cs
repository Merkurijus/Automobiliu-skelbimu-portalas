using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Data
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("CarMakeId")]
        public int CarMakeId { get; set; }
        public Make CarMake { get; set; }
        [Required]
        [ForeignKey("CarModelId")]
        public int CarModelId { get; set; }
        public Model CarModel { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [ForeignKey("FuelTypeId")]
        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        [Required]
        [ForeignKey("BodyTypeId")]
        public int BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }
        [Required]
        public int EngineCapacity { get; set; }
        [Required]
        public int Kilometrage { get; set; }
        [Required]
        [ForeignKey("DamageId")]
        public int DamageId { get; set; }
        public Damage Damage { get; set; }
        [Required]
        [ForeignKey("ColorId")]
        public int ColorId { get; set; }
        public Color Color { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        [ForeignKey("GearBoxId")]
        public int GearBoxId { get; set; }
        public GearBox GearBox { get; set; }
        [Required]
        public string SteeringWheel { get; set; }
        public bool? IsApproved { get; set; }

    }
}
