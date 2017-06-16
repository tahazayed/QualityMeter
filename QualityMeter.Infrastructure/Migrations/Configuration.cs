using QualityMeter.Core.Models;
using System.Linq;

namespace QualityMeter.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<QualityMeter.Infrastructure.Data.EfQualityMeterBaseDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(QualityMeter.Infrastructure.Data.EfQualityMeterBaseDb context)
        {
            //create roles
            context.Roles.AddOrUpdate(u => u.Roles,
                new Role
                {
                    Roles = "Admin",
                    IsSystem = true
                },
                new Role
                {
                    Roles = "Auditor",
                    IsSystem = true
                }
            );
            //create admin user
            context.Users.AddOrUpdate(u => u.UserName, new User
            {
                Active = true,
                Password = "RG9uJ3RMb2dpbg==-bzwUvvK6shM=", //Don'tLogin
                UserName = "Admin",
                IsSystem = true
            },
             new User
             {
                 Active = true,
                 Password = "RG9uJ3RMb2dpbg==-bzwUvvK6shM=", //Don'tLogin
                 UserName = "Auditor",
                 IsSystem = true
             });

            context.SaveChanges();

            var adminRole = (from r in context.Roles
                             where r.Roles == "Admin"
                             select r).SingleOrDefault();
            var auditorRole = (from r in context.Roles
                               where r.Roles == "Auditor"
                               select r).SingleOrDefault();

            var adminUser = (from r in context.Users
                             where r.UserName == "Admin"
                             select r).SingleOrDefault();
            var auditorUser = (from r in context.Users
                               where r.UserName == "Auditor"
                               select r).SingleOrDefault();
            context.UserRoles.AddOrUpdate(r => new { r.RoleId, r.UserId }, new UserRole
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id
            }
            , new UserRole
            {
                RoleId = auditorRole.Id,
                UserId = auditorUser.Id
            });
            context.SaveChanges();
        }
    }
}
