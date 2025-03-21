using Ex_1.GestionAbsences.entity;

namespace Ex_1.GestionAbsences.service;

public interface IAbsenceService
{
    void AjouterAbsence(Absence absence);
    void ModifierAbsence(Absence absence);
    void SupprimerAbsence(AbsenceId id);
    List<Absence> AfficherToutesAbsences();
    Absence TrouverParId(AbsenceId id);
    List<Absence> TrouverParSemaine(int semaine);
    List<Absence> TrouverParEleve(int idEleve);
    int CalculerTotalAbsencesById(int eleveId);
    void AddAbsenceToEleveInWeek(Eleve eleve, int numAbsences, int numSemaine);
    List<Absence> RechercheMultiCritere(int numSemaine, int idEleve, int numAbsences);
}