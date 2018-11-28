using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Configuration.Interface;
using Gadi.Business.Interfaces;
using Gadi.Business.Models;
using Gadi.Common.Dto;
using Gadi.Extensions;
using Gadi.Models;
using Gadi.Models.Authorization;
using Microsoft.Owin.Security.Authorization;
using DocumentCategory = Gadi.Business.Enum.DocumentCategory;
using Filter = Gadi.Business.Dto.Filter;

namespace Gadi.Controllers
{
    [RoutePrefix("DrivingSchool")]
    public class DrivingSchoolController : BaseController
    {
        private readonly IPersonnelBusinessService _personnelBusinessService;
        private readonly IDocumentsBusinessService _documentsBusinessService;
        private readonly IDrivingSchoolBusinessService _drivingSchoolBusinessService;
        const string UserNotExist = "User does not exist.";
        public DrivingSchoolController(IDrivingSchoolBusinessService drivingSchoolBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService, IPersonnelBusinessService personnelBusinessService, IDocumentsBusinessService documentsBusinessService) : base(configurationManager, authorizationService)
        {
            _drivingSchoolBusinessService = drivingSchoolBusinessService;
            _personnelBusinessService = personnelBusinessService;
            _documentsBusinessService = documentsBusinessService;
        }

        // GET: School
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Create")]
        public async Task<ActionResult> Create()
        {
            var viewModel = new DrivingSchoolViewModel()
            {
                DrivingSchool = new DrivingSchool()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<ActionResult> Create(DrivingSchoolViewModel drivingSchoolViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _drivingSchoolBusinessService.CreateDrivingSchool(drivingSchoolViewModel.DrivingSchool);
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

        [HttpGet]
        [Route("{drivingSchoolId:int}/Detail")]
        public async Task<ActionResult> Detail(int drivingSchoolId)
        {
            var drivingSchool = await _drivingSchoolBusinessService.RetrieveDrivingSchool(drivingSchoolId);
            var drivingSchools = await _drivingSchoolBusinessService.RetrieveDrivingSchools();
            var drivingSchoolGrid = drivingSchools.Items.FirstOrDefault(e => e.DrivingSchoolId == drivingSchoolId);
            var drivingSchoolCarGridData = await _drivingSchoolBusinessService.RetrieveDrivingSchoolCarGridsByDrivingSchoolId(drivingSchoolId);
            var drivingSchoolRatingAndReviewList = await _drivingSchoolBusinessService.RetrieveDrivingSchoolRatingAndReviewByDrivingSchoolId(drivingSchoolId);
            if (drivingSchool == null)
            {
                return HttpNotFound();
            }
            var viewModel = new DrivingSchoolViewModel()
            {
                DrivingSchool = drivingSchool,
                DrivingSchoolCarGrid = drivingSchoolCarGridData,
                DrivingSchoolRatingAndReviewList = drivingSchoolRatingAndReviewList,
                DrivingSchoolGrid = drivingSchoolGrid
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("{drivingSchoolId:int}/UploadPhoto")]
        public async Task<ActionResult> UploadPhoto(int drivingSchoolId)
        {
            //if (!await AuthorizationService.AuthorizeAsync((ClaimsPrincipal)User, personnelId, Policies.Resource.Personnel.ToString()))
            //    return HttpForbidden();

            try
            {
                var getPersonnelResult = await _drivingSchoolBusinessService.RetrieveDrivingSchool(drivingSchoolId);
                if (getPersonnelResult == null)
                    return HttpNotFound();

                var drivingSchool = getPersonnelResult;

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        //var personnelProfile = await _personnelDocumentBusinessService.RetrievePersonnelProfileImage(getPersonnelResult.Entity.PersonnelId);
                        //if (personnelProfile.Succeeded)
                        //    await _documentsBusinessService.DeleteDocument(new List<Guid> { personnelProfile.Entity.DocumentGuid.Value });

                        byte[] fileData = null;
                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(file.ContentLength);
                        }
                        var documentMeta = new Document()
                        {
                            Content = fileData,
                            Description = string.Format("{0} Profile Image", drivingSchool.Name),
                            FileName = file.FileName.Split('\\').Last() + ".png",
                            PersonnelName = drivingSchool.Name,
                            CreatedBy = User.Identity.Name,
                            PersonnelId = drivingSchool.DrivingSchoolId.ToString(),
                            Category = Business.Enum.DocumentCategory.DrivingSchoolProfile.ToString(),
                            CategoryId = (int)Business.Enum.DocumentCategory.DrivingSchoolProfile
                        };

                        var result = await _documentsBusinessService.CreateDocument(documentMeta);
                        if (!result.Succeeded)
                            return this.JsonNet("SaveError");
                    }
                }
                return this.JsonNet("");
            }
            catch (Exception ex)
            {
                return this.JsonNet(ex);
            }
        }

        [HttpPost]
        public ActionResult DeletePhoto(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //EgharpayBusinessService.DeletePhoto(UserOrganisationId, id.Value);
                return this.JsonNet("");
            }
            catch (Exception ex)
            {
                return this.JsonNet(ex);
            }

        }

        [Route("RetrieveProfileImage/{drivingSchoolId:int}")]
        public async Task<ActionResult> RetrieveProfileImage(int drivingSchoolId)
        {
            //if (!await AuthorizationService.AuthorizeAsync((ClaimsPrincipal)User, personnelId, Policies.Resource.Personnel.ToString()))
            //    return HttpForbidden();

            var personnels = await _documentsBusinessService.RetrieveDocuments(drivingSchoolId, DocumentCategory.DrivingSchoolProfile);
            if (personnels == null)
                return HttpNotFound(UserNotExist);

            var profileImage = personnels.Entity.FirstOrDefault();

            return this.JsonNet(profileImage);
        }

        [HttpPost]
        [Route("List")]
        public async Task<ActionResult> List(Filter filter, Paging paging, List<OrderBy> orderBy)
        {
            try
            {
                var data = await RetrieveDrivingSchools(filter, paging, orderBy);
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
            return this.JsonNet(await _drivingSchoolBusinessService.Search(searchKeyword, orderBy, paging));
        }

        private async Task<ActionResult> RetrieveDrivingSchools(Filter filter, Paging paging = null, List<OrderBy> orderBy = null)
        {
            if (filter != null && filter.IsFilter)
                return this.JsonNet(await _drivingSchoolBusinessService.RetrieveDrivingSchools(filter, orderBy, paging));
            return this.JsonNet(await _drivingSchoolBusinessService.RetrieveDrivingSchools(orderBy, paging));
        }

        [HttpPost]
        [Route("RetrieveDrivingSchoolAvailability")]
        public async Task<ActionResult> RetrieveDrivingSchoolAvailability(DrivingSchoolAvailabilityFilter drivingSchoolAvailabilityFilter, Paging paging, List<OrderBy> orderBy)
        {
            var data = await _drivingSchoolBusinessService.RetrieveDrivingSchoolAvailability(drivingSchoolAvailabilityFilter, orderBy, paging);
            return this.JsonNet(data);
        }

        //public async Task<ActionResult> AssignDrivingSchoolCar(int drivingSchoolId, int carId, decimal withLicenseFee, decimal withOutLicenseFee, decimal discountOnFee)
        //{
        //    var data = await _drivingSchoolBusinessService.CreateDrivingSchoolCar(drivingSchoolId, carId, withLicenseFee, withOutLicenseFee, discountOnFee);
        //    return this.JsonNet(data);
        //}

        //public async Task<ActionResult> UnassignedDrivingSchoolCars(int drivingSchoolId)
        //{
        //    var data = await _drivingSchoolBusinessService.RetrieveUnassignedDrivingSchoolCars(drivingSchoolId);
        //    return this.JsonNet(data);
        //}

        //public async Task<ActionResult> DrivingSchoolCars(int drivingSchoolId)
        //{
        //    var data = await _drivingSchoolBusinessService.RetrieveDrivingSchoolCars(drivingSchoolId);
        //    return this.JsonNet(data);
        //}

        //[HttpPost]
        //public async Task<ActionResult> UnassignDrivingSchoolCar(int drivingSchoolId, int carId)
        //{
        //    var data = await _drivingSchoolBusinessService.DeleteDrivingSchoolCar(drivingSchoolId, carId);
        //    return this.JsonNet("");
        //}
    }
}