using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gadi.Business.Dto;
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
using DrivingSchoolFilterGrid = Gadi.Business.Models.DrivingSchoolFilterGrid;
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

        public async Task<PagedResult<DrivingSchoolFilterGrid>> RetrieveDrivingSchools(Filter filter, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var predicate = BuildDrivingSchoolSearchPredicate(filter);
            var result = await _dataService.RetrievePagedResultAsync<Data.Entities.DrivingSchoolFilterGrid>(predicate, orderBy, paging);
            return _mapper.MapToPagedResult<DrivingSchoolFilterGrid>(result);
        }

        private ExpressionStarter<Data.Entities.DrivingSchoolFilterGrid> BuildDrivingSchoolSearchPredicate(Filter filter)
        {
            var predicate = PredicateBuilder.New<Data.Entities.DrivingSchoolFilterGrid>(true);
            if (filter != null && filter.IsMondayFilter)
                predicate = predicate.And(e => e.WorkinDays.Contains(filter.Monday));
            if (filter != null && filter.IsTuesdayFilter)
                predicate = predicate.And(e => e.WorkinDays.Contains(filter.Tuesday));
            if (filter != null && filter.IsWednesdayFilter)
                predicate = predicate.And(e => e.WorkinDays.Contains(filter.Wednesday));
            if (filter != null && filter.IsThursdayFilter)
                predicate = predicate.And(e => e.WorkinDays.Contains(filter.Thursday));
            if (filter != null && filter.IsFridayFilter)
                predicate = predicate.And(e => e.WorkinDays.Contains(filter.Friday));
            if (filter != null && filter.IsSaturdayFilter)
                predicate = predicate.And(e => e.WorkinDays.Contains(filter.Saturday));
            if (filter != null && filter.IsSundayFilter)
                predicate = predicate.And(e => e.WorkinDays.Contains(filter.Sunday));
            if (filter != null && filter.IsTwoWheelerFilter)
                predicate = predicate.And(e => e.WheelTypes.Contains(filter.Sunday));
            if (filter != null && filter.IsFourWheelerFilter)
                predicate = predicate.And(e => e.WheelTypes.Contains(filter.FourWheeler));
            if (filter != null && filter.IsWithLicenseFilter)
                predicate = predicate.And(e => e.License.Contains(filter.WithLicense));
            if (filter != null && filter.IsWithoutLicenseFilter)
                predicate = predicate.And(e => e.License.Contains(filter.WithoutLicense));
            if (filter != null && filter.IsNormalFilter)
                predicate = predicate.And(e => e.CarType.Contains(filter.Normal));
            if (filter != null && filter.IsSuvFilter)
                predicate = predicate.And(e => e.CarType.Contains(filter.Suv));
            if (filter != null && filter.IsMuvFilter)
                predicate = predicate.And(e => e.CarType.Contains(filter.Muv));
            if (filter != null && filter.IsXuvFilter)
                predicate = predicate.And(e => e.CarType.Contains(filter.Xuv));
            if (filter != null && filter.IsDrivingFeesFilter)
            {
                predicate = predicate.And(e => e.MinimumFeeWithLicense >= filter.FromFees && e.MinimumFeeWithLicense <= filter.ToFees);
                predicate = predicate.And(e => e.MinimumFeeWithOutLicense >= filter.FromFees && e.MinimumFeeWithOutLicense <= filter.ToFees);
            }
            if (filter != null && filter.IsMaruti800Filter)
                predicate = predicate.And(e => e.CarName.Contains(filter.Maruti800));
            if (filter != null && filter.IsSantroFilter)
                predicate = predicate.And(e => e.CarName.Contains(filter.Santro));
            if (filter != null && filter.IsIndicaFilter)
                predicate = predicate.And(e => e.CarName.Contains(filter.Indica));
            if (filter != null && filter.IsQualisFilter)
                predicate = predicate.And(e => e.CarName.Contains(filter.Qualis));
            return predicate;
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
