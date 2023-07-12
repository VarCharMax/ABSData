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
        public void APIReturnsData()
        {
            var mock = new Mock<IABSDataService>();

            var myType = mock.SetupGet(p => p.GetDataByRegionIdAndSexIdAsync(104, 1)).Returns(Task.FromResult(new PopulationData { RegionCode = 104, RegionName = "West Coast" }));

            var controller = new AbsDataController(mock.Object);

            var model = (await controller.GetData(104, 1) as ViewResult)?.ViewData.Model as IEnumerable<Product>;
        }

    }
}
