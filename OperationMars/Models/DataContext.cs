using System.Collections.Generic;

namespace OperationMars.Models
{
    static public class DataContext
    {

        static DataContext() {
            Plateaus = new List<Plateau>();
            Rovers = new List<Rover>();
        }

        public static List<Plateau> Plateaus { get; set; }

        public static List<Rover> Rovers { get; set; }
    }
}