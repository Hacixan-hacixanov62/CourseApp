 using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constans;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System.Reflection.Emit;
using System.Reflection;
using System;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        public readonly IGroupRepository _groupRepository;
        private int count = 1;

        public GroupService()
        {
            _groupRepository = new GroupRepository();

        }
        public void Create(Group data)
        {
            if(data == null) throw new NotImplementedException();
            data.Id = count;
            _groupRepository.Create(data);
            count++;
        }

        public void Delete(int? id)
        {
            if(id==null) throw new NotImplementedException();

            Group group = _groupRepository.GetById((int)id);

            if (group is null) throw new NotFoundException(ResponseMessages.DataNotFound);

            _groupRepository.Delete(group);
        }

        public List<Group> GetAll()
        {
          return _groupRepository.GetAll();
        }

        public List<Group> GetAllByRoom(string room)
        {

            return _groupRepository.GetAllByRoom(room);
        }

        public List<Group> GetAllByTeacher(string teacher)
        {
            return _groupRepository.GetAllByTeacher(teacher);

        }

        public List<Group> GetAllWithExpression(Func<Group, bool> predicate)
        {
            return _groupRepository.GetAllWithExpression(predicate);
        }

        public Group GetById(int? id)
        {
            if (id==null) throw new NotImplementedException();

            Group group = _groupRepository.GetById((int)id); 

            if (group is null)
            {
               throw new NotFoundException(ResponseMessages.DataNotFound);
            }

           return _groupRepository.GetById((int)id);
        }    

        public List<Group> SearchByName(string searchText)
        {
            return _groupRepository.SearchByName(searchText);
        }

        public void Update(Group data)
        {
            throw new NotImplementedException();

        }

       
    }
}
