using System;
using System.Collections.Generic;
using System.Text;

namespace Eatech.FleetManager.ApplicationCore.Entities
{
    public class CarFilter
    {
        public int? YearMin { get; set; }

        public int? YearMax { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

    }
}
