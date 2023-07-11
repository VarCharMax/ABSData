using ABSDataFramework.Interfaces;
using ABSDataFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABSDataFramework.Services
{
    public class ABSDataService : IABSDataService
    {
        ApplicationDbContext dbContext;

        public ABSDataService(ApplicationDbContext _db)
        {
            dbContext = _db;
        }

        /*
        public Task<IEnumerable<PopulationData>> GetDataByRegionAsync(int regionCode)
        {
            throw new NotImplementedException();
        }
        */

        public async Task<IEnumerable<PopulationData>> GetDataByRegionIdAndSexIdAsync(int regionCode, int sexId)
        {
            var dataList = await dbContext.FactPopulation
                .Where(f => f.Region.ABSRegionId == regionCode && f.Sex.ABSSexId == sexId).ToListAsync();

            return dataList;
        }
    }
}
