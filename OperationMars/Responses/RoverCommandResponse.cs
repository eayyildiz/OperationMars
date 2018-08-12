using OperationMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperationMars.Responses
{
    public class RoverCommandResponse : ResponseBase
    {
        public string FinalCoordinates { get; set; }
        public Rover Rover { get; set; }
    }
}