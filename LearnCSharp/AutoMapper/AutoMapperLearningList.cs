using AutoMapper;
using Data.Models;
using Data.Models.ViewModels;

namespace LearnCSharp.AutoMapper
{
    public class AutoMapperLearningList : Profile
    {
        public AutoMapperLearningList()
        {
            CreateMap<LearningList, LearningListVM>().ReverseMap();
        }
       
    }
}
