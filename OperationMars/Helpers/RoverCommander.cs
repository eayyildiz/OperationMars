using OperationMars.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace OperationMars.Helpers
{
    public class RoverCommander
    {
        private Rover Rover;
        private Point TopRight;

        public RoverCommander(Guid RoverId) {
            Rover = DataContext.Rovers.Where(r => r.Id == RoverId).FirstOrDefault();
            if (Rover == null) {
                throw new Exception("Rover not found");
            }
            TopRight = DataContext.Plateaus.Where(p => p.Id == Rover.PlateauId).FirstOrDefault().TopRight;

        }

        public Rover Execute(string Commands) {
            try
            {
                while (!String.IsNullOrEmpty(Commands))
                {

                    ExecuteSingleCommand(Commands.First());
                    Commands = Commands.Remove(0, 1);
                }
                return Rover;
            }
            catch {
                return Rover;
            }

        }

        protected void ExecuteSingleCommand(char Command) {
            if (Command == 'L')
                TurnLeft();
            else if (Command == 'R')
                TurnRight();
            else if (Command == 'M')
                Move();
            else
                throw new Exception("Invalid Command");
        }

        protected void TurnLeft() {
            switch (Rover.Direction) {
                case Direction.East:
                    Rover.Direction = Direction.North;
                    break;
                case Direction.North:
                    Rover.Direction = Direction.West;
                    break;
                case Direction.West:
                    Rover.Direction = Direction.South;
                    break;
                case Direction.South:
                    Rover.Direction = Direction.East;
                    break;
            }
        }

        protected void TurnRight() {
            switch (Rover.Direction)
            {
                case Direction.East:
                    Rover.Direction = Direction.South;
                    break;
                case Direction.South:
                    Rover.Direction = Direction.West;
                    break;
                case Direction.West:
                    Rover.Direction = Direction.North;
                    break;
                case Direction.North:
                    Rover.Direction = Direction.East;
                    break;
            }
        }

        protected void Move() {
            Point newLocation = new Point(0,0);
            switch (Rover.Direction)
            {
                case Direction.East:
                    newLocation = new Point(Rover.Location.X + 1, Rover.Location.Y);
                    break;
                case Direction.South:
                    newLocation = new Point(Rover.Location.X, Rover.Location.Y - 1);
                    break;
                case Direction.West:
                    newLocation = new Point(Rover.Location.X - 1, Rover.Location.Y);
                    break;
                case Direction.North:
                    newLocation = new Point(Rover.Location.X, Rover.Location.Y + 1);
                    break;
            }

            if (newLocation.X < 0 || newLocation.Y < 0 ||
                newLocation.X > TopRight.X || newLocation.Y > TopRight.Y)
            {
                Rover.State = RoverState.Lost;
                throw new Exception("Rover Lost");
            }

            Rover collapsedRover = DataContext.Rovers.Where(r => r.Location == newLocation).FirstOrDefault();
            if (collapsedRover != null) {
                Rover.State = RoverState.OffWork;
                throw new Exception("Rovers Collapsed");
            }

            Rover.Location = newLocation;
        }
    }
}