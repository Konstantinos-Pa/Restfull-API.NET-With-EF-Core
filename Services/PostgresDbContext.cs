using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Assignment.Service
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {
        }
        // Define your DbSets here
        // public DbSet<YourEntity> YourEntities { get; set; }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CandidatesAnalytics> CandidatesAnalytics { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<PhotoId> photoIds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
