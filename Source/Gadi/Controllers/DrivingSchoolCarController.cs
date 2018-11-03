using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using DocumentCategory = Gadi.Business.Enum.DocumentCategory;

namespace Gadi.Controllers
{
    [RoutePrefix("DrivingSchoolCar")]
    public class DrivingSchoolCarController : BaseController
    {
        private readonly IDrivingSchoolCarBusinessService _drivingSchoolCarBusinessService;
        private readonly IDocumentsBusinessService _documentsBusinessService;
        const string UserNotExist = "User does not exist.";
        public DrivingSchoolCarController(IDrivingSchoolCarBusinessService drivingSchoolCarBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService, IDocumentsBusinessService documentsBusinessService) : base(configurationManager, authorizationService)
        {
            _drivingSchoolCarBusinessService = drivingSchoolCarBusinessService;
            _documentsBusinessService = documentsBusinessService;
        }

        // GET: DrivingSchool
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Create")]
        public async Task<ActionResult> Create()
        {
            var viewModel = new DrivingSchoolCarViewModel()
            {
                DrivingSchoolCar = new DrivingSchoolCar(),
                DrivingSchoolCarFee = new DrivingSchoolCarFee()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<ActionResult> Create(DrivingSchoolCarViewModel drivingSchoolCarViewModel)
        {
            if (ModelState.IsValid)
            {
                drivingSchoolCarViewModel.DrivingSchoolCar.DrivingSchoolId = UserDrivingSchoolId;
                var result = await _drivingSchoolCarBusinessService.CreateDrivingSchoolCar(drivingSchoolCarViewModel.DrivingSchoolCar, drivingSchoolCarViewModel.DrivingSchoolCarFee);
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
            return View(drivingSchoolCarViewModel);
        }

        [HttpGet]
        [Route("{drivingSchoolCarId:int}/Edit")]
        public async Task<ActionResult> Edit(int drivingSchoolCarId)
        {
            var drivingSchoolCar = await _drivingSchoolCarBusinessService.RetrieveDrivingSchoolCar(drivingSchoolCarId);
            if (drivingSchoolCar == null)
            {
                return HttpNotFound();
            }
            var drivingSchoolCarFee = await _drivingSchoolCarBusinessService.RetrieveDrivingSchoolCarFee(drivingSchoolCarId);
            var viewModel = new DrivingSchoolCarViewModel()
            {
                DrivingSchoolCar = drivingSchoolCar,
                DrivingSchoolCarFee = drivingSchoolCarFee
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{drivingSchoolCarId:int}/Edit")]
        public async Task<ActionResult> Edit(int drivingSchoolCarId, DrivingSchoolCarViewModel drivingSchoolCarViewModel)
        {
            if (ModelState.IsValid)
            {
                drivingSchoolCarViewModel.DrivingSchoolCar.DrivingSchoolCarId = drivingSchoolCarId;
                var result = await _drivingSchoolCarBusinessService.UpdateDrivingSchoolCar(drivingSchoolCarViewModel.DrivingSchoolCar, drivingSchoolCarViewModel.DrivingSchoolCarFee);
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
            return View(drivingSchoolCarViewModel);
        }

        [HttpPost]
        [Route("{drivingSchoolCarId:int}/UploadPhoto")]
        public async Task<ActionResult> UploadPhoto(int drivingSchoolCarId)
        {
            //if (!await AuthorizationService.AuthorizeAsync((ClaimsPrincipal)User, personnelId, Policies.Resource.Personnel.ToString()))
            //    return HttpForbidden();

            try
            {
                var getPersonnelResult = await _drivingSchoolCarBusinessService.RetrieveDrivingSchoolCar(drivingSchoolCarId);
                if (getPersonnelResult == null)
                    return HttpNotFound();

                var drivingSchoolCar = getPersonnelResult;

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
                            Description = string.Format("{0} Profile Image", drivingSchoolCar.Name),
                            FileName = file.FileName.Split('\\').Last() + ".png",
                            PersonnelName = drivingSchoolCar.Name,
                            CreatedBy = User.Identity.Name,
                            PersonnelId = drivingSchoolCar.DrivingSchoolCarId.ToString(),
                            Category = Business.Enum.DocumentCategory.CarProfile.ToString(),
                            CategoryId = (int)Business.Enum.DocumentCategory.CarProfile
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

        [Route("RetrieveProfileImage/{drivingSchoolCarId:int}")]
        public async Task<ActionResult> RetrieveProfileImage(int drivingSchoolCarId)
        {
            //if (!await AuthorizationService.AuthorizeAsync((ClaimsPrincipal)User, personnelId, Policies.Resource.Personnel.ToString()))
            //    return HttpForbidden();

            var personnels = await _documentsBusinessService.RetrieveDocuments(drivingSchoolCarId, DocumentCategory.CarProfile);
            if (personnels == null)
                return HttpNotFound(UserNotExist);

            var profileImage = personnels.Entity.FirstOrDefault();

            return this.JsonNet(profileImage);
        }

        [HttpPost]
        [Route("List")]
        public async Task<ActionResult> List(Paging paging, List<OrderBy> orderBy)
        {
            var isSuperAdmin = User.IsSuperAdmin();
            var drivingSchoolId = UserDrivingSchoolId;
            try
            {
                var data = await _drivingSchoolCarBusinessService.RetrieveDrivingSchoolCars(isSuperAdmin, drivingSchoolId, orderBy, paging);
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
            var isSuperAdmin = User.IsSuperAdmin();
            var drivingSchoolId = UserDrivingSchoolId;
            return this.JsonNet(await _drivingSchoolCarBusinessService.Search(isSuperAdmin, drivingSchoolId, searchKeyword, orderBy, paging));
        }
    }
}