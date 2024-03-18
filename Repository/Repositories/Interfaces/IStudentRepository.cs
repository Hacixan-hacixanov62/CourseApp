using Domain.Models;


namespace Repository.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        List<Student> GetAllByAge(int age);
        List<Student> GetAllByGroup(int group);

        List<Student> SearchByNameOrSurname(string SearchText);

    }
}
