using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS1ProjectTeam01
{
    [Serializable()]
    public class Car
    {
        public string Make { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal EngineSize { get; set; } // in litres
        public int Price { get; set; } // in dollars
        public string Dealer { get; set; } // dealer selling the car
        public Car() { }
    }
}
