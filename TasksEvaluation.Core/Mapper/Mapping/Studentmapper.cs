﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Core.Mapper.Mapper
{
    public class Studentmapper :Profile
    {
        public Studentmapper() { 
        
        CreateMap<StudentDTO,Student>().ReverseMap();      }
    }
}
