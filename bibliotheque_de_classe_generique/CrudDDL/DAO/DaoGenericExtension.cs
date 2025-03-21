using System.Data;
using CrudDDL.repository;
using CrudDDL.utils;

namespace CrudDDL.DAO;

public static class DaoGenericExtension
{
    public static void Add(this object entity)
    {
        var primaryKeyType = entity.GetPrimaryKeyType();
        var daoType = typeof(DAO_Generique<,>).MakeGenericType(entity.GetType(), primaryKeyType);
        
        var daoInstance = Activator.CreateInstance(daoType);
        daoType.GetMethod("Add")?.Invoke(daoInstance, new object[] { entity });
    }

    public static void Update(this object entity)
    {
        var primaryKeyType = entity.GetPrimaryKeyType();
        var daoType = typeof(DAO_Generique<,>).MakeGenericType(entity.GetType(), primaryKeyType);
        var daoInstance = Activator.CreateInstance(daoType);
        daoType.GetMethod("Update")?.Invoke(daoInstance, new object[] { entity });
    }

    public static void Delete(this object entity)
    {
        var primaryKeyType = entity.GetPrimaryKeyType();
        var daoType = typeof(DAO_Generique<,>).MakeGenericType(entity.GetType(), primaryKeyType);
        var daoInstance = Activator.CreateInstance(daoType);
        daoType.GetMethod("Delete")?.Invoke(daoInstance, new object[] { entity });
    }

    public static List<object> GetAll(this object repository)
    {
        var repositoryType = repository.GetType();
        if (repositoryType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICrudRepository<,>)))
        {
            var method = repositoryType.GetMethod("GetAll");
            return (List<object>)method.Invoke(repository, new object[] { });
        }
        throw new Exception("Repository type doesn't implement ICrudRepository<,>.");
    }

    public static object GetById(this object repository, object id)
    {
        var repositoryType = repository.GetType();
        if (repositoryType.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICrudRepository<,>)))
        {
            var method = repositoryType.GetMethod("GetById");
            return method.Invoke(repository, new object[] { id });
        }
        throw new Exception("Repository type doesn't implement ICrudRepository<,>.");
    }
    
}