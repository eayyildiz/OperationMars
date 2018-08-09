using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace OperationMars.Models
{
    public class Plateau
    {
        public Plateau() {
            this.Id = Guid.NewGuid();
            Grid = new int[10, 10];
            TopRight = new Point(10, 10);
        }
        public Plateau(int x, int y) {
            this.Id = Guid.NewGuid();
            Grid = new int[x, y];
            TopRight = new Point(x, y);
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int[,] Grid { get; set; }
        public Point TopRight { get; set; }
    }
}