using System.Data;
using Ex_1.GestionAbsences.repository;
using Ex_1.GestionAbsences.entity;

namespace Ex_1.GestionAbsences.DAO;

public class EleveDaoImpl : IEleveRepository
{
    private readonly Connexion _connexion;
    private readonly IDbConnection _dbConnection;

    public EleveDaoImpl(string dbType, string host, string user, string password, string dbName, int port)
    {
        _connexion = new Connexion(dbType, host, user, password, dbName, port);
        _dbConnection = _connexion.GetConnection();
    }
    
    public void Add(Eleve entity)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "INSERT INTO ELEVES(ID,Nom,Prenom,Groupe) VALUES(@ID,@Nom,@Prenom,@Groupe)";
                command.AddParameter("@ID", entity.ID);
                command.AddParameter("@Nom", entity.Nom ?? "Inconnu");
                command.AddParameter("@Prenom", entity.Prenom ?? "Inconnu");
                command.AddParameter("@Groupe", entity.Groupe ?? "Inconnu");
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Update(Eleve entity)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "UPDATE Eleves SET Nom = @Nom, Prenom = @Prenom, Groupe = @Groupe WHERE ID = @ID";
                command.AddParameter("@Nom", entity.Nom);
                command.AddParameter("@Prenom", entity.Prenom);
                command.AddParameter("@Groupe", entity.Groupe);
                command.AddParameter("@ID", entity.ID);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Delete(int id)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Eleves WHERE ID = @ID";
                command.AddParameter("@ID", id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public List<Eleve> GetAll()
    {
        List<Eleve> eleves = new List<Eleve>();
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM ELEVES";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eleves.Add(new Eleve(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetString(3)));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return eleves;
    }

    public Eleve GetById(int id)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM ELEVES WHERE ID = @ID";
                command.AddParameter("@ID", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Eleve(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetString(3));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }

    public List<Eleve> GetByName(string name)
    {
        List<Eleve> eleves = new List<Eleve>();
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM ELEVES WHERE Nom LIKE @Nom";
                command.AddParameter("@Nom", "%" + name + "%");
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eleves.Add(new Eleve(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetString(3)));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return eleves;
    }

    public List<Eleve> Search(string nom, string prenom, string groupe)
    {
        List<Eleve> eleves = new List<Eleve>();
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                string query = "SELECT * FROM ELEVES WHERE 1=1";
                if (!string.IsNullOrEmpty(nom)) query += " AND Nom LIKE @Nom";
                if (!string.IsNullOrEmpty(prenom)) query += " AND Prenom LIKE @Prenom";
                if (!string.IsNullOrEmpty(groupe)) query += " AND Groupe LIKE @Groupe";

                command.CommandText = query;
                if (!string.IsNullOrEmpty(nom)) command.AddParameter("@Nom", nom);
                if (!string.IsNullOrEmpty(prenom)) command.AddParameter("@Prenom", prenom);
                if (!string.IsNullOrEmpty(groupe)) command.AddParameter("@Groupe", groupe);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eleves.Add(new Eleve(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetString(3)));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return eleves;
    }
}