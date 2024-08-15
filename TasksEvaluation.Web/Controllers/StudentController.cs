using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;
using TasksEvaluation.Core.Interfaces.IServices;

namespace TasksEvaluation.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentRepo;
         private IMapper _mapper;

        public StudentController(IStudentService studentRepo,   IMapper mapper)
        {
            _studentRepo = studentRepo;
             _mapper = mapper;
        }

        public IActionResult Index()
        {
          var students = _studentRepo.GetStudents();

             return View(students);
        }

        [HttpPost]
        public IActionResult Create(StudentDTO studentVm)
        {
            if (ModelState.IsValid) { 
            var mapedstudent = _mapper.Map<StudentDTO>(studentVm);
            
                _studentRepo.Create(mapedstudent);
                return RedirectToAction(nameof(Index));
            }

            return View(studentVm);
        }

        public IActionResult Edit([FromRoute]int id,StudentDTO studentVm) 
        {
            if (id != studentVm.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                     _studentRepo.Update(studentVm);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty,ex.Message);
                }
            }
        return View(studentVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]int id , StudentDTO studentVm) 
        {
            if (id != studentVm.Id)
                return BadRequest();
            try
            {
                _studentRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
               return View();
        }

        public IActionResult Details(int? id , string viewname ="Details")   
        {
            if (id is null)
                return BadRequest();

            var student = _studentRepo.GetStudent(id.Value);

            if (student is null)
                return NotFound();

            return View(viewname , student);
        }
    }
}
