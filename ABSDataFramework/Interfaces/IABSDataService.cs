using ABSDataFramework.Models;
using System.Collections.Generic;

namespace ABSDataFramework.Interfaces
{
    public interface IABSDataService
    {
        IEnumerable<abs_data> GetDataByRegion(int regionCode);

        IEnumerable<abs_data> GetDataByRegionIdAndSexId(int regionCode, int sexId);
    }
}
