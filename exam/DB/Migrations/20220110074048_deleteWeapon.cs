using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class deleteWeapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weapon",
                table: "Monsters");

            migrationBuilder.AlterColumn<string>(
                name: "Damage",
                table: "Monsters",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttackModifier", "AttackPerRound", "Damage", "DamageModifier" },
                values: new object[] { 4, 1, "1d10", 1 });

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttackPerRound", "Damage", "DamageModifier" },
                values: new object[] { 2, "11d8", 4 });

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttackPerRound", "Damage", "DamageModifier" },
                values: new object[] { 1, "2d10", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Damage",
                table: "Monsters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Weapon",
                table: "Monsters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttackModifier", "AttackPerRound", "Damage", "DamageModifier", "Weapon" },
                values: new object[] { 5, 2, 6, 8, 15 });

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttackPerRound", "Damage", "DamageModifier", "Weapon" },
                values: new object[] { 11, 13, 8, 4 });

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttackPerRound", "Damage", "DamageModifier", "Weapon" },
                values: new object[] { 2, 7, 6, 2 });
        }
    }
}
