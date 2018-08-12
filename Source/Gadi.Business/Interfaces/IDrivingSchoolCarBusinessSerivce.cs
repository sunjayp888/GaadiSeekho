using System.Collections.Generic;
using System.Threading.Tasks;
using Gadi.Common.Dto;
using Gadi.Business.Models;
using Gadi.Data.Entities;

namespace Gadi.Business.Interfaces
{
    public interface IDrivingSchoolCarBusinessService
    {
        //Create
        Task<ValidationResult<DrivingSchoolCar>> CreateDrivingSchoolCar(DrivingSchoolCar drivingSchoolCar);

        //Retrieve
        Task<DrivingSchoolCar> RetrieveDrivingSchoolCar(int drivingSchoolCarId);
        Task<PagedResult<DrivingSchoolCar>> RetrieveDrivingSchoolCars(List<OrderBy> orderBy = null, Paging paging = null);
        //Task<PagedResult<DrivingSchoolCarGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null);
    }
}
