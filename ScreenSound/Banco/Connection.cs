using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class Connection
    {
        private string connectionString = "Server=DESKTOP-7JU3SNC\\SQLSERVER2022;Database=ScreenSound;Trusted_Connection=True;TrustServerCertificate=True;";

        //vamos fazer um método para abrir a conexão com o banco
        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }
    }
}
