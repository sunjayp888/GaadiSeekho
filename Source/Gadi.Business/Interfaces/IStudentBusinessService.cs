using System.Collections.Generic;
using System.Threading.Tasks;
using Gadi.Common.Dto;
using Gadi.Business.Models;

namespace Gadi.Business.Interfaces
{
    public interface IStudentBusinessService
    {
        //Create
        Task<ValidationResult<Student>> CreateStudent(Student student);

        //Update
        Task<ValidationResult<Student>> UpdateStudent(Student student);

        //Retrieve
        Task<Student> RetrieveStudent(int studentId);
        Task<PagedResult<Student>> RetrieveStudents(bool isSuperAdmin, int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null);
        Task<PagedResult<StudentGrid>> Search(bool isSuperAdmin, int drivingSchoolId, string term, List<OrderBy> orderBy = null, Paging paging = null);
    }
}
