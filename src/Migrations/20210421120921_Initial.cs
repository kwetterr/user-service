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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                values: new object[,]
                {
                    { "feabb8fb-6d8c-48a4-b060-e02c66b25405", "https://cdn.pixabay.com/photo/2018/08/28/12/41/avatar-3637425_1280.png", "Zit hier voor de fun, voor de gezelligheid, voor de humor, beetje slap ouwehoeren, als ik gemekker wil koop ik wel een geit.", "NL", "aron@email.com", "Aron Heesakkers", "5.iSz3oLa2gaAw3sjTUjHG7A==.cXtCflhoIMH2+jka0xFhjHZenRDlgQW5UbiK4zxaOyo=", "ADMIN", "AronKwats" },
                    { "c30fa353-d4e2-4b72-bbcf-0cd963763316", null, null, "NL", "jaap@email.com", "Jaap van der Meer", "5.iSz3oLa2gaAw3sjTUjHG7A==.cXtCflhoIMH2+jka0xFhjHZenRDlgQW5UbiK4zxaOyo=", "MODERATOR", "Jaapie98" },
                    { "25853618-ef7b-44e8-aec2-bc7dae97498b", null, null, "NL", "sverre@email.com", "Sverre van Gompel", "5.iSz3oLa2gaAw3sjTUjHG7A==.cXtCflhoIMH2+jka0xFhjHZenRDlgQW5UbiK4zxaOyo=", "USER", "SverrieBoy" },
                    { "61e1b100-6626-4aa0-b15b-53a1fe5503ec", null, null, "NL", "tim@email.com", "Tim la Haije", "5.iSz3oLa2gaAw3sjTUjHG7A==.cXtCflhoIMH2+jka0xFhjHZenRDlgQW5UbiK4zxaOyo=", "USER", "Timothy" },
                    { "5685180c-a18e-4fc9-9d79-985f85b8fc1d", null, null, "NL", "dirk@email.com", "Dirk van de Waerden", "5.iSz3oLa2gaAw3sjTUjHG7A==.cXtCflhoIMH2+jka0xFhjHZenRDlgQW5UbiK4zxaOyo=", "USER", "Dirkvdw" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
