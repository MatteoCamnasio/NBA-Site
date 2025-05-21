using System;
using SitoWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace SitoWeb.Data;

public class NBADbContext :DbContext
{
    public NBADbContext(DbContextOptions<NBADbContext> opt):base(opt) {}
    public DbSet<Squadra> Squadre { get; set; }
    public DbSet<Giocatore> Giocatori { get; set; }
}
