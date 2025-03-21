namespace Ex_1.GestionAbsences;

using System;
using System.Data;
using System.Data.SqlClient; // SqlServer
using Npgsql; // PostgreSQL
using MySql.Data.MySqlClient; // MySQL
using Oracle.ManagedDataAccess.Client; // Oracle

public class Connexion
{
    private readonly string connectionString;
    private readonly string dbType;
    private IDbConnection connection;

    public Connexion(string dbType, string host, string user, string password, string dbName, int port)
    {
        this.dbType = dbType.ToLower();
        connectionString = $"User Id={user};Password={password};Host={host};Port={port};Database={dbName}";
    }

    public IDbConnection GetConnection()
    {
        try
        {
            connection = dbType switch
            {
                "sqlserver" => new SqlConnection(connectionString),
                "mysql" => new MySqlConnection(connectionString),
                "postgresql" => new NpgsqlConnection(connectionString),
                "oracle" => new OracleConnection(connectionString),
                _ => throw new Exception("Type de base de données non supporté !")
            };

            connection.Open();
            Console.WriteLine("Connexion reussie a " + dbType);
            return connection;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur de connexion : " + ex.Message);
            return null;
        }
    }

    public void FermerConnexion()
    {
        if (connection != null && connection.State == ConnectionState.Open)
        {
            connection.Close();
            Console.WriteLine("Connexion fermée.");
        }
    }
}
