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
using LinqKit;
using Driver = Gadi.Business.Models.Driver;
using DriverCar = Gadi.Business.Models.DriverCar;
using DriverGrid = Gadi.Business.Models.DriverGrid;
using DrivingSchoolCar = Gadi.Business.Models.DrivingSchoolCar;

namespace Gadi.Business.Services
{
    public partial class DriverBusinessService : IDriverBusinessService
    {
        protected IDriverDataService _dataService;
        protected IMapper _mapper;

        public DriverBusinessService(IDriverDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ValidationResult<Driver>> CreateDriver(Driver driver)
        {
            ValidationResult<Driver> validationResult = new ValidationResult<Driver>();
            try
            {
                var driverData = _mapper.Map<Data.Entities.Driver>(driver);
                await _dataService.CreateAsync(driverData);
                validationResult.Entity = driver;
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

        public async Task<ValidationResult<DriverCar>> CreateDriverCar(int driverId, int drivingSchoolCarId)
        {
            ValidationResult<DriverCar> validationResult = new ValidationResult<DriverCar>();
            var driverCar = new DriverCar()
            {
                DriverId = driverId,
                DrivingSchoolCarId = drivingSchoolCarId
            };

            try
            {
                var driverCarData = _mapper.Map<Data.Entities.DriverCar>(driverCar);
                await _dataService.CreateAsync(driverCarData);
                validationResult.Entity = driverCar;
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

        public async Task<ValidationResult<Driver>> UpdateDriver(Driver driver)
        {
            ValidationResult<Driver> validationResult = new ValidationResult<Driver>();
            try
            {
                var driverData = _mapper.Map<Data.Entities.Driver>(driver);
                await _dataService.UpdateAsync(driverData);
                validationResult.Entity = driver;
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

        public async Task<Driver> RetrieveDriver(int driverId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.Driver>(a => a.DriverId == driverId);
            var driver = _mapper.MapToList<Driver>(result);
            return driver.FirstOrDefault();
        }

        public async Task<PagedResult<Driver>> RetrieveDrivers(bool isSuperAdmin, int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var drivers = await _dataService.RetrievePagedResultAsync<Data.Entities.Driver>(a => isSuperAdmin || a.DrivingSchoolId == drivingSchoolId, orderBy, paging);
            return _mapper.MapToPagedResult<Driver>(drivers);
        }

        public async Task<PagedResult<DriverGrid>> Search(bool isSuperAdmin, int drivingSchoolId, string term, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var predicate = PredicateBuilder.New<Data.Entities.DriverGrid>(a => isSuperAdmin || a.DrivingSchoolId == drivingSchoolId);
            if (!string.IsNullOrEmpty(term))
                predicate = predicate.And(a => (isSuperAdmin || a.DrivingSchoolId == drivingSchoolId) && a.SearchField.ToLower().Contains(term.ToLower()));
            var drivers = await _dataService.RetrievePagedResultAsync<Data.Entities.DriverGrid>(predicate, orderBy, paging);
            return _mapper.MapToPagedResult<Models.DriverGrid>(drivers);
        }

        public async Task<IEnumerable<DrivingSchoolCar>> RetrieveUnassignedDriverCars(int driverlId)
        {
            var data = await _dataService.RetrievePagedResultAsync<Data.Entities.DrivingSchoolCar>(e => !e.DriverCars.Any(a => a.DriverId == driverlId));
            var result = data.Items.ToList();
            return _mapper.MapToList<DrivingSchoolCar>(result);
        }

        public async Task<PagedResult<DriverCar>> RetrieveDriverCars(int driverId, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var data = await _dataService.RetrievePagedResultAsync<Data.Entities.DriverCar>(e => e.DriverId == driverId, orderBy, paging, a => a.Driver, a => a.DrivingSchoolCar);
            return _mapper.MapToPagedResult<DriverCar>(data);
        }

        public async Task<bool> DeleteDriverCar(int driverlId, int drivingSchoolCarId)
        {
            try
            {
                await _dataService.DeleteWhereAsync<Data.Entities.DriverCar>(e => e.DriverId == driverlId && e.DrivingSchoolCarId == drivingSchoolCarId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
