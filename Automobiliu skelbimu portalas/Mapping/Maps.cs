using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Automobiliu_skelbimu_portalas.Models;
using Automobiliu_skelbimu_portalas.Data;

namespace Automobiliu_skelbimu_portalas.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<BodyType, BodyTypeVM>().ReverseMap();
            CreateMap<BodyType, CreateBodyTypeVM>().ReverseMap();
            CreateMap<Make, MakeVM>().ReverseMap();
            CreateMap<Make, CreateMakeVM>().ReverseMap();
            CreateMap<Ad, AdVM>().ReverseMap();
            CreateMap<Ad, CreateAdVM>().ReverseMap();
            CreateMap<Color, ColorVM>().ReverseMap();
            CreateMap<Color, CreateColorVM>().ReverseMap();
            CreateMap<Damage, DamageVM>().ReverseMap();
            CreateMap<Damage, CreateDamageVM>().ReverseMap();
            CreateMap<FuelType, FuelTypeVM>().ReverseMap();
            CreateMap<FuelType, CreateFuelTypeVM>().ReverseMap();
            CreateMap<GearBox, GearBoxVM>().ReverseMap();
            CreateMap<GearBox, CreateGearBoxVM>().ReverseMap();
            CreateMap<Model, ModelVM>().ReverseMap();
            CreateMap<Model, CreateModelVM>().ReverseMap();
        }
    }
}
