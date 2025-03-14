using System.Data.SqlTypes;
using System.Security.AccessControl;

namespace Ex_1.fichiers_repertoires;

using System;
public class Fichier
{
    private String nom;
    private String extension;
    private float taille; // Taille en Ko

    public Fichier(String nom, String extension, float taille)
    {
        Nom = nom;
        Extension = extension;
        Taille = taille;
    }

    public String Nom
    {
        get { return nom; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Le Nom du fichier est invalide\n");
            }

            if (value.Length > 255)
            {
                throw new ArgumentException("Le Nom du fichier doit etre au max 255 characters");
            }
            nom = value;
        }
    }

    public String Extension
    {
        get { return extension; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Le extension du fichier est invalide\n");
            }

            if (!value.StartsWith("."))
            {
                throw new ArgumentException("Veuillez ajouter l'extension du fichier\n");
            }

            if (value.Length > 10)
            {
                throw new ArgumentException("L'extension du fichier n'est pas valide\n");
            }
            extension = value.ToLower();
        }
    }

    public float Taille
    {
        get { return taille; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("La taille doit etre positive\n");
            }
            taille = value;
        }
    }

    public override string ToString()
    {
        return $"Nom : {Nom} Extension : {extension} Taille : {Taille}";
    }
}