using Libriary_DAL.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_DAL.Data
{
    public class UserSeed(ModelBuilder modelBuilder)
    {
        private readonly ModelBuilder _modelBuilder = modelBuilder;

        public void Seed()
        {
            var adminRoleId = Guid.NewGuid().ToString();
            var userRoleId = Guid.NewGuid().ToString();

            AddRoles(adminRoleId, userRoleId);

            var adminId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();

            AddTestData(adminId, userId);

            GrantRole(adminRoleId, adminId);
            GrantRole(userRoleId, userId);
        }

        private void AddRoles(string adminRoleId, string userRoleId)
        {
            _modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "USER"
                });
        }

        private void AddTestData(string adminId, string userId)
        {
            var passwordHasher = new PasswordHasher<User>();

            var adminUser = new User
            {
                Id = adminId,
                Email = "admin@admin.com",
                EmailConfirmed = true,
                UserName = "AdminTest",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMINTEST",
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "9100");

            var regularUser = new User
            {
                Id = userId,
                Email = "user@user.com",
                EmailConfirmed = false,
                UserName = "Man I Love Frogs",
                NormalizedUserName = "MAN I LOVE FROGS",
                NormalizedEmail = "USER@USER.COM"
            };
            regularUser.PasswordHash = passwordHasher.HashPassword(regularUser, "MILF");

            _modelBuilder.Entity<User>().HasData(
                adminUser,
                regularUser);
        }

        private void GrantRole(string roleId, string userId)
        {
            _modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = roleId,
                    UserId = userId
                });
        }
    }
}
