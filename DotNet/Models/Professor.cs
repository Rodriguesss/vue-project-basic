using System.Collections.Generic;
using DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos {get; set; }

        public Professor(){ }

    }
}