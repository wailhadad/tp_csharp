using Ex_1.GestionAbsences.entity;

namespace Ex_1.GestionAbsences.repository;

public interface IAbsenceRepository : ICrudRepository<Absence, AbsenceId>
{
    List<Absence> FindBySemaine(int semaineId);
    List<Absence> FindByEleve(int date);
}