using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Miniproject_course_app.Controllers
{
    internal class StudentController
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;
        public StudentController()
        {
            _studentService = new StudentService();
            _groupService = new GroupService();


        }


        public void Create()
        {

            if (_groupService.GetAll().Count == 0)
            {

                ConsoleColor.Red.WriteConsole("First Create group ");
                return;
            }

            ConsoleColor.Magenta.WriteConsole("Add name: ");
        Name: string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Name;
            }

            if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Name;
            }



            ConsoleColor.Magenta.WriteConsole("Add surname: ");
        Surname: string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Surname;
            }

            ConsoleColor.Magenta.WriteConsole("Add age: ");
        age: string ageStr = Console.ReadLine();

            int age;
            bool isCorrectAgeFormat = int.TryParse(ageStr, out age);

            if (age < 15 || age > 50)
            {
                ConsoleColor.Red.WriteConsole("Wrong age limit ");
                goto age;
            }

            if (isCorrectAgeFormat)
            {

                ConsoleColor.Magenta.WriteConsole("Add group: ");
            IdStr: string idStr = Console.ReadLine();

                int id;
                bool isCorrectIdFormat = int.TryParse(idStr, out id);


                if (isCorrectIdFormat)
                {
                    try
                    {

                        var response = _groupService.GetById(id);

                        _studentService.Create(new Student { Name = name, Surname = surname, Age = age, Group = response });

                        ConsoleColor.Green.WriteConsole("Data successfully added");
                    }
                    catch (Exception ex)
                    {
                        ConsoleColor.Red.WriteConsole(ex.Message);
                        goto IdStr;
                    }
                }
                else
                {
                    Console.WriteLine(" Id format is wrong ");
                    goto IdStr;

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole(" Age format is wrong ");
                goto age;

            }

        }

        public void Delete()
        {

            ConsoleColor.Cyan.WriteConsole("Add group id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    _studentService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }

        }

        public void GetAll()
        {


            var response = _studentService.GetAll();

            foreach (var item in response)
            {
                string data = $"Id: {item.Id}, Student name : {item.Name}, Student surname : {item.Surname}, Student age: {item.Age}, Student" +
                    $"Group id : {item.Group.Id} ";

                Console.WriteLine(data);
            }

        }


        public void GetAllByAge()
        {
            ConsoleColor.Cyan.WriteConsole("Add Age: ");
        Age: string ageStr = Console.ReadLine();
            int age;

            bool isCorrectIdFormat = int.TryParse(ageStr, out age);

            if (isCorrectIdFormat)
            {
                var result = _studentService.GetAllByAge(age);
                if (result == null)
                {
                    ConsoleColor.Red.WriteConsole("Data notfaund");

                }
                else
                {
                    foreach (var item in result)
                    {
                        string data = $"Id: {item.Id}, Student name : {item.Name}, Student surname : {item.Surname}, Student age : {item.Age}" +
                            $" Student Group id : {item.Group.Id} ";

                        Console.WriteLine(data);

                    }

                }


            }



        }

        public void GetAllByGroupId()
        {
            ConsoleColor.Cyan.WriteConsole("Add group id: ");
        Id: string idStr = Console.ReadLine();

            int id;

            bool isCorrectIdFormat = int.TryParse(idStr, out id);


            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Id;
            }
            if (isCorrectIdFormat)
            {
                try
                {



                    List<Domain.Models.Student> response = _studentService.GetAllByGroupId(id);

                    if (response.Count == 0)
                    {
                        ConsoleColor.Red.WriteConsole(" Group Id notfound ");
                    }

                    foreach (var item in response)
                    {
                        string data = $" Id: {item.Id}, Student  name : {item.Name}, Student  surname : {item.Surname}, Student age : {item.Age}, Student group id : {item.Group.Id}";
                        Console.WriteLine(data);
                    }

                }
                catch (Exception)
                {
                    ConsoleColor.Red.WriteConsole(" Group /*id*/ notfound ");
                    goto Id;
                }

            }


        }

        public void GetById()
        {

            ConsoleColor.Cyan.WriteConsole("Add Id: ");
        Id: string idStr = Console.ReadLine();
            int id;

            bool isCorrectIdFormat = int.TryParse(idStr, out id);

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Id;
            }
            try
            {

                _groupService.GetById(id);

                var response = _studentService.GetById(id);

                string data = $"Id: {response.Id}, Student name : {response.Name}, Student surname : {response.Surname}, Group room: {response.Group.Id}";
                Console.WriteLine(data);



            }
            catch (Exception)
            {
                ConsoleColor.Red.WriteConsole(" Id notfound ");
            }
        }

        public void SearchByNameOrSurname()
        {
           SearchByNameOrSurname: ConsoleColor.Cyan.WriteConsole("Add search text: ");

          Name: string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto SearchByNameOrSurname;
            }
            try
            {
                var response = _studentService.GetAllWithExpression(m => m.Name.ToLower().Trim().Contains(searchText.ToLower().Trim()) || m.Surname.ToLower().Trim().Contains(searchText.ToLower().Trim()));


                if (response.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole(" Name or Surname notfaound ");
                }

                foreach (var item in response)
                {
                    string data = $"Id: {item.Id}, Student name : {item.Name}, Student surname : {item.Surname}, Student age : {item.Age}";
                    Console.WriteLine(data);
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto SearchByNameOrSurname;
            }





        }

        public void Update()
        {

        }
    }
}
