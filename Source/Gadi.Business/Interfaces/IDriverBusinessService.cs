using System.Collections.Generic;
using System.Threading.Tasks;
using Gadi.Common.Dto;
using Gadi.Business.Models;

namespace Gadi.Business.Interfaces
{
    public interface IDriverBusinessService
    {
        //Create
        Task<ValidationResult<Driver>> CreateDriver(Driver driver);
        Task<ValidationResult<DriverCar>> CreateDriverCar(int driverId, int drivingSchoolCarId);

        //Update
        Task<ValidationResult<Driver>> UpdateDriver(Driver driver);

        //Retrieve
        Task<Driver> RetrieveDriver(int driverId);
        Task<PagedResult<Driver>> RetrieveDrivers(bool isSuperAdmin, int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null);
        Task<PagedResult<DriverGrid>> Search(bool isSuperAdmin, int drivingSchoolId, string term, List<OrderBy> orderBy = null, Paging paging = null);
        Task<IEnumerable<DrivingSchoolCar>> RetrieveUnassignedDriverCars(int driverlId);
        Task<PagedResult<DriverCar>> RetrieveDriverCars(int driverId, List<OrderBy> orderBy = null, Paging paging = null);

        //Delete
        Task<bool> DeleteDriverCar(int driverlId, int drivingSchoolCarId);
    }
}
