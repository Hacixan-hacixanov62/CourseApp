

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
        List<Student> GetAll();
        List<Student> GetAllByAge(int age);
        List<Student> SearchByNameOrSurname(string searchText);
        List<Student> GetAllByGroup(int id);
        
    }
}
