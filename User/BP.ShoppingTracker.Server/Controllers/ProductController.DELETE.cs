using BP.ShoppingTracker.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.ShoppingTracker.Server.Controllers
{
    public partial class ProductController : ControllerBase
    {
        [HttpDelete("product-category")]
        public async Task<IActionResult> DeleteProductCategory([FromBody] ProductCategory productCategory)
        {
            try
            {
                await dataService.DeleteAsync(productCategory);
                return NoContent();
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
            }
        }

        [HttpDelete("product-type")]
        public async Task<IActionResult> DeleteProductType([FromBody] ProductType productType)
        {
            try
            {
                await dataService.DeleteAsync(productType);
                return NoContent();
            }
            catch (Exception ex)
            {
                return this.ManageException(ex);
            }
        }
    }
}
