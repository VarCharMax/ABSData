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

        public async Task<IEnumerable<PopulationData>> GetDataByRegionIdAndSexIdAsync(int regionCode, int sexId)
        {
            var dataList = await dbContext.FactPopulation
                .Where(f => f.Region.ABSRegionId == regionCode 
                && f.Sex.ABSSexId == sexId)
                .Include(d => d.Sex)
                .Include(d => d.AgeCode)
                .Include(d => d.Region)
                .Include(d => d.State)
                .ToListAsync();

            return dataList;
        }

        public async Task<IEnumerable<PopulationData>> GetDataByRegionIdAndSexIdDiffAsync(int regionCode, 
            int sexId, int year1, int year2)
        {
            var dataList = await dbContext.FactPopulation
                .Where(f => f.Region.ABSRegionId == regionCode
                && f.Sex.ABSSexId == sexId)
                .Include(d => d.Sex)
                .Include(d => d.AgeCode)
                .Include(d => d.Region)
                .Include(d => d.State)
                .Where()
                .ToListAsync();

            return dataList;
        }
    }
}
