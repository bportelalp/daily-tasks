using BP.ShoppingTracker.D10.Models.Products;
using BP.ShoppingTracker.D20.Adapters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.ShoppingTracker.U50.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class ProductController : Controller
    {
        private readonly IDataService dataService;

        public ProductController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet("product-category")]
        public async Task<IActionResult> GetProductCategory([FromQuery] string? SearchName)
        {
            try
            {
                var query = await dataService.ReadProductCategories();

                if (string.IsNullOrWhiteSpace(SearchName))
                    return Ok(query.ToList());
                else
                    return Ok(query.ToList().Where(p => p.Name.ToUpperInvariant().Contains(SearchName.ToUpperInvariant())));
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet("product-category/{Id}")]
        public async Task<IActionResult> GetProductCategory([FromRoute] Guid Id)
        {
            try
            {
                var query = await dataService.ReadProductCategories();
                var result = query.ToList().Find(pc => pc.Id == Id);
                if (result is null)
                    return NotFound($"None product-category is registered with Id={Id}");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet("product-type")]
        public async Task<IActionResult> GetProductType([FromQuery] string? SearchName, bool IncludeCategory = true, bool returnHierarchy = false)
        {
            try
            {
                var response = await dataService.ReadProductTypes(SearchName,IncludeCategory, returnHierarchy);
                return Ok(response);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return Problem();
        }

        [HttpGet("product-type/{Id}")]
        public async Task<IActionResult> GetProductType([FromRoute] Guid Id, [FromQuery] bool IncludeParent = false, [FromQuery] bool IncludeChildren = false)
        {
            try
            {
                var response = await dataService.ReadProductType(Id, IncludeParent, IncludeChildren);
                if (response is null) return NotFound();
                else return Ok(response);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return Problem();
        }

        [HttpGet("measure-type/{Id?}")]
        public async Task<IActionResult> GetMeasureType([FromRoute] int? Id)
        {
            try
            {
                var response = await dataService.ReadMeasureTypes();
                if (Id is null)
                    return Ok(response);
                
                var result = response.FirstOrDefault(mt => mt.Id == Id);
                if(result is null)
                    return NotFound();
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return Problem();
        }

        [HttpGet("format-type")]
        public async Task<IActionResult> GetFormatType([FromQuery] string SearchName = "")
        {
            try
            {
                var response = await dataService.ReadFormatTypes(SearchName);
                if (response is null || !response.Any())
                    return NotFound();
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return Problem();
        }

        [HttpGet("format-type/{Id}")]
        public async Task<IActionResult> GetFormatType([FromRoute] Guid Id)
        {
            try
            {
                var response = await dataService.ReadFormatTypes();
                var result = response.FirstOrDefault(mt => mt.Id == Id);
                if (result is null)
                    return NotFound();
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return Problem();
        }

        [HttpGet("format")]
        public async Task<IActionResult> GetFormat()
        {
            try
            {
                var response = await dataService.ReadFormats();
                if (response is null)
                    return NotFound();
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return Problem();
        }

        [HttpGet("format/{Id}")]
        public async Task<IActionResult> GetFormat([FromRoute] Guid Id)
        {
            try
            {
                var response = await dataService.ReadFormat(Id);
                var cadena = response.ToString();
                if (response is null)
                    return NotFound();
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return Problem();
        }
    }
}
