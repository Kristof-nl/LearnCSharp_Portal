using AutoMapper;
using Data.Models;
using Data.Models.ViewModels;

namespace LearnCSharp.AutoMapper
{
    public class AutoMapperTutorial : Profile
    {
        public AutoMapperTutorial()
        {
            CreateMap<Tutorial, TutorialWithScoreVM>().ReverseMap();
        }
       
    }
}
