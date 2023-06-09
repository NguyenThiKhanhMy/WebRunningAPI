using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Migrations
{
    public partial class updateurlanh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "URL_Anh",
                table: "Por_Anhs",
                type: "character varying(155)",
                maxLength: 155,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(55)",
                oldMaxLength: 55,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "URL_Anh",
                table: "Por_Anhs",
                type: "character varying(55)",
                maxLength: 55,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(155)",
                oldMaxLength: 155,
                oldNullable: true);
        }
    }
}
