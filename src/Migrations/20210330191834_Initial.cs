using Microsoft.EntityFrameworkCore.Migrations;

namespace kwetter_authentication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Biography", "Country", "Email", "Name", "Password", "Role", "Username" },
                values: new object[] { 1234, null, null, null, "aron@email.com", "Aron Heesakkers", "asdf", "ADMIN", "AronKwats" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Biography", "Country", "Email", "Name", "Password", "Role", "Username" },
                values: new object[] { 12345, null, null, null, "aron@email.com", "Aron Heesakkers", "asdf", "ADMIN", "AronKwats" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
