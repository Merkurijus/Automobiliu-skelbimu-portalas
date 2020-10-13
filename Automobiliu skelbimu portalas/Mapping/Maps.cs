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
            CreateMap<Make, MakeVM>().ReverseMap();
        }
    }
}
