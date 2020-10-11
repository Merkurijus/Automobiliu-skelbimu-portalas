using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Data
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MakeId { get; set; }
        public Make Make { get; set; }
        [Required]
        public int ModelId { get; set; }
        public Model Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        [Required]
        public int BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }
        [Required]
        public int EngineCapacity { get; set; }
        [Required]
        public int Kilometrage { get; set; }
        [Required]
        public int DamageId { get; set; }
        public Damage Damage { get; set; }
        [Required]
        public int ColorId { get; set; }
        public Color Color { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        public int GearBoxId { get; set; }
        public GearBox GearBox { get; set; }
        [Required]
        public string SteeringWheel { get; set; }
        public bool? IsApproved { get; set; }

    }
}
