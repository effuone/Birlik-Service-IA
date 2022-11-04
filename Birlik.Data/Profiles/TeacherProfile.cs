using System.Text.Json.Serialization;
using AutoMapper;
using Birlik.Data.DTOs;
using Birlik.Data.Models;

namespace Birlik.Data.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            //Mapping task entity modelss
            CreateMap<CreateTeacherDTO, Teacher>().ForMember(x=>x.Resume, o=>o.Ignore());
            CreateMap<UpdateTeacherDTO, Teacher>().ForMember(x=>x.Resume, o=>o.Ignore());
            CreateMap<Teacher, TeacherDTO>();

            // //Mapping project entity models
            // CreateMap<CreateTeacherDTO, Project>();
            // CreateMap<UpdateProjectDTO, Project>();
            // CreateMap<Project, ProjectDTO>();
        }
    }
}