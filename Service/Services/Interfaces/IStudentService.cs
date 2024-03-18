

using Domain.Models;
using Repository.Repositories.Interfaces;

namespace Service.Services.Interfaces
{
    public  interface IStudentService 
    {

        void Create(Student data);
        void Update(Student data);
        void Delete(int? id);
        Student GetById(int? id);
        List<Student> GetAllWithExpression(Func<Student, bool> predicate);
        List<Student> GetAllByAge(int age);
        List<Student> SearchByNameOrSurname(string searchText);
        List<Student> GetAllByGroupId(int id);
        
    }
}
