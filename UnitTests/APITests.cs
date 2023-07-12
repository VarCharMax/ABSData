using ABSData.Controllers;
using ABSDataFramework.Interfaces;
using ABSDataFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class APITests
    {
        [Fact]
        public async Task APIReturnsDataAsync()
        {
            var mockService = new Mock<IABSDataService>();

            var myType = mockService.Setup(p => p.GetDataByRegionIdAndSexIdAsync(104, 1)).Returns(Task.FromResult(new PopulationData { RegionCode = 104, RegionName = "West Coast" }));

            var controller = new AbsDataController(mockService.Object);

            var model = (await controller.GetData(104, 1) as ActionResult);

            Assert.NotNull(model);
        }

    }
}
