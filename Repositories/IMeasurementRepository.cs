using System.Collections.Generic;

using Eve.Models;

namespace Eve.Repositories
{
    public interface IMeasurementRepository
    {
        public int Count { get; }
        public IEnumerable<Measurement> RecentMeasurements { get; }
        
        public IEnumerable<HourlyMeasurement> DailyMeasurementsByHour { get; }
        public IEnumerable<DailyMeasurement> MonthlyMeasurementsByDay { get; }
    }
}