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
        Task<ValidationResult<DrivingSchoolCar>> CreateDrivingSchoolCar(DrivingSchoolCar drivingSchoolCar,DrivingSchoolCarFee drivingSchoolCarFee);

        //Update
        Task<ValidationResult<DrivingSchoolCar>> UpdateDrivingSchoolCar(DrivingSchoolCar drivingSchoolCar, DrivingSchoolCarFee drivingSchoolCarFee);
        //Retrieve
        Task<DrivingSchoolCar> RetrieveDrivingSchoolCar(int drivingSchoolCarId);
        Task<DrivingSchoolCarFee> RetrieveDrivingSchoolCarFee(int drivingSchoolCarId);
        Task<DrivingSchoolCar> RetrieveDrivingSchoolCarByDrivingSchoolIdCarId(int drivingSchoolId, int drivingSchoolCarId);
        Task<PagedResult<DrivingSchoolCarGrid>> RetrieveDrivingSchoolCars(bool isSuperAdmin,int drivingSchoolId,List<OrderBy> orderBy = null, Paging paging = null);
        Task<PagedResult<DrivingSchoolCarGrid>> Search(bool isSuperAdmin, int drivingSchoolId, string term, List<OrderBy> orderBy = null, Paging paging = null);
    }
}
