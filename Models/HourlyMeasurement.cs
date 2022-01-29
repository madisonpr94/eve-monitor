using System;

namespace Eve.Models
{
    public class HourlyMeasurement
    {
        public string Hour { get; set; }
        public int CO2 { get; set; }
        public float Temp { get; set; }
        public float Humidity { get; set; }
    }
}