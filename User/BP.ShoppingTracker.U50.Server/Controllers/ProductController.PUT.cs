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
    }
}
