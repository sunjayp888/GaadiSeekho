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
    [RoutePrefix("Student")]
    public class StudentController : BaseController
    {
        private readonly IStudentBusinessService _studentBusinessService;
        public StudentController(IStudentBusinessService studentBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService) : base(configurationManager, authorizationService)
        {
            _studentBusinessService = studentBusinessService;
        }

        // GET: Student
        [Route("")]
        public ActionResult Index()
        {
            return View();
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
                return this.JsonNet(""); ;
            }
        }

        //[HttpPost]
        //[Route("Search")]
        //public async Task<ActionResult> Search(string searchKeyword, Paging paging, List<OrderBy> orderBy)
        //{
        //    return this.JsonNet(await _studentBusinessService.Search(searchKeyword, orderBy, paging));
        //}
    }
}