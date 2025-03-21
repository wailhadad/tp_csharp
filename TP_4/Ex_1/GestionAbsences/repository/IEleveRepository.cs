using Ex_1.GestionAbsences.entity;

namespace Ex_1.GestionAbsences.repository;

public interface IEleveRepository : ICrudRepository<Eleve, int>
{
    List<Eleve> GetByName(string name);
    List<Eleve> Search(string nom, string prenom, string groupe);
}