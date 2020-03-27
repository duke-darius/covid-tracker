using System;
using System.Collections.Generic;
using System.Text;
using covid_tracker.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace covid_tracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }




        public DbSet<DataPoint> DataPoints { get; set; }
        public DbSet<DataActivity> DataActivities { get; set; }
        public DbSet<DataActivityPoint> DataActivityPoints { get; set; }
        public DbSet<covid_tracker.Data.Models.DataSet> DataSet { get; set; }

    }
}
