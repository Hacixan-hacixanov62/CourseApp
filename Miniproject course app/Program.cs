
using Miniproject_course_app.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;



GroupController groupController = new ();
StudentController studentController = new  ();

while (true)
{
    GetMenues();

Operation: string operationStr = Console.ReadLine();

    int operation;

    bool isCorrectOpreationFormat = int.TryParse(operationStr, out operation);
    if (isCorrectOpreationFormat)
    {
        switch (operation)
        {
            case (int)OperationType.GroupCtreate:
                groupController.Create();
                break;

            case (int)OperationType.GroupDelete:
                 groupController.Delete();
                break;

            case (int)OperationType.GetAllGroups:
                groupController.GetAll();
                break;

            case (int)OperationType.GetAllByRoomGroups:
                groupController.GetAllByRoom();
                break;

            case (int)OperationType.GetAllByTeacherGroups:
                groupController.GetAllByTeacher();
                break;

            case (int)OperationType.GetGroupById:
                groupController.GetById();
                break;


            case (int)OperationType.SearchByNameGroups:
                groupController.SearchByName();
                break;


            case (int)OperationType.GroupUpdate:
                groupController.Update();
                break;


            case (int)OperationType.StudentCreate:
                studentController.Create();
                break;

            case (int)OperationType.GetAllStudents:
                studentController.GetAll();
                break;


            case (int)OperationType.StudentDelete:
                studentController.Delete();
                break;


            case (int)OperationType.GetAllByAgeStudents:
                studentController.GetAllByAge();
                break;

            case (int)OperationType.GetAllByGroupIdStudents:
                studentController.GetAllByGroupId();
                break;

            case (int)OperationType.GetStudentById:
                studentController.GetById();
                break;


            case (int)OperationType.SearchByNameOrSurnameStudents:
                studentController.SearchByNameOrSurname();
                break;

            case (int)OperationType.StudentUpdate:
                studentController.Update();
                break;


            default:
                ConsoleColor.Red.WriteConsole("Operation is wrong, please choose again");
                goto Operation;

        }


    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong, please add operation again");
        goto Operation;
    }



}

static void GetMenues()
{

    ConsoleColor.Cyan.WriteConsole("\nSelect one operation:\n\n" +

          " Group operations                  Student operations\n" +

        " 1. Group create                     9. Student Create\n" +
        " 2. Group delete                    10. Student delete\n" +
        " 3. Get all Groups                  11. Get all Students\n" +
        " 4. Get all by room groups          12. Get all by ages Students\n" +
        " 5. Get all by teacher groups       13. Get all by student group id\n" +
        " 6. Get all group by id             14. Get all students by id\n" +
        " 7. Search by name groups           15. Search name or surname students\n" +
        " 8. Group Update                    16.Student Update");
 
}





