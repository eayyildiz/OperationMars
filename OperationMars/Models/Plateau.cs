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
            TopRight = new Point(10, 10);
        }
        public Plateau(int x, int y) {
            this.Id = Guid.NewGuid();
            TopRight = new Point(x, y);
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Point TopRight { get; set; }
    }
}