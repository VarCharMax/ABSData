using ABSData.Models;
using ABSDataFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABSData.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public RegionsController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        [Route("/api/getregions")]
        public async Task<ActionResult<IEnumerable<region>>> GetData()
        {

            return Ok(await _context.DimRegion.ToListAsync());
        }
    }
}
