namespace Ex_1.GestionAbsences.repository;

public interface ICrudRepository <T, TId>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(TId id);
    List<T> GetAll();
    T GetById(TId id);
}