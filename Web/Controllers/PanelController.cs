using BusinessLogic.Abstract;
using BusinessLogic.Utilities.AutoMapper;
using Entity.Dtos;
using Entity.Dtos.Web.Panel;
using Entity.ViewModels.Web.Panel;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.Helper.FluentValidation;

namespace Web.Controllers
{
    [Authorize(Roles = "Owner")]
    [RoutePrefix("panel")]
    public class PanelController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICustomerService _customerService;
        public PanelController(ICarService carService, ICustomerService customerService)
        {
            _carService = carService;
            _customerService = customerService;
        }
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("araba-ekle")]
        public ActionResult NewCar()
        {
            return View();
        }
        [Route("araba-ekle")]
        [HttpPost]
        public ActionResult NewCar(NewCarViewModel model)
        {
            var createResult = _carService.Create(model.CarDto);
            if (!createResult.Success)
            {
                ModelState.ValidateModel(createResult.ValidationErrors, typeof(CarDto));
                return View(model);
            }
            return RedirectToAction("CarList", "Panel");
        }
        [Route("araba-listesi")]
        public ActionResult CarList()
        {
            CarListViewModel model = new CarListViewModel();
            model.CarDtos = Mapping.Mapper.Map<IList<CarDto>>(_carService.GetAll().Data);
            return View(model);
        }

        [Route("araba-detay/{carId:int}")]
        public ActionResult CarDetail(int carId)
        {
            CarDetailViewModel model = new CarDetailViewModel();
            model.CarDto = Mapping.Mapper.Map<CarDto>(_carService.GetById(carId).Data);

            return View(model);
        }

        [Route("musteri-ekle")]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [Route("musteri-ekle")]
        [HttpPost]
        public ActionResult AddCustomer(AddCustomerViewModel model)
        {
            var addResult = _customerService.Create(model.CreateCustomerDto);
            if (!addResult.Success)
            {
                ModelState.ValidateModel(addResult.ValidationErrors, typeof(CreateCustomerDto));
                return View(model);
            }
            return RedirectToAction("Index", "Panel");
        }
    }
}