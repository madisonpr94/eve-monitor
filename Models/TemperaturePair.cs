using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Eve.Models
{
    public class TemperaturePair
    {
        public TemperaturePair() { }
        public TemperaturePair(float tempInC) { InnerTemp = tempInC; }

        // Backing value
        public float InnerTemp = 0.0f;

        [JsonInclude]
        public float Celsius { get { return InnerTemp; } }
        [JsonInclude]
        public float Fahrenheit
        {
            get
            {
                return (InnerTemp * 9.0f / 5.0f) + 32.0f;
            }
        }
    }
}