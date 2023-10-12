using System.Security.Principal;
using WebApi1.Models.Interface;
using WebApi1.Services.Interfaces;

namespace WebApi1.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class, IEntity
    {
        private List<TEntity> _entities;
        public Service() 
        {
            _entities = new List<TEntity>();
        }
        public TEntity GetById(int id)
        {
            return _entities.FirstOrDefault(x => x.Id == id) ?? throw new Exception($"L'entité {nameof(TEntity)} #{id} n'existe pas");
        }
        public List<TEntity> GetAll()
        {
            return _entities;
        }
        public TEntity Create(TEntity entity)
        {
            entity.Id = _entities.Count + 1;
            _entities.Add(entity);
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            _entities.Remove(GetById(entity.Id));
            _entities.Add(entity);
            return entity;
        }
        public string DeleteById(int id)
        {
            _entities.Remove(GetById(id));
            return $"L'entité {nameof(TEntity)} #{id} à bien été supprimé";
        }
    }
}
