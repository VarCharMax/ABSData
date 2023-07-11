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
        public async Task<ActionResult> GetData([FromRoute(Name = "regionId")] int regionId, int sexId)
        {
            var data = (await _dataService.GetDataByRegionIdAndSexIdAsync(regionId, sexId)).ToList();

            List<PopulationData> lst = new List<PopulationData>();

            data.ForEach(d =>
            {
                var pData = new PopulationData
                {
                    Age = d.AgeCode.name,
                    Sex = d.Sex.name,
                    Region = d.Region.name,
                    State = d.State.name,
                    CensusYear = d.CensusYear,
                    GeographyLevel = d.GeographyLevel,
                    RegionType = d.RegionType,
                    Time = d.Time,
                    Value = d.Value
                };

                lst.Add(pData);
            });

            return Ok(lst);
        }
    }
}
