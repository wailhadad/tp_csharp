using System.Data;

namespace Ex_1.GestionAbsences;

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
}