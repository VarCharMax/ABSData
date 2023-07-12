using ABSDataFramework.Interfaces;
using ABSDataFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ABSData.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class AbsDatController : ControllerBase
    {
        private IABSDataService _dataService;

        public AbsDatController(IABSDataService dataService) {
            _dataService = dataService;
        }

        [HttpGet]
        [Route("/api/age-structure/{regionId}/{sexId}")]
        public async Task<ActionResult> GetData(int regionId, int sexId)
        {
            if (regionId == 0 || sexId == 0)
            {
                return BadRequest();
            }

            PopulationData data;

            try
            {
                data = (await _dataService.GetDataByRegionIdAndSexIdAsync(regionId, sexId));
            }
            catch(Exception)
            {
                return BadRequest();
            }
            
            if (data == null)
            {
                return NotFound(data);
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet]
        [Route("/api/age-structure-diff/{regionId}/{sexId}/{year1}/{year2}")]
        public async Task<ActionResult> GetData(int regionId, int sexId, int year1, int year2)
        {
            if (regionId == 0 || sexId == 0 || year1 == 0 || year2 == 0)
            {
                return BadRequest();
            }

            PopulationData data;

            try
            {
                data = (await _dataService.GetDataByRegionIdAndSexIdDiffAsync(regionId, sexId, year1, year2));
            }
            catch (Exception)
            {
                return BadRequest();
            }

            if (data == null)
            {
                return NotFound(data);
            }
            else
            {
                return Ok(data);
            }
        }
    }
}
