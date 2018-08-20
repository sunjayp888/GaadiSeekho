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
        Task<PagedResult<Student>> RetrieveStudents(List<OrderBy> orderBy = null, Paging paging = null);
        //Task<PagedResult<StudentGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null);
    }
}
