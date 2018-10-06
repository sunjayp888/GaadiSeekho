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
using Car = Gadi.Business.Models.Car;


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

        public async Task<ValidationResult<Car>> CreateCar(Car car)
        {
            ValidationResult<Car> validationResult = new ValidationResult<Car>();
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

        public async Task<ValidationResult<Car>> UpdateCar(Car car)
        {
            ValidationResult<Car> validationResult = new ValidationResult<Car>();
            try
            {
                var carData = _mapper.Map<Data.Entities.Car>(car);
                await _dataService.UpdateAsync(carData);
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

        public async Task<Car> RetrieveCar(int carId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.Car>(a => a.CarId == carId);
            var mobile = _mapper.MapToList<Car>(result);
            return mobile.FirstOrDefault();
        }

        public async Task<PagedResult<Car>> RetrieveCars(List<OrderBy> orderBy = null, Paging paging = null)
        {
            var cars = await _dataService.RetrievePagedResultAsync<Data.Entities.Car>(a => true, orderBy, paging);
            return _mapper.MapToPagedResult<Car>(cars);
        }

        public async Task<PagedResult<Models.CarGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var predicate = PredicateBuilder.New<Data.Entities.CarGrid>(true);
            if (!string.IsNullOrEmpty(term))
                predicate = predicate.And(a => a.SearchField.ToLower().Contains(term.ToLower()));
            var cars = await _dataService.RetrievePagedResultAsync<Data.Entities.CarGrid>(predicate, orderBy, paging);
            return _mapper.MapToPagedResult<Models.CarGrid>(cars);
        }
    }
}
