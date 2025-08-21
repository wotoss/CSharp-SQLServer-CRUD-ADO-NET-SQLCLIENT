using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(ArtistaORMEntityFramework artistaORMEntity)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
