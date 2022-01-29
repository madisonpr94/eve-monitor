using System;
using System.ComponentModel.DataAnnotations;

namespace Eve.Models
{
    public class Measurement
    {
        [Key]
        public int RowId { get; set; }
        public DateTime Timestamp { get; set; }
        public int CO2 { get; set; }
        public float Temp { get; set; }
        public float Humidity { get; set; }
    }
}