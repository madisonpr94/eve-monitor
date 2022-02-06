using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

using Eve.Repositories;

namespace Eve.Models
{
    public class AirQuality
    {
        IMeasurementRepository _repository;

        public AirQuality(IMeasurementRepository repository)
        {
            _repository = repository;
        }

        #region Recent average values
        /*
            Returns the recent average temperature.
            Returns a negative temperature if no valid or recent measurements.
            ( If this ever needs to return a negative temperature, we have bigger problems... )
        */
        [JsonInclude]
        public TemperaturePair AverageTemperature
        {
            get
            {
                var recent = _repository.RecentMeasurements;

                if (recent != null && recent.Count() > 0)
                {
                    float avgTemp = recent.Select(x => x.Temperatures).Average(x => x.Celsius);
                    return new TemperaturePair(avgTemp);
                }
                else
                {
                    return new TemperaturePair(-1.0f);
                }
            }
        }

        /*
            Returns the recent average humidity.
            Returns a negative value if no valid / recent measurements.
        */
        [JsonInclude]
        public float AverageHumidity
        {
            get
            {
                var recent = _repository.RecentMeasurements;

                if (recent != null && recent.Count() > 0)
                {
                    float avgHumidity = recent.Select(x => x.Humidity).Average();
                    return avgHumidity;
                }
                else
                {
                    return -1.0f;
                }
            }
        }

        /*
            Returns the recent average CO2 measurement.
            Returns a negative value if no valid / recent measurements.
        */
        [JsonInclude]
        public int AverageCO2
        {
            get
            {
                var recent = _repository.RecentMeasurements;

                if (recent != null && recent.Count() > 0)
                {
                    int avgCO2 = (int)Math.Round(recent.Select(x => x.CO2).Average());
                    return avgCO2;
                }
                else
                {
                    return -1;
                }
            }
        }
        #endregion
        #region Historic values - last 24 hours
        public IEnumerable<Measurement> TodaysMeasurements
        {
            get
            {
                var today = _repository.TodaysMeasurementsByHour;

                return today;
            }
        }
        #endregion
        #region Historic values - last 30 days

        #endregion
        #region Historic values - last year

        #endregion
    }
}
