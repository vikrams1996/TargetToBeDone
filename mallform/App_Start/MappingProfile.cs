using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using mallform.Models;
using mallform.Dtos;
namespace mallform.App_Start
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {
            Mapper.CreateMap<Rent, RentDto>();
            Mapper.CreateMap<RentDto, Rent>(); 

        }

    }
}