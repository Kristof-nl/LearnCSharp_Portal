using AutoMapper;
using Data.Models;
using Logic.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.AutoMapper
{
    public class AutoMapperCategory : Profile
    {
        public AutoMapperCategory()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }

    }
}
