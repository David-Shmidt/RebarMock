using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RebarMock.Models.Dtos;

namespace RebarMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ProductDto GetAllProducts()
        {
            return null;
        }
    }
}
