using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WebApi1.Context;
using WebApi1.Models.Interface;
using WebApi1.Services.Interfaces;

namespace WebApi1.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class, IEntity
    {
        private readonly ApplicationDbContext _context;
        public Service(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"L'entité {nameof(TEntity)} #{id} n'existe pas");
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(DbUpdateException ex)
            {
                throw new DbUpdateException($"L'entité {nameof(TEntity)} n'a pas pu être ajouté");
            }
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(DbUpdateException ex)
            {
                throw new DbUpdateException($"L'entité {nameof(TEntity)} #{entity.Id} n'a pas pu être mis à jour");
            }
        }
        public async Task<string> DeleteById(int id)
        {
            try
            {
                var entity = await GetById(id);
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return $"L'entité {nameof(TEntity)} à bien été supprimé";
            }
            catch(DbUpdateException)
            {
                return $"L'entité {nameof(TEntity)} n'a pas pu être supprimé";
            }
        }
    }
}
