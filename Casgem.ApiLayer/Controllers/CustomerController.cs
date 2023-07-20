using Casgem.BusinessLayer.Abstract;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Casgem.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var values = _customerService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.TInsert(customer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var value = _customerService.TGetById(id);
            _customerService.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCustomerw(Customer customer)
        {
            _customerService.TUpdate(customer);
            return Ok();
        }
    }
}
