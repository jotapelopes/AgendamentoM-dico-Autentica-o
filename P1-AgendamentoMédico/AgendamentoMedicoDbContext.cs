using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using P1_AgendamentoMédico.Models;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace P1_AgendamentoMédico;

public partial class AgendamentoMedicoDbContext : DbContext
{

    public DbSet<Agendamento> agendamentos { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }

    public AgendamentoMedicoDbContext()
    {
    }

    public AgendamentoMedicoDbContext(DbContextOptions<AgendamentoMedicoDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Agendamento>().HasKey(a => a.Id);
        modelBuilder.Entity<Agendamento>().Property(a => a.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Medico>().HasKey(m => m.Id);
        modelBuilder.Entity<Medico>().Property(m => m.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Paciente>().HasKey(p => p.Id);
        modelBuilder.Entity<Paciente>().Property(p => p.Id).ValueGeneratedOnAdd();


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
