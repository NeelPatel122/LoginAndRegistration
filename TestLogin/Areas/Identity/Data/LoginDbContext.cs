using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestLogin.Areas.Identity.Data;

namespace TestLogin.Areas.Identity.Data;

public class LoginDbContext : IdentityDbContext<TestLoginUser>
{
    public LoginDbContext(DbContextOptions<LoginDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<TestLoginUser>
{
    public void Configure(EntityTypeBuilder<TestLoginUser> builder)
    {
        builder.Property(x=>x.FirstName).HasMaxLength(50);
        builder.Property(x=>x.LastName).HasMaxLength(50);

    }
}