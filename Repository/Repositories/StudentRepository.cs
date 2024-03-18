using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository

    {
        public List<Student> GetAllByGroup(int groupId)
        {
            return AppDbContent<Student>.datas.Where( m=>m.Group.Id == groupId).ToList();

        }

        public List<Student> SearchByNameOrSurname(string SearchText)
        {

            return AppDbContent<Student>.datas.Where(m => m.Surname.Contains(SearchText) || m.Name.Contains(SearchText)).ToList();
        }

        public List<Student> GetAllByAge(int age)
        {
            return AppDbContent<Student>.datas.Where(m=>m.Age == age).ToList();
        }
    }
}
