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
using DriverFeedback = Gadi.Business.Models.DriverFeedback;
using DriverFeedbackGrid = Gadi.Business.Models.DriverFeedbackGrid;

namespace Gadi.Business.Services
{
    public partial class DriverFeedbackBusinessService : IDriverFeedbackBusinessService
    {
        protected IDriverFeedbackDataService _dataService;
        protected IMapper _mapper;

        public DriverFeedbackBusinessService(IDriverFeedbackDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ValidationResult<DriverFeedback>> CreateDriverFeedback(DriverFeedback driverFeedback)
        {
            ValidationResult<DriverFeedback> validationResult = new ValidationResult<DriverFeedback>();
            try
            {
                var driverFeedbackData = _mapper.Map<Data.Entities.DriverFeedback>(driverFeedback);
                await _dataService.CreateAsync(driverFeedbackData);
                validationResult.Entity = driverFeedback;
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

        public async Task<ValidationResult<DriverFeedback>> UpdateDriverFeedback(DriverFeedback driverFeedback)
        {
            ValidationResult<DriverFeedback> validationResult = new ValidationResult<DriverFeedback>();
            try
            {
                var driverFeedbackData = _mapper.Map<Data.Entities.DriverFeedback>(driverFeedback);
                await _dataService.UpdateAsync(driverFeedbackData);
                validationResult.Entity = driverFeedback;
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

        public async Task<DriverFeedback> RetrieveDriverFeedback(int driverFeedbackId)
        {
            var result = await _dataService.RetrieveAsync<Data.Entities.DriverFeedback>(a => a.DriverFeedBackId == driverFeedbackId);
            var driverFeedback = _mapper.MapToList<DriverFeedback>(result);
            return driverFeedback.FirstOrDefault();
        }

        public async Task<PagedResult<DriverFeedbackGrid>> RetrieveDriverFeedbacks(bool isSuperAdmin, int drivingSchoolId, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var driverFeedbacks = await _dataService.RetrievePagedResultAsync<Data.Entities.DriverFeedbackGrid>(a => isSuperAdmin || a.DrivingSchoolId == drivingSchoolId, orderBy, paging);
            return _mapper.MapToPagedResult<DriverFeedbackGrid>(driverFeedbacks);
        }

        //public async Task<PagedResult<DriverFeedbackGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null)
        //{
        //    if (string.IsNullOrEmpty(term))
        //        return await _dataService.RetrievePagedResultAsync<DriverFeedbackGrid>(a => true, orderBy, paging);
        //    return await _dataService.RetrievePagedResultAsync<DriverFeedbackGrid>(a => a.SearchField.ToLower().Contains(term.ToLower()), orderBy, paging);
        //}
    }
}
