using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/bookprice")]
    [ApiController]
    public class BookPriceController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public BookPriceController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBookPrice()
        {
            var result = await _appDbContext.BookPrices.ToListAsync();

            return Ok(result);
        }
    }
}
