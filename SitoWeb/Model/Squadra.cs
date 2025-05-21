using System;

namespace SitoWeb.Model;

public class Squadra
{
    public int SquadraId {get;set;}
    public string? Nome {get;set;}
    public string? Citta {get;set;}
    public string? Stadio {get;set;}
    public int AnnoFondazione {get;set;}
    public string? Descrizione {get;set;}
    public List<Giocatore> Giocatori {get;set;} = new();
}
