using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL;

public class UsersContext : IdentityDbContext<CustomUser>
{
    public UsersContext(DbContextOptions<UsersContext> options)
       : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<CustomUser>().ToTable("Users");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UsersClaims");
    }
}
