using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Gadi.Business.Extensions;
using Gadi.Business.Interfaces;
using Gadi.Business.Models;
using Gadi.Common.Dto;
using Gadi.Data.Interfaces;
using LinqKit;

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

        public async Task<ValidationResult<DrivingSchoolCar>> CreateDrivingSchoolCar(DrivingSchoolCar drivingSchoolCar, DrivingSchoolCarFee drivingSchoolCarFee)
        {
            ValidationResult<DrivingSchoolCar> validationResult = new ValidationResult<DrivingSchoolCar>();
            try
            {
                var drivingSchoolCarData = _mapper.Map<Data.Entities.DrivingSchoolCar>(drivingSchoolCar);
                await _dataService.CreateAsync(drivingSchoolCarData);
                var drivingSchoolCarFeeData = _mapper.Map<Data.Entities.DrivingSchoolCarFee>(drivingSchoolCarFee);
                drivingSchoolCarFeeData.DrivingSchoolCarId = drivingSchoolCarData.DrivingSchoolCarId;
                await _dataService.CreateAsync(drivingSchoolCarFeeData);
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

        public async Task<ValidationResult<DrivingSchoolCar>> UpdateDrivingSchoolCar(DrivingSchoolCar drivingSchoolCar, DrivingSchoolCarFee drivingSchoolCarFee)
        {
            ValidationResult<DrivingSchoolCar> validationResult = new ValidationResult<DrivingSchoolCar>();
            try
            {
                var drivingSchoolCarData = _mapper.Map<Data.Entities.DrivingSchoolCar>(drivingSchoolCar);
                await _dataService.UpdateAsync(drivingSchoolCarData);
                var drivingSchoolCarFeeData = _mapper.Map<Data.Entities.DrivingSchoolCarFee>(drivingSchoolCarFee);
                drivingSchoolCarFeeData.DrivingSchoolCarId = drivingSchoolCarData.DrivingSchoolCarId;
                await _dataService.CreateAsync(drivingSchoolCarFeeData);
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
            var result = await _dataService.RetrieveAsync<Data.Entities.DrivingSchoolCar>(a => a.DrivingSchoolCarId == drivingSchoolCarId);
            var drivingSchoolCar = _mapper.MapToList<DrivingSchoolCar>(result);
            return drivingSchoolCar.FirstOrDefault();
        }

        public async Task<DrivingSchoolCarFee> RetrieveDrivingSchoolCarFee(int drivingSchoolCarId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.DrivingSchoolCarFee>(a => a.DrivingSchoolCarId == drivingSchoolCarId);
            var drivingSchoolCar = _mapper.MapToList<DrivingSchoolCarFee>(result);
            return drivingSchoolCar.FirstOrDefault();
        }

        public async Task<DrivingSchoolCar> RetrieveDrivingSchoolCarByDrivingSchoolIdCarId(int drivingSchoolId, int drivingSchoolCarId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.DrivingSchoolCar>(a => a.DrivingSchoolId == drivingSchoolId && a.DrivingSchoolCarId == drivingSchoolCarId);
            var drivingSchoolCar = _mapper.MapToList<DrivingSchoolCar>(result);
            return drivingSchoolCar.FirstOrDefault();
        }

        public async Task<PagedResult<DrivingSchoolCarGrid>> RetrieveDrivingSchoolCars(bool isSuperAdmin, int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var drivingSchoolCars = await _dataService.RetrievePagedResultAsync<Data.Entities.DrivingSchoolCarGrid>(a => isSuperAdmin || a.DrivingSchoolId == drivingSchoolId, orderBy, paging);
            return _mapper.MapToPagedResult<DrivingSchoolCarGrid>(drivingSchoolCars);
        }

        public async Task<PagedResult<DrivingSchoolCarGrid>> Search(bool isSuperAdmin, int drivingSchoolId, string term, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var predicate = PredicateBuilder.New<Data.Entities.DrivingSchoolCarGrid>(true);
            if (!string.IsNullOrEmpty(term))
                predicate = predicate.And(a => (isSuperAdmin || a.DrivingSchoolId == drivingSchoolId) && a.SearchField.ToLower().Contains(term.ToLower()));
            var drivingSchoolCars = await _dataService.RetrievePagedResultAsync<Data.Entities.DrivingSchoolCarGrid>(predicate, orderBy, paging);
            return _mapper.MapToPagedResult<Models.DrivingSchoolCarGrid>(drivingSchoolCars);
        }
    }
}
