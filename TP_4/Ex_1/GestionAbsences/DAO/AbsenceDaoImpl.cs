using System.Data;
using Ex_1.GestionAbsences.entity;
using Ex_1.GestionAbsences.repository;

namespace Ex_1.GestionAbsences.DAO;

public class AbsenceDaoImpl : IAbsenceRepository
{
    private readonly Connexion _connexion;
    private readonly IDbConnection _dbConnection;

    public AbsenceDaoImpl(string dbType, string connectionString)
    {
        _connexion = new Connexion(dbType, connectionString);
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
}