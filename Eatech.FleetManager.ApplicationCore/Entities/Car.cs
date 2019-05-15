using System;

namespace Eatech.FleetManager.ApplicationCore.Entities
{
    public class Car
    {
        public Guid Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Registration { get; set; }

        public int Year { get; set; }

        public DateTime InspectionDate { get; set; }

        public double EngineSize { get; set; }

        public double EnginePower { get; set; }

    }
}