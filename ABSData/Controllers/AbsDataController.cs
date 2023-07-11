using ABSData.Models;
using ABSDataFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABSData.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AbsDataController : ControllerBase
    {
        private IABSDataService _dataService;

        public AbsDataController(IABSDataService dataService) {
            _dataService = dataService;
        }

        [HttpGet]
        [Route("/api/age-structure/{id/{id}}")]
        public async Task<ActionResult> GetData(int region, int sex)
        {
            var data = (await _dataService.GetDataByRegionIdAndSexIdAsync(region, sex)).ToList();

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
