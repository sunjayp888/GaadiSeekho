using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gadi.Business.Interfaces;
using Gadi.Business.Models;
using Gadi.Common.Dto;
using Gadi.Data.Interfaces;


namespace Gadi.Business.Services
{
    public partial class DrivingSchoolBusinessService : IDrivingSchoolBusinessService
    {
        private readonly IMapper _mapper;
        private readonly IDrivingSchoolCarDataService _drivingSchoolCarDataService;

        public DrivingSchoolBusinessService(IMapper mapper, IDrivingSchoolCarDataService drivingSchoolCarDataService)
        {
            _mapper = mapper;
            _drivingSchoolCarDataService = drivingSchoolCarDataService;
        }

        public Task<ValidationResult<DrivingSchool>> CreateDrivingSchool(DrivingSchool drivingSchool)
        {
            throw new NotImplementedException();
        }

        public Task<DrivingSchool> RetrieveDrivingSchool(int drivingSchoolId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<DrivingSchool>> RetrieveDrivingSchools(List<OrderBy> orderBy = null, Paging paging = null)
        {
            var data = await _drivingSchoolCarDataService.RetrievePagedResultAsync<Data.Entities.DrivingSchool>(e => true, orderBy, paging);
            return _mapper.MapToPagedResult<DrivingSchool>(data);
        }
    }
}
