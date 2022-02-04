namespace FreeWheelers.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetValues()
        {
            return new[] { "m", "n" };
        }
    }
}