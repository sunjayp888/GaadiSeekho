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
    [RoutePrefix("Car")]
    public class CarController : BaseController
    {
        private readonly ICarBusinessService _carBusinessService;
        public CarController(ICarBusinessService carBusinessService, IConfigurationManager configurationManager, IAuthorizationService authorizationService) : base(configurationManager, authorizationService)
        {
            _carBusinessService = carBusinessService;
        }

        // GET: Car
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("{carId:int}/Edit")]
        public async Task<ActionResult> Edit(int carId)
        {
            var car = await _carBusinessService.RetrieveCar(carId);
            if (car == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CarViewModel()
            {
                Car = car
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{carId:int}/Edit")]
        public async Task<ActionResult> Edit(int carId, CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                carViewModel.Car.CarId = carId;
                var result = await _carBusinessService.UpdateCar(carViewModel.Car);
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
            return View(carViewModel);
        }

        [HttpPost]
        [Route("List")]
        public async Task<ActionResult> List(Paging paging, List<OrderBy> orderBy)
        {
            try
            {
                var data = await _carBusinessService.RetrieveCars(orderBy, paging);
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
            return this.JsonNet(await _carBusinessService.Search(searchKeyword, orderBy, paging));
        }
    }
}