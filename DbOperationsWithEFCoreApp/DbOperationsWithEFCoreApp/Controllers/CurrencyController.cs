using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            //var result = _appDbContext.Currencies.ToList();
            //var result = (from currencies in  _appDbContext.Currencies select  currencies).ToList();

            var result = await _appDbContext.Currencies.ToListAsync();
            //var result = (from currencies in  _appDbContext.Currencies select  currencies).ToList();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyByIdAsync([FromRoute] int id)
        {
            var result = await _appDbContext.Currencies.FindAsync(id);
            return Ok(result);
        }

        /*[HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByName([FromRoute] string name)
        {
            var result = await _appDbContext.Currencies.Where(x => x.Title == name).FirstOrDefaultAsync();
            // This will go through all the data then filter out data based on name and return the first
            // occurence of the element.

            //var result = await _appDbContext.Currencies.FirstOrDefaultAsync(x => x.Title == name); //in this step
            //performance will improve because it will not run in whole database it will return the data 
            //if it finds it first. It will not go to every data.

            // var result = await _appDbContext.Currencies.Where(x => x.Title == name).FirstAsync();
            // This will also show First value but it gives exception when the name is not present in
            // the database. FirstorDefault will give you some default value that is 'null'.

            //var result = await _appDbContext.Currencies.Where(x => x.Title == name).SingleAsync();
            // SingleAsync will also throw error(500) if data is not found.

            //var result = await _appDbContext.Currencies.Where(x => x.Title == name).SingleorDefaultAsync();
            // SingleorDefaultAsync will not throw error(204) if data is not found, it will give
            // null value as a default

            // Difference between FirstAsync/FirstOrDefaultAsync and SingleAsync/SingleorDefaultAsync 
            // is that if duplicate records are present in the database SingleAsync/SingleorDefaultAsync 
            // will throw an error/exception but FirstAsync/FirstOrDefaultAsync will not throw an exception

            return Ok(result);
        }*/

        /*[HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencybyNameDescAsync
            ([FromRoute] string name, [FromQuery] string? description)// here there is '?' after string
            // because description can be nullable.
        {
            var result = await _appDbContext.Currencies
                .FirstOrDefaultAsync(x=>x.Title ==name
                && (string.IsNullOrEmpty(description)||x.Description == description));
            // This will
            // check if description is null if yes it will not check the next condition and will
            // give null value as the response. If description is not null it will give the
            // appropriate value of the record from the table.

            
            
            
            // After running the project hit this url - 
            // https://localhost:7285/api/currencies/Dollar?Description=American%20Dollar
            // this url gives Dollar as Title and provides a query value Description.
            // %20 means giving a space. Read url carefully and learn from it.

            return Ok(result);
        }
        */

        // Get All records using multiple parameters
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByNameAsync([FromRoute] string name,
            [FromQuery] string? description)
        {
            var result = await _appDbContext.Currencies
                .Where(x=>x.Title==name
                && (string.IsNullOrEmpty(description)||x.Description==description))
                .ToListAsync();// wo saare records jo condition hai where ke ander 
                // wo aa jayenge. FirstorDefault me pehla record aaya tha jo condition
                // satisfy krta hai. But where se wo saare records aa jayenge jo condition
                // satisfy krta hai.

                // ToList Method returns data in the form of collection of lists.

            return Ok(result);
        }



    }
}
