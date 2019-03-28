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
            builder.Entity<Professor>().HasData(
                new Professor(){
                    Id = 1,
                    Nome = "Vinicius"
                },
                new Professor(){
                    Id = 2,
                    Nome = "Lucas"
                },
                new Professor(){
                    Id = 3,
                    Nome = "João"
                }
            );

            builder.Entity<Aluno>().HasData(
                new List<Aluno>(){
                    new Aluno(){
                        Id = 2,
                        Nome = "Paula",
                        ProfessorId = 1,
                    },
                    new Aluno(){
                        Id = 3,
                        Nome = "João",
                        ProfessorId = 2,
                    }
                }
            );
        }
    }


}