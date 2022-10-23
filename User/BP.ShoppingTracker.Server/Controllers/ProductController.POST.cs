using BP.ShoppingTracker.Adaptables;
using BP.ShoppingTracker.Models.Products;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BP.ShoppingTracker.Server.Controllers
{
    public partial class ProductController : ControllerBase
    {
        [HttpPost("product-category")]
        public async Task<IActionResult> PostCategory([FromBody] ProductCategory productCategory)
        {
            try
            {
                await dataService.CreateAsync(productCategory);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
            }
        }
        [HttpPost("product-type")]
        public async Task<IActionResult> PostProductType([FromBody] ProductType productType)
        {
            try
            {
                await dataService.CreateAsync(productType);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
            }
        }

        [HttpPost("company")]
        public async Task<IActionResult> Postcompany([FromBody] Company company)
        {
            try
            {
                await dataService.CreateAsync(company);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
            }
        }

        [HttpPost("format-type")]
        public async Task<IActionResult> PostFormatType([FromBody] FormatType formatType)
        {
            try
            {
                await dataService.CreateAsync(formatType);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
            }
        }

        [HttpPost("format")]
        public async Task<IActionResult> PostFormat([FromBody] Format format, [FromQuery] bool updateMain = true, [FromQuery] bool updateDerived = false)
        {
            try
            {
                await dataService.CreateAsync(format, updateMain, updateDerived);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
            }
        }

        [HttpPost("format/combine/{mainFormatId}/{derivedFormatId}")]
        public async Task<IActionResult> PostFormat([FromRoute] Guid mainFormatId, [FromRoute] Guid derivedFormatId)
        {
            try
            {
                await dataService.CreateAsync(new Tuple<Guid, Guid>(mainFormatId, derivedFormatId));
                return Ok(new Tuple<Guid, Guid>(mainFormatId, derivedFormatId));
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
            }
        }
    }
}
