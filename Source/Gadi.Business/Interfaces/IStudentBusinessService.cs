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
        Task<ValidationResult<FormOneA>> CreateFormOneA(FormOneA formOneA);
        Task<ValidationResult<FormFour>> CreateFormFour(FormFour formFour);
        Task<ValidationResult<FormFive>> CreateFormFive(FormFive formFive);
        Task<ValidationResult<FormEight>> CreateFormEight(FormEight formEight);
        Task<ValidationResult<FormFourteen>> CreateFormFourteen(FormFourteen formFourteen);
        Task<ValidationResult<List<StudentQuestionResponse>>> CreateStudentQuestionResponse(List<StudentQuestionResponse> studentQuestionResponses);

        //Update
        Task<ValidationResult<Student>> UpdateStudent(Student student);
        Task<ValidationResult<FormOneA>> UpdateFormOneA(FormOneA formOneA);
        Task<ValidationResult<FormFour>> UpdateFormFour(FormFour formFour);
        Task<ValidationResult<FormFive>> UpdateFormFive(FormFive formFive);
        Task<ValidationResult<FormEight>> UpdateFormEight(FormEight formEight);
        Task<ValidationResult<FormFourteen>> UpdateFormFourteen(FormFourteen formFourteen);

        //Retrieve
        Task<Student> RetrieveStudent(int studentId);
        Task<FormOneA> RetrieveFormOneAByStudentId(int studentId);
        Task<FormFour> RetrieveFormFourByStudentId(int studentId);
        Task<FormFive> RetrieveFormFiveByStudentId(int studentId);
        Task<FormEight> RetrieveFormEightByStudentId(int studentId);
        Task<FormFourteen> RetrieveFormFourteenByStudentId(int studentId);
        Task<FormFourGrid> RetrieveFormFourGridByStudentId(int studentId);
        Task<PagedResult<Student>> RetrieveStudents(bool isSuperAdmin, int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null);
        Task<PagedResult<StudentGrid>> Search(bool isSuperAdmin, int drivingSchoolId, string term, List<OrderBy> orderBy = null, Paging paging = null);
        Task<PagedResult<Question>> RetrieveQuestions(List<OrderBy> orderBy = null, Paging paging = null);

        //Template
        byte[] CreateFormOneABytes(int drivingSchoolId, int studentId);
        byte[] CreateFormFourBytes(int drivingSchoolId, int studentId);
        byte[] CreateFormFiveBytes(int drivingSchoolId, int studentId);
        byte[] CreateFormEightBytes(int drivingSchoolId, int studentId);
        byte[] CreateFormFourteenBytes(int drivingSchoolId, int studentId);
    }
}
