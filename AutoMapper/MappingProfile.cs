using AutoMapper;
using StudentAPI.Models;

namespace StudentAPI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Ánh xạ hai chiều giữa Student và StudentDto
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}

