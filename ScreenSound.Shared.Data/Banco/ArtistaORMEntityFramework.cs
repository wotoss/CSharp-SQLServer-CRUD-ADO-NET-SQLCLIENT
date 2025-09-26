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
    internal class ArtistaORMEntityFramework : DALgenerico<Artista> 
    {
        // base( : base(context) ) esta herdando o context da super classe que é o DAL
        public ArtistaORMEntityFramework(ScreenSoundContext context) : base(context) { }
    }
}
