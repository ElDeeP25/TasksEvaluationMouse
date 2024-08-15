using AutoMapper;
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Assignment, AssignmentDTO>().ReverseMap();
            CreateMap<SolutionDTO, Solution>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<EvaluationGrade, EvaluationGradeDTO>().ReverseMap();



            // Add other mappings here
        }
    }
}

