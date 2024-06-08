using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoralSafe.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CORALSAFE_ONG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_ONG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ENDERECO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ESTADO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TELEFONE_ONG = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EMAIL_ONG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CORALSAFE_ONG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_CORALSAFE_PRODUTOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    QUANTIDADE_PONTOS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CORALSAFE_PRODUTOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_CORALSAFE_USUARIO",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name_Usuario = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha_Do_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status_Usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Data_Cadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Pontos = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CORALSAFE_USUARIO", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "T_CORALSAFE_CAMPANHA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name_Campanha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao_Camapanha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Valor_Campanha = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    Data_Campanha = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ongId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CORALSAFE_CAMPANHA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_CORALSAFE_CAMPANHA_T_CORALSAFE_ONG_ongId",
                        column: x => x.ongId,
                        principalTable: "T_CORALSAFE_ONG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_CORALSAFE_APOIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Valor_Doado = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    Data_Doacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Id_Doador = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Userid = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CORALSAFE_APOIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_CORALSAFE_APOIO_T_CORALSAFE_USUARIO_Userid",
                        column: x => x.Userid,
                        principalTable: "T_CORALSAFE_USUARIO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_CORALSAFE_APOIO_Userid",
                table: "T_CORALSAFE_APOIO",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_T_CORALSAFE_CAMPANHA_ongId",
                table: "T_CORALSAFE_CAMPANHA",
                column: "ongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CORALSAFE_APOIO");

            migrationBuilder.DropTable(
                name: "T_CORALSAFE_CAMPANHA");

            migrationBuilder.DropTable(
                name: "T_CORALSAFE_PRODUTOS");

            migrationBuilder.DropTable(
                name: "T_CORALSAFE_USUARIO");

            migrationBuilder.DropTable(
                name: "T_CORALSAFE_ONG");
        }
    }
}
