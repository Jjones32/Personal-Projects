using ClarityAssesmentEmail.Models;
using Microsoft.EntityFrameworkCore;

namespace ClarityAssesmentEmail.Data
{
    public class EmailDbContext : DbContext
    {
        public EmailDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Sender);
                entity.Property(e => e.Recipient);
                entity.Property(e => e.Subject);
                entity.Property(e => e.Body);

            });
        }

    }
}   
