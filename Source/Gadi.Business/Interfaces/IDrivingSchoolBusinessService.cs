using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gadi.Common.Dto;
using Gadi.Business.Models;

namespace Gadi.Business.Interfaces
{
    public interface IDrivingSchoolBusinessService
    {
        //Create
        Task<ValidationResult<DrivingSchool>> CreateDrivingSchool(DrivingSchool drivingSchool);
        Task<ValidationResult<DrivingSchoolCar>> CreateDrivingSchoolCar(int drivingSchoolId, int carId, decimal withLicenseFee, decimal withOutLicenseFee, decimal discountOnFee);

        //Update
        Task<ValidationResult<DrivingSchool>> UpdateDrivingSchool(DrivingSchool drivingSchool);

        //Retrieve
        Task<DrivingSchool> RetrieveDrivingSchool(int drivingSchoolId);
        Task<DrivingSchool> RetrieveDrivingSchoolByPersonnelId(int personnelId);
        Task<PagedResult<DrivingSchoolGrid>> RetrieveDrivingSchools(List<OrderBy> orderBy = null, Paging paging = null);
        Task<List<DrivingSchoolCarGrid>> RetrieveDrivingSchoolCarGridsByDrivingSchoolId(int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null);
        Task<List<DrivingSchoolRatingAndReview>> RetrieveDrivingSchoolRatingAndReviewByDrivingSchoolId(int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null);
        Task<PagedResult<DrivingSchoolGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null);
        Task<IEnumerable<Car>> RetrieveUnassignedDrivingSchoolCars(int drivingSchoolId);
        Task<PagedResult<DrivingSchoolCar>> RetrieveDrivingSchoolCars(int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null);

        //Delete
        Task<bool> DeleteDrivingSchoolCar(int drivingSchoolId, int carId);
    }
}
