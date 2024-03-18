

using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public List<Group> GetAllByRoom(string roomName)
        {
            return AppDbContent<Group>.datas.Where(m => m.Room == roomName).ToList();
        }

        public List<Group> GetAllByTeacher(string teacherName)
        {
            return AppDbContent<Group>.datas.Where(m => m.Teacher == teacherName).ToList();
        }

        public List<Group> SearchByName(string searchText)
        {
            return AppDbContent<Group>.datas.Where(m=> m.Name.ToLower().Trim().Contains(searchText.ToLower().Trim())).ToList();

        }

        

       
    }
}
