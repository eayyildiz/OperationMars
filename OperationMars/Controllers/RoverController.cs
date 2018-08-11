using OperationMars.Models;
using OperationMars.Requests;
using OperationMars.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OperationMars.Controllers
{
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

        [Route("api/rover/{id}/test")]
        public Rover GetTest(Guid id) {
            return DataContext.Rovers.Where(p => p.Id == id).FirstOrDefault();
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