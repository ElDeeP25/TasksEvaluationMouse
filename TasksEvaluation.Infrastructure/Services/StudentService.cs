
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;
using TasksEvaluation.Core.Interfaces.IRepositories;
using TasksEvaluation.Core.Interfaces.IServices;
using TasksEvaluation.Core.Mapper;

namespace TasksEvaluation.Infrastructure.Services
{
    public class StudentService:IStudentService
    {
        private readonly IBaseMapper<Student, StudentDTO> _StudentDTOMapper;
        private readonly IBaseMapper<StudentDTO, Student> _StudentMapper;
        private readonly IBaseRepository<Student> _StudentRepository;

        public StudentService(
         IBaseMapper<Student, StudentDTO> StudentDTOMapper,
       IBaseMapper<StudentDTO, Student> StudentMapper,
       IBaseRepository<Student> StudentRepository)
        {
            _StudentMapper = StudentMapper;
            _StudentDTOMapper = StudentDTOMapper;
            _StudentRepository = StudentRepository;
        }
        public async Task<IEnumerable<StudentDTO>> GetStudents() => _StudentDTOMapper.MapList(await _StudentRepository.GetAll());

        public async Task<StudentDTO> GetStudent(int id) => _StudentDTOMapper.MapModel(await _StudentRepository.GetById(id));

        public async Task<StudentDTO> Create(StudentDTO model)
        {
            var entity = _StudentMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;
            return _StudentDTOMapper.MapModel(await _StudentRepository.Create(entity));
        }
        public async Task Update(StudentDTO model)
        {
            var existingData = await _StudentRepository.GetById(model.Id);
            var newEntity = _StudentMapper.MapModel(model);
            existingData.UpdateDate = DateTime.Now;
            await _StudentRepository.Update(existingData);
        }
        public async Task Delete(int id)
        {
            var entity = await _StudentRepository.GetById(id);
            await _StudentRepository.Delete(entity);
        }
    }
}
