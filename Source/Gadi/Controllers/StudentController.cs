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
            var formOneA = await _studentBusinessService.RetrieveFormOneAByStudentId(studentId);
            var formFour = await _studentBusinessService.RetrieveFormFourByStudentId(studentId);
            var formFive = await _studentBusinessService.RetrieveFormFiveByStudentId(studentId);
            var formEight = await _studentBusinessService.RetrieveFormEightByStudentId(studentId);
            var formFourteen = await _studentBusinessService.RetrieveFormFourteenByStudentId(studentId);
            var questions = await _studentBusinessService.RetrieveQuestions();
            var formOneAData = formOneA ?? new FormOneA();
            var formFourData = formFour ?? new FormFour();
            var formFiveData = formFive ?? new FormFive();
            var formEightData = formEight ?? new FormEight();
            var formFourteenData = formFourteen ?? new FormFourteen();
            if (student == null)
            {
                return HttpNotFound();
            }
            var viewModel = new StudentViewModel()
            {
                Student = student,
                FormOneA = formOneAData,
                FormFour = formFourData,
                FormFive = formFiveData,
                FormEight = formEightData,
                FormFourteen = formFourteenData,
                Questions = questions.Items.ToList()
            };
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
        [Route("CreateFormOneA")]
        public async Task<ActionResult> CreateFormOneA(FormOneA formOneA, int drivingSchoolId, int studentId)
        {
            formOneA.DrivingSchoolId = drivingSchoolId;
            formOneA.StudentId = studentId;
            formOneA.CreatedDate = DateTime.UtcNow;
            var result = await _studentBusinessService.CreateFormOneA(formOneA);
            if (result.Succeeded)
            {
                return this.JsonNet(result.Succeeded);
            }
            ModelState.AddModelError("", result.Exception);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.JsonNet(ModelState);
        }

        [HttpPost]
        [Route("CreateFormFour")]
        public async Task<ActionResult> CreateFormFour(FormFour formFour, int drivingSchoolId, int studentId)
        {
            formFour.DrivingSchoolId = drivingSchoolId;
            formFour.StudentId = studentId;
            formFour.CreatedDate = DateTime.UtcNow;
            var result = await _studentBusinessService.CreateFormFour(formFour);
            if (result.Succeeded)
            {
                return this.JsonNet(result.Succeeded);
            }
            ModelState.AddModelError("", result.Exception);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.JsonNet(ModelState);
        }

        [HttpPost]
        [Route("CreateFormFive")]
        public async Task<ActionResult> CreateFormFive(FormFive formFive, int drivingSchoolId, int studentId)
        {
            formFive.DrivingSchoolId = drivingSchoolId;
            formFive.StudentId = studentId;
            formFive.CreatedDate = DateTime.UtcNow;
            var result = await _studentBusinessService.CreateFormFive(formFive);
            if (result.Succeeded)
            {
                return this.JsonNet(result.Succeeded);
            }
            ModelState.AddModelError("", result.Exception);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.JsonNet(ModelState);
        }

        [HttpPost]
        [Route("CreateFormEight")]
        public async Task<ActionResult> CreateFormEight(FormEight formEight, int drivingSchoolId, int studentId)
        {
            formEight.DrivingSchoolId = drivingSchoolId;
            formEight.StudentId = studentId;
            formEight.CreatedDate = DateTime.UtcNow;
            formEight.TestedAndPassedOn=DateTime.UtcNow;
            var result = await _studentBusinessService.CreateFormEight(formEight);
            if (result.Succeeded)
            {
                return this.JsonNet(result.Succeeded);
            }
            ModelState.AddModelError("", result.Exception);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.JsonNet(ModelState);
        }

        [HttpPost]
        [Route("CreateFormFourteen")]
        public async Task<ActionResult> CreateFormFourteen(FormFourteen formFourteen, int drivingSchoolId, int studentId)
        {
            formFourteen.DrivingSchoolId = drivingSchoolId;
            formFourteen.StudentId = studentId;
            formFourteen.CreatedDate = DateTime.UtcNow;
            var result = await _studentBusinessService.CreateFormFourteen(formFourteen);
            if (result.Succeeded)
            {
                return this.JsonNet(result.Succeeded);
            }
            ModelState.AddModelError("", result.Exception);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.JsonNet(ModelState);
        }

        [HttpPost]
        [Route("UpdateFormOneA")]
        public async Task<ActionResult> UpdateFormOneA(FormOneA formOneA, int drivingSchoolId, int studentId)
        {
            formOneA.DrivingSchoolId = drivingSchoolId;
            formOneA.StudentId = studentId;
            formOneA.CreatedDate = DateTime.UtcNow;
            var result = await _studentBusinessService.UpdateFormOneA(formOneA);
            if (result.Succeeded)
            {
                return this.JsonNet(result.Succeeded);
            }
            ModelState.AddModelError("", result.Exception);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.JsonNet(ModelState);
        }

        [HttpPost]
        [Route("UpdateFormFour")]
        public async Task<ActionResult> UpdateFormFour(FormFour formFour, int drivingSchoolId, int studentId)
        {
            formFour.DrivingSchoolId = drivingSchoolId;
            formFour.StudentId = studentId;
            //formFour.CreatedDate = DateTime.UtcNow;
            var result = await _studentBusinessService.UpdateFormFour(formFour);
            if (result.Succeeded)
            {
                return this.JsonNet(result.Succeeded);
            }
            ModelState.AddModelError("", result.Exception);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.JsonNet(ModelState);
        }

        [HttpPost]
        [Route("UpdateFormFive")]
        public async Task<ActionResult> UpdateFormFive(FormFive formFive, int drivingSchoolId, int studentId)
        {
            formFive.DrivingSchoolId = drivingSchoolId;
            formFive.StudentId = studentId;
           // formFive.CreatedDate = DateTime.UtcNow;
            var result = await _studentBusinessService.UpdateFormFive(formFive);
            if (result.Succeeded)
            {
                return this.JsonNet(result.Succeeded);
            }
            ModelState.AddModelError("", result.Exception);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.JsonNet(ModelState);
        }

        [HttpPost]
        [Route("UpdateFormEight")]
        public async Task<ActionResult> UpdateFormEight(FormEight formEight, int drivingSchoolId, int studentId)
        {
            formEight.DrivingSchoolId = drivingSchoolId;
            formEight.StudentId = studentId;
            //formEight.CreatedDate = DateTime.UtcNow;
            //formEight.TestedAndPassedOn = DateTime.UtcNow;
            var result = await _studentBusinessService.UpdateFormEight(formEight);
            if (result.Succeeded)
            {
                return this.JsonNet(result.Succeeded);
            }
            ModelState.AddModelError("", result.Exception);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.JsonNet(ModelState);
        }

        [HttpPost]
        [Route("UpdateFormFourteen")]
        public async Task<ActionResult> UpdateFormFourteen(FormFourteen formFourteen, int drivingSchoolId, int studentId)
        {
            formFourteen.DrivingSchoolId = drivingSchoolId;
            formFourteen.StudentId = studentId;
            //formFourteen.CreatedDate = DateTime.UtcNow;
            var result = await _studentBusinessService.UpdateFormFourteen(formFourteen);
            if (result.Succeeded)
            {
                return this.JsonNet(result.Succeeded);
            }
            ModelState.AddModelError("", result.Exception);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return this.JsonNet(ModelState);
        }

        [HttpPost]
        [Route("RetrieveFormOneA")]
        public async Task<ActionResult> RetrieveFormOneA(int studentId)
        {
            var formOneA = await _studentBusinessService.RetrieveFormOneAByStudentId(studentId);
            return this.JsonNet(formOneA);
        }

        [HttpPost]
        [Route("RetrieveFormFour")]
        public async Task<ActionResult> RetrieveFormFour(int studentId)
        {
            var formFour = await _studentBusinessService.RetrieveFormFourByStudentId(studentId);
            return this.JsonNet(formFour);
        }

        [HttpPost]
        [Route("RetrieveFormFive")]
        public async Task<ActionResult> RetrieveFormFive(int studentId)
        {
            var formFive = await _studentBusinessService.RetrieveFormFiveByStudentId(studentId);
            return this.JsonNet(formFive);
        }

        [HttpPost]
        [Route("RetrieveFormFourteen")]
        public async Task<ActionResult> RetrieveFormFourteen(int studentId)
        {
            var formFourteen = await _studentBusinessService.RetrieveFormFourteenByStudentId(studentId);
            return this.JsonNet(formFourteen);
        }

        [HttpPost]
        [Route("RetrieveFormEight")]
        public async Task<ActionResult> RetrieveFormEight(int studentId)
        {
            var formEight = await _studentBusinessService.RetrieveFormEightByStudentId(studentId);
            return this.JsonNet(formEight);
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
                            Description = string.Format("{0} Profile Image", student.Name),
                            FileName = file.FileName.Split('\\').Last() + ".png",
                            PersonnelName = student.Name,
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
        
        //  [HttpPost]
        public ActionResult FormOneADownload(int studentId)
        {
            var drivingSchoolId = UserDrivingSchoolId;
            var data = _studentBusinessService.CreateFormOneABytes(drivingSchoolId, studentId);
            return File(data, ".pdf", "Form 1A.pdf");
        }

        //  [HttpPost]
        public ActionResult FormFourDownload(int studentId)
        {
            var drivingSchoolId = UserDrivingSchoolId;
            var data = _studentBusinessService.CreateFormFourBytes(drivingSchoolId, studentId);
            return File(data, ".pdf", "Form 4.pdf");
        }

        //  [HttpPost]
        public ActionResult FormFiveDownload(int studentId)
        {
            var drivingSchoolId = UserDrivingSchoolId;
            var data = _studentBusinessService.CreateFormFiveBytes(drivingSchoolId, studentId);
            return File(data, ".pdf", "Form 5.pdf");
        }

        //  [HttpPost]
        public ActionResult FormEightDownload(int studentId)
        {
            var drivingSchoolId = UserDrivingSchoolId;
            var data = _studentBusinessService.CreateFormEightBytes(drivingSchoolId, studentId);
            return File(data, ".pdf", "Form 8.pdf");
        }

        //  [HttpPost]
        public ActionResult FormFourteenDownload(int studentId)
        {
            var drivingSchoolId = UserDrivingSchoolId;
            var data = _studentBusinessService.CreateFormFourteenBytes(drivingSchoolId, studentId);
            return File(data, ".pdf", "Form 14.pdf");
        }
    }
}