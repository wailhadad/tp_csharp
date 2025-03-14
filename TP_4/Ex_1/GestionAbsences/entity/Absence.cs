namespace Ex_1.GestionAbsences.entity;

public class Absence
{
    private int _numSemaine;
    private int _idEleve;
    private int _nbrAbsences;

    public Absence(int numSemaine, int idEleve, int nbrAbsences)
    {
        NumSemaine = numSemaine;
        IDEleve = idEleve;
        NbrAbsences = nbrAbsences;
    }
    
    public int NumSemaine
    {
        get => _numSemaine;
        set
        {
            if (value < 0) throw new ArgumentException("NumSemaine cannot be less than 0");
            _numSemaine = value;
        }
    }

    public int IDEleve
    {
        get => _idEleve; 
        set
        {
            if (value < 0) throw new ArgumentException("IDEleve cannot be less than 0");
            _idEleve = value;
        }
    }

    public int NbrAbsences
    {
        get => _nbrAbsences;
        set
        {
            if (value < 0) throw new ArgumentException("NbrAbsences cannot be less than 0");
            _nbrAbsences = value;
        }
    }
    
    public override string ToString()
    {
        return $"Semaine {NumSemaine} | Eleve ID: {IDEleve} | Absences: {NbrAbsences}";
    }
}