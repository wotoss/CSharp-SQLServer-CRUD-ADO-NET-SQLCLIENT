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
    //veja que diferente do AdoNet neste caso vamos extender do DbContext
    public class ScreenSoundContext : DbContext 
    {
        //(localdb)\MSSQLLocalDB
        private string connectionString = "Server=DESKTOP-7JU3SNC\\SQLSERVER2022;Database=ScreenSoundAnalisandoBd;Trusted_Connection=True;TrustServerCertificate=True;";
        //private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ScreenSound;Trusted_Connection=True;TrustServerCertificate=True;";

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //lembrando que string de conexão(connectionString) pode ir no appsetings
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        //vamos criar o mapeamento da nossa (tabela Artistas) para a classe (conjunto)DbSet<Artista>
        //desta forma o ( ORM - Entity Framework ) consegue indentificar a nossa tabela
        public DbSet<Artista> Artistas { set; get; }  
        public DbSet<Musica> Musicas { set; get; }
    }
}
