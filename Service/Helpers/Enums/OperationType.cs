using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Enums
{
    public enum OperationType
    {
        GroupCtreate = 1,
        GroupDelete,
        GetAllGroups,
        GetAllByRoomGroups,
        GetAllByTeacherGroups,
        GetGroupById,
        SearchByNameGroups,
        GroupUpdate,

        StudentCreate,
        StudentDelete,
        GetAllStudents,
        GetAllByAgeStudents,
        GetAllByGroupIdStudents,
        GetStudentById,
        SearchByNameOrSurnameStudents,
        StudentUpdate,


    }
}
