

using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group data);
        void Update(Group data);
        void Delete(int? id);
        Group GetById(int? id);  
        List<Group> GetAll();   
        List<Group> GetAllByRoom(string room);
        List<Group> GetAllByTeacher(string teacher);
        List<Group> GetAllWithExpression(Func<Group, bool> predicate);
        List<Group> SearchByName(string searchText);
        


    }
}
