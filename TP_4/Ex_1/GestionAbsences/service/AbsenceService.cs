using Ex_1.GestionAbsences.entity;
using Ex_1.GestionAbsences.repository;

namespace Ex_1.GestionAbsences.service;

public class AbsenceService : IAbsenceService
{
    private readonly IAbsenceRepository _absenceRepository;

    public AbsenceService(IAbsenceRepository absenceRepository)
    {
        _absenceRepository = absenceRepository;
    }

    public void AjouterAbsence(Absence absence)
    {
        _absenceRepository.Add(absence);
    }

    public void ModifierAbsence(Absence absence)
    {
        _absenceRepository.Update(absence);
    }

    public void SupprimerAbsence(AbsenceId absenceId)
    {
        _absenceRepository.Delete(absenceId);
    }

    public List<Absence> AfficherToutesAbsences()
    {
        return _absenceRepository.GetAll();
    }

    public Absence TrouverParId(AbsenceId absenceId)
    {
        return _absenceRepository.GetById(absenceId);
    }

    public List<Absence> TrouverParSemaine(int semaine)
    {
        return _absenceRepository.FindBySemaine(semaine);
    }

    public List<Absence> TrouverParEleve(int idEleve)
    {
        return _absenceRepository.FindByEleve(idEleve);
    }

    public int CalculerTotalAbsencesById(int eleveId)
    {
        return _absenceRepository.CalculerTotalAbsencesById(eleveId);
    }

    public void AddAbsenceToEleveInWeek(Eleve eleve, int numAbsences, int numSemaine)
    {
        _absenceRepository.AddAbsenceToEleveInWeek(eleve, numAbsences, numSemaine);
    }

    public List<Absence> RechercheMultiCritere(int numSemaine, int idEleve, int numAbsences)
    {
        return _absenceRepository.RechercheMultiCritere(numSemaine, idEleve, numAbsences);
    }
}