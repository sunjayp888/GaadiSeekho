using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Configuration.Interface;
using Gadi.Business.Interfaces;
using Gadi.Common.Dto;
using Gadi.Extensions;
using Microsoft.Owin.Security.Authorization;

namespace Gadi.Controllers
{
    public class DrivingSchoolController : BaseController
    {
        private readonly IDrivingSchoolBusinessService _drivingSchoolBusinessService;
        public DrivingSchoolController(IDrivingSchoolBusinessService drivingSchoolBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService) : base(configurationManager, authorizationService)
        {
            _drivingSchoolBusinessService = drivingSchoolBusinessService;
        }
        // GET: School
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> List(Paging paging, List<OrderBy> orderBy)
        {
            var data = await _drivingSchoolBusinessService.RetrieveDrivingSchools(orderBy, paging);
            return this.JsonNet(data);
        }
    }
}