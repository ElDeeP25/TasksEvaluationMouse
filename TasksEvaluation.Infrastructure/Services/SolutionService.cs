using Microsoft.CodeAnalysis;
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
using Solution = TasksEvaluation.Core.Entities.Business.Solution;

namespace TasksEvaluation.Infrastructure.Services
{
    public class SolutionService:ISolutionService
    {
        private readonly IBaseMapper<Solution, SolutionDTO> _SolutionDTOMapper;
        private readonly IBaseMapper<SolutionDTO, Solution> _SolutionMapper;
        private readonly IBaseRepository<Solution> _SolutionRepository;

        public SolutionService(
         IBaseMapper<Solution, SolutionDTO> SolutionDTOMapper,
       IBaseMapper<SolutionDTO, Solution> SolutionMapper,
       IBaseRepository<Solution> SolutionRepository)
        {
            _SolutionMapper = SolutionMapper;
            _SolutionDTOMapper = SolutionDTOMapper;
            _SolutionRepository = SolutionRepository;
        }
        public async Task<IEnumerable<SolutionDTO>> GetSolutions() => _SolutionDTOMapper.MapList(await _SolutionRepository.GetAll());

        public async Task<SolutionDTO> GetSolution(int id) => _SolutionDTOMapper.MapModel(await _SolutionRepository.GetById(id));

        public async Task<SolutionDTO> Create(SolutionDTO model)
        {
            var entity = _SolutionMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;
            return _SolutionDTOMapper.MapModel(await _SolutionRepository.Create(entity));
        }
     
        public async Task Update(SolutionDTO model)
        {
            var existingData = await _SolutionRepository.GetById(model.Id);
            var newEntity = _SolutionMapper.MapModel(model);
            existingData = newEntity;
            existingData.UpdateDate = DateTime.Now;
            await _SolutionRepository.Update(existingData);
        }
        public async Task Delete(int id)
        {
            var entity = await _SolutionRepository.GetById(id);
            await _SolutionRepository.Delete(entity);
        }
    }
}
