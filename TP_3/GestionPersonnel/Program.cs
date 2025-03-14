using GestionPersonnel.GestionPersonnel;

class Program
{
    static void Main()
    {
        RessourcesHumaines rh = new RessourcesHumaines();
        
        Enseignant ens1 = new Enseignant(1, "Ahmed", "Bennani", "PA", 20);
        rh.AjouterPersonnel(ens1);
        
        Enseignant ens2 = new Enseignant(2, "mohammad", "alami", "PES", 30);
        rh.AjouterPersonnel(ens2);
        
        Etudiant etu1 = new Etudiant(101,"Ali","Khalid","AP2",15 );
        ens1.AjouterGroupe("Groupe A");
        ens1.AjouterEtudiant("Groupe A", etu1);

        rh.Afficher_Enseignants();
    }
}