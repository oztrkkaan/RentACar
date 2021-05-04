using BusinessLogic.Abstract;
using Entity.Dtos;
using System.Web.Mvc;

namespace Web.Controllers
{
    [RoutePrefix("api")]
    public class ApiController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;

        public ApiController(ICustomerService customerService, IBookingService bookingService = null)
        {
            _customerService = customerService;
            _bookingService = bookingService;
        }

        // GET: Api
        [Route("get-all-customers")]
        [HttpGet]
        public JsonResult GetAllCustomers()
        {
            return Json(_customerService.GetAll(), JsonRequestBehavior.AllowGet);
        }
        [Route("save-booking")]
        public JsonResult SaveBooking(BookingDto bookingDto)
        {
            return Json(_bookingService.Create(bookingDto));
        }
        [Route("get-booking-list-by-carId/{carId:int}")]
        public JsonResult GetBookingListByCarId(int carId)
        {
            return Json(_bookingService.GetListByCarId(carId), JsonRequestBehavior.AllowGet);
        }
    }
}