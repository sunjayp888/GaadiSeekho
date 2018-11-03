using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
    [RoutePrefix("Student")]
    public class StudentController : BaseController
    {
        private readonly IStudentBusinessService _studentBusinessService;
        private readonly IDocumentsBusinessService _documentsBusinessService;
        const string UserNotExist = "User does not exist.";
        public StudentController(IStudentBusinessService studentBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService, IDocumentsBusinessService documentsBusinessService) : base(configurationManager, authorizationService)
        {
            _studentBusinessService = studentBusinessService;
            _documentsBusinessService = documentsBusinessService;
        }

        // GET: Student
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Create")]
        public async Task<ActionResult> Create()
        {
            var viewModel = new StudentViewModel()
            {
                Student = new Student()
            };
            viewModel.TitleList = new SelectList(viewModel.TitleType, "Value", "Name");
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<ActionResult> Create(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                studentViewModel.Student.DrivingSchoolId = UserDrivingSchoolId;
                var result = await _studentBusinessService.CreateStudent(studentViewModel.Student);
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
            return View(studentViewModel);
        }

        [HttpGet]
        [Route("{studentId:int}/Edit")]
        public async Task<ActionResult> Edit(int studentId)
        {
            var student = await _studentBusinessService.RetrieveStudent(studentId);
            if (student == null)
            {
                return HttpNotFound();
            }
            var viewModel = new StudentViewModel()
            {
                Student = student
            };
            viewModel.TitleList = new SelectList(viewModel.TitleType, "Value", "Name");
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{studentId:int}/Edit")]
        public async Task<ActionResult> Edit(int studentId, StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                studentViewModel.Student.StudentId = studentId;
                var result = await _studentBusinessService.UpdateStudent(studentViewModel.Student);
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
            return View(studentViewModel);
        }

        [HttpPost]
        [Route("{studentId:int}/UploadPhoto")]
        public async Task<ActionResult> UploadPhoto(int studentId)
        {
            //if (!await AuthorizationService.AuthorizeAsync((ClaimsPrincipal)User, personnelId, Policies.Resource.Personnel.ToString()))
            //    return HttpForbidden();

            try
            {
                var getPersonnelResult = await _studentBusinessService.RetrieveStudent(studentId);
                if (getPersonnelResult == null)
                    return HttpNotFound();

                var student = getPersonnelResult;

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
                            Description = string.Format("{0} Profile Image", student.FullName),
                            FileName = file.FileName.Split('\\').Last() + ".png",
                            PersonnelName = student.FullName,
                            CreatedBy = User.Identity.Name,
                            PersonnelId = student.StudentId.ToString(),
                            Category = Business.Enum.DocumentCategory.DrivingStudentProfile.ToString(),
                            CategoryId = (int)Business.Enum.DocumentCategory.DrivingStudentProfile
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

        [Route("RetrieveProfileImage/{studentId:int}")]
        public async Task<ActionResult> RetrieveProfileImage(int studentId)
        {
            //if (!await AuthorizationService.AuthorizeAsync((ClaimsPrincipal)User, personnelId, Policies.Resource.Personnel.ToString()))
            //    return HttpForbidden();

            var personnels = await _documentsBusinessService.RetrieveDocuments(studentId, DocumentCategory.DrivingStudentProfile);
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
                var data = await _studentBusinessService.RetrieveStudents(isSuperAdmin, drivingSchoolId, orderBy, paging);
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
            return this.JsonNet(await _studentBusinessService.Search(isSuperAdmin, drivingSchoolId, searchKeyword, orderBy, paging));
        }
    }
}