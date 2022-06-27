using BP.ShoppingTracker.D10.Models.Products;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BP.ShoppingTracker.U50.Server.Controllers
{
    public partial class ProductController : ControllerBase
    {
        [HttpPut("format/combine/{mainFormatId}/{derivedFormatId}/{active}")]
        public async Task<IActionResult> PutFormat([FromRoute] Guid mainFormatId, [FromRoute] Guid derivedFormatId, [FromRoute] bool active = true)
        {
            try
            {
                await dataService.UpdateFormatCombination(mainFormatId, derivedFormatId, active);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
            }
        }

        [HttpPut("product-category")]
        public async Task<IActionResult> PutProductCategory([FromBody] ProductCategory productCategory)
        {
            try
            {
                var result = await dataService.UpdateAsync(productCategory);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
                throw;
            }
        }

        [HttpPut("product-type")]
        public async Task<IActionResult> PutProductType([FromBody] ProductType productType)
        {
            try
            {
                var result = await dataService.UpdateAsync(productType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
                throw;
            }
        }

        [HttpPut("company")]
        public async Task<IActionResult> Putcompany([FromBody] BP.ShoppingTracker.D10.Models.Products.Company company)
        {
            try
            {
                await dataService.UpdateAsync(company);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
            }
        }
    }
}
