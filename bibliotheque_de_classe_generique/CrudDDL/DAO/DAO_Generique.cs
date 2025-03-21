using System.Data;
using System.Reflection;
using CrudDDL.repository;
using CrudDDL.utils;

namespace CrudDDL.DAO;

public class DAO_Generique<T, TId> : ICrudRepository<T, TId>
{
    private readonly Connexion _connexion;
    private readonly IDbConnection _dbConnection;

    public DAO_Generique(string dbType, string host, string user, string password, string dbName, int port)
    {
        _connexion = new Connexion(dbType, host, user, password, dbName, port);
        _dbConnection = _connexion.GetConnection();
    }

    public DAO_Generique()
    {
        _dbConnection = DbConnexionManager.DBConnection;
    }
    
    public void Add(T entity)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                var tableName = entity?.GetTableName();
                var columnNames = entity?.GetColumnNames();
                var columnValues = entity?.GetColumnValues();
                Console.WriteLine(tableName);
                Console.WriteLine(columnNames);
                Console.WriteLine(columnValues);
                
                command.CommandText = $"INSERT INTO {tableName} ({columnNames}) VALUES ({columnValues})";
                command.AddParameters(columnNames, entity);
                
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Update(T entity)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                var tableName = entity?.GetTableName(); // Get the table name from entity
                var columnNames = entity?.GetColumnNamesWithoutId(); // Exclude primary key
                var columnValues = entity?.GetColumnValuesWithoutId(); // Exclude primary key

                // Dynamically generate the column names with @parameter_name and values
                string setClause = string.Join(", ", columnNames.Split(',').Select(name => $"{name} = @{name.Trim()}"));

                // Construct the SQL query for the UPDATE operation
                command.CommandText = $"UPDATE {tableName} SET {setClause} WHERE {entity?.GetPrimaryKeyCondition()}";

                // Add parameters for each column and its corresponding value
                command.AddParameters(columnNames, entity);

                // Add the primary key parameter separately (for WHERE clause)
                var primaryKeyProperty = entity.GetType().GetProperties()
                    .FirstOrDefault(p => Attribute.IsDefined(p, typeof(PrimaryKeyAttribute)));

                if (primaryKeyProperty != null)
                {
                    var primaryKeyValue = primaryKeyProperty.GetValue(entity);
                    command.AddParameter($"@{primaryKeyProperty.Name}", primaryKeyValue); // Add the primary key parameter
                }

                // Execute the query
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Delete(T entity)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                var tableName = entity?.GetTableName(); // Get the table name from entity
                
                // Construct the SQL query for the UPDATE operation
                command.CommandText = $"DELETE FROM {tableName} WHERE {entity?.GetPrimaryKeyCondition()}";
                
                Console.WriteLine($"La condition est : {entity?.GetPrimaryKeyCondition()}");

                // Add the primary key parameter separately (for WHERE clause)
                var primaryKeyProperty = entity?.GetType().GetProperties()
                    .FirstOrDefault(p => Attribute.IsDefined(p, typeof(PrimaryKeyAttribute)));

                if (primaryKeyProperty != null)
                {
                    var primaryKeyValue = primaryKeyProperty.GetValue(entity);
                    command.AddParameter($"@{primaryKeyProperty.Name}", primaryKeyValue); // Add the primary key parameter
                }

                // Execute the query
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public List<T> GetAll()
    {
        List<T> listGetAll = new List<T>();
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                var tableName = Utils.GetTableName(typeof(T)); // Get the table name from entity
                var columnNames = Utils.GetColumnNames(typeof(T)); // Exclude primary key
                var columnValues = Utils.GetColumnValues(typeof(T)); // Exclude primary key
                
                command.CommandText = $"SELECT * FROM {tableName}";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T entity = Activator.CreateInstance<T>();
                        foreach (var column in columnNames.Split(','))
                        {
                            var property = entity?.GetType().GetProperties()
                                .FirstOrDefault(p => p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name == column.Trim() || p.Name == column.Trim());
                            
                            property?.SetValue(entity, reader[column]);
                        }
                        listGetAll.Add(entity);
                    }
                    return listGetAll;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return default;
    }

    public T GetById(TId id)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                var tableName = Utils.GetTableName(typeof(T));
                var columnNames = Utils.GetColumnNamesWithoutId(typeof(T));
                var columnValues = Utils.GetColumnValuesWithoutId(typeof(T));
                command.CommandText = $"SELECT * FROM {tableName} WHERE {Utils.GetPrimaryKeyCondition(typeof(T))}";
                
                var primaryKeyName = typeof(T).GetProperties()
                    .FirstOrDefault(p => Attribute.IsDefined(p, typeof(PrimaryKeyAttribute)));

                if (primaryKeyName != null)
                {
                    var PrimaryKeyValue = id;
                    command.AddParameter($"@{primaryKeyName.Name}", PrimaryKeyValue);
                }
                
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        T entity = Activator.CreateInstance<T>();
                        foreach (var column in columnNames.Split(','))
                        {
                            var property = entity?.GetType().GetProperties()
                                .FirstOrDefault(p => p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name == column.Trim() || p.Name == column.Trim());
                            property?.SetValue(entity, reader[column]);
                        }
                        return entity;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return default(T);
    }
}