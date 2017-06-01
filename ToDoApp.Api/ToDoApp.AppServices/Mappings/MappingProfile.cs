﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.AppServices.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Dtos.ToDoDto, Domain.Entities.ToDo>().ReverseMap();
            CreateMap<Dtos.ToDoFilterDto, Domain.Filters.ToDoFilter>().ReverseMap();
        }
    }
}
