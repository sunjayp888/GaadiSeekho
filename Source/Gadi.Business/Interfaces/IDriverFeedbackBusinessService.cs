using System.Collections.Generic;
using System.Threading.Tasks;
using Gadi.Common.Dto;
using Gadi.Business.Models;
using Gadi.Data.Entities;

namespace Gadi.Business.Interfaces
{
    public interface IDriverFeedbackBusinessService
    {
        //Create
        Task<ValidationResult<DriverFeedback>> CreateDriverFeedback(DriverFeedback driverFeedback);

        //Retrieve
        Task<DriverFeedback> RetrieveDriverFeedback(int driverFeedbackId);
        Task<PagedResult<DriverFeedback>> RetrieveDriverFeedbacks(List<OrderBy> orderBy = null, Paging paging = null);
        //Task<PagedResult<DriverGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null);
    }
}
