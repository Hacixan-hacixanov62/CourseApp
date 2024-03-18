

using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Miniproject_course_app.Controllers
{
    internal class GroupController
    {
        private readonly IGroupService _groupService;

        public GroupController()
        {
            _groupService = new GroupService();
        }

        public void Create()
        {
            ConsoleColor.Cyan.WriteConsole("Add name: ");
        Name: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Name;
            }
            
            
            if(_groupService.GetAll().FirstOrDefault(m=> m.Name.ToLower()== name.ToLower().Trim())!=null)
            {
                Console.WriteLine("Group already exists ");
                goto Name;
            }



            ConsoleColor.Cyan.WriteConsole("Add teacher: ");
        Teacher: string teacher = Console.ReadLine();

            if (teacher.Length < 3)
            {
                ConsoleColor.Red.WriteConsole(" Name must not be less than three letters ");
                goto Name;
            }

            if (string.IsNullOrWhiteSpace(teacher))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Teacher;
            }


            if (!Regex.IsMatch(teacher, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Teacher;
            }



            ConsoleColor.Cyan.WriteConsole("Add room: ");
           Room : string room = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(room))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Room;
            }



            try
            {

                _groupService.Create(new Domain.Models.Group { Name = name.Trim(), Teacher = teacher.Trim(), Room = room.Trim() });

                ConsoleColor.Green.WriteConsole("Data successfully added");
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Name;
            }


        }


        public void GetAll()
        {

            var response = _groupService.GetAll();

            foreach (var item in response)
            {
                string data = $"Id: {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room: {item.Room}";
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
                    _groupService.Delete(id);
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

        public void GetAllByRoom()
        {

            ConsoleColor.Cyan.WriteConsole("Add room: ");
        Room: string room = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(room))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Room;
            }

            try
            {
                 

                List<Domain.Models.Group> response = _groupService.GetAllByRoom(room);

                if (response.Count ==0)
                {
                    ConsoleColor.Red.WriteConsole(" Room notfound ");
                }

                foreach (var item in response)
                {
                    string data = $"Id: {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room : {item.Room}";
                    Console.WriteLine(data);
                }

            }
            catch (Exception )
            {
                ConsoleColor.Red.WriteConsole(" Room notfound ");
                goto Room;
            }

        }

        public void GetAllByTeacher()
        {
            ConsoleColor.Cyan.WriteConsole("Add teacher: ");
        Teacher: string teachername = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(teachername))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Teacher;
            }

            try
            {

                List<Domain.Models.Group>  response = _groupService.GetAllByTeacher(teachername);
                if ( response.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole(" Teachername notfound ");
                }

                foreach (var item in response)
                {
                    string data = $"Id: {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room : {item.Room}";
                    Console.WriteLine(data);
                }

            }
            catch (Exception )
            {
                ConsoleColor.Red.WriteConsole("Teachername notfound");
                goto Teacher;
            }

        }

        public void GetById()
        {

            ConsoleColor.Cyan.WriteConsole("Add Id: ");
             Id : string idStr = Console.ReadLine();
                int id;

            bool isCorrectIdFormat = int.TryParse(idStr , out id);

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Id;
            }
            try
            {

                _groupService.GetById(id);

                var response = _groupService.GetById(id);

                string data = $"Id: {response.Id}, Group name : {response.Name}, Group teacher : {response.Teacher}, Group room: {response.Room}";
                Console.WriteLine(data);



            }
            catch (Exception )
            {
                ConsoleColor.Red.WriteConsole(" Id notfound ");
            }
        }

        public void SearchByName()
        {

            ConsoleColor.Cyan.WriteConsole("Add name: ");
        Name: string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto  Name;
            }
            try
            {

                List<Domain.Models.Group> response = _groupService.SearchByName(searchText);
                if (response.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole(" Name notfaound ");
                }

                foreach (var item in response)
                {
                    string data = $"Id: {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room : {item.Room}";
                    Console.WriteLine(data);
                }

            }
            catch (Exception )
            {
                ConsoleColor.Red.WriteConsole(" Name notfaound ");
                goto Name;
            }
        }

        public void Update()
        {

        }
        



    }
}
