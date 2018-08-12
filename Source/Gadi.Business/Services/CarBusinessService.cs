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
using Gadi.Data.Interfaces;


namespace Gadi.Business.Services
{
    public partial class CarBusinessService : ICarBusinessService
    {
        protected ICarDataService _dataService;
        protected IMapper _mapper;

        public CarBusinessService(ICarDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ValidationResult<Models.Car>> CreateCar(Models.Car car)
        {
            ValidationResult<Models.Car> validationResult = new ValidationResult<Models.Car>();
            try
            {
                var carData = _mapper.Map<Data.Entities.Car>(car);
                await _dataService.CreateAsync(carData);
                validationResult.Entity = car;
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

        public async Task<Models.Car> RetrieveCar(int carId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.Car>(a => a.CarId == carId);
            var mobile = _mapper.MapToList<Car>(result);
            return mobile.FirstOrDefault();
        }

        public async Task<PagedResult<Car>> RetrieveCars(List<OrderBy> orderBy = null, Paging paging = null)
        {
            var cars = await _dataService.RetrievePagedResultAsync<Car>(a => true, orderBy, paging);
            return cars;
        }
    }
}
