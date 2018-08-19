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
        public DriverFeedbackController(IDriverFeedbackBusinessService driverFeedbackBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService) : base(configurationManager, authorizationService)
        {
            _driverFeedbackBusinessService = driverFeedbackBusinessService;
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
            var driverFeedback = await _driverFeedbackBusinessService.RetrieveDriverFeedback(driverFeedbackId);
            if (driverFeedback == null)
            {
                return HttpNotFound();
            }
            var viewModel = new DriverFeedbackViewModel()
            {
                DriverFeedback = driverFeedback
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
            try
            {
                var data = await _driverFeedbackBusinessService.RetrieveDriverFeedbacks(orderBy, paging);
                return this.JsonNet(data);
            }
            catch (Exception ex)
            {
                return this.JsonNet(""); ;
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