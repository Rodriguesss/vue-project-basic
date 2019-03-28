using System.Collections.Generic;
using DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores {get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor() { Id = 1, Nome = "Vinicius" },
                    new Professor() { Id = 2, Nome = "Lucas" },
                    new Professor() { Id = 3, Nome = "João" }
                }
            );

            builder.Entity<Aluno>()
            .HasData(new List<Aluno>(){
                    new Aluno(){
                        Id = 1,
                        Nome = "Paula",
                        Sobrenome = "Maria",
                        DataNasc = "20/01/1990",
                        ProfessorId = 1
                    },
                    new Aluno(){
                        Id = 2,
                        Nome = "João",
                        Sobrenome = "Paulo",
                        DataNasc = "26/06/1981",
                        ProfessorId = 2
                    },
                    new Aluno(){
                        Id = 3,
                        Nome = "Pedro",
                        Sobrenome = "Bola",
                        DataNasc = "26/06/1977",
                        ProfessorId = 3
                    }
                });
        }
    }
}