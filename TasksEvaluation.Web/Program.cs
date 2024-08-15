using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;
using TasksEvaluation.Core.Interfaces.IRepositories;
using TasksEvaluation.Core.Interfaces.IServices;
using TasksEvaluation.Core.Mapper;
using TasksEvaluation.Infrastructure.Data;
using TasksEvaluation.Infrastructure.Repositories;
using TasksEvaluation.Infrastructure.Services;
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

            builder.Services.AddAutoMapper(m => m.AddProfile(new MappingProfile()));
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient<IAssignmentService, AssignmentService>();
            builder.Services.AddTransient<ISolutionService, SolutionService>();
            builder.Services.AddTransient<IStudentService, StudentService>();
            builder.Services.AddTransient<ICourseService, CourseService>();
            builder.Services.AddTransient<IGroupService, GroupService>();

            // Register mappers
            builder.Services.AddScoped<IBaseMapper<Student, StudentDTO>, BaseMapper<Student, StudentDTO>>();
            builder.Services.AddScoped<IBaseMapper<StudentDTO, Student>, BaseMapper<StudentDTO, Student>>();
            builder.Services.AddScoped<IBaseMapper<Assignment, AssignmentDTO>, BaseMapper<Assignment, AssignmentDTO>>();
            builder.Services.AddScoped<IBaseMapper<AssignmentDTO, Assignment>, BaseMapper<AssignmentDTO, Assignment>>();
            builder.Services.AddScoped<IBaseMapper<Solution, SolutionDTO>, BaseMapper<Solution, SolutionDTO>>();
            builder.Services.AddScoped<IBaseMapper<SolutionDTO, Solution>, BaseMapper<SolutionDTO, Solution>>();
            builder.Services.AddScoped<IBaseMapper<Course, CourseDTO>, BaseMapper<Course, CourseDTO>>();
            builder.Services.AddScoped<IBaseMapper<CourseDTO, Course>, BaseMapper<CourseDTO, Course>>();
            builder.Services.AddScoped<IBaseMapper<Group, GroupDTO>, BaseMapper<Group, GroupDTO>>();
            builder.Services.AddScoped<IBaseMapper<GroupDTO, Group>, BaseMapper<GroupDTO, Group>>();

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

            app.MapRazorPages();
            app.Run();
           
        }
    }
}