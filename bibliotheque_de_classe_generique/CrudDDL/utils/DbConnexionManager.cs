using System.Data;

namespace CrudDDL.utils;

public static class DbConnexionManager
{
    private static IDbConnection _dbConnection;
    
    public static void GetConnection(string dbType, string host, string user, string password, string dbName, int port)
    {
        if (_dbConnection != null) return;
        DBConnection = new Connexion(dbType, host, user, password, dbName, port).GetConnection();
    }

    public static IDbConnection DBConnection
    {
        get => _dbConnection;
        set => _dbConnection = value;
    }

    public static void CloseConnection()
    {
        if (_dbConnection == null) return;
        DBConnection.Dispose();
    }
    
}