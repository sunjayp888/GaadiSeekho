using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Configuration.Interface;
using Gadi.Business.Interfaces;
using Gadi.Extensions;
using Gadi.Models;
using Microsoft.Owin.Security.Authorization;

namespace Gadi.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDrivingSchoolBusinessService _drivingSchoolBusinessService;

        public HomeController(IDrivingSchoolBusinessService drivingSchoolBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService) : base(configurationManager, authorizationService)
        {
            _drivingSchoolBusinessService = drivingSchoolBusinessService;
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
            return RedirectToAction("Test", "Home");
        }

        public ActionResult Test()
        {
            return View();
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

        [AllowAnonymous]
        public ActionResult PrivacyPolicy()
        {
            ViewBag.Message = "Your contact page.";

            return View(new BaseViewModel());
        }
    }
}