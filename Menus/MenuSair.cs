using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DALgenerico<Artista> dalGenerico)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
