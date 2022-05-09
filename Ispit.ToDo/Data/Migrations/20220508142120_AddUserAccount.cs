using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Ispit.ToDo.Data.Migrations
{
    public partial class AddUserAccount : Migration
    {
        const string USER_GUID = "ee36e8b3-229a-4024-9960-8d39f5bdcf48";
        const string USER_ROLE_GUID = "8a23fc46-03e8-45c2-bc7b-a6ced2d367c3";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            // Lozinka za admin korisnički račun
            var passwordHash = hasher.HashPassword(null, "Password12345"); // Napomena: U praksi postoje bolji načini da se zaštiti ova lozinka

            StringBuilder sb = new StringBuilder();

            
            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp,FirstName)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{USER_GUID}'");
            sb.AppendLine(",'user@user.com'");
            sb.AppendLine(",'USER@USER.COM'");
            sb.AppendLine(",'user@user.com'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(",'USER@USER.COM'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(",'User'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{USER_ROLE_GUID}','User','USER')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{USER_GUID}','{USER_ROLE_GUID}')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
