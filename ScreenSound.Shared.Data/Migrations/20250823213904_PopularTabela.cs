using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        /// quando nós quisermos "inserir" informações usamos o Up ou seja Update.
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            /*realizando "inserção no banco pela migration".
              em qual tabela vamos adicionar informações
              (tabela, new string[] campos, quais os dados que vamos inserir nas colunas new object[] ).*/
            migrationBuilder.InsertData("Artistas", new string[] {"Nome", "Bio",
                "FotoPerfil"}, new object[] {"Djavan Negro", "Estamos estudando banco de dados",
                "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] {"Woto", 
            "Analise desenvolvimento de sistemas",
            "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png"});

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]{ "Livia Victoria", "Estudante de tecnologia com odontologia",
            "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png"});

        }

        /// <inheritdoc />
        /// quando quisermos dar um downgrade ou seja "apagar as informações da tabela".
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas");
        }
    }
}
