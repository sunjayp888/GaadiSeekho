using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Configuration.Interface;
using Gadi.Business.Interfaces;
using Gadi.Common.Dto;
using Gadi.Extensions;
using Gadi.Models;
using Microsoft.Owin.Security.Authorization;

namespace Gadi.Controllers
{
    [RoutePrefix("DrivingSchool")]
    public class DrivingSchoolController : BaseController
    {
        private readonly IDrivingSchoolBusinessService _drivingSchoolBusinessService;
        public DrivingSchoolController(IDrivingSchoolBusinessService drivingSchoolBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService) : base(configurationManager, authorizationService)
        {
            _drivingSchoolBusinessService = drivingSchoolBusinessService;
        }
        
        // GET: School
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("{drivingSchoolId:int}/Edit")]
        public async Task<ActionResult> Edit(int drivingSchoolId)
        {
            var drivingSchool = await _drivingSchoolBusinessService.RetrieveDrivingSchool(drivingSchoolId);
            if (drivingSchool == null)
            {
                return HttpNotFound();
            }
            var viewModel = new DrivingSchoolViewModel()
            {
                DrivingSchool = drivingSchool
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{drivingSchoolId:int}/Edit")]
        public async Task<ActionResult> Edit(int drivingSchoolId, DrivingSchoolViewModel drivingSchoolViewModel)
        {
            if (ModelState.IsValid)
            {
                drivingSchoolViewModel.DrivingSchool.DrivingSchoolId = drivingSchoolId;
                var result = await _drivingSchoolBusinessService.UpdateDrivingSchool(drivingSchoolViewModel.DrivingSchool);
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
            return View(drivingSchoolViewModel);
        }

        [HttpPost]
        [Route("List")]
        public async Task<ActionResult> List(Paging paging, List<OrderBy> orderBy)
        {
            try
            {
                var data = await _drivingSchoolBusinessService.RetrieveDrivingSchools(orderBy, paging);
                return this.JsonNet(data);
            }
            catch (Exception ex)
            {
                return this.JsonNet(""); ;
            }
        }

        [HttpPost]
        [Route("Search")]
        public async Task<ActionResult> Search(string searchKeyword, Paging paging, List<OrderBy> orderBy)
        {
            return this.JsonNet(await _drivingSchoolBusinessService.Search(searchKeyword, orderBy, paging));
        }
    }
}