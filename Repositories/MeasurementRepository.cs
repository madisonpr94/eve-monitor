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
    }
}