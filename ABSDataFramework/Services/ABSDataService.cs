using ABSDataFramework.Interfaces;
using ABSDataFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABSDataFramework.Services
{
    internal class ABSDataService : IABSDataService
    {
        ApplicationDbContext dbContext;

        public ABSDataService(ApplicationDbContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<abs_data> GetDataByRegion(int regionCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<abs_data> GetDataByRegionIdAndSexId(int regionCode, int sexId)
        {
            throw new NotImplementedException();
        }
    }
}
