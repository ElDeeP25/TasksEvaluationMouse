
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;
using TasksEvaluation.Core.Interfaces.IRepositories;
using TasksEvaluation.Core.Interfaces.IServices;
using TasksEvaluation.Core.Mapper;

namespace TasksEvaluation.Infrastructure.Services
{
    public class CourseService:ICourseService
    {
        private readonly IBaseMapper<Course, CourseDTO> _CourseDTOMapper;
        private readonly IBaseMapper<CourseDTO, Course> _CourseMapper;
        private readonly IBaseRepository<Course> _CourseRepository;

        public CourseService(
         IBaseMapper<Course, CourseDTO> CourseDTOMapper,
       IBaseMapper<CourseDTO, Course> CourseMapper,
       IBaseRepository<Course> CourseRepository)
        {
            _CourseMapper = CourseMapper;
            _CourseDTOMapper = CourseDTOMapper;
            _CourseRepository = CourseRepository;
        }
        public async Task<IEnumerable<CourseDTO>> GetCourses() => _CourseDTOMapper.MapList(await _CourseRepository.GetAll());

        public async Task<CourseDTO> GetCourse(int id) => _CourseDTOMapper.MapModel(await _CourseRepository.GetById(id));

        public async Task<CourseDTO> Create(CourseDTO model)
        {
            var entity = _CourseMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;
            return _CourseDTOMapper.MapModel(await _CourseRepository.Create(entity));
        }
        public async Task Update(CourseDTO model)
        {
            var existingData = await _CourseRepository.GetById(model.Id);
            var newEntity = _CourseMapper.MapModel(model);
            existingData.UpdateDate = DateTime.Now;
            await _CourseRepository.Update(existingData);
        }
        public async Task Delete(int id)
        {
            var entity = await _CourseRepository.GetById(id);
            await _CourseRepository.Delete(entity);
        }
    }
}
