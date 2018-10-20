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
        private readonly IPersonnelBusinessService _personnelBusinessService;
        private readonly IDocumentsBusinessService _documentsBusinessService;
        const string UserNotExist = "User does not exist.";
        public StudentController(IStudentBusinessService studentBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService, IPersonnelBusinessService personnelBusinessService, IDocumentsBusinessService documentsBusinessService) : base(configurationManager, authorizationService)
        {
            _studentBusinessService = studentBusinessService;
            _personnelBusinessService = personnelBusinessService;
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
        [Route("{personnelId:int}/UploadPhoto")]
        public async Task<ActionResult> UploadPhoto(int personnelId)
        {
            //if (!await AuthorizationService.AuthorizeAsync((ClaimsPrincipal)User, personnelId, Policies.Resource.Personnel.ToString()))
            //    return HttpForbidden();

            try
            {
                var getPersonnelResult = await _personnelBusinessService.RetrievePersonnel(personnelId);
                if (!getPersonnelResult.Succeeded)
                    return HttpNotFound(string.Join(";", getPersonnelResult.Errors));

                var person = getPersonnelResult.Entity;

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
                            Description = string.Format("{0} Profile Image", person.FullName),
                            FileName = file.FileName.Split('\\').Last() + ".png",
                            PersonnelName = person.FullName,
                            CreatedBy = User.Identity.Name,
                            PersonnelId = person.PersonnelId.ToString(),
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

        [Route("RetrieveProfileImage/{personnelId:int}")]
        public async Task<ActionResult> RetrieveProfileImage(int personnelId)
        {
            //if (!await AuthorizationService.AuthorizeAsync((ClaimsPrincipal)User, personnelId, Policies.Resource.Personnel.ToString()))
            //    return HttpForbidden();

            var personnels = await _documentsBusinessService.RetrieveDocuments(personnelId, DocumentCategory.DrivingStudentProfile);
            if (personnels == null)
                return HttpNotFound(UserNotExist);

            var profileImage = personnels.Entity.FirstOrDefault();

            return this.JsonNet(profileImage);
        }

        [HttpPost]
        [Route("List")]
        public async Task<ActionResult> List(Paging paging, List<OrderBy> orderBy)
        {
            try
            {
                var data = await _studentBusinessService.RetrieveStudents(orderBy, paging);
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
            return this.JsonNet(await _studentBusinessService.Search(searchKeyword, orderBy, paging));
        }
    }
}