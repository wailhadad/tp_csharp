namespace Ex_4;

public partial class Form1 : Form
{
    private List<double> notes = new List<double>();
    private int current_student = 0;
    private int nbr_etudiants;
    public Form1()
    {
        InitializeComponent();
        txtMax.Enabled = false;
        txtMin.Enabled = false;
        txtMoyenne.Enabled = false;
    }
    
    private void btnSaisir_Click(object sender, EventArgs e)
    {
        if (current_student == 0)
        {
            if (!int.TryParse(txtNbEtudiants.Text, out nbr_etudiants) || nbr_etudiants <= 0)
            {
                MessageBox.Show("Veuillez saisir un nombre d'étudiants valide svp.");
                return;
            }
        }

        txtNbEtudiants.Enabled = false;
            if (!double.TryParse(txtNote.Text, out double note) || note < 0 || note > 20)
            {
                MessageBox.Show("Veuillez saisir une note <=20 et >=0");
                return;
            }
            notes.Add(note);
            current_student++;
            if (current_student < nbr_etudiants)
            {
                txtNote.Text = "";
                txtNote.Focus();
                txtNote.PlaceholderText = $"Etudiant No : {current_student+1}";
            }
            else
            {
                btnSaisir.Enabled = false;
                txtNote.Enabled = false;
                CalculateStatistics();
            }
    }

    private void CalculateStatistics()
    {
        txtMax.Text = notes.Max().ToString("F2");
        txtMin.Text = notes.Min().ToString("F2");
        txtMoyenne.Text = notes.Average().ToString("F2");
    }

    private void RefreshBtn_Click(object sender, EventArgs e)
    {
        current_student = 0;
        nbr_etudiants = 0;
        notes.Clear();
        
        txtNote.PlaceholderText = $"Etudiant No : {current_student+1}";
        
        txtNote.Clear();
        txtNote.Enabled = true;
        
        txtNbEtudiants.Clear(); 
        txtNbEtudiants.Enabled = true;
        
        btnSaisir.Enabled = true;
        
        txtMax.Clear();
        txtMin.Clear();
        txtMoyenne.Clear();
    }
}