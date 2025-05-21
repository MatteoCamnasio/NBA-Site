using System;
using Microsoft.EntityFrameworkCore;
using SitoWeb.Data;
using SitoWeb.Model;

namespace SitoWeb.Endpoints;

public  static class SquadreEndpoints
{
    public static void MapSquadreEndpoints(this WebApplication app){


        app.MapGet("/squadre", async (NBADbContext dbContext) =>
        {
            var squadre = await dbContext.Squadre.ToListAsync();
            return Results.Ok(squadre);
        });
        app.MapGet("/squadre/{id}", async (NBADbContext dbContext, int id) =>
        {
            var squadra = await dbContext.Squadre.FindAsync(id);
            if(squadra == null){
                return Results.NotFound();
            }
            return Results.Ok(squadra);
        });

        app.MapPost("/squadre", async (NBADbContext dbContext, SquadraDTO squadraDTO) =>
        {
            Console.WriteLine("entrato nel post");
            Squadra squadra = new(){
                Nome = squadraDTO.Nome,
                Citta = squadraDTO.Citta,
                Stadio = squadraDTO.Stadio,
                AnnoFondazione = squadraDTO.AnnoFondazione,
                Descrizione = squadraDTO.Descrizione
            };
            Console.WriteLine("creata squadra");
            dbContext.Squadre.Add(squadra);
            await dbContext.SaveChangesAsync();
            Console.WriteLine("salvata squadra");
            return Results.Created($"/squadre/{squadra.SquadraId}", squadra);
            
        });

        app.MapPut("/squadre/{id}", async (NBADbContext dbContext, int id, SquadraDTO squadraDTO) =>
        {
            var squadra = await dbContext.Squadre.FindAsync(id);
            if(squadra == null){
                return Results.NotFound();
            }
            squadra.Nome = squadraDTO.Nome;
            squadra.Citta = squadraDTO.Citta;
            squadra.Stadio = squadraDTO.Stadio;
            squadra.AnnoFondazione = squadraDTO.AnnoFondazione;
            squadra.Descrizione = squadraDTO.Descrizione;
            await dbContext.SaveChangesAsync();
            return Results.Ok(squadra);
        });

        app.MapDelete("/squadre/{id}", async (NBADbContext dbContext, int id) =>
        {
            var squadra = await dbContext.Squadre.FindAsync(id);
            if(squadra == null){
                return Results.NotFound();
            }
            dbContext.Squadre.Remove(squadra);
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
