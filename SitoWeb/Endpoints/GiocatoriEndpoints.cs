using System;
using Microsoft.EntityFrameworkCore;
using SitoWeb.Data;
using SitoWeb.Model;

namespace SitoWeb.Endpoints;

public static class GiocatoriEndpoints
{
    public static void MapGiocatoriEndPoint(this WebApplication app){
        app.MapGet("/giocatori", async (NBADbContext dbContext) =>
        {
            var giocatori = await dbContext.Giocatori.ToListAsync();
            return Results.Ok(giocatori);
        });
        app.MapGet("/giocatori/{id}", async (NBADbContext dbContext, int id) =>
        {
            var giocatore = await dbContext.Giocatori.FindAsync(id);
            if(giocatore == null){
                return Results.NotFound();
            }
            return Results.Ok(giocatore);
        });

        app.MapPost("/giocatori", async (NBADbContext dbContext, Model.GiocatoreDTO giocatoreDTO) =>
        {
            Giocatore giocatore = new(){
                GiocatoreName = giocatoreDTO.GiocatoreName,
                SquadraId = giocatoreDTO.SquadraId,
                Ruolo = giocatoreDTO.Ruolo,
                Nazionalita = giocatoreDTO.Nazionalita,
                DataNascita = giocatoreDTO.DataNascita,
                Altezza = giocatoreDTO.Altezza,
                Peso = giocatoreDTO.Peso,
                Descrizione = giocatoreDTO.Descrizione
            };
            dbContext.Giocatori.Add(giocatore);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/giocatori/{giocatore.GiocatoreId}", giocatore);
        });

        app.MapPut("/giocatori/{id}", async (NBADbContext dbContext, int id, GiocatoreDTO giocatoreDTO) =>
        {
            var giocatore = await dbContext.Giocatori.FindAsync(id);
            if(giocatore == null){
                return Results.NotFound();
            }
            giocatore.GiocatoreName = giocatoreDTO.GiocatoreName;
            giocatore.SquadraId = giocatoreDTO.SquadraId;
            giocatore.Ruolo = giocatoreDTO.Ruolo;
            giocatore.Nazionalita = giocatoreDTO.Nazionalita;
            giocatore.DataNascita = giocatoreDTO.DataNascita;
            giocatore.Altezza = giocatoreDTO.Altezza;
            giocatore.Peso = giocatoreDTO.Peso;
            giocatore.Descrizione = giocatoreDTO.Descrizione;
            await dbContext.SaveChangesAsync();
            return Results.Ok(giocatore);
        });

        app.MapDelete("/giocatori/{id}", async (NBADbContext dbContext, int id) =>
        {
            var giocatore = await dbContext.Giocatori.FindAsync(id);
            if(giocatore == null){
                return Results.NotFound();
            }
            dbContext.Giocatori.Remove(giocatore);
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
