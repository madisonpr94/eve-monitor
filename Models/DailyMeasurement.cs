using System;

namespace Eve.Models
{
    public class DailyMeasurement : Measurement
    {
        public override string FormattedTimestamp {
            get {
                return Timestamp.ToLocalTime().ToString("MMM dd");
            }
        }
    }
}