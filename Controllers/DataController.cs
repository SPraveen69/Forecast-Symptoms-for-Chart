using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess;

namespace TestProject.Controllers
{
    [Route("Data")]
    public class DataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetHistoricalData")]
        //[Route("Data/GetHistoricalData")]
        public async Task<IActionResult> GetHistoricalData()
        {
            var historicalData = await _context.symptom_data
                .Where(d => d.RecordDate >= new DateTime(2024, 6, 1) && d.RecordDate <= new DateTime(2024, 9, 3))
                .OrderBy(d => d.RecordDate)
                .ToListAsync();

            return Json(historicalData);
        }
        [HttpGet("GetForecastData")]
        public async Task<IActionResult> GetForecastData()
        {
            var forecastData = await _context.symptom_data
                .Where(d => d.RecordDate >= new DateTime(2024, 9, 3) && d.RecordDate <= new DateTime(2024, 9, 8))
                .OrderBy(d => d.RecordDate)
                .ToListAsync();

            return Json(forecastData);
        }

    }
}
