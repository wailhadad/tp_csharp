namespace Ex_1.GestionAbsences.entity;

public class AbsenceId
{
    private int _id;
    private int _numSemaine;

    public int Id
    {
        get => _id;
        set
        {
            if (value < 0) throw new ArgumentException("Id cannot be less than 0");
            _id = value;
        }
    }

    public int NumSemaine
    {
        get => _numSemaine;
        set
        {
            if (value < 0) throw new ArgumentException("NumSemaines cannot be less than 0");
            _numSemaine = value;
        }
    }

    public AbsenceId(int id, int numSemaine)
    {
        Id = id;
        NumSemaine = numSemaine;
    }

    public override bool Equals(object? obj)
    {
        return obj is AbsenceId other && Id == other.Id && NumSemaine == other.NumSemaine;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, NumSemaine);
    }

    public override string ToString()
    {
        return $"Id: {Id}, NumSemaines: {NumSemaine}";
    }
}