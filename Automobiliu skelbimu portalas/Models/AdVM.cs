using Automobiliu_skelbimu_portalas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Models
{
    public class AdVM
    {
        
       
        public int MakeId { get; set; }
        public Make Make { get; set; }
        public int ModelId { get; set; }
        public ModelVM Model { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public int FuelTypeId { get; set; }
        public FuelTypeVM FuelType { get; set; }
        public int BodyTypeId { get; set; }
        public BodyTypeVM BodyType { get; set; }
        public int EngineCapacity { get; set; }
        public int Kilometrage { get; set; }
        public int DamageId { get; set; }
        public DamageVM Damage { get; set; }
        public int ColorId { get; set; }
        public ColorVM Color { get; set; }
        public int NumberOfSeats { get; set; }
        public int GearBoxId { get; set; }
        public GearBoxVM GearBox { get; set; }
        public string SteeringWheel { get; set; }
    }
    
}
