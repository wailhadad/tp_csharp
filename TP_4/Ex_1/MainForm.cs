using Ex_1.GestionAbsences.entity;
using Ex_1.GestionAbsences.repository;
using Ex_1.GestionAbsences.service;

namespace Ex_1;

public partial class MainForm : Form
{
    private IAbsenceService _absenceService;
    private IEleveService _eleveService;
    private string type;
    
    public MainForm(IAbsenceService absenceService, IEleveService eleveService)
    {
        InitializeComponent();
        panel2.Visible = false;
        panel3.Visible = true;
        panel3.BringToFront();
        _absenceService = absenceService;
        _eleveService = eleveService;
        dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
    }

    private void CleanInputs()
    {
        textBox1.Text = "";
        textBox2.Text = "";
        textBox3.Text = "";
        textBox4.Text = "";
    }
    
    private void SetupPanel(string type)
    {
        panel3.Visible = false;
        panel2.Visible = true;
        panel2.BringToFront();
        string[] eleveFields = ["ID", "Nom", "Prénom", "Groupe"];
        string[] absenceFields = ["Numéro de semaine", "ID Élève", "Nombre d'absences"];
        LoadData();

        if (type == "gestionAbsences")
        {
            label1.Text = absenceFields[0];
            label2.Text = absenceFields[1];
            label3.Text = absenceFields[2];
            label6.Text = "Tableau Des Absences";
            label4.Visible = false;
            textBox4.Visible = false;
        }
        else
        {
            label1.Text = eleveFields[0];
            label2.Text = eleveFields[1];
            label3.Text = eleveFields[2];
            label6.Text = "Tableau Des Elèves";
            textBox4.Visible = true;
            label4.Visible = true;
            label4.Text = eleveFields[3];
        }
        CleanInputs();
    }

    private void gestionAbsencesBtn_Click(object sender, EventArgs e)
    {
        this.type = "gestionAbsences";
        SetupPanel(type);
    }
    
    private void GestionElevesBtn_Click(object sender, EventArgs e)
    {
        type = "gestionEleves";
        SetupPanel(type);
    }

    private void AddBtn_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wanna add this Row ?", "Confirm Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (type == "gestionAbsences")
                {
                    var absence = new Absence(int.Parse(textBox1.Text.Trim()), int.Parse(textBox2.Text.Trim()),
                        int.Parse(textBox3.Text.Trim()));
                    _absenceService.AjouterAbsence(absence);
                }
                else
                {
                    var eleve = new Eleve(int.Parse(textBox1.Text.Trim()), textBox2.Text.Trim(), textBox3.Text.Trim(),
                        textBox4.Text.Trim());
                    _eleveService.AjouterEleve(eleve);
                }
                MessageBox.Show("Row added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        LoadData();
        CleanInputs();
    }

    private void SearchBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.type == "gestionAbsences")
            {
                int numSemaine  = string.IsNullOrWhiteSpace(textBox1.Text) ? 0 : int.Parse(textBox1.Text.Trim());
                int idEleve     = string.IsNullOrWhiteSpace(textBox2.Text) ? 0 : int.Parse(textBox2.Text.Trim());
                int numAbsences = string.IsNullOrWhiteSpace(textBox3.Text) ? 0 : int.Parse(textBox3.Text.Trim());
            
                dataGridView1.DataSource = _absenceService.RechercheMultiCritere(numSemaine, idEleve, numAbsences);
            }
            else
            {
                dataGridView1.DataSource = 
                    _eleveService.RechercheMultiCritere(textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim());
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void UpdateBtn_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wanna update this Row ?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (type == "gestionAbsences")
                {
                    Absence absenceModifie = new Absence(int.Parse(textBox1.Text.Trim()), int.Parse(textBox2.Text.Trim()),
                        int.Parse(textBox3.Text.Trim()));
                    _absenceService.ModifierAbsence(absenceModifie);
                }
                else
                {
                    Eleve eleveModifie = new Eleve(int.Parse(textBox1.Text.Trim()), textBox2.Text.Trim(),
                        textBox3.Text.Trim(), textBox4.Text.Trim());
                    _eleveService.ModifierEleve(eleveModifie);
                }
                MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        LoadData();
        CleanInputs();
    }

    private void searchByIdBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (type == "gestionAbsences")
            {
                int numSemaine = !string.IsNullOrEmpty(textBox1.Text) ? int.Parse(textBox1.Text.Trim()) : 0;
                int idEleve    = !string.IsNullOrEmpty(textBox2.Text) ? int.Parse(textBox2.Text.Trim()) : 0;
                
                if (numSemaine == 0 || idEleve == 0) 
                    throw new Exception(
                        "\nThe correct Absence ID structure is :\n" +
                        "Primary_Key(num_semaine, id_Eleve)\n" + 
                        "Make sure to insert them both."
                        );
                
                AbsenceId absenceId = new AbsenceId(idEleve, numSemaine);
                Absence absenceRecherche = _absenceService.TrouverParId(absenceId);
                if (absenceRecherche == null)
                {
                    throw new Exception("Aucune absence trouvée avec ces critères.");
                }
                dataGridView1.DataSource = new[] { absenceRecherche };
            }
            else
            {
                Eleve eleveRecherche = _eleveService.TrouverParId(int.Parse(textBox1.Text.Trim()));
                dataGridView1.DataSource = new List<Eleve>([eleveRecherche]);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteBtn_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Row ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (type == "gestionAbsences")
                {
                    int numSemaine = !string.IsNullOrEmpty(textBox1.Text) ? int.Parse(textBox1.Text.Trim()) : 0;
                    int idEleve    = !string.IsNullOrEmpty(textBox2.Text) ? int.Parse(textBox2.Text.Trim()) : 0;
                
                    if (numSemaine == 0 || idEleve == 0) 
                        throw new Exception(
                            "\nThe correct Absence ID structure is :\n" +
                            "Primary_Key(num_semaine, id_Eleve)\n" + 
                            "Make sure to insert them both."
                        );

                    AbsenceId absenceId = new AbsenceId(int.Parse(textBox2.Text.Trim()), int.Parse(textBox1.Text.Trim()));
                    _absenceService.SupprimerAbsence(absenceId);
                }
                else
                {
                    _eleveService.SupprimerEleve(int.Parse(textBox1.Text.Trim()));
                }
                MessageBox.Show("Row deleted successfully", "Succès !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        LoadData();
        CleanInputs();
    }

    private void LoadData()
    {
        if (type == "gestionAbsences")
        {
            dataGridView1.DataSource = _absenceService.AfficherToutesAbsences();
        }
        else
        {
            dataGridView1.DataSource = _eleveService.AfficherTous();
        }
    }

    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count > 0)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            if (type == "gestionAbsences")
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
            }
            else
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
            }
        }
    }
    
}