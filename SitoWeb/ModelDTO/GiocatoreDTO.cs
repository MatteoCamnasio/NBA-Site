using System;

namespace SitoWeb.Model;

public class GiocatoreDTO
{
    public int GiocatoreId {get;set;}
    public string? GiocatoreName {get;set;}
    public string? SquadraId {get;set;}
    public string? Ruolo {get;set;}
    public string? Nazionalita {get;set;}
    public DateOnly DataNascita {get;set;}
    public int Altezza {get;set;}
    public int Peso {get;set;}
    public string? Descrizione {get;set;}
    public GiocatoreDTO()
{
    
}
public GiocatoreDTO(int giocatoreId, string? giocatoreName, string? squadraId, string? ruolo, string? nazionalita, DateOnly dataNascita, int altezza, int peso, string? descrizione)
{
    GiocatoreId = giocatoreId;
    GiocatoreName = giocatoreName;
    SquadraId = squadraId;
    Ruolo = ruolo;
    Nazionalita = nazionalita;
    DataNascita = dataNascita;
    Altezza = altezza;
    Peso = peso;
    Descrizione = descrizione;
}
}

