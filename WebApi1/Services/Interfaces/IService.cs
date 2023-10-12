namespace WebApi1.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        string DeleteById(int id);
    }
}
