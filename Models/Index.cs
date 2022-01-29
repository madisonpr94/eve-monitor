using System;
using System.Collections.Generic;

using System.Linq;

using Eve.Repositories;

namespace Eve.Models
{
    public class AirStatistics
    {
        private readonly IMeasurementRepository _repository;

        public AirStatistics(IMeasurementRepository repository)
        {
            _repository = repository;
        }

        public int Count
        {
            get
            {
                return _repository.Count;
            }
        }

        public float RecentAvgTemp {
            get
            {
                var recentMeasurements = _repository.RecentMeasurements;
                if (recentMeasurements.Count() != 0)
                {
                    return recentMeasurements.Average(x => x.Temp);
                }
                else
                {
                    return 0.0f;
                }
            }
        }
        
        public float RecentAvgHumidity {
            get
            {
                var recentMeasurements = _repository.RecentMeasurements;
                if (recentMeasurements.Count() != 0)
                {
                    return recentMeasurements.Average(x => x.Humidity);
                }
                else
                {
                    return 0.0f;
                }
            }
        }
        
        public int RecentAvgCO2 {
            get
            {
                var recentMeasurements = _repository.RecentMeasurements;
                if (recentMeasurements.Count() != 0)
                {
                    return (int)recentMeasurements.Average(x => x.CO2);
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool UseFahrenheit
        {
            get; set;
        } = true;

        public List<Graph> graphs;
        
    }
}