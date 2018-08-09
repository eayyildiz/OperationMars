using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Windows;

namespace OperationMars.Models
{
    public class Rover
    {
        public Rover() {
            this.Id = Guid.NewGuid();
            this.Location = new Point(0, 0);
            this.Direction = Direction.North;
            this.State = RoverState.Active;
        }

        public Rover(int x, int y) {
            this.Id = Guid.NewGuid();
            this.Location = new Point(x, y);
            this.Direction = Direction.North;
            this.State = RoverState.Active;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PlateauId { get; set; }
        public Point Location { get; set; }
        public Direction Direction { get; set; }
        public RoverState State { get; set; }
    }

    public enum Direction {
        North,
        East,
        South,
        West
    }

    public enum RoverState
    {
        Active,
        OffWork,
        Lost
    }
}