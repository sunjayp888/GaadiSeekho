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
using Student = Gadi.Business.Models.Student;
using LinqKit;
using StudentGrid = Gadi.Business.Models.StudentGrid;

namespace Gadi.Business.Services
{
    public partial class StudentBusinessService : IStudentBusinessService
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

        public async Task<Student> RetrieveStudent(int studentId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.Student>(a => a.StudentId == studentId);
            var student = _mapper.MapToList<Student>(result);
            return student.FirstOrDefault();
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
                predicate = predicate.And(a =>(isSuperAdmin || a.DrivingSchoolId == drivingSchoolId) && a.SearchField.ToLower().Contains(term.ToLower()));
            var students = await _dataService.RetrievePagedResultAsync<Data.Entities.StudentGrid>(predicate, orderBy, paging);
            return _mapper.MapToPagedResult<Models.StudentGrid>(students);
        }
    }
}
