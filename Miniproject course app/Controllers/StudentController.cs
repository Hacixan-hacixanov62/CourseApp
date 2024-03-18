﻿using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
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

            if( _groupService.GetAll().Count == 0)
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

             ConsoleColor.Magenta.WriteConsole("Add surname: ");
         Surname : string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Surname;
            }

            ConsoleColor.Magenta.WriteConsole("Add age: ");
         age  : string ageStr = Console.ReadLine();   
            
            int age;
            bool isCorrectAgeFormat = int.TryParse(ageStr, out age);


            if (isCorrectAgeFormat)
            {

                ConsoleColor.Magenta.WriteConsole("Add group: ");
                IdStr :  string idStr = Console.ReadLine();

                int id;
                bool isCorrectIdFormat = int.TryParse(idStr, out id);


                if (isCorrectIdFormat)
                {
                    try
                    {

                       var response=  _groupService.GetById(id);
                      
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

                Console.WriteLine(" Age format is wrong ");
                goto age;

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

        public void GetAllByAge()
        {
            ConsoleColor.Cyan.WriteConsole("Add Age: ");
          Age: string ageStr = Console.ReadLine();
            int age;

            bool isCorrectIdFormat = int.TryParse(ageStr, out age);

            if (isCorrectIdFormat)
            {
                var result =_studentService.GetAllByAge(age);
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






    }

    
}