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

        public string RecentAvgTemp {
            get
            {
                var recentMeasurements = _repository.RecentMeasurements;
                if (recentMeasurements.Count() != 0)
                {
                    float avgTemp = recentMeasurements
                        .Select(x => UseFahrenheit ? x.Temperatures.Fahrenheit : x.Temperatures.Celsius)
                        .Average();
                    return Math.Round(avgTemp).ToString("N0") + TempUnit;
                }
                else
                {
                    return "--";
                }
            }
        }
        
        public string RecentAvgHumidity {
            get
            {
                var recentMeasurements = _repository.RecentMeasurements;
                if (recentMeasurements.Count() != 0)
                {
                    return recentMeasurements.Average(x => x.Humidity)
                                                .ToString("N0") + "%";
                }
                else
                {
                    return "--";
                }
            }
        }
        
        public string RecentAvgCO2 {
            get
            {
                var recentMeasurements = _repository.RecentMeasurements;
                if (recentMeasurements.Count() != 0)
                {
                    return recentMeasurements.Average(x => x.CO2)
                                                .ToString("N0") + " ppm CO₂";
                }
                else
                {
                    return "--";
                }
            }
        }

        /*
            Set by the controller with request cookie.
        */
        public bool UseFahrenheit
        {
            get; set;
        } = true;

        /*
            Returns the proper symbol and unit
        */
        public string TempUnit
        {
            get {
                return UseFahrenheit ? "° F" : "° C";
            }
        }

        /*
            Returns a set of graphs representing today's daily trends
        */
        public List<Graph> DailyGraphs
        {
            get
            {
                var measurements = _repository.DailyMeasurementsByHour;

                var hours = measurements.Select(x => x.FormattedTimestamp)
                                        .ToList();
                var tempReadings = measurements.Select(x => x.Temperatures)
                                        .Select(x => UseFahrenheit ? x.Celsius : x.Fahrenheit)
                                        .Select(x => (int)Math.Round(x))
                                        .ToList();
                var co2Readings = measurements.Select(x => x.CO2)
                                        .ToList();
                var humidityReadings = measurements.Select(x => x.Humidity)
                                        .Select(x => (int)Math.Round(x))
                                        .ToList();

                // Create the graph set for rendering
                var dailyGraphs = new List<Graph>();
                
                // Create model for last 24 hours temperature
                dailyGraphs.Add(
                    new Graph() { 
                        Title = "Temperature",
                        LabelValues = hours,
                        DataValues = tempReadings
                    }
                );
                
                // Create model for last 24 hours CO2
                dailyGraphs.Add(
                    new Graph() { 
                        Title = "CO2",
                        LabelValues = hours,
                        DataValues = co2Readings
                    }
                );
                
                // Create model for last 24 hours humidity
                dailyGraphs.Add(
                    new Graph() { 
                        Title = "Humidity",
                        LabelValues = hours,
                        DataValues = humidityReadings
                    }
                );

                return dailyGraphs;
            }
        }

        public float ConvertTempToFahrenheit(float temp)
        {
            return (temp * (9.0f/5)) + 32.0f;
        }
        

        /*
            TODO
        */
        public List<Graph> MonthlyGraphs
        {
            get
            {
                var measurements = _repository.DailyMeasurementsByHour;

                var hours = measurements.Select(x => x.FormattedTimestamp)
                                        .ToList();
                var tempReadings = measurements.Select(x => x.Temperatures)
                                        .Select(x => UseFahrenheit ? x.Celsius : x.Fahrenheit)
                                        .Select(x => (int)Math.Round(x))
                                        .ToList();
                var co2Readings = measurements.Select(x => x.CO2)
                                        .ToList();
                var humidityReadings = measurements.Select(x => x.Humidity)
                                        .Select(x => (int)Math.Round(x))
                                        .ToList();

                // Create the graph set for rendering
                var dailyGraphs = new List<Graph>();
                
                // Create model for last 24 hours temperature
                dailyGraphs.Add(
                    new Graph() { 
                        Title = "Temperature",
                        LabelValues = hours,
                        DataValues = tempReadings
                    }
                );
                
                // Create model for last 24 hours CO2
                dailyGraphs.Add(
                    new Graph() { 
                        Title = "CO2",
                        LabelValues = hours,
                        DataValues = co2Readings
                    }
                );
                
                // Create model for last 24 hours humidity
                dailyGraphs.Add(
                    new Graph() { 
                        Title = "Humidity",
                        LabelValues = hours,
                        DataValues = humidityReadings
                    }
                );

                return dailyGraphs;
            }
        }
        
    }
}