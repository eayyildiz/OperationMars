using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationMars.Controllers;
using OperationMars.Models;
using OperationMars.Requests;
using OperationMars.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationMars.Tests
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void GetAllRoversTest()
        {
            List<Rover> testRovers = DataContext.Rovers;
            RoverController controller = new RoverController();

            List<Rover> result = controller.Get() as List<Rover>;
            Assert.AreEqual(testRovers.Count, result.Count);
        }

        [TestMethod]
        public void RoverController_ShouldReturnCorrectRover()
        {
            Guid id = new Guid("ac077fdf-ca63-45b2-9c63-74f73383d8c8");
            Rover testRover = DataContext.Rovers.Where(p => p.Id == id).FirstOrDefault();
            RoverController controller = new RoverController();

            Rover result = controller.Get(id);
            Assert.IsNotNull(result);
            Assert.AreEqual(testRover.Name, result.Name);
        }

        [TestMethod]
        public void RoverController_SuccessCommand() {
            Guid id = new Guid("ac077fdf-ca63-45b2-9c63-74f73383d8c8");

            RoverCommandRequest request = new RoverCommandRequest
            {
                Commands = "LMMRMMR"
            };
            RoverController controller = new RoverController();
            RoverCommandResponse response = controller.PostCommand(id, request);

            Assert.IsNotNull(response.Rover);
            Assert.AreEqual(response.Success, true);
            Assert.AreEqual(response.FinalCoordinates, "3, 7, E");
            Assert.AreEqual(response.Rover.State, RoverState.Active);
        }

        [TestMethod]
        public void RoverController_LostCommand()
        {
            Guid id = new Guid("67968965-e69a-420c-a28a-9e7109692140");

            RoverCommandRequest request = new RoverCommandRequest
            {
                Commands = "RMMLMMRMMMM"
            };
            RoverController controller = new RoverController();
            RoverCommandResponse response = controller.PostCommand(id, request);

            Assert.IsNotNull(response.Rover);
            Assert.AreEqual(response.Success, false);
            Assert.AreEqual(response.FinalCoordinates, "15, 12, E");
            Assert.AreEqual(response.Rover.State, RoverState.Lost);
        }
    }
}
