using Ex_1.GestionAbsences.DAO;
using Ex_1.GestionAbsences.entity;
using Ex_1.GestionAbsences.repository;

namespace Ex_1.GestionAbsences.service;

public class EleveService : IEleveService
{
    private readonly IEleveRepository _eleveRepository;

    public EleveService(IEleveRepository eleveRepository)
    {
        _eleveRepository = eleveRepository;
    }
    
    public void AjouterEleve(Eleve eleve)
    {
        _eleveRepository.Add(eleve);
    }

    public void ModifierEleve(Eleve eleve)
    {
        _eleveRepository.Update(eleve);
    }

    public void SupprimerEleve(int idEleve)
    {
        _eleveRepository.Delete(idEleve);
    }

    public List<Eleve> AfficherTous()
    {
        return _eleveRepository.GetAll();
    }

    public Eleve TrouverParId(int id)
    {
        return _eleveRepository.GetById(id);
    }

    public List<Eleve> TrouverParNom(string nom)
    {
        return _eleveRepository.GetByName(nom);
    }

    public List<Eleve> RechercheMultiCritere(string nom, string prenom, string groupe)
    {
        return _eleveRepository.Search(nom, prenom, groupe);
    }
}