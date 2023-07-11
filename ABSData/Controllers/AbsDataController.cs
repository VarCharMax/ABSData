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
    public class AbsDataController : ControllerBase
    {
        private ApplicationDbContext _context;

        public AbsDataController(ApplicationDbContext ctx) {
            _context = ctx;
        }

        [HttpGet]
        [Route("/api/getdata")]
        public async Task<ActionResult<IEnumerable<abs_data>>> GetData() {

            return Ok(await _context.AbsData.ToListAsync());
        }
    }
}
