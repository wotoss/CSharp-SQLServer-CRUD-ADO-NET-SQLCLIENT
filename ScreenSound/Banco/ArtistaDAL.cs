using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        //trazer os dados listados
        public IEnumerable<Artista> Listar()
        {
            //criamos uma lista 
            var lista = new List<Artista>();
            //fazendo a conecção com o banco
            using var connection = new Connection().ObterConexao();
            connection.Open();

            /*passando o script de sql
              se passamos (*) vem todos os campos 
              então podemos (personalizar) e trazer
              somente os campos que fazem "sentido" no filtro.*/
            string sql = "SELECT * FROM Artistas";
            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader dataReader = command.ExecuteReader();

            //atraves deste while vamos fazer a leitura das informações
            while (dataReader.Read())
            {
                string nomeArtista = Convert.ToString(dataReader["Nome"]);
                string bioArtista = Convert.ToString(dataReader["Bio"]);
                int idArtista = Convert.ToInt32(dataReader["Id"]);

                //vamos criar o nosso artistas
                Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };
                //vamos adicona-lo na lista o nosso artista.
                lista.Add(artista);
            }
            //vamos retornar a nossa lista de artistas
            return lista;
        }
        //criar o inlclui add
        public void Adicionar(Artista artista)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            //vamos fazer o insert das informações do artistas 
            //das informações nos campos que eu tenho na tabela
            string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) Values (@nome, @fotoPerfil, @bio)";
            SqlCommand command = new SqlCommand(sql, connection);
            //vamos montar a inserção com paramentros
            //mapeamos qual informação vai para cada um dos campos ex: "@nome", artista.Nome
            command.Parameters.AddWithValue("@nome", artista.Nome);
            command.Parameters.AddWithValue("@fotoPerfil", artista.FotoPerfil);
            command.Parameters.AddWithValue("@bio", artista.Bio);

            //retorno de linhas "afetas" no adicionar
            int retorno = command.ExecuteNonQuery();

            //mostrar as linhas afetadas
            Console.WriteLine($"Linhas afetadas: {retorno}");
            
        }

        //Atualizar 
        public void Atualizar(Artista artista)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            //vamos fazer o insert das informações do artistas 
            //das informações nos campos que eu tenho na tabela
            string sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";
            SqlCommand command = new SqlCommand(sql, connection);

            //vamos montar a inserção com paramentros
            //mapeamos qual informação vai para cada um dos campos ex: "@nome", artista.Nome
            command.Parameters.AddWithValue("@nome", artista.Nome);
            command.Parameters.AddWithValue("@bio", artista.Bio);
            command.Parameters.AddWithValue("@id", artista.Id);

            //retorno de linhas "afetas" no adicionar
            int retorno = command.ExecuteNonQuery();

            //mostrar as linhas afetadas
            Console.WriteLine($"Linhas afetadas: {retorno}");
        }

        //Delete / Excluir
        public void Deletar(Artista artista)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "Delete FROM Artistas WHERE Id = @id";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", artista.Id);

            int delete = command.ExecuteNonQuery();

            Console.WriteLine($"Linhas afetadas {delete}");
        }
    }
}
