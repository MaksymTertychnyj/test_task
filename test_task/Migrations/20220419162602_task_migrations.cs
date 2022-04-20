using Microsoft.EntityFrameworkCore.Migrations;

namespace test_task.Migrations
{
    public partial class task_migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "incidents",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidents", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IncidentName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Name);
                    table.ForeignKey(
                        name: "FK_accounts_incidents_IncidentName",
                        column: x => x.IncidentName,
                        principalTable: "incidents",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Email);
                    table.ForeignKey(
                        name: "FK_contacts_accounts_AccountName",
                        column: x => x.AccountName,
                        principalTable: "accounts",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_IncidentName",
                table: "accounts",
                column: "IncidentName");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_Name",
                table: "accounts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contacts_AccountName",
                table: "contacts",
                column: "AccountName");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_Email",
                table: "contacts",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "incidents");
        }
    }
}
