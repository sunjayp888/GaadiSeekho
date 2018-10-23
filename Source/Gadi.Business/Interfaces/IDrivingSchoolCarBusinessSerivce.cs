using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gadi.Common.Dto;
using Gadi.Business.Models;

namespace Gadi.Business.Interfaces
{
    public interface IDrivingSchoolCarBusinessService
    {
        //Create
        Task<ValidationResult<DrivingSchoolCar>> CreateDrivingSchoolCar(DrivingSchoolCar drivingSchoolCar);

        //Update
        Task<ValidationResult<DrivingSchoolCar>> UpdateDrivingSchoolCar(DrivingSchoolCar drivingSchoolCar);
        //Retrieve
        Task<DrivingSchoolCar> RetrieveDrivingSchoolCar(int drivingSchoolCarId);
        Task<DrivingSchoolCar> RetrieveDrivingSchoolCarByDrivingSchoolIdCarId(int drivingSchoolId, int carId);
        Task<PagedResult<DrivingSchoolCar>> RetrieveDrivingSchoolCars(List<OrderBy> orderBy = null, Paging paging = null);
        //Task<PagedResult<DrivingSchoolCarGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null);
    }
}
