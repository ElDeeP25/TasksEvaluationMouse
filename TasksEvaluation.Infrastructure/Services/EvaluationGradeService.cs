using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;
using TasksEvaluation.Core.Interfaces.IRepositories;
using TasksEvaluation.Core.Interfaces.IServices;
using TasksEvaluation.Core.Mapper;

namespace TasksEvaluation.Infrastructure.Services
{
    public class EvaluationGradeService : IEvaluationGradeService
    {
        private readonly IBaseMapper<EvaluationGrade, EvaluationGradeDTO> _EvaluationGradeDTOMapper;
        private readonly IBaseMapper<EvaluationGradeDTO, EvaluationGrade> _EvaluationGradeMapper;
        private readonly IBaseRepository<EvaluationGrade> _EvaluationGradeRepository;

        public EvaluationGradeService(
         IBaseMapper<EvaluationGrade, EvaluationGradeDTO> EvaluationGradeDTOMapper,
       IBaseMapper<EvaluationGradeDTO, EvaluationGrade> EvaluationGradeMapper,
       IBaseRepository<EvaluationGrade> EvaluationGradeRepository)
        {
            _EvaluationGradeMapper = EvaluationGradeMapper;
            _EvaluationGradeDTOMapper = EvaluationGradeDTOMapper;
            _EvaluationGradeRepository = EvaluationGradeRepository;
        }
        public async Task<IEnumerable<EvaluationGradeDTO>> GetEvaluationGrades() => _EvaluationGradeDTOMapper.MapList(await _EvaluationGradeRepository.GetAll());

        public async Task<EvaluationGradeDTO> GetEvaluationGrade(int id) => _EvaluationGradeDTOMapper.MapModel(await _EvaluationGradeRepository.GetById(id));

        public async Task<EvaluationGradeDTO> Create(EvaluationGradeDTO model)
        {
            var entity = _EvaluationGradeMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;
            return _EvaluationGradeDTOMapper.MapModel(await _EvaluationGradeRepository.Create(entity));
        }
        public async Task Update(EvaluationGradeDTO model)
        {
            var existingData = await _EvaluationGradeRepository.GetById(model.Id);
            var newEntity = _EvaluationGradeMapper.MapModel(model);
            existingData=newEntity;
            existingData.UpdateDate = DateTime.Now;
            await _EvaluationGradeRepository.Update(existingData);
        }
        public async Task Delete(int id)
        {
            var entity = await _EvaluationGradeRepository.GetById(id);
            await _EvaluationGradeRepository.Delete(entity);
        }

        public Task<EvaluationGradeDTO> GetEvaluationGrades(int id)
        {
            throw new NotImplementedException();
        }
    }
}
