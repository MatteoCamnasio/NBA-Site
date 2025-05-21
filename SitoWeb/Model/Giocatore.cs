using System;

namespace SitoWeb.Model;

public class Giocatore
{
    public int GiocatoreId {get;set;}
    public string? GiocatoreName {get;set;}
    public string? SquadraId {get;set;}
    public Squadra? Squadra {get;set;}
    public string? Ruolo {get;set;}
    public string? Nazionalita {get;set;}
    public DateOnly DataNascita {get;set;}
    public int Altezza {get;set;}
    public int Peso {get;set;}
    public string? Descrizione {get;set;}
}
