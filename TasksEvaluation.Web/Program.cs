using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using TasksEvaluation.Infrastructure.Data;
using Microsoft.Extensions.Options;
using TasksEvaluation.Core.Interfaces.IServices;
using TasksEvaluation.Infrastructure.Services;
using TasksEvaluation.Core.Mapper.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using AutoMapper;
using FluentAssertions.Common;
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;
using TasksEvaluation.Core.Mapper;
using TasksEvaluation.Web.Helper;

namespace TaskEvaluation.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();


           // builder.Services.AddTransient<IEmailSender, EmailSettings>();

            builder.Services.AddAutoMapper(m=> m.AddProfile(new Studentmapper()));
            builder.Services.AddAutoMapper(m => m.AddProfile(new Coursemapper()));
            builder.Services.AddAutoMapper(m => m.AddProfile(new Assignmentmapper()));
            builder.Services.AddAutoMapper(m => m.AddProfile(new EvaluationGrademapper()));
            builder.Services.AddAutoMapper(m => m.AddProfile(new Groupmapper()));
            builder.Services.AddAutoMapper(m => m.AddProfile(new Solutionmapper()));

            #region Mapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentDTO, Student>();

                cfg.CreateMap<Assignment, AssignmentDTO>();
                cfg.CreateMap<AssignmentDTO, Assignment>();

                cfg.CreateMap<Course, CourseDTO>();
                cfg.CreateMap<CourseDTO, Course>();

                cfg.CreateMap<EvaluationGrade, EvaluationGradeDTO>();
                cfg.CreateMap<EvaluationGradeDTO, EvaluationGrade>();

                cfg.CreateMap<Group, GroupDTO>();
                cfg.CreateMap<GroupDTO, Group>();

                cfg.CreateMap<Solution, SolutionDTO>();
                cfg.CreateMap<SolutionDTO, Solution>();

            });

            IMapper mapper = configuration.CreateMapper();

            // Register the IMapperService implementation with your dependency injection container

          builder.Services.AddSingleton<IBaseMapper<Student, StudentDTO>>(new BaseMapper<Student, StudentDTO>(mapper));
            builder.Services.AddSingleton<IBaseMapper<StudentDTO, Student>>(new BaseMapper<StudentDTO, Student>(mapper));

            builder.Services.AddSingleton<IBaseMapper<Assignment, AssignmentDTO>>(new BaseMapper<Assignment, AssignmentDTO>(mapper));
            builder.Services.AddSingleton<IBaseMapper<AssignmentDTO, Assignment>>(new BaseMapper<AssignmentDTO, Assignment>(mapper));

            builder.Services.AddSingleton<IBaseMapper<Course, CourseDTO>>(new
                BaseMapper<Course, CourseDTO>(mapper));
            builder.Services.AddSingleton<IBaseMapper<CourseDTO, Course>>(new BaseMapper<CourseDTO, Course>(mapper));

            builder.Services.AddSingleton<IBaseMapper<EvaluationGrade, EvaluationGradeDTO>>(new BaseMapper<EvaluationGrade, EvaluationGradeDTO>(mapper));
            builder.Services.AddSingleton<IBaseMapper<EvaluationGradeDTO, EvaluationGrade>>(new BaseMapper<EvaluationGradeDTO, EvaluationGrade>(mapper));

            builder.Services.AddSingleton<IBaseMapper<Group, GroupDTO>>(new BaseMapper<Group, GroupDTO>(mapper));
            builder.Services.AddSingleton<IBaseMapper<GroupDTO, Group>>(new BaseMapper<GroupDTO, Group>(mapper));

            builder.Services.AddSingleton<IBaseMapper<Solution, SolutionDTO>>(new BaseMapper<Solution, SolutionDTO>(mapper));
            builder.Services.AddSingleton<IBaseMapper<SolutionDTO, Solution>>(new BaseMapper<SolutionDTO, Solution>(mapper));

            #endregion
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
             
            //Authentication and authorization
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
           options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
            })

                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

            //  builder.Services.AddMemoryCache();


            builder.Services.AddSession();
           
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme )
            .AddCookie(options => {
                options.LoginPath  ="Account/Login"  ;
                options.AccessDeniedPath = "Home / Error";
               
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Register" +
                "}/{id?}");

            app.Run();
           
        }
    }
}