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
    internal class ArtistaORMEntityFramework
    {
        //vamos criar um campo context
        private readonly ScreenSoundContext context;

        public ArtistaORMEntityFramework(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<Artista> Listar()
        {
            //Com o ( ORM - Entity Framework ) substituimos mais de 10 linhas
            //do mesmo listar ( AdoNet ) por ( 2 linhas do ORM-Entity Framework )
            var lista = context.Artistas.ToList();
        
            return lista;
        }
        //criar o inlclui add
        public void Adicionar(Artista artista)
        {
            //Ao fazer o Adicionar com o ( ORM - Entity Framework )
            var retorno = context.Artistas.Add(artista);
            context.SaveChanges();
            
        }

        //Atualizar 
        public void Atualizar(Artista artista)
        {
            //Com o ( ORM - Entity Framework ) substituimos mais de 10 linhas
            //do mesmo listar ( AdoNet ) por ( 2 linhas do ORM-Entity Framework )
            context.Artistas.Update(artista);
            //como estamos fazendo alterações em nossa tabela
            //precisamos passar - SaveChanges();
            context.SaveChanges();
        }

        //Delete / Excluir
        public void Deletar(Artista artista)
        {
            context.Artistas.Remove(artista);
            context.SaveChanges();
        }

        //recuperar pelo nome
        public Artista RecuperadoPeloNome(string nomeDoArtista)
        {
            var nomeRecuperado = context.Artistas.FirstOrDefault(x => x.Nome == nomeDoArtista);
           
            return nomeRecuperado;

        }
    }
}
