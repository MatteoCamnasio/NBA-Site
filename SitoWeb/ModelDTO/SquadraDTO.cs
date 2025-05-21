using System;

namespace SitoWeb.Model;

public class SquadraDTO
{
    public int SquadraId {get;set;}
    public string? Nome {get;set;}
    public string? Citta {get;set;}
    public string? Stadio {get;set;}
    public int AnnoFondazione {get;set;}
    public string? Descrizione {get;set;}
    public SquadraDTO()
    {
        
    }
    public SquadraDTO(int squadraId, string? nome, string? citta, string? stadio, int annoFondazione, string? descrizione)
    {
        SquadraId = squadraId;
        Nome = nome;
        Citta = citta;
        Stadio = stadio;
        AnnoFondazione = annoFondazione;
        Descrizione = descrizione;
    }
}
