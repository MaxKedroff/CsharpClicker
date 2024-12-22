using CSharpClicker.Web.Domain;
using CSharpClicker.Web.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CSharpClicker.Web.Infrastructure.DataAccess;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IAppDbContext
{
    public DbSet<ApplicationRole> ApplicationRoles { get; private set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; private set; }

    public DbSet<UserAchievement> UserAchievements { get; private set; }

    public DbSet<Achievement> Achievements { get; private set; }

    
    public DbSet<Boost> Boosts { get; private set; }

    public DbSet<UserBoost> UserBoosts { get; private set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserBoost>()
            .HasOne(ub => ub.User)
            .WithMany(u => u.UserBoosts)
            .HasForeignKey(ub => ub.UserId);

        builder.Entity<UserBoost>()
            .HasOne(ub => ub.Boost)
            .WithMany()
            .HasForeignKey(ub => ub.BoostId);

        builder.Entity<UserAchievement>()
                .HasKey(ua => new { ua.UserId, ua.AchievementId });

        builder.Entity<UserAchievement>()
            .HasOne(ua => ua.User)
            .WithMany(u => u.UserAchievements)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserAchievement>()
            .HasOne(ua => ua.Achievement)
            .WithMany()
            .HasForeignKey(ua => ua.AchievementId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
