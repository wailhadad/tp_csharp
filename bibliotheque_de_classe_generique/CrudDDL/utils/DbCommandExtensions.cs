using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;

namespace CrudDDL.utils;

public static class DbCommandExtensions {
    public static void AddParameter(this IDbCommand command, string name, object value)
    {
        IDbDataParameter parameter = command.CreateParameter();
        if (command.Connection != null && command.Connection.GetType().Name.ToLower().StartsWith("oracle"))
        {
            parameter.ParameterName = ":" + name.TrimStart();
        }
        else
        {
            parameter.ParameterName = name;
        }
        parameter.Value = value ?? DBNull.Value;
        command.Parameters.Add(parameter);
    }
    
    public static void AddParameters(this IDbCommand command, string columnNames, object entity)
    {
        var properties = entity.GetType().GetProperties();
        string[] columnNamesArray = columnNames.Split(',');
        
        foreach (var columnName in columnNamesArray)
        {
            var property = properties.FirstOrDefault(p => 
                p.GetCustomAttribute<ColumnNameAttribute>()?.column_Name == columnName.Trim() || p.Name == columnName.Trim());

            if (property != null)
            {
                var value = property.GetValue(entity, null);
                command.AddParameter($"@{columnName.Trim()}", value);
            }
        }
    }
    
}