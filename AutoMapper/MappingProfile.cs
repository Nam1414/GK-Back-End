using AutoMapper;
using StudentAPI.Models;

namespace StudentAPI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
             // Map Student ↔ StudentDto
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class != null ? src.Class.Name : null))
                .ReverseMap()
                .ForMember(dest => dest.Class, opt => opt.Ignore());

            // Map cho tạo mới
            CreateMap<StudentCreateDto, Student>();

            // Map cho cập nhật (không đổi lớp)
            CreateMap<StudentUpdateDto, Student>()
                .ForMember(dest => dest.ClassId, opt => opt.Ignore());
        }
    }
}

