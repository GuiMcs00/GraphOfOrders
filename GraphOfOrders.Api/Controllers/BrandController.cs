using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Lib.DI;
using Microsoft.AspNetCore.Mvc;
using GraphOfOrders.Lib.Exceptions;

namespace GraphOfOrders.Api
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("brands-by-product")]
        public IEnumerable<BrandDTO> GetBrandsByProduct(int productId)
        {
            return _brandService.GetBrandsByProduct(productId);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BrandDTO>> GetBrands([FromQuery] int? itemsPerPage, [FromQuery] int? page)
        {
            var brands = _brandService.GetBrands(itemsPerPage ??= 20, page ??= 1);
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            try
            {
                var brandDto = await _brandService.GetBrandById(id);
                return Ok(brandDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }
    }
}