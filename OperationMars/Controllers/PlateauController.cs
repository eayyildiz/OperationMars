using OperationMars.Models;
using OperationMars.Requests;
using OperationMars.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OperationMars.Controllers
{
    public class PlateauController : ApiController
    {

        public IEnumerable<Plateau> Get()
        {
            return DataContext.Plateaus;   
        }

        public Plateau Get(Guid id)
        {
            return DataContext.Plateaus.Where(p => p.Id == id).FirstOrDefault();
        }

        public CreatePlateauResponse Post(CreatePlateauRequest request)
        {
            CreatePlateauResponse response = new CreatePlateauResponse();
            Plateau data = (request.TopRightAxis.HasValue && request.TopRightOrdinate.HasValue) ?
                            new Plateau(request.TopRightAxis.Value, request.TopRightOrdinate.Value):
                            new Plateau();
            data.Name = request.Name;
            try
            {
                DataContext.Plateaus.Add(data);
                response.Data = data;
                return (CreatePlateauResponse)response.ReturnWithSuccess();
            }
            catch (Exception ex) {
                return (CreatePlateauResponse)response.ReturnWithErrors(ex.Message);
            }
        }

        public void Delete(Guid id)
        {
            Plateau data = DataContext.Plateaus.Where(p => p.Id == id).FirstOrDefault();
            if (data != null) {
                DataContext.Plateaus.Remove(data);
            }
        }
    }
}