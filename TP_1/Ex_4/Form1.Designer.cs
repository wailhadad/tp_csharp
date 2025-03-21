namespace Ex_4;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtNbEtudiants = new System.Windows.Forms.TextBox();
        txtNote = new System.Windows.Forms.TextBox();
        btnSaisir = new System.Windows.Forms.Button();
        txtMax = new System.Windows.Forms.TextBox();
        txtMin = new System.Windows.Forms.TextBox();
        txtMoyenne = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        labelMax = new System.Windows.Forms.Label();
        labelMin = new System.Windows.Forms.Label();
        labelMoyenne = new System.Windows.Forms.Label();
        labelTitle = new System.Windows.Forms.Label();
        RefreshBtn = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // txtNbEtudiants
        // 
        txtNbEtudiants.ForeColor = System.Drawing.Color.Gray;
        txtNbEtudiants.Location = new System.Drawing.Point(234, 50);
        txtNbEtudiants.Name = "txtNbEtudiants";
        txtNbEtudiants.Size = new System.Drawing.Size(130, 30);
        txtNbEtudiants.TabIndex = 1;
        txtNbEtudiants.Text = "Entrez N...";
        txtNbEtudiants.Enter += RemovePlaceholder;
        txtNbEtudiants.Leave += AddPlaceholder;
        // 
        // txtNote
        // 
        txtNote.ForeColor = System.Drawing.Color.Gray;
        txtNote.Location = new System.Drawing.Point(234, 90);
        txtNote.Name = "txtNote";
        txtNote.Size = new System.Drawing.Size(130, 30);
        txtNote.TabIndex = 2;
        txtNote.Text = "Entrez la note...";
        txtNote.Enter += RemovePlaceholder;
        txtNote.Leave += AddPlaceholder;
        // 
        // btnSaisir
        // 
        btnSaisir.BackColor = System.Drawing.Color.MediumSeaGreen;
        btnSaisir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSaisir.ForeColor = System.Drawing.Color.White;
        btnSaisir.Location = new System.Drawing.Point(391, 90);
        btnSaisir.Name = "btnSaisir";
        btnSaisir.Size = new System.Drawing.Size(100, 30);
        btnSaisir.TabIndex = 3;
        btnSaisir.Text = "Saisir";
        btnSaisir.UseVisualStyleBackColor = false;
        btnSaisir.Click += btnSaisir_Click;
        // 
        // txtMax
        // 
        txtMax.BackColor = System.Drawing.Color.WhiteSmoke;
        txtMax.Location = new System.Drawing.Point(100, 150);
        txtMax.Name = "txtMax";
        txtMax.ReadOnly = true;
        txtMax.Size = new System.Drawing.Size(80, 30);
        txtMax.TabIndex = 4;
        // 
        // txtMin
        // 
        txtMin.BackColor = System.Drawing.Color.WhiteSmoke;
        txtMin.Location = new System.Drawing.Point(250, 150);
        txtMin.Name = "txtMin";
        txtMin.ReadOnly = true;
        txtMin.Size = new System.Drawing.Size(80, 30);
        txtMin.TabIndex = 5;
        // 
        // txtMoyenne
        // 
        txtMoyenne.BackColor = System.Drawing.Color.WhiteSmoke;
        txtMoyenne.Location = new System.Drawing.Point(448, 150);
        txtMoyenne.Name = "txtMoyenne";
        txtMoyenne.ReadOnly = true;
        txtMoyenne.Size = new System.Drawing.Size(80, 30);
        txtMoyenne.TabIndex = 6;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(50, 50);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(178, 25);
        label1.TabIndex = 7;
        label1.Text = "Nombre d\'étudiants:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(50, 90);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(178, 25);
        label2.TabIndex = 8;
        label2.Text = "Note de l\'étudiant:";
        // 
        // labelMax
        // 
        labelMax.Location = new System.Drawing.Point(50, 150);
        labelMax.Name = "labelMax";
        labelMax.Size = new System.Drawing.Size(50, 25);
        labelMax.TabIndex = 9;
        labelMax.Text = "Max:";
        // 
        // labelMin
        // 
        labelMin.Location = new System.Drawing.Point(200, 150);
        labelMin.Name = "labelMin";
        labelMin.Size = new System.Drawing.Size(50, 25);
        labelMin.TabIndex = 10;
        labelMin.Text = "Min:";
        // 
        // labelMoyenne
        // 
        labelMoyenne.Location = new System.Drawing.Point(350, 150);
        labelMoyenne.Name = "labelMoyenne";
        labelMoyenne.Size = new System.Drawing.Size(92, 25);
        labelMoyenne.TabIndex = 11;
        labelMoyenne.Text = "Moyenne:";
        // 
        // labelTitle
        // 
        labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        labelTitle.ForeColor = System.Drawing.Color.DarkBlue;
        labelTitle.Location = new System.Drawing.Point(150, 10);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new System.Drawing.Size(280, 30);
        labelTitle.TabIndex = 0;
        labelTitle.Text = "📚 Gestion des Notes";
        // 
        // RefreshBtn
        // 
        RefreshBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
        RefreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        RefreshBtn.ForeColor = System.Drawing.Color.White;
        RefreshBtn.Location = new System.Drawing.Point(391, 50);
        RefreshBtn.Name = "RefreshBtn";
        RefreshBtn.Size = new System.Drawing.Size(100, 30);
        RefreshBtn.TabIndex = 12;
        RefreshBtn.Text = "Refresh";
        RefreshBtn.UseVisualStyleBackColor = false;
        RefreshBtn.Click += RefreshBtn_Click;
        // 
        // Form1
        // 
        BackColor = System.Drawing.Color.LightBlue;
        ClientSize = new System.Drawing.Size(571, 220);
        Controls.Add(RefreshBtn);
        Controls.Add(labelTitle);
        Controls.Add(txtNbEtudiants);
        Controls.Add(txtNote);
        Controls.Add(btnSaisir);
        Controls.Add(txtMax);
        Controls.Add(txtMin);
        Controls.Add(txtMoyenne);
        Controls.Add(label1);
        Controls.Add(label2);
        Controls.Add(labelMax);
        Controls.Add(labelMin);
        Controls.Add(labelMoyenne);
        Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Text = "Gestion des Notes";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button RefreshBtn;

    // 📌 Placeholder Handling
    private void RemovePlaceholder(object sender, EventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        if (textBox.ForeColor == System.Drawing.Color.Gray)
        {
            textBox.Text = "";
            textBox.ForeColor = System.Drawing.Color.Black;
        }
    }

    private void AddPlaceholder(object sender, EventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        if (string.IsNullOrWhiteSpace(textBox.Text))
        {
            textBox.ForeColor = System.Drawing.Color.Gray;
            textBox.Text = textBox == txtNbEtudiants ? "Entrez N..." : "Entrez la note...";
        }
    }

    private System.Windows.Forms.TextBox txtNbEtudiants;
    private System.Windows.Forms.TextBox txtNote;
    private System.Windows.Forms.Button btnSaisir;
    private System.Windows.Forms.TextBox txtMax;
    private System.Windows.Forms.TextBox txtMin;
    private System.Windows.Forms.TextBox txtMoyenne;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label labelMax;
    private System.Windows.Forms.Label labelMin;
    private System.Windows.Forms.Label labelMoyenne;
    private System.Windows.Forms.Label labelTitle;

    #endregion
}
