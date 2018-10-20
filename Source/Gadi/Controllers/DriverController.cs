using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Configuration.Interface;
using Gadi.Business.Interfaces;
using Gadi.Business.Models;
using Gadi.Common.Dto;
using Gadi.Extensions;
using Gadi.Models;
using Microsoft.Owin.Security.Authorization;

namespace Gadi.Controllers
{
    [RoutePrefix("Driver")]
    public class DriverController : BaseController
    {
        private readonly IDriverBusinessService _driverBusinessService;
        public DriverController(IDriverBusinessService driverBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService) : base(configurationManager, authorizationService)
        {
            _driverBusinessService = driverBusinessService;
        }

        // GET: Driver
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Create")]
        public async Task<ActionResult> Create()
        {
            var viewModel = new DriverViewModel()
            {
                Driver = new Driver()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<ActionResult> Create(DriverViewModel driverViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _driverBusinessService.CreateDriver(driverViewModel.Driver);
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
            return View(driverViewModel);
        }

        [HttpGet]
        [Route("{driverId:int}/Edit")]
        public async Task<ActionResult> Edit(int driverId)
        {
            var driver = await _driverBusinessService.RetrieveDriver(driverId);
            if (driver == null)
            {
                return HttpNotFound();
            }
            var viewModel = new DriverViewModel()
            {
                Driver = driver
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{driverId:int}/Edit")]
        public async Task<ActionResult> Edit(int driverId, DriverViewModel driverViewModel)
        {
            if (ModelState.IsValid)
            {
                driverViewModel.Driver.DriverId = driverId;
                var result = await _driverBusinessService.UpdateDriver(driverViewModel.Driver);
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
            return View(driverViewModel);
        }

        [HttpPost]
        [Route("List")]
        public async Task<ActionResult> List(Paging paging, List<OrderBy> orderBy)
        {
            try
            {
                var data = await _driverBusinessService.RetrieveDrivers(orderBy, paging);
                return this.JsonNet(data);
            }
            catch (Exception ex)
            {
                return this.JsonNet("");
            }
        }

        [HttpPost]
        [Route("Search")]
        public async Task<ActionResult> Search(string searchKeyword, Paging paging, List<OrderBy> orderBy)
        {
            return this.JsonNet(await _driverBusinessService.Search(searchKeyword, orderBy, paging));
        }
    }
}