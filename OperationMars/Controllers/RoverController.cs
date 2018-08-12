using OperationMars.Helpers;
using OperationMars.Models;
using OperationMars.Requests;
using OperationMars.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OperationMars.Controllers
{
    [RoutePrefix("api/rover")]
    public class RoverController : ApiController
    {
        public IEnumerable<Rover> Get()
        {
            return DataContext.Rovers;
        }

        public Rover Get(Guid id)
        {
            return DataContext.Rovers.Where(p => p.Id == id).FirstOrDefault();
        }

        [Route("{id}/command")]
        public RoverCommandResponse PostCommand(Guid id, RoverCommandRequest request) {
            RoverCommandResponse response = new RoverCommandResponse();
            response.Rover = DataContext.Rovers.Where(p => p.Id == id).FirstOrDefault();
            if (response.Rover != null) {
                RoverCommander commander = new RoverCommander(response.Rover.Id);
                response.Rover = commander.Execute(request.Commands);
            }

            response.FinalCoordinates = $"{response.Rover.Location.X}, {response.Rover.Location.Y}, {response.Rover.Direction.ToString().ElementAt(0)}";
            return response;
        }

        public CreateRoverResponse Post(CreateRoverRequest request)
        {
            CreateRoverResponse response = new CreateRoverResponse();
            Rover data = new Rover();
            data.Name = request.Name;
            data.Location = request.Location;
            data.PlateauId = request.PlateauId;
            data.Direction = request.Direction;

            try
            {
                DataContext.Rovers.Add(data);
                response.Data = data;
                return (CreateRoverResponse)response.ReturnWithSuccess();
            }
            catch (Exception ex)
            {
                return (CreateRoverResponse)response.ReturnWithErrors(ex.Message);
            }
        }

        public void Delete(Guid id)
        {
            Rover data = DataContext.Rovers.Where(p => p.Id == id).FirstOrDefault();
            if (data != null)
            {
                DataContext.Rovers.Remove(data);
            }
        }
    }
}