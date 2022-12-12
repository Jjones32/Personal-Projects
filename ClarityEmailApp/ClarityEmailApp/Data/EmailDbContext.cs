using Microsoft.EntityFrameworkCore;

namespace ClarityEmailApp.Data;

public partial class EmailDbContext : DbContext
{

    public EmailDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Email> Emails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Sender);
            entity.Property(e => e.Recipient);
            entity.Property(e => e.Subject);
            entity.Property(e => e.Body);
            entity.Property(e => e.Date);

        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}






/*entity.HasData(new Email
            {  //HardCoded example/ constant
                Id = 1,
                Sender= "jakejones@gmail.com",
                Recipient= "tara.rolfson94@ethereal.email",
                Subject= "Test1 ",
                Body= "First offical test hard coded in MVC"
            });*/