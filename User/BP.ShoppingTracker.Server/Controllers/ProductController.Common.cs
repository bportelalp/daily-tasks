﻿using Microsoft.AspNetCore.Mvc;

namespace BP.ShoppingTracker.Server.Controllers
{
    public partial class ProductController : ControllerBase
    {
        private IActionResult ManageException(Exception ex)
        {
            Type exceptionType = ex.GetType();
            if (exceptionType == typeof(Microsoft.EntityFrameworkCore.DbUpdateException))
                return BadRequest(ex.InnerException?.Message);
            return BadRequest(ex.Message);
        }
    }
}
