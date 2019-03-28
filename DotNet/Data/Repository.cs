using System.Linq;
using System.Threading.Tasks;
using DotNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DotNet.Data
{
    public class Repository : IRepository
    {
        public readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;

        }

        //CRUD
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        //CRUD
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        //CRUD
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        //CRUD
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if(includeProfessor)
            {
                query = query.Include(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunosAsyncById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if(includeProfessor)
            {
                query = query.Include(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(aluno => aluno.Id).Where(a => a.Id == alunoId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetALunosAsyncByProfessorId(int professorId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
            {
                query = query.Include(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(aluno => aluno.ProfessorId == professorId);
            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetAllProfessoresAsync(bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if(includeAluno)
            {
                query = query.Include(p => p.Alunos);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorAsyncById(int professorId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if(includeAluno)
            {
                query = query.Include(p => p.Alunos);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.Id == professorId);
            return await query.FirstOrDefaultAsync();
        }
    }
}