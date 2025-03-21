using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace CrudDDL.utils;

public static class Utils
{
    public static Dictionary<string, object> ToDictionary(this object obj)
    {
        Dictionary<string, object?> dictionary = new Dictionary<string, object?>();
        foreach (PropertyInfo p in obj.GetType().GetProperties())
        {
            dictionary.Add(p.Name, p.GetValue(obj));
        }
        return dictionary;
    }
    
    public static string GetPrimaryKeyCondition(this object entity)
    {
        var properties = entity.GetType().GetProperties();
        var primaryKeyProperty = properties
            .FirstOrDefault(p => Attribute.IsDefined(p, typeof(PrimaryKeyAttribute)));

        if (primaryKeyProperty != null)
        {
            // Fetch the column name from the ColumnNameAttribute
            var columnName = primaryKeyProperty.GetCustomAttribute<ColumnNameAttribute>()?.column_Name ?? primaryKeyProperty.Name;
            return $"{columnName} = @{primaryKeyProperty.Name}";
        }

        throw new InvalidOperationException("No primary key defined for the entity.");
    }       
    public static string GetPrimaryKeyCondition(Type entityType)
    {
        var properties = entityType.GetProperties();
        var primaryKeyProperty = properties
            .FirstOrDefault(p => Attribute.IsDefined(p, typeof(PrimaryKeyAttribute)));

        if (primaryKeyProperty != null)
        {
            // Fetch the column name from the ColumnNameAttribute
            var columnName = primaryKeyProperty.GetCustomAttribute<ColumnNameAttribute>()?.column_Name ?? primaryKeyProperty.Name;
            return $"{columnName} = @{primaryKeyProperty.Name}";
        }

        throw new InvalidOperationException("No primary key defined for the entity.");
    }
    
    public static string GetTableName(this object entity)
    {
        Type entityType = entity.GetType();
        var tableName = entityType.Name;
        var tableAttribute = entityType.GetCustomAttribute<TableAttribute>();
        if (tableAttribute != null)
        {
            tableName = tableAttribute.Name;
        }
        return tableName;
    }    
    
    public static string GetTableName(Type entityType)
    {
        var tableName = entityType.Name;
        var tableAttribute = entityType.GetCustomAttribute<TableAttribute>();
        if (tableAttribute != null)
        {
            tableName = tableAttribute.Name;
        }
        return tableName;
    }

    public static string GetColumnNames(Type entityType)
    {
        var properties = entityType.GetProperties();
        var columnNames = properties
            .Select(p =>
            {
                var columnAttribute = p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name ?? p.Name;
                return columnAttribute;
            })
            .ToList();
        return string.Join(",", columnNames);
    }    
    
    public static string GetColumnNames(this object entity)
    {
        var properties = entity.GetType().GetProperties();
        var columnNames = properties
            .Select(p =>
            {
                var columnAttribute = p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name ?? p.Name;
                return columnAttribute;
            })
            .ToList();
        return string.Join(",", columnNames);
    }

    public static string GetColumnNamesWithoutId(this object entity)
    {
        var properties = entity.GetType().GetProperties();
        var columnNames = properties
            .Where(p => !Attribute.IsDefined(p, typeof(PrimaryKeyAttribute))) // Exclude PrimaryKey
            .Select(p =>
            {
                var columnAttribute = p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name ?? p.Name;
                return columnAttribute;
            })
            .ToList();
        return string.Join(",", columnNames);
    }   
    
    public static string GetColumnNamesWithoutId(Type entityType)
    {
        var properties = entityType.GetProperties();
        var columnNames = properties
            .Where(p => !Attribute.IsDefined(p, typeof(PrimaryKeyAttribute))) // Exclude PrimaryKey
            .Select(p =>
            {
                var columnAttribute = p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name ?? p.Name;
                return columnAttribute;
            })
            .ToList();
        return string.Join(",", columnNames);
    }

    public static string GetColumnValuesWithoutId(this object entity)
    {
        var properties = entity.GetType().GetProperties();
        var values = properties
            .Where(p => !Attribute.IsDefined(p, typeof(PrimaryKeyAttribute))) // Exclude PrimaryKey
            .Select(p =>
            {
                var columnValues = "@" + (p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name ?? p.Name);
                return columnValues;
            })
            .ToList();
        return string.Join(",", values);
    }  
    
    public static string GetColumnValuesWithoutId(Type entityType)
    {
        var properties = entityType.GetProperties();
        var values = properties
            .Where(p => !Attribute.IsDefined(p, typeof(PrimaryKeyAttribute))) // Exclude PrimaryKey
            .Select(p =>
            {
                var columnValues = "@" + (p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name ?? p.Name);
                return columnValues;
            })
            .ToList();
        return string.Join(",", values);
    }

    public static string GetColumnValues(this object entity)
    {
        var properties = entity.GetType().GetProperties();
        var values = properties
            .Select(
                p =>
                {
                    var columnsValues = "@" + (p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name ?? p.Name);
                    return columnsValues;
                }
            ).ToList();
        return string.Join(",", values);
    }   
    
    public static string GetColumnValues(Type entityType)
    {
        var properties = entityType.GetProperties();
        var values = properties
            .Select(
                p =>
                {
                    var columnsValues = "@" + (p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name ?? p.Name);
                    return columnsValues;
                }
            ).ToList();
        return string.Join(",", values);
    }
    
    public static Type GetPrimaryKeyType(this object entity)
    {
        var primaryKeyProperty = entity.GetType().GetProperties()
            .FirstOrDefault(p => Attribute.IsDefined(p, typeof(PrimaryKeyAttribute)));

        return primaryKeyProperty?.PropertyType ?? typeof(int);  // Default to int if no primary key found
    }

}