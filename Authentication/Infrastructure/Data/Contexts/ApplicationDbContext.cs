using Microsoft.EntityFrameworkCore;
using Authentication.Domain.Entities;

namespace Authentication.Infrastructure.Data.Contexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> users { get; set; }
    //public DbSet<RefreshToken> refreshTokens { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //// Configuring the User-RefreshToken relationship
        //modelBuilder.Entity<RefreshToken>(entity =>
        //{
        //    // Explicitly setting UserId as the primary key
        //    entity.HasKey(rt => rt.UserId);

        //    // Configuring the one-to-one relationship
        //    entity.HasOne(rt => rt.User)
        //          .WithOne(u => u.RefreshToken)
        //          .HasForeignKey<RefreshToken>(rt => rt.UserId);
        //});

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.RefreshToken)
                  .IsRequired(false);

            entity.Property(e => e.ExpireDate)
                 .IsRequired(false);
        });
    }
}