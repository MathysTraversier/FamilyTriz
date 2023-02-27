using Microsoft.EntityFrameworkCore;
using MvcFamilyTriz.Models;

namespace MvcFamilyTriz.Data;

public class MvcFamilyTrizContext: DbContext{
    public DbSet<Eleve> Eleves {get; set;} =null!;
    public DbSet<Famille> Familles {get; set;} =null!;
    public DbSet<Evenement> Evenements {get; set;} =null!;
    public string DbPath {get; private set;}

    public MvcFamilyTrizContext()
    {
        DbPath = "MvcFamilyTriz.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseSqlite($"Data Source ={DbPath}");
        options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }
}