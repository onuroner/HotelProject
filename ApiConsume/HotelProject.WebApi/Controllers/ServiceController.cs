using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var services = _serviceService.TGetAll();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var service = _serviceService.TGetByID(id);
            return Ok(service);
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceService.TInsert(service);
            return Ok(service);
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            return Ok(service);
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var service = _serviceService.TGetByID(id);
            _serviceService.TDelete(service);
            return Ok(service);
        }
    }
}
