using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoralSafe.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_CORALSAFE_APOIO_T_CORALSAFE_USUARIO_Userid",
                table: "T_CORALSAFE_APOIO");

            migrationBuilder.DropForeignKey(
                name: "FK_T_CORALSAFE_CAMPANHA_T_CORALSAFE_ONG_ongId",
                table: "T_CORALSAFE_CAMPANHA");

            migrationBuilder.DropIndex(
                name: "IX_T_CORALSAFE_APOIO_Userid",
                table: "T_CORALSAFE_APOIO");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "T_CORALSAFE_APOIO");

            migrationBuilder.RenameColumn(
                name: "ongId",
                table: "T_CORALSAFE_CAMPANHA",
                newName: "OngId");

            migrationBuilder.RenameIndex(
                name: "IX_T_CORALSAFE_CAMPANHA_ongId",
                table: "T_CORALSAFE_CAMPANHA",
                newName: "IX_T_CORALSAFE_CAMPANHA_OngId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "T_CORALSAFE_PRODUTOS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "TELEFONE_ONG",
                table: "T_CORALSAFE_ONG",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<long>(
                name: "CNPJ",
                table: "T_CORALSAFE_ONG",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.CreateIndex(
                name: "IX_T_CORALSAFE_PRODUTOS_UserId",
                table: "T_CORALSAFE_PRODUTOS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_T_CORALSAFE_APOIO_Id_Doador",
                table: "T_CORALSAFE_APOIO",
                column: "Id_Doador");

            migrationBuilder.AddForeignKey(
                name: "FK_T_CORALSAFE_APOIO_T_CORALSAFE_USUARIO_Id_Doador",
                table: "T_CORALSAFE_APOIO",
                column: "Id_Doador",
                principalTable: "T_CORALSAFE_USUARIO",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_CORALSAFE_CAMPANHA_T_CORALSAFE_ONG_OngId",
                table: "T_CORALSAFE_CAMPANHA",
                column: "OngId",
                principalTable: "T_CORALSAFE_ONG",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_CORALSAFE_PRODUTOS_T_CORALSAFE_USUARIO_UserId",
                table: "T_CORALSAFE_PRODUTOS",
                column: "UserId",
                principalTable: "T_CORALSAFE_USUARIO",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_CORALSAFE_APOIO_T_CORALSAFE_USUARIO_Id_Doador",
                table: "T_CORALSAFE_APOIO");

            migrationBuilder.DropForeignKey(
                name: "FK_T_CORALSAFE_CAMPANHA_T_CORALSAFE_ONG_OngId",
                table: "T_CORALSAFE_CAMPANHA");

            migrationBuilder.DropForeignKey(
                name: "FK_T_CORALSAFE_PRODUTOS_T_CORALSAFE_USUARIO_UserId",
                table: "T_CORALSAFE_PRODUTOS");

            migrationBuilder.DropIndex(
                name: "IX_T_CORALSAFE_PRODUTOS_UserId",
                table: "T_CORALSAFE_PRODUTOS");

            migrationBuilder.DropIndex(
                name: "IX_T_CORALSAFE_APOIO_Id_Doador",
                table: "T_CORALSAFE_APOIO");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "T_CORALSAFE_PRODUTOS");

            migrationBuilder.RenameColumn(
                name: "OngId",
                table: "T_CORALSAFE_CAMPANHA",
                newName: "ongId");

            migrationBuilder.RenameIndex(
                name: "IX_T_CORALSAFE_CAMPANHA_OngId",
                table: "T_CORALSAFE_CAMPANHA",
                newName: "IX_T_CORALSAFE_CAMPANHA_ongId");

            migrationBuilder.AlterColumn<int>(
                name: "TELEFONE_ONG",
                table: "T_CORALSAFE_ONG",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)");

            migrationBuilder.AlterColumn<int>(
                name: "CNPJ",
                table: "T_CORALSAFE_ONG",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)");

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "T_CORALSAFE_APOIO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_T_CORALSAFE_APOIO_Userid",
                table: "T_CORALSAFE_APOIO",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_T_CORALSAFE_APOIO_T_CORALSAFE_USUARIO_Userid",
                table: "T_CORALSAFE_APOIO",
                column: "Userid",
                principalTable: "T_CORALSAFE_USUARIO",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_CORALSAFE_CAMPANHA_T_CORALSAFE_ONG_ongId",
                table: "T_CORALSAFE_CAMPANHA",
                column: "ongId",
                principalTable: "T_CORALSAFE_ONG",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
