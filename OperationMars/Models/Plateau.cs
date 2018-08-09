using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperationMars.Models
{
    public class Plateau
    {
        public Plateau() {
            Grid = new int[10, 10];
        }
        public Plateau(int x, int y) {
            Grid = new int[x, y];
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int[,] Grid { get; set; }
    }
}