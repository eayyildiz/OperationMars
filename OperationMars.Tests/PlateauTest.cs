using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationMars.Models;
using OperationMars.Controllers;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Linq;

namespace OperationMars.Tests
{
    [TestClass]
    public class PlateauTest
    {
        [TestMethod]
        public void GetAllPlateausTest()
        {
            List<Plateau> testPlateaus = DataContext.Plateaus;
            PlateauController controller = new PlateauController();

            List<Plateau> result = controller.Get() as List<Plateau>;
            Assert.AreEqual(testPlateaus.Count, result.Count);
        }

        [TestMethod]
        public void PlateauController_ShouldReturnCorrectPlateau()
        {
            Guid id = new Guid("653648ee-6a4b-4a12-ab74-b5f9663b06cd");
            Plateau testPlateau = DataContext.Plateaus.Where(p => p.Id == id).FirstOrDefault();
            PlateauController controller = new PlateauController();

            Plateau result = controller.Get(id);
            Assert.IsNotNull(result);
            Assert.AreEqual(testPlateau.Name, result.Name);
        }

    }
}
