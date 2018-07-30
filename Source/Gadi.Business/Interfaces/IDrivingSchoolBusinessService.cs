using System.Collections.Generic;
using System.Threading.Tasks;
using Gadi.Common.Dto;
using Gadi.Business.Models;
using Gadi.Data.Entity;

namespace Gadi.Business.Interfaces
{
    public interface IDrivingSchoolBusinessService
    {
        //Create
        Task<ValidationResult<DrivingSchool>> CreateDrivingSchool(DrivingSchool drivingSchool);

        //Retrieve
        Task<DrivingSchool> RetrieveDrivingSchool(int drivingSchoolId);
        Task<PagedResult<DrivingSchool>> RetrieveDrivingSchools(List<OrderBy> orderBy = null, Paging paging = null);
        //Task<PagedResult<DrivingSchoolGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null);
    }
}
