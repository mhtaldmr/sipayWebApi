namespace Application.Interfaces.Repositories;

public interface  IRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);

}