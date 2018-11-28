using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Configuration.Interface;
using Gadi.Business.Interfaces;
using Gadi.Business.Models;
using Gadi.Extensions;
using Gadi.Models;
using Microsoft.Owin.Security.Authorization;

namespace Gadi.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDrivingSchoolBusinessService _drivingSchoolBusinessService;
        private readonly IDrivingSchoolCarBusinessService _drivingSchoolCarBusinessService;

        public HomeController(IDrivingSchoolBusinessService drivingSchoolBusinessService, IDrivingSchoolCarBusinessService drivingSchoolCarBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService) : base(configurationManager, authorizationService)
        {
            _drivingSchoolBusinessService = drivingSchoolBusinessService;
            _drivingSchoolCarBusinessService = drivingSchoolCarBusinessService;
        }

        public async Task<ActionResult> Index()
        {
            var viewModel = new HomeViewModel { PersonnelId = UserPersonnelId };
            if (User.Identity.IsAuthenticated && viewModel.PersonnelId == 0)
                return RedirectToAction("Logout", "Account");
            if (User.Identity.IsAuthenticated && User.IsDrivingSchool())
            {
                var drivingSchool = await _drivingSchoolBusinessService.RetrieveDrivingSchoolByPersonnelId(viewModel.PersonnelId);
                if (drivingSchool == null)
                    return RedirectToAction("Login", "Account");
                //viewModel.IsDrivingSchoolApproved = drivingSchool.ApprovalStateId == (int)SellerApprovalState.Approved;
                return View();
            }
            if (User.Identity.IsAuthenticated && User.IsSuperUser())
                return View();
            return View();
        }

        public async Task<ActionResult> DrivingSchoolAvailability()
        {
            var drivingSchoolCar = await _drivingSchoolCarBusinessService.RetrieveDrivingSchoolCars(false, 0);
            var drivingSchoolCarList = drivingSchoolCar.Items.ToList();
            var viewModel = new HomeViewModel()
            {
                DrivingSchoolAvailabilityFilter = new DrivingSchoolAvailabilityFilter(),
                DrivingSchoolCars = new SelectList(drivingSchoolCarList, "DrivingSchoolCarId", "DrivingSchoolCarName")

            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpPost]
        [Route("Home/DrivingSchool/{searchKeyword}")]
        public ActionResult DrivingSchool(string searchKeyword)
        {
            var viewModel = new HomeViewModel()
            {
                SearchKeyword = searchKeyword
            };
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult PrivacyPolicy()
        {
            ViewBag.Message = "Your contact page.";

            return View(new BaseViewModel());
        }
    }
}