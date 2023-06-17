using AutoMapper;
using Entities.Models;
using Shared.DataTransferObject;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ClassJournal
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupDto>()
            .ForMember( c => c.Info,
            opt => opt.MapFrom(x => string.Join(' ', x.GroupName, x.GroupCourse))).ReverseMap();

            CreateMap<Student, StudentDto>();
            CreateMap<GroupForCreationDto, Group>();
            CreateMap<StudentForCreationDto, Student>();
            CreateMap<StudentForUpdateDto, Student>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<SubjectForCreationDto, Subject >();
            CreateMap<Subject, SubjectDto>();
            CreateMap<MarkForCreationDto,Mark >();
            CreateMap<Mark, MarkDto>();
        }
    }
}
