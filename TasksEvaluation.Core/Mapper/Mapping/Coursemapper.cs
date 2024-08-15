using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Core.Mapper.Mapper
{
    public class Coursemapper : Profile
    {
        public Coursemapper() {

             CreateMap<CourseDTO,Course>();

            /*CreateMap<CourseDTO, Course>()
                .ForMember(d=> d.IsCompleted, o=>o.MapFrom(s=>s.IsCompleted));
            -----ForMember : when use a prop is name in Dto and another in Entity
             */


        }
    }
}
