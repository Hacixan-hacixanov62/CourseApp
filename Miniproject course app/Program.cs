
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

    ConsoleColor.Cyan.WriteConsole("Chose one operation :  \n 1-Group create\n 2-Group delete\n 3-Get all Groups,4-Get all by room groups, 5- Get all by teacher groups," +
        " 6-Get group by id, 7-Search by name groups, 8-Group Update, 9-Student Create, 10-Get all Students, 11-Student delete, 12-Get by" +
        "ages Students, 13-Get all by group id ");
}






