using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gadi.Business.Extensions;
using Gadi.Business.Interfaces;
using Gadi.Business.Models;
using Gadi.Common.Dto;
using Gadi.Data.Entities;
using Gadi.Data.Interfaces;
using DrivingSchool = Gadi.Business.Models.DrivingSchool;


namespace Gadi.Business.Services
{
    public partial class DrivingSchoolBusinessService : IDrivingSchoolBusinessService
    {
        private readonly IMapper _mapper;
        private readonly IDrivingSchoolDataService _dataService;

        public DrivingSchoolBusinessService(IMapper mapper, IDrivingSchoolDataService dataService)
        {
            _mapper = mapper;
            _dataService = dataService;
        }

        public async Task<ValidationResult<DrivingSchool>> CreateDrivingSchool(DrivingSchool drivingSchool)
        {
            ValidationResult<Models.DrivingSchool> validationResult = new ValidationResult<Models.DrivingSchool>();
            try
            {
                var drivingSchoolData = _mapper.Map<Data.Entities.DrivingSchool>(drivingSchool);
                await _dataService.CreateAsync(drivingSchoolData);
                validationResult.Entity = drivingSchool;
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

        public async Task<ValidationResult<DrivingSchool>> UpdateDrivingSchool(DrivingSchool drivingSchool)
        {
            ValidationResult<DrivingSchool> validationResult = new ValidationResult<DrivingSchool>();
            try
            {
                await _dataService.UpdateAsync(drivingSchool);
                validationResult.Entity = drivingSchool;
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

        public async Task<DrivingSchool> RetrieveDrivingSchool(int drivingSchoolId)
        {
            var result = await _dataService.RetrieveAsync<DrivingSchool>(a =>a.DrivingSchoolId == drivingSchoolId);
            var driver = _mapper.MapToList<DrivingSchool>(result);
            return driver.FirstOrDefault();
        }

        public async Task<PagedResult<DrivingSchool>> RetrieveDrivingSchools(List<OrderBy> orderBy = null, Paging paging = null)
        {
            var data = await _dataService.RetrievePagedResultAsync<Data.Entities.DrivingSchool>(e => true, orderBy, paging);
            return _mapper.MapToPagedResult<DrivingSchool>(data);
        }

        //public async Task<PagedResult<DrivingSchoolGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null)
        //{
        //    if (string.IsNullOrEmpty(term))
        //        return await _dataService.RetrievePagedResultAsync<DrivingSchoolGrid>(a => true, orderBy, paging);
        //    return await _dataService.RetrievePagedResultAsync<DrivingSchoolGrid>(a => a.SearchField.ToLower().Contains(term.ToLower()), orderBy, paging);
        //}
    }
}
