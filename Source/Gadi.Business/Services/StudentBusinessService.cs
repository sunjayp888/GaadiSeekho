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
using Car = Gadi.Business.Models.Car;

namespace Gadi.Business.Services
{
    public partial class StudentBusinessService:IStudentBusinessService
    {
        protected IStudentDataService _dataService;
        protected IMapper _mapper;

        public StudentBusinessService(IStudentDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        public async Task<ValidationResult<Student>> CreateStudent(Student student)
        {
            ValidationResult<Student> validationResult = new ValidationResult<Student>();
            try
            {
                var studentData = _mapper.Map<Student>(student);
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

        public async Task<ValidationResult<Student>> UpdateStudent(Student student)
        {
            ValidationResult<Student> validationResult = new ValidationResult<Student>();
            try
            {
                await _dataService.UpdateAsync(student);
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

        public async Task<Student> RetrieveStudent(int studentId)
        {
            var result = await _dataService.RetrieveAsync<Student>(a => a.StudentId == studentId);
            var student = _mapper.MapToList<Student>(result);
            return student.FirstOrDefault();
        }

        public async Task<PagedResult<Student>> RetrieveStudents(List<OrderBy> orderBy = null, Paging paging = null)
        {
            var students = await _dataService.RetrievePagedResultAsync<Student>(a => true, orderBy, paging);
            return students;
        }

        //public async Task<PagedResult<StudentGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null)
        //{
        //    if (string.IsNullOrEmpty(term))
        //        return await _dataService.RetrievePagedResultAsync<StudentGrid>(a => true, orderBy, paging);
        //    return await _dataService.RetrievePagedResultAsync<StudentGrid>(a => a.SearchField.ToLower().Contains(term.ToLower()), orderBy, paging);
        //}
    }
}
