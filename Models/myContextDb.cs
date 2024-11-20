using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityFaroq.Models
{
    public class myContextDb : IdentityDbContext
    {
        public myContextDb(DbContextOptions<myContextDb> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seeding Roles (User,Admin) Two roles
            var adminroleid = "29968818-b206-4c45-8131-e049915cf58f";
            var userroleId = "f91c5088-df3e-409d-a778-5c3e96fadaca";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = adminroleid,
                    Name = "Admin",
                    NormalizedName = "Admin",
                    ConcurrencyStamp = adminroleid
                },
                new IdentityRole
                {
                    Id = userroleId,
                    Name = "User",
                    NormalizedName = "User",
                    ConcurrencyStamp = userroleId
                }
            };

            //Adding roles in the roles table
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
