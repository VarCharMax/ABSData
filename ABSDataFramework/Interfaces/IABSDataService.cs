using ABSDataFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABSDataFramework.Interfaces
{
    public interface IABSDataService
    {
        Task<PopulationData> GetDataByRegionIdAndSexIdAsync(int regionCode, int sexId);

        Task<IEnumerable<FactPopulation>> GetDataByRegionIdAndSexIdDiffAsync(int regionCode,
            int sexId, int year1, int year2);
    }
}
