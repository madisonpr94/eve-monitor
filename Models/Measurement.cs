using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Eve.Models
{
    public class Measurement
    {
        [Key]
        [JsonIgnore]
        public int RowId { get; set; }

        // Inner temperature retrieved from DB - used to create TemperaturePair
        [JsonIgnore]
        public float Temp { get; set; }

#region JSON-included fields
        [JsonInclude]
        public DateTime Timestamp { get; set; }

        [JsonInclude]
        public int CO2 { get; set; }

        [JsonInclude]
        public float Humidity { get; set; }

        [NotMapped]
        [JsonInclude]
        public TemperaturePair Temperatures { get { return new TemperaturePair(Temp); } }

        [NotMapped]
        [JsonInclude]
        public virtual string FormattedTimestamp {
            get {
                return Timestamp.ToShortTimeString();
            }
        }
#endregion
        

    }
}