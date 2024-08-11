using AutoMapper;
using Pschool.Core.DTOs;
using Pschool.Infrastructure.Models;
using Student = Pschool.Infrastructure.Models.Student;

namespace Pschool.API.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<ParentDto, Parent>().ReverseMap();
        CreateMap<Student, StudentDto>().ReverseMap();
    }
}