using System.Collections.Generic;
using System.Threading.Tasks;
using Gadi.Common.Dto;
using Gadi.Business.Models;

namespace Gadi.Business.Interfaces
{
    public interface ICarBusinessService
    {
        //Create
        Task<ValidationResult<Car>> CreateCar(Car car);

        //Update
        Task<ValidationResult<Car>> UpdateCar(Car car);

        //Retrieve
        Task<Car> RetrieveCar(int carId);
        Task<PagedResult<Car>> RetrieveCars(List<OrderBy> orderBy = null, Paging paging = null);
        //Task<PagedResult<CarGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null);
    }
}
