using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksEvaluation.Core.DTOs;
using TasksEvaluation.Core.Entities.Business;
using TasksEvaluation.Core.Interfaces.IRepositories;
using TasksEvaluation.Core.Interfaces.IServices;
using TasksEvaluation.Core.Mapper;


namespace TasksEvaluation.Infrastructure.Services
{
    public class GroupService: IGroupService
    {
        private readonly IBaseMapper<Group, GroupDTO> _GroupDTOMapper;
        private readonly IBaseMapper<GroupDTO, Group> _GroupMapper;
        private readonly IBaseRepository<Group> _GroupRepository;

        public GroupService(
       IBaseMapper<Group, GroupDTO> GroupDTOMapper,
       IBaseMapper<GroupDTO, Group> GroupMapper,
       IBaseRepository<Group> GroupRepository)
        {
            _GroupMapper = GroupMapper;
            _GroupDTOMapper = GroupDTOMapper;
            _GroupRepository = GroupRepository;
        }
        public async Task<IEnumerable<GroupDTO>> GetGroups() => _GroupDTOMapper.MapList(await _GroupRepository.GetAll());

        public async Task<GroupDTO> GetGroup(int id) => _GroupDTOMapper.MapModel(await _GroupRepository.GetById(id));

        public async Task<GroupDTO> Create(GroupDTO model)
        {
            var entity = _GroupMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;
            return _GroupDTOMapper.MapModel(await _GroupRepository.Create(entity));
        }
        public async Task Update(GroupDTO model)
        {
            var existingData = await _GroupRepository.GetById(model.Id);
            var newEntity = _GroupMapper.MapModel(model);
            existingData.UpdateDate = DateTime.Now;
            await _GroupRepository.Update(existingData);
        }
        public async Task Delete(int id)
        {
            var entity = await _GroupRepository.GetById(id);
            await _GroupRepository.Delete(entity);
        }
    }
}
