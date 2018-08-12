using System.Collections.Generic;

namespace OperationMars.Models
{
    static public class DataContext
    {

        static DataContext() {
            Plateaus = new List<Plateau>();
            Rovers = new List<Rover>();

            Plateaus.Add(new Plateau {
                Id = new System.Guid("653648ee-6a4b-4a12-ab74-b5f9663b06cd"),
                Name = "PlateauTest",
                TopRight = new System.Drawing.Point(15, 15)
            });

            Rovers.Add(new Rover
            {
                Id = new System.Guid("ac077fdf-ca63-45b2-9c63-74f73383d8c8"),
                Name = "RoverTest",
                PlateauId = new System.Guid("653648ee-6a4b-4a12-ab74-b5f9663b06cd"),
                Direction = Direction.North,
                Location = new System.Drawing.Point(5, 5),
                State = RoverState.Active
            });

            Rovers.Add(new Rover
            {
                Id = new System.Guid("67968965-e69a-420c-a28a-9e7109692140"),
                Name = "RoverTest",
                PlateauId = new System.Guid("653648ee-6a4b-4a12-ab74-b5f9663b06cd"),
                Direction = Direction.North,
                Location = new System.Drawing.Point(10, 10),
                State = RoverState.Active
            });

        }

        public static List<Plateau> Plateaus { get; set; }

        public static List<Rover> Rovers { get; set; }
    }
}