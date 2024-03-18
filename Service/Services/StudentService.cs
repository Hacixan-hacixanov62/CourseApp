using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constans;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private int count = 1;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public void Create(Student data)
        {
            if (data == null) throw new NotImplementedException();
            data.Id = count;
            _studentRepository.Create(data);  
            count++;
        }

        public void Delete(int? id)
        {
            if (id == null) throw new NotImplementedException();

            Student student = _studentRepository.GetById((int)id);

            if (student is null) throw new NotFoundException(ResponseMessages.DataNotFound);

            _studentRepository.Delete(student);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public List<Student> GetAllWithExpression()
        {
            return _studentRepository.GetAll();
        }

        public List<Student> GetAllByAge(int age)
        {
            return _studentRepository.GetAllByAge(age);
        }

        public List<Student> GetAllWithExpression(Func<Student, bool> predicate)
        {
            return _studentRepository.GetAllWithExpression(predicate);
        }

        public List<Student> GetAllByGroupId(int id)
        {
            return _studentRepository.GetAllByGroup(id);
        }

        public Student GetById(int? id)
        {
            if (id == null) throw new NotImplementedException();

            Student student = _studentRepository.GetById((int)id);

            return _studentRepository.GetById((int)id);
        }

        public List<Student> SearchByNameOrSurname(string searchText)
        {
            return _studentRepository.SearchByNameOrSurname(searchText);
        }

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }

  
    }
}
