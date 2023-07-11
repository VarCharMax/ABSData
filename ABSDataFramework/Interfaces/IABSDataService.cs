using ABSDataFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABSDataFramework.Interfaces
{
    public interface IABSDataService
    {
        Task<IEnumerable<PopulationData>> GetDataByRegionIdAndSexIdAsync(int regionCode, int sexId);

        Task<IEnumerable<PopulationData>> GetDataByRegionIdAndSexIdDiffAsync(int regionCode,
            int sexId, int year1, int year2);
    }
}
