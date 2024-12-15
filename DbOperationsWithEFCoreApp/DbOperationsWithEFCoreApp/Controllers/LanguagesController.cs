using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public LanguagesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLanguages()
        {
            //var result = _appDbContext.Languages.ToList();
            //var result = (from languages in  _appDbContext.Languages select  languages).ToList();

            //var result = await _appDbContext.Languages.ToListAsync();
            var result = await (from languages in _appDbContext.Languages select languages).ToListAsync();

            return Ok(result);
        }

        [HttpGet("{title}/{description}")]
        public async Task<IActionResult> GetLanguageByTitleDescriptionAsync([FromRoute] string title, [FromRoute] string description)
        {
            var result = await _appDbContext.Languages.FirstOrDefaultAsync(x=>x.Title==title && x.Description==description);
            return Ok(result);
        }
    }
}
