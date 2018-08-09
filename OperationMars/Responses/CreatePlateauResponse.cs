using OperationMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperationMars.Responses
{
    public class CreatePlateauResponse : ResponseBase
    {
        public Plateau Data { get; set; }
    }
}