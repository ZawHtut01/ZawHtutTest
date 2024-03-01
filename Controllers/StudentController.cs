using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZawHtutTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController() { }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Get(int id)
        {
            return Ok();
        }
    }
}
