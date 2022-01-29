using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Eve.Models;

namespace Eve.Repositories
{
    public class MeasurementContext : DbContext
    {
        public DbSet<Measurement> Measurements { get; set; }

        public string DbPath { get; }

        public MeasurementContext(IConfiguration configuration)
        {
            DbPath = configuration["Data:DbConnection:Path"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class MeasurementRepository : IMeasurementRepository
    {
        IConfiguration _configuration;
        MeasurementContext _context;

        public MeasurementRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _context = new MeasurementContext(configuration);
        }

        public int Count {
            get {
                return _context.Measurements.Count();
            }
        }

        public IEnumerable<Measurement> RecentMeasurements {
            get {
                var recentTime = DateTime.UtcNow.AddMinutes(-15);
                return _context.Measurements.Where(x => 
                    DateTime.Compare(x.Timestamp, recentTime) >= 0);
            }
        }

        public IEnumerable<HourlyMeasurement> TodaysMeasurementsByHour {
            get {
                var yesterday = DateTime.UtcNow.AddDays(-1);
                var now = DateTime.UtcNow;

                return _context.Measurements.AsEnumerable()
                        .GroupBy(x => x.Timestamp.Hour)
                        .Select(x => new HourlyMeasurement {
                            Hour = $"{x.Key}:00",
                            Temp = x.Average(y => y.Temp),
                            Humidity = x.Average(y => y.Humidity),
                            CO2 = (int)Math.Round(x.Average(y => y.CO2))
                        });
            }
        }
    }
}