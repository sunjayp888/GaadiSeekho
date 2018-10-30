using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Configuration.Interface;
using Gadi.Business.Interfaces;
using Gadi.Common.Dto;
using Gadi.Extensions;
using Gadi.Models;
using Microsoft.Owin.Security.Authorization;

namespace Gadi.Controllers
{
    [RoutePrefix("DriverFeedback")]
    public class DriverFeedbackController : BaseController
    {
        private readonly IDriverFeedbackBusinessService _driverFeedbackBusinessService;
        private readonly IDriverBusinessService _driverBusinessService;
        public DriverFeedbackController(IDriverFeedbackBusinessService driverFeedbackBusinessService,IDriverBusinessService driverBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService) : base(configurationManager, authorizationService)
        {
            _driverFeedbackBusinessService = driverFeedbackBusinessService;
            _driverBusinessService = driverBusinessService;
        }

        // GET: DriverFeedback
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("{driverFeedbackId:int}/Edit")]
        public async Task<ActionResult> Edit(int driverFeedbackId)
        {
            var isSuperAdmin = User.IsSuperAdmin();
            var drivingSchoolId = UserDrivingSchoolId;
            var driverFeedback = await _driverFeedbackBusinessService.RetrieveDriverFeedback(driverFeedbackId);
            if (driverFeedback == null)
            {
                return HttpNotFound();
            }
            var driverData = await _driverBusinessService.RetrieveDrivers(isSuperAdmin, drivingSchoolId);
            var drivers = driverData.Items.ToList();
            var viewModel = new DriverFeedbackViewModel()
            {
                DriverFeedback = driverFeedback,
                Drivers = new SelectList(drivers, "DriverId", "Name")
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{driverFeedbackId:int}/Edit")]
        public async Task<ActionResult> Edit(int driverFeedbackId, DriverFeedbackViewModel driverFeedbackViewModel)
        {
            if (ModelState.IsValid)
            {
                driverFeedbackViewModel.DriverFeedback.DriverFeedBackId = driverFeedbackId;
                var result = await _driverFeedbackBusinessService.UpdateDriverFeedback(driverFeedbackViewModel.DriverFeedback);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Exception);
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return View(driverFeedbackViewModel);
        }

        [HttpPost]
        [Route("List")]
        public async Task<ActionResult> List(Paging paging, List<OrderBy> orderBy)
        {
            var isSuperAdmin = User.IsSuperAdmin();
            var drivingSchoolId = UserDrivingSchoolId;
            try
            {
                var data = await _driverFeedbackBusinessService.RetrieveDriverFeedbacks(isSuperAdmin, drivingSchoolId, orderBy, paging);
                return this.JsonNet(data);
            }
            catch (Exception ex)
            {
                return this.JsonNet("");
            }
        }

        //[HttpPost]
        //[Route("Search")]
        //public async Task<ActionResult> Search(string searchKeyword, Paging paging, List<OrderBy> orderBy)
        //{
        //    return this.JsonNet(await _driverFeedbackBusinessService.Search(searchKeyword, orderBy, paging));
        //}
    }
}