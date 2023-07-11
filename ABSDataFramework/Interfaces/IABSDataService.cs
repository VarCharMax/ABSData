using ABSDataFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABSDataFramework.Interfaces
{
    public interface IABSDataService
    {
        // IEnumerable<PopulationData> GetDataByRegion(int regionCode);

        Task<IEnumerable<PopulationData>> GetDataByRegionIdAndSexIdAsync(int regionCode, int sexId);
    }
}
