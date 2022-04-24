using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Infrastructure.Persistence.Migrations
{
    public partial class requestResponseLogEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestResponseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifedBy = table.Column<string>(nullable: true),
                    LastModifedDate = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    RequestData = table.Column<string>(nullable: true),
                    ResponseData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestResponseLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestResponseLogs");
        }
    }
}
