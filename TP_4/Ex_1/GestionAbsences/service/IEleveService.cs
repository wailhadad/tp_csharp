using Ex_1.GestionAbsences.entity;

namespace Ex_1.GestionAbsences.service;

public interface IEleveService
{
    void AjouterEleve(Eleve eleve);
    void ModifierEleve(Eleve eleve);
    void SupprimerEleve(int idEleve);
    List<Eleve> AfficherTous();
    Eleve TrouverParId(int id);
    List<Eleve> TrouverParNom(string nom);
    List<Eleve> RechercheMultiCritere(string nom, string prenom, string groupe);
}