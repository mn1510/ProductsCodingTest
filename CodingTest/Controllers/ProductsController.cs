using AutoMapper;
using CodingTest.DataModel;
using CodingTest.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IRepo<Product> prodRepo;
        private readonly IMapper mapper;

        public ProductsController(ILogger<ProductsController> logger, IRepo<Product> prodRepo, IMapper mapper)
        {
            _logger = logger;
            this.prodRepo = prodRepo;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {
            try
            {
                var prods = prodRepo.GetAll();
                var prodDTOs = mapper.Map<IEnumerable<ProductDTO>>(prods);


                return Ok(prodDTOs);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [Route("{colour}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get(string colour)
        {
            try
            {
                var prods = prodRepo.GetAll().Where(product=>product.Colour.ToString()==colour).ToList();
                var prodDTOs = mapper.Map<IEnumerable<ProductDTO>>(prods);

                return Ok(prodDTOs);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}