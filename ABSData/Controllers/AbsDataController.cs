using ABSData.Models;
using ABSDataFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
            var data = (await _dataService.GetDataByRegionIdAndSexIdAsync(regionId, sexId));

            return Ok(data);
        }

        [HttpGet]
        [Route("/api/age-structure/{regionId}/{sexId}/year1/year2")]
        public async Task<ActionResult> GetData(int regionId, int sexId, int year1, int year2)
        {
            var data = (await _dataService.GetDataByRegionIdAndSexIdDiffAsync(regionId, sexId, year1, year2)).ToList();

            List<PopulationData> lst = new List<PopulationData>();

            data.ForEach(d =>
            {
                var pData = new PopulationData
                {
                    Age = d.AgeCode.name,
                    Sex = d.Sex.name,
                    Region = d.Region.name,
                    CensusYear = d.CensusYear,
                    RegionType = d.RegionType,
                };

                lst.Add(pData);
            });

            return Ok(lst);
        }
    }
}
