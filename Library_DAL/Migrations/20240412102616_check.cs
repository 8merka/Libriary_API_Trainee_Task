using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libriary_DAL.Migrations
{
    /// <inheritdoc />
    public partial class check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7227354e-9652-4cdc-8d36-c95e3d7952e3", "39e5d882-14a3-4a75-9e7f-bff9afff6cc8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce7fb4c4-0d8f-4a01-8e93-112799b504ac", "cb189d32-e29f-4ebf-b0a8-b4ce3c87e038" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7227354e-9652-4cdc-8d36-c95e3d7952e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce7fb4c4-0d8f-4a01-8e93-112799b504ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39e5d882-14a3-4a75-9e7f-bff9afff6cc8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb189d32-e29f-4ebf-b0a8-b4ce3c87e038");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ac01ff7-758b-4473-a9af-1e81751ed35f", "4ac01ff7-758b-4473-a9af-1e81751ed35f", "Admin", "ADMIN" },
                    { "c26cb0fe-1797-424a-9ec2-3f1c255e8dc9", "c26cb0fe-1797-424a-9ec2-3f1c255e8dc9", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpireTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "752f36de-2222-4226-8c1a-0a84958a1e76", 0, "91355e9d-78b7-4b23-ba1c-0732f5490e4f", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMINTEST", "AQAAAAIAAYagAAAAEKo11kTE0prGLMev0lvBH/FlukCKctV3UIhA6IX+9hyG8xzLDBbzFSAhvDlrjvjKQw==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9ec84b27-fe66-4e5d-8d45-e0583c1d885c", false, "AdminTest" },
                    { "f8278f3b-248e-4913-92f8-f1de8d704205", 0, "1aaa31ef-63bd-4ab1-9964-f1185b3a9573", "user@user.com", false, false, null, "USER@USER.COM", "MAN I LOVE FROGS", "AQAAAAIAAYagAAAAEJZ6eXf7lmun0yi2CowhepZX+FJxqHjwQkYxEcQ9amZ1ySTm3IIhSguF4ZGtvmjQ+w==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eca087f2-195a-4a9c-ad09-2726b76db5b1", false, "Man I Love Frogs" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4ac01ff7-758b-4473-a9af-1e81751ed35f", "752f36de-2222-4226-8c1a-0a84958a1e76" },
                    { "c26cb0fe-1797-424a-9ec2-3f1c255e8dc9", "f8278f3b-248e-4913-92f8-f1de8d704205" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ac01ff7-758b-4473-a9af-1e81751ed35f", "752f36de-2222-4226-8c1a-0a84958a1e76" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c26cb0fe-1797-424a-9ec2-3f1c255e8dc9", "f8278f3b-248e-4913-92f8-f1de8d704205" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ac01ff7-758b-4473-a9af-1e81751ed35f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c26cb0fe-1797-424a-9ec2-3f1c255e8dc9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "752f36de-2222-4226-8c1a-0a84958a1e76");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8278f3b-248e-4913-92f8-f1de8d704205");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7227354e-9652-4cdc-8d36-c95e3d7952e3", "7227354e-9652-4cdc-8d36-c95e3d7952e3", "User", "USER" },
                    { "ce7fb4c4-0d8f-4a01-8e93-112799b504ac", "ce7fb4c4-0d8f-4a01-8e93-112799b504ac", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpireTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "39e5d882-14a3-4a75-9e7f-bff9afff6cc8", 0, "e9e3d236-0344-4cf0-88df-30300bab10fb", "user@user.com", false, false, null, "USER@USER.COM", "MAN I LOVE FROGS", "AQAAAAIAAYagAAAAEKbAivBt7SlHZ8EQ1ix7/ipwRy+4v0LmDi1P/8m4mHVLvtjPoOXwOaiwCFR1h3FdFw==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "be87b51a-56e2-4caa-a2ba-c99d6bcb246b", false, "Man I Love Frogs" },
                    { "cb189d32-e29f-4ebf-b0a8-b4ce3c87e038", 0, "6166955f-fe62-49a4-a73b-db5a077ced51", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMINTEST", "AQAAAAIAAYagAAAAEIwQIVo5DWAk+aILj0zfsx33G++ds6BxZRYwew2mMdX32aRFb02YEPeYMnrhyOfZIw==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b955b794-c758-4029-9bfb-6be22f67d8b7", false, "AdminTest" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7227354e-9652-4cdc-8d36-c95e3d7952e3", "39e5d882-14a3-4a75-9e7f-bff9afff6cc8" },
                    { "ce7fb4c4-0d8f-4a01-8e93-112799b504ac", "cb189d32-e29f-4ebf-b0a8-b4ce3c87e038" }
                });
        }
    }
}
