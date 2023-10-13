namespace WebApi1.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<string> DeleteById(int id);
    }
}
