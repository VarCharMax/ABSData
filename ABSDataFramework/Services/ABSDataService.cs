﻿using ABSDataFramework.Interfaces;
using ABSDataFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public async Task<PopulationData> GetDataByRegionIdAndSexIdAsync(int regionCode, int sexId)
        {
            PopulationData pData = null;

            var dataList = await dbContext.FactPopulation
                .Where(f => f.Region.ABSRegionId == regionCode
                && f.Sex.ABSSexId == sexId)
                .Include(d => d.Sex)
                .Include(d => d.AgeCode)
                .Include(d => d.Region)
                .ToListAsync();

            if (dataList.Count > 0)
            {
                var dataRow = dataList.FirstOrDefault();

                var popList = dataList.GroupBy(g => g.AgeCode.name, g => g.AgeCode,
                (baseAge, ages) => new DataList
                {
                    Age = baseAge,
                    Population = ages.Count(),
                    Sex = dataRow.Sex.name
                }).ToList();

                pData = new PopulationData() { RegionCode = dataRow.Region.ABSRegionId, 
                    RegionName = dataRow.Region.name, Data = popList };
            }


            return pData;
        }

        public async Task<IEnumerable<FactPopulation>> GetDataByRegionIdAndSexIdDiffAsync(int regionCode, 
            int sexId, int year1, int year2)
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
    }
}
