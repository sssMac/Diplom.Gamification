using AutoMapper;
using Diplom.Gamification.Application.ViewModels;
using Diplom.Gamification.Domain;
using Newtonsoft.Json;

namespace Diplom.Gamification.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, AddCourseViewModel>().ReverseMap();
            CreateMap<Lesson, AddLessonViewModel>().ReverseMap();
            CreateMap<Assignment, AddAssignmentViewModel>()
                .ForMember(dest => dest.AssigmentTest, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<AssignmentTestViewModel>(src.Tests)));
            CreateMap<AddAssignmentViewModel, Assignment>()
                .ForMember(dest => dest.Tests, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.AssigmentTest)));

            CreateMap<Course, CourseViewModel>().ReverseMap();
            CreateMap<Lesson, LessonViewModel>().ReverseMap();
            CreateMap<Assignment, AssignmentViewModel>()
                .ForMember(dest => dest.AssignmentTest, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<AssignmentTestViewModel>(src.Tests)));
            CreateMap<AssignmentViewModel, Assignment>()
                .ForMember(dest => dest.Tests, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.AssignmentTest)));
        }
    }
}
