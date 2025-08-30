using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    /*
     * quando eu coloco uma classe abstract - 
     * siginifica que não quero "criar" nenhum "objeto" desta class
     * uma classe abstrata só server para ser herdada.
     * 
     * Anotação "diamante" <T> que "simboliza" qualquer tipo que tenha 
       em nossa aplicação.
      
       Quando eu faço where T : class estou dizendo que este T será uma classe 
       dentro da nossa aplicação
    */
    internal class DALgenerico<T> where T : class
    {
        //vamos criar um campo context
        protected readonly ScreenSoundContext context;

        public DALgenerico(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }
        public void Adicionar(T objeto)
        {
            //Ao fazer o Adicionar com o ( ORM - Entity Framework )
            var retorno = context.Set<T>().Add(objeto);
            context.SaveChanges();
        }
        public void Atualizar(T objeto)
        {
            //Com o ( ORM - Entity Framework ) substituimos mais de 10 linhas
            //do mesmo listar ( AdoNet ) por ( 2 linhas do ORM-Entity Framework )
            context.Set<T>().Update(objeto);
            //como estamos fazendo alterações em nossa tabela
            //precisamos passar - SaveChanges();
            context.SaveChanges();
        }
        public void Deletar(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }
    }
}
