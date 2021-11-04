using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FavoriteMaster.Models
{

    public class WeatherContext : DbContext
    {
        public DbSet<WeatherForecast> Weather { get; set; }
      
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
            //  Database.EnsureDeleted();

            Database.EnsureCreated();
        }
       
    }
}
