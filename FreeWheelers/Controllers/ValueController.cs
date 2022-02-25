using FreeWheelers.Models;

namespace FreeWheelers.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly ProductContext _productContext;

        public ValueController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetValues()
        {
            return _productContext.Products;
        }
    }
}