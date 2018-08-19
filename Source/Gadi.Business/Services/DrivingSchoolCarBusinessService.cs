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

namespace Gadi.Business.Services
{
    public partial class DrivingSchoolCarBusinessService : IDrivingSchoolCarBusinessService
    {
        protected IDrivingSchoolCarDataService _dataService;
        protected IMapper _mapper;

        public DrivingSchoolCarBusinessService(IDrivingSchoolCarDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ValidationResult<DrivingSchoolCar>> CreateDrivingSchoolCar(DrivingSchoolCar drivingSchoolCar)
        {
            ValidationResult<DrivingSchoolCar> validationResult = new ValidationResult<DrivingSchoolCar>();
            try
            {
                var drivingSchoolCarData = _mapper.Map<DrivingSchoolCar>(drivingSchoolCar);
                await _dataService.CreateAsync(drivingSchoolCarData);
                validationResult.Entity = drivingSchoolCar;
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

        public async Task<ValidationResult<DrivingSchoolCar>> UpdateDrivingSchoolCar(DrivingSchoolCar drivingSchoolCar)
        {
            ValidationResult<DrivingSchoolCar> validationResult = new ValidationResult<DrivingSchoolCar>();
            try
            {
                await _dataService.UpdateAsync(drivingSchoolCar);
                validationResult.Entity = drivingSchoolCar;
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

        public async Task<DrivingSchoolCar> RetrieveDrivingSchoolCar(int drivingSchoolCarId)
        {
            var result = await _dataService.RetrieveAsync<DrivingSchoolCar>(a => a.DrivingSchoolCarId == drivingSchoolCarId);
            var drivingSchoolCar = _mapper.MapToList<DrivingSchoolCar>(result);
            return drivingSchoolCar.FirstOrDefault();
        }

        public async Task<PagedResult<DrivingSchoolCar>> RetrieveDrivingSchoolCars(List<OrderBy> orderBy = null, Paging paging = null)
        {
            var drivingSchoolCars = await _dataService.RetrievePagedResultAsync<DrivingSchoolCar>(a => true, orderBy, paging);
            return drivingSchoolCars;
        }

        //public async Task<PagedResult<DrivingSchoolCarGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null)
        //{
        //    if (string.IsNullOrEmpty(term))
        //        return await _dataService.RetrievePagedResultAsync<DrivingSchoolCarGrid>(a => true, orderBy, paging);
        //    return await _dataService.RetrievePagedResultAsync<DrivingSchoolCarGrid>(a => a.SearchField.ToLower().Contains(term.ToLower()), orderBy, paging);
        //}
    }
}
