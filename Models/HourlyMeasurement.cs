using System;

namespace Eve.Models
{
    public class HourlyMeasurement : Measurement
    {
        public override string FormattedTimestamp {
            get {
                return Timestamp.ToLocalTime().ToString("HH:00");
            }
        }
    }
}