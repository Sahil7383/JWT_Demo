using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet,Authorize]
        public IEnumerable<string> GetCustomers()
        {
            return new[] { "John Doe", "jon Deo" };
        }
    }
}
