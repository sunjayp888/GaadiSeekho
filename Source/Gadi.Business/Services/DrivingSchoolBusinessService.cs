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
using LinqKit;
using Car = Gadi.Business.Models.Car;
using DrivingSchool = Gadi.Business.Models.DrivingSchool;
using DrivingSchoolCar = Gadi.Business.Models.DrivingSchoolCar;
using DrivingSchoolGrid = Gadi.Business.Models.DrivingSchoolGrid;


namespace Gadi.Business.Services
{
    public partial class DrivingSchoolBusinessService : IDrivingSchoolBusinessService
    {
        private readonly IMapper _mapper;
        private readonly IDrivingSchoolDataService _dataService;
        private readonly IDrivingSchoolCarBusinessService _drivingSchoolCarBusinessService;

        public DrivingSchoolBusinessService(IMapper mapper, IDrivingSchoolDataService dataService, IDrivingSchoolCarBusinessService drivingSchoolCarBusinessService)
        {
            _mapper = mapper;
            _dataService = dataService;
            _drivingSchoolCarBusinessService = drivingSchoolCarBusinessService;
        }

        public async Task<ValidationResult<DrivingSchool>> CreateDrivingSchool(DrivingSchool drivingSchool)
        {
            ValidationResult<DrivingSchool> validationResult = new ValidationResult<Models.DrivingSchool>();
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

        //public async Task<ValidationResult<DrivingSchoolCar>> CreateDrivingSchoolCar(int drivingSchoolId, int carId, decimal withLicenseFee, decimal withOutLicenseFee, decimal discountOnFee)
        //{
        //    ValidationResult<DrivingSchoolCar> validationResult = new ValidationResult<Models.DrivingSchoolCar>();
        //    var drivingSchoolCar = new DrivingSchoolCar()
        //    {
        //        DrivingSchoolId = drivingSchoolId,
        //        CarId = carId
        //    };
            
        //    try
        //    {
        //        var drivingSchoolCarData = _mapper.Map<Data.Entities.DrivingSchoolCar>(drivingSchoolCar);
        //        await _dataService.CreateAsync(drivingSchoolCarData);
        //        var drivingSchoolCarFee = new DrivingSchoolCarFee()
        //        {
        //            WithLicenseFee = withLicenseFee,
        //            WithoutLicenseFee = withOutLicenseFee,
        //            DiscountAmount = discountOnFee,
        //            DrivingSchoolCarId = drivingSchoolCarData.DrivingSchoolCarId
        //        };
        //        var drivingSchoolCarFeeData = _mapper.Map<Data.Entities.DrivingSchoolCarFee>(drivingSchoolCarFee);
        //        await _dataService.CreateAsync(drivingSchoolCarFeeData);
        //        validationResult.Entity = drivingSchoolCar;
        //        validationResult.Succeeded = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        validationResult.Succeeded = false;
        //        validationResult.Errors = new List<string> { ex.InnerMessage() };
        //        validationResult.Exception = ex;
        //    }
        //    return validationResult;
        //}

        public async Task<ValidationResult<DrivingSchool>> UpdateDrivingSchool(DrivingSchool drivingSchool)
        {
            ValidationResult<DrivingSchool> validationResult = new ValidationResult<DrivingSchool>();
            try
            {
                var drivingSchoolData = _mapper.Map<Data.Entities.DrivingSchool>(drivingSchool);
                await _dataService.UpdateAsync(drivingSchoolData);
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
            var result = await _dataService.RetrieveAsync<Data.Entities.DrivingSchool>(a => a.DrivingSchoolId == drivingSchoolId);
            var driver = _mapper.MapToList<DrivingSchool>(result);
            return driver.FirstOrDefault();
        }

        public async Task<DrivingSchool> RetrieveDrivingSchoolByPersonnelId(int personnelId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.DrivingSchool>(a => a.PersonnelId == personnelId);
            var driver = _mapper.MapToList<DrivingSchool>(result);
            return driver.FirstOrDefault();
        }

        public async Task<PagedResult<DrivingSchoolGrid>> RetrieveDrivingSchools(List<OrderBy> orderBy = null, Paging paging = null)
        {
            var data = await _dataService.RetrievePagedResultAsync<Data.Entities.DrivingSchoolGrid>(e => true, orderBy, paging);
            return _mapper.MapToPagedResult<DrivingSchoolGrid>(data);
        }

        public async Task<List<Models.DrivingSchoolCarGrid>> RetrieveDrivingSchoolCarGridsByDrivingSchoolId(int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var data = await _dataService.RetrievePagedResultAsync<Data.Entities.DrivingSchoolCarGrid>(e => e.DrivingSchoolId == drivingSchoolId, orderBy, paging);
            var result = data.Items.ToList();
            return _mapper.MapToList<Models.DrivingSchoolCarGrid>(result);
        }

        public async Task<List<Models.DrivingSchoolRatingAndReview>> RetrieveDrivingSchoolRatingAndReviewByDrivingSchoolId(int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var data = await _dataService.RetrievePagedResultAsync<Data.Entities.DrivingSchoolRatingAndReview>(e => e.DrivingSchoolId == drivingSchoolId, orderBy, paging);
            var result = data.Items.ToList();
            return _mapper.MapToList<Models.DrivingSchoolRatingAndReview>(result);
        }

        public async Task<PagedResult<Models.DrivingSchoolGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var predicate = PredicateBuilder.New<Data.Entities.DrivingSchoolGrid>(true);
            if (!string.IsNullOrEmpty(term))
                predicate = predicate.And(a => a.SearchField.ToLower().Contains(term.ToLower()));
            var drivingSchools = await _dataService.RetrievePagedResultAsync<Data.Entities.DrivingSchoolGrid>(predicate, orderBy, paging);
            return _mapper.MapToPagedResult<Models.DrivingSchoolGrid>(drivingSchools);
        }

        //public async Task<IEnumerable<Car>> RetrieveUnassignedDrivingSchoolCars(int drivingSchoolId)
        //{
        //    var data = await _dataService.RetrievePagedResultAsync<Data.Entities.Car>(e => !e.DrivingSchoolCars.Any(a => a.DrivingSchoolId == drivingSchoolId));
        //    var result = data.Items.ToList();
        //    return _mapper.MapToList<Models.Car>(result);
        //}

        //public async Task<PagedResult<DrivingSchoolCar>> RetrieveDrivingSchoolCars(int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null)
        //{
        //    var data = await _dataService.RetrievePagedResultAsync<Data.Entities.DrivingSchoolCar>(e => e.DrivingSchoolId == drivingSchoolId, orderBy, paging, a => a.DrivingSchool);
        //    return _mapper.MapToPagedResult<DrivingSchoolCar>(data);
        //}

        //public async Task<bool> DeleteDrivingSchoolCar(int drivingSchoolId, int carId)
        //{
        //    try
        //    {
        //        var drivingSchoolCar = await _drivingSchoolCarBusinessService.RetrieveDrivingSchoolCarByDrivingSchoolIdCarId(drivingSchoolId, carId);
        //        await _dataService.DeleteWhereAsync<DrivingSchoolCarFee>(e => e.DrivingSchoolCarId == drivingSchoolCar.DrivingSchoolCarId);
        //        //await _dataService.DeleteWhereAsync<Data.Entities.DrivingSchoolCar>(e => e.DrivingSchoolId == drivingSchoolId && e.CarId == carId);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}
