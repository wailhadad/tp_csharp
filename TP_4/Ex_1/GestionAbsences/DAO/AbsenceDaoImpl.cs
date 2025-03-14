using System.Data;
using Ex_1.GestionAbsences.entity;
using Ex_1.GestionAbsences.repository;

namespace Ex_1.GestionAbsences.DAO;

public class AbsenceDaoImpl : IAbsenceRepository
{
    private readonly Connexion _connexion;
    private readonly IDbConnection _dbConnection;

    public AbsenceDaoImpl(string dbType, string host, string user, string password, string dbName, int port)
    {
        _connexion = new Connexion(dbType, host, user, password, dbName, port);
        _dbConnection = _connexion.GetConnection();
    }
    
    public void Add(Absence entity)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Absences (Num_semaine, ID, Nbr_absences) VALUES (@Semaine, @ID, @NbrAbsences)";
                command.AddParameter("@Semaine", entity.NumSemaine);
                command.AddParameter("@ID", entity.IDEleve);
                command.AddParameter("@NbrAbsences", entity.NbrAbsences);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Update(Absence entity)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                AbsenceId absenceId = new AbsenceId(entity.IDEleve, entity.NumSemaine);
                command.CommandText =
                    "UPDATE Absences SET Nbr_absences = @NbrAbsences WHERE ID = @ID AND Num_semaine = @Semaine";
                command.AddParameter("@NbrAbsences", entity.NbrAbsences);
                command.AddParameter("@Semaine", absenceId.NumSemaine);
                command.AddParameter("@ID", absenceId.Id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Delete(AbsenceId absenceId)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Absences WHERE ID = @ID AND Num_semaine = @Semaine";
                command.AddParameter("@Semaine", absenceId.NumSemaine);
                command.AddParameter("@ID", absenceId.Id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public List<Absence> GetAll()
    {
        List<Absence> absences = new List<Absence>();
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Absences";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        absences.Add(new Absence(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return absences;
    }

    public Absence GetById(AbsenceId id)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Absences where ID = @ID AND Num_semaine = @Semaine";
                command.AddParameter("@Semaine", id.NumSemaine);
                command.AddParameter("@ID", id.Id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return new Absence(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public List<Absence> FindBySemaine(int semaineId)
    {
        List<Absence> absences = new List<Absence>();
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Absences where Num_semaine = @Semaine";
                command.AddParameter("@Semaine", semaineId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        absences.Add(new Absence(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return absences;
    }

    public List<Absence> FindByEleve(int id)
    {
        List<Absence> absences = new List<Absence>();
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Absences where ID = @ID";
                command.AddParameter("@ID", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        absences.Add(new Absence(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return absences;
    }

    public int CalculerTotalAbsencesById(int eleveId)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                command.CommandText = "SELECT SUM(Nbr_absences) FROM Absences where ID = @EleveId";
                command.AddParameter("@EleveId", eleveId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) return reader.GetInt32(0);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return 0;
    }

    public void AddAbsenceToEleveInWeek(Eleve eleve, int numAbsences, int numSemaine)
    {
        try
        {
            using (IDbCommand command = _dbConnection.CreateCommand())
            {
                var existingAbsence = GetAll().Find(abs => abs.IDEleve == eleve.ID && abs.NumSemaine == numSemaine);
                if (existingAbsence != null)
                {
                    command.CommandText = "INSERT INTO ABSENCES(Num_semaine,ID,Nbr_absences) VALUES(@NumSemaine,@EleveId, @NumAbsences)";
                    command.AddParameter("@NumAbsences", numAbsences);
                    command.AddParameter("@EleveId", eleve.ID);
                    command.AddParameter("@NumSemaine", numSemaine);
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.CommandText = "UPDATE ABSENCES SET Nbr_absences = @Nbr_absences WHERE Num_semaine = @Num_semaine and ID = @ID";
                    command.AddParameter("@NumAbsences", numAbsences);
                    command.AddParameter("@Num_semaine", numSemaine);
                    command.AddParameter("@ID", eleve.ID);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public List<Absence> RechercheMultiCritere(int numSemaine, int idEleve, int numAbsences)
    {
        List<Absence> absences = new List<Absence>();
        string query = "SELECT * FROM ABSENCES WHERE 1=1";
        using (IDbCommand command = _dbConnection.CreateCommand())
        {
            if(numSemaine  > 0) query += " AND Num_semaine = @Num_semaine";
            if(idEleve     > 0) query += " AND ID = @Eleve";
            if(numAbsences > 0) query += " AND Nbr_absences = @Num_absences";
            
            command.CommandText = query;
            if(numSemaine  > 0) command.AddParameter("@Num_semaine", numSemaine);
            if(idEleve     > 0) command.AddParameter("@Eleve", idEleve);
            if(numAbsences > 0) command.AddParameter("@Num_absences", numAbsences);

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    absences.Add(new Absence(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                }
            }
        }
        return absences;
    }
    
}