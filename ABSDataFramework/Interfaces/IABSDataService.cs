using ABSDataFramework.Models;
using System.Collections.Generic;

namespace ABSDataFramework.Interfaces
{
    public interface IABSDataService
    {
        IEnumerable<PopulationData> GetDataByRegion(int regionCode);

        IEnumerable<PopulationData> GetDataByRegionIdAndSexId(int regionCode, int sexId);
    }
}
