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
using Driver = Gadi.Business.Models.Driver;

namespace Gadi.Business.Services
{
    public partial class DriverBusinessService:IDriverBusinessService
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
                var driverData = _mapper.Map<Driver>(driver);
                await _dataService.CreateAsync(driverData);
                validationResult.Entity = driverData;
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
                await _dataService.UpdateAsync(driver);
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
            var result = await _dataService.RetrieveAsync<Driver>(a => a.DriverId == driverId);
            var driver = _mapper.MapToList<Driver>(result);
            return driver.FirstOrDefault();
        }

        public async Task<PagedResult<Driver>> RetrieveDrivers(List<OrderBy> orderBy = null, Paging paging = null)
        {
            var drivers = await _dataService.RetrievePagedResultAsync<Driver>(a => true, orderBy, paging);
            return drivers;
        }

        //public async Task<PagedResult<DriverGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null)
        //{
        //    if (string.IsNullOrEmpty(term))
        //        return await _dataService.RetrievePagedResultAsync<DriverGrid>(a => true, orderBy, paging);
        //    return await _dataService.RetrievePagedResultAsync<DriverGrid>(a => a.SearchField.ToLower().Contains(term.ToLower()), orderBy, paging);
        //}
    }
}
