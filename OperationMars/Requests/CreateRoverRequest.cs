using OperationMars.Models;
using System;
using System.Drawing;

namespace OperationMars.Requests
{
    public class CreateRoverRequest
    {
        public string Name { get; set; }
        public Guid PlateauId { get; set; }
        public Point Location { get; set; }
        public Direction Direction { get; set; }
    }
}