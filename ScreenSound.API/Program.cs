using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Diagnostics;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//fazer a configuração da minha base de dados na API
builder.Services.AddDbContext<ScreenSoundContext>();
//vou passar o DAl<e qual tipo de DAL eu quero criar>
builder.Services.AddTransient<DALgenerico<Artista>>();

builder.Services.AddTransient<DALgenerico<Musica>>();


//este codigo para não dar as (referencias citricas ou referencia circular)
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>
    (options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

//rota buscando todos - fazendo injeção dependencia com -[ FromServices ]
app.MapGet("/Artistas", ([FromServices] DALgenerico<Artista> dalGenerico) =>
{
    return Results.Ok(dalGenerico.Listar());
});

//realizando a consulta por nome
app.MapGet("/Artistas/{nome}", ([FromServices] DALgenerico<Artista> dalGenerico, string nome) =>
{
    var artistaEncontrado = dalGenerico.RecuperarPor(artis => artis.Nome.ToUpper().Equals(nome.ToUpper()));
    if (artistaEncontrado == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(artistaEncontrado);
});
//vamos registrar, adicionar 
app.MapPost("/Artistas", ([FromServices] DALgenerico<Artista> dalGenerico, [FromBody] Artista artista) =>
{
    dalGenerico.Adicionar(artista);
    return Results.Ok();
});

//vamos fazer o delete
app.MapDelete("/Artistas/{id}", ([FromServices] DALgenerico<Artista> dalGenerico, int id) =>
{
    Debugger.Break();
    var artista = dalGenerico.RecuperarPor(a => a.Id == id);
    if (artista is null)
    {
        return Results.NotFound();
    }
    dalGenerico.Deletar(artista);

    return Results.NoContent();
});

//atualizar passando no corpo da requisição
app.MapPut("/Artistas", ([FromServices] DALgenerico<Artista> dalGenerico, [FromBody] Artista artista) =>
{
    var artistaAtualizando = dalGenerico.RecuperarPor(a => a.Id == artista.Id);
    if (artistaAtualizando is null)
    {
        return Results.NotFound();
    }

    //vou fazer um ( de - para )
    artistaAtualizando.Nome = artista.Nome;
    artistaAtualizando.Bio = artista.Bio;
    artistaAtualizando.FotoPerfil = artista.FotoPerfil;

    dalGenerico.Atualizar(artistaAtualizando);
    return Results.Ok();
});

//inicio - musica

#region Endpoint Músicas
app.MapGet("/Musicas", ([FromServices] DALgenerico<Musica> dal) =>
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/Musicas/{nome}", ([FromServices] DALgenerico<Musica> dal, string nome) =>
{
    var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (musica is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(musica);

});

app.MapPost("/Musicas", ([FromServices] DALgenerico<Musica> dal, [FromBody] Musica musica) =>
{
    dal.Adicionar(musica);
    return Results.Ok();
});

app.MapDelete("/Musicas/{id}", ([FromServices] DALgenerico<Musica> dal, int id) => {
    var musica = dal.RecuperarPor(a => a.Id == id);
    if (musica is null)
    {
        return Results.NotFound();
    }
    dal.Deletar(musica);
    return Results.NoContent();

});

app.MapPut("/Musicas", ([FromServices] DALgenerico<Musica> dal, [FromBody] Musica musica) => {
    var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musica.Id);
    if (musicaAAtualizar is null)
    {
        return Results.NotFound();
    }
    musicaAAtualizar.Nome = musica.Nome;
    musicaAAtualizar.AnoLancamento = musica.AnoLancamento;

    dal.Atualizar(musicaAAtualizar);
    return Results.Ok();
});
#endregion


//fim - musica


app.Run();