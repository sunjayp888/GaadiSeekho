using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gadi.Business.Extensions;
using Gadi.Business.Interfaces;
using Gadi.Business.Models;
using Gadi.Common.Dto;
using Gadi.Data.Entities;
using Gadi.Data.Interfaces;
using iTextSharp.text;
using Student = Gadi.Business.Models.Student;
using LinqKit;
using Newtonsoft.Json;
using FormEight = Gadi.Business.Models.FormEight;
using FormFive = Gadi.Business.Models.FormFive;
using FormFour = Gadi.Business.Models.FormFour;
using FormFourGrid = Gadi.Business.Models.FormFourGrid;
using FormFourteen = Gadi.Business.Models.FormFourteen;
using FormOneA = Gadi.Business.Models.FormOneA;
using Question = Gadi.Business.Models.Question;
using StudentGrid = Gadi.Business.Models.StudentGrid;
using StudentQuestionResponse = Gadi.Business.Models.StudentQuestionResponse;

namespace Gadi.Business.Services
{
    public partial class StudentBusinessService : IStudentBusinessService
    {
        protected IStudentDataService _dataService;
        private readonly ITemplateBusinessService _templateBusinessService;
        protected IMapper _mapper;
        private readonly ICacheProvider _cacheProvider;

        public StudentBusinessService(IStudentDataService dataService, IMapper mapper, ITemplateBusinessService templateBusinessService, ICacheProvider cacheProvider)
        {
            _dataService = dataService;
            _mapper = mapper;
            _templateBusinessService = templateBusinessService;
            _cacheProvider = cacheProvider;
        }
        public async Task<ValidationResult<Student>> CreateStudent(Student student)
        {
            ValidationResult<Student> validationResult = new ValidationResult<Student>();
            try
            {
                var studentData = _mapper.Map<Data.Entities.Student>(student);
                await _dataService.CreateAsync(studentData);
                validationResult.Entity = student;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<FormOneA>> CreateFormOneA(FormOneA formOneA)
        {
            ValidationResult<FormOneA> validationResult = new ValidationResult<FormOneA>();
            try
            {
                var formOneAData = _mapper.Map<Data.Entities.FormOneA>(formOneA);
                await _dataService.CreateAsync(formOneAData);
                validationResult.Entity = formOneA;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<FormFour>> CreateFormFour(FormFour formFour)
        {
            ValidationResult<FormFour> validationResult = new ValidationResult<FormFour>();
            try
            {
                var formFourData = _mapper.Map<Data.Entities.FormFour>(formFour);
                await _dataService.CreateAsync(formFourData);
                validationResult.Entity = formFour;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<FormFive>> CreateFormFive(FormFive formFive)
        {
            ValidationResult<FormFive> validationResult = new ValidationResult<FormFive>();
            try
            {
                var formFiveData = _mapper.Map<Data.Entities.FormFive>(formFive);
                await _dataService.CreateAsync(formFiveData);
                validationResult.Entity = formFive;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<FormEight>> CreateFormEight(FormEight formEight)
        {
            ValidationResult<FormEight> validationResult = new ValidationResult<FormEight>();
            try
            {
                var formEightData = _mapper.Map<Data.Entities.FormEight>(formEight);
                await _dataService.CreateAsync(formEightData);
                validationResult.Entity = formEight;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<FormFourteen>> CreateFormFourteen(FormFourteen formFourteen)
        {
            ValidationResult<FormFourteen> validationResult = new ValidationResult<FormFourteen>();
            try
            {
                var formFourteenData = _mapper.Map<Data.Entities.FormFourteen>(formFourteen);
                await _dataService.CreateAsync(formFourteenData);
                validationResult.Entity = formFourteen;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<List<StudentQuestionResponse>>> CreateStudentQuestionResponse(List<StudentQuestionResponse> studentQuestionResponses)
        {
            ValidationResult<List<StudentQuestionResponse>> validationResult = new ValidationResult<List<StudentQuestionResponse>>();
            try
            {
                var studentQuestionResponseList = _mapper.Map<List<Data.Entities.StudentQuestionResponse>>(studentQuestionResponses);
                await _dataService.CreateRangeAsync(studentQuestionResponseList);
                validationResult.Entity = studentQuestionResponses;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<Student>> UpdateStudent(Student student)
        {
            ValidationResult<Student> validationResult = new ValidationResult<Student>();
            try
            {
                var studentEntity = _mapper.Map<Data.Entities.Student>(student);
                await _dataService.UpdateAsync(studentEntity);
                validationResult.Entity = student;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<FormOneA>> UpdateFormOneA(FormOneA formOneA)
        {
            ValidationResult<FormOneA> validationResult = new ValidationResult<FormOneA>();
            try
            {
                var formOneAEntity = _mapper.Map<Data.Entities.FormOneA>(formOneA);
                await _dataService.UpdateAsync(formOneAEntity);
                validationResult.Entity = formOneA;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<FormFour>> UpdateFormFour(FormFour formFour)
        {
            ValidationResult<FormFour> validationResult = new ValidationResult<FormFour>();
            try
            {
                var formFourEntity = _mapper.Map<Data.Entities.FormFour>(formFour);
                await _dataService.UpdateAsync(formFourEntity);
                validationResult.Entity = formFour;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<FormFive>> UpdateFormFive(FormFive formFive)
        {
            ValidationResult<FormFive> validationResult = new ValidationResult<FormFive>();
            try
            {
                var formFiveEntity = _mapper.Map<Data.Entities.FormFive>(formFive);
                await _dataService.UpdateAsync(formFiveEntity);
                validationResult.Entity = formFive;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<FormEight>> UpdateFormEight(FormEight formEight)
        {
            ValidationResult<FormEight> validationResult = new ValidationResult<FormEight>();
            try
            {
                var formEightEntity = _mapper.Map<Data.Entities.FormEight>(formEight);
                await _dataService.UpdateAsync(formEightEntity);
                validationResult.Entity = formEight;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<FormFourteen>> UpdateFormFourteen(FormFourteen formFourteen)
        {
            ValidationResult<FormFourteen> validationResult = new ValidationResult<FormFourteen>();
            try
            {
                var formFourteenEntity = _mapper.Map<Data.Entities.FormFourteen>(formFourteen);
                await _dataService.UpdateAsync(formFourteenEntity);
                validationResult.Entity = formFourteen;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<Student> RetrieveStudent(int studentId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.Student>(a => a.StudentId == studentId);
            var student = _mapper.MapToList<Student>(result);
            return student.FirstOrDefault();
        }

        public async Task<FormOneA> RetrieveFormOneAByStudentId(int studentId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.FormOneA>(a => a.StudentId == studentId);
            var student = _mapper.MapToList<FormOneA>(result);
            return student.FirstOrDefault();
        }

        public async Task<FormFour> RetrieveFormFourByStudentId(int studentId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.FormFour>(a => a.StudentId == studentId);
            var student = _mapper.MapToList<FormFour>(result);
            return student.FirstOrDefault();
        }

        public async Task<FormFive> RetrieveFormFiveByStudentId(int studentId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.FormFive>(a => a.StudentId == studentId);
            var student = _mapper.MapToList<FormFive>(result);
            return student.FirstOrDefault();
        }

        public async Task<FormEight> RetrieveFormEightByStudentId(int studentId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.FormEight>(a => a.StudentId == studentId);
            var student = _mapper.MapToList<FormEight>(result);
            return student.FirstOrDefault();
        }

        public async Task<FormFourteen> RetrieveFormFourteenByStudentId(int studentId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.FormFourteen>(a => a.StudentId == studentId);
            var student = _mapper.MapToList<FormFourteen>(result);
            return student.FirstOrDefault();
        }

        public async Task<FormFourGrid> RetrieveFormFourGridByStudentId(int studentId)
        {
            try
            {
                var result = await _dataService.RetrieveAsync<Data.Entities.FormFourGrid>(a => a.StudentId == studentId);
                var student = _mapper.MapToList<FormFourGrid>(result);
                return student.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<PagedResult<Student>> RetrieveStudents(bool isSuperAdmin, int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var students = await _dataService.RetrievePagedResultAsync<Data.Entities.Student>(a => isSuperAdmin || a.DrivingSchoolId == drivingSchoolId, orderBy, paging);
            return _mapper.MapToPagedResult<Student>(students);
        }

        public async Task<PagedResult<StudentGrid>> Search(bool isSuperAdmin, int drivingSchoolId, string term, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var predicate = PredicateBuilder.New<Data.Entities.StudentGrid>(a => isSuperAdmin || a.DrivingSchoolId == drivingSchoolId);
            if (!string.IsNullOrEmpty(term))
                predicate = predicate.And(a => (isSuperAdmin || a.DrivingSchoolId == drivingSchoolId) && a.SearchField.ToLower().Contains(term.ToLower()));
            var students = await _dataService.RetrievePagedResultAsync<Data.Entities.StudentGrid>(predicate, orderBy, paging);
            return _mapper.MapToPagedResult<Models.StudentGrid>(students);
        }

        public async Task<PagedResult<Question>> RetrieveQuestions(List<OrderBy> orderBy = null, Paging paging = null)
        {
            var questions = await _dataService.RetrievePagedResultAsync<Data.Entities.Question>(e => true, orderBy, paging);
            return _mapper.MapToPagedResult<Question>(questions);
        }

        public byte[] CreateFormOneABytes(int drivingSchoolId, int studentId)
        {
            //var result = _dataService.Retrieve<Data.Entities.FormOneAGrid>(a => a.StudentId == studentId);
            //var student = _mapper.MapToList<FormOneAGrid>(result);
            //var formOneAData = student.FirstOrDefault();
            //return _templateBusinessService.CreatePDF(JsonConvert.SerializeObject(formOneAData), "FormOneA");
            return null;
        }

        public byte[] CreateFormFourBytes(int drivingSchoolId, int studentId)
        {
            var result = _dataService.Retrieve<Data.Entities.FormFourGrid>(a => a.StudentId == studentId);
            var student = _mapper.MapToList<FormFourGrid>(result);
            var formFourData = student.FirstOrDefault();
            return _templateBusinessService.CreatePDF(JsonConvert.SerializeObject(formFourData), "FormFour");
        }

        public byte[] CreateFormFiveBytes(int drivingSchoolId, int studentId)
        {
            //var result = _dataService.Retrieve<Data.Entities.FormFiveGrid>(a => a.StudentId == studentId);
            //var student = _mapper.MapToList<FormFiveGrid>(result);
            //var formFiveData = student.FirstOrDefault();
            //return _templateBusinessService.CreatePDF(JsonConvert.SerializeObject(formFiveData), "FormFive");
            return null;
        }

        public byte[] CreateFormEightBytes(int drivingSchoolId, int studentId)
        {
            //var result = _dataService.Retrieve<Data.Entities.FormEightGrid>(a => a.StudentId == studentId);
            //var student = _mapper.MapToList<FormEightGrid>(result);
            //var formEightData = student.FirstOrDefault();
            //return _templateBusinessService.CreatePDF(JsonConvert.SerializeObject(formEightData), "FormEight");
            return null;
        }

        public byte[] CreateFormFourteenBytes(int drivingSchoolId, int studentId)
        {
            //var result = _dataService.Retrieve<Data.Entities.FormFourteenGrid>(a => a.StudentId == studentId);
            //var student = _mapper.MapToList<FormFourteenGrid>(result);
            //var formFourteenData = student.FirstOrDefault();
            //return _templateBusinessService.CreatePDF(JsonConvert.SerializeObject(formFourteenData), "FormFourteen");
            return null;
        }
    }
}
