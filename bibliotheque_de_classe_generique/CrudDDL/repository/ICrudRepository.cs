namespace CrudDDL.repository;

public interface ICrudRepository <T, TId>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    List<T> GetAll();
    T GetById(TId id);
}