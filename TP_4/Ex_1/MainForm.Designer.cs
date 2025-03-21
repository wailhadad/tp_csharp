using System.ComponentModel;

namespace Ex_1;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        label1 = new System.Windows.Forms.Label();
        AddBtn = new System.Windows.Forms.Button();
        SearchBtn = new System.Windows.Forms.Button();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        DeleteBtn = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        textBox3 = new System.Windows.Forms.TextBox();
        panel1 = new System.Windows.Forms.Panel();
        label5 = new System.Windows.Forms.Label();
        gestionAbsencesBtn = new System.Windows.Forms.Button();
        gestionElevesBtn = new System.Windows.Forms.Button();
        panel2 = new System.Windows.Forms.Panel();
        welcomeLabel = new System.Windows.Forms.Label();
        searchByIdBtn = new System.Windows.Forms.Button();
        textBox4 = new System.Windows.Forms.TextBox();
        UpdateBtn = new System.Windows.Forms.Button();
        label6 = new System.Windows.Forms.Label();
        dataGridView1 = new System.Windows.Forms.DataGridView();
        panel3 = new System.Windows.Forms.Panel();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        panel3.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(14, 47);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(204, 34);
        label1.TabIndex = 0;
        label1.Text = "label1";
        // 
        // AddBtn
        // 
        AddBtn.Location = new System.Drawing.Point(519, 25);
        AddBtn.Name = "AddBtn";
        AddBtn.Size = new System.Drawing.Size(184, 34);
        AddBtn.TabIndex = 1;
        AddBtn.Text = "Ajouter";
        AddBtn.UseVisualStyleBackColor = true;
        AddBtn.Click += AddBtn_Click;
        // 
        // SearchBtn
        // 
        SearchBtn.Location = new System.Drawing.Point(519, 87);
        SearchBtn.Name = "SearchBtn";
        SearchBtn.Size = new System.Drawing.Size(184, 36);
        SearchBtn.TabIndex = 2;
        SearchBtn.Text = "Recherche Multi-Critère";
        SearchBtn.UseVisualStyleBackColor = true;
        SearchBtn.Click += SearchBtn_Click;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(14, 116);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(204, 34);
        label2.TabIndex = 3;
        label2.Text = "label2";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(14, 194);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(204, 34);
        label3.TabIndex = 4;
        label3.Text = "label3";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(14, 274);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(204, 36);
        label4.TabIndex = 5;
        label4.Text = "label4";
        // 
        // DeleteBtn
        // 
        DeleteBtn.Location = new System.Drawing.Point(519, 285);
        DeleteBtn.Name = "DeleteBtn";
        DeleteBtn.Size = new System.Drawing.Size(184, 36);
        DeleteBtn.TabIndex = 6;
        DeleteBtn.Text = "Supprimer";
        DeleteBtn.UseVisualStyleBackColor = true;
        DeleteBtn.Click += DeleteBtn_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(231, 37);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(227, 53);
        textBox1.TabIndex = 7;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(231, 116);
        textBox2.Multiline = true;
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(227, 49);
        textBox2.TabIndex = 8;
        // 
        // textBox3
        // 
        textBox3.Location = new System.Drawing.Point(231, 194);
        textBox3.Multiline = true;
        textBox3.Name = "textBox3";
        textBox3.Size = new System.Drawing.Size(227, 50);
        textBox3.TabIndex = 9;
        // 
        // panel1
        // 
        panel1.BackColor = System.Drawing.SystemColors.Highlight;
        panel1.Controls.Add(label5);
        panel1.Controls.Add(gestionAbsencesBtn);
        panel1.Controls.Add(gestionElevesBtn);
        panel1.Location = new System.Drawing.Point(1, 1);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(200, 726);
        panel1.TabIndex = 11;
        // 
        // label5
        // 
        label5.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        label5.Location = new System.Drawing.Point(20, 47);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(139, 249);
        label5.TabIndex = 12;
        label5.Text = " Absences               et                     Elèves";
        // 
        // gestionAbsencesBtn
        // 
        gestionAbsencesBtn.BackColor = System.Drawing.SystemColors.ControlLight;
        gestionAbsencesBtn.Location = new System.Drawing.Point(20, 337);
        gestionAbsencesBtn.Name = "gestionAbsencesBtn";
        gestionAbsencesBtn.Size = new System.Drawing.Size(164, 36);
        gestionAbsencesBtn.TabIndex = 12;
        gestionAbsencesBtn.Text = "Gestion Des Absences";
        gestionAbsencesBtn.UseVisualStyleBackColor = false;
        gestionAbsencesBtn.Click += gestionAbsencesBtn_Click;
        // 
        // gestionElevesBtn
        // 
        gestionElevesBtn.BackColor = System.Drawing.SystemColors.ControlLight;
        gestionElevesBtn.Location = new System.Drawing.Point(20, 418);
        gestionElevesBtn.Name = "gestionElevesBtn";
        gestionElevesBtn.Size = new System.Drawing.Size(164, 36);
        gestionElevesBtn.TabIndex = 13;
        gestionElevesBtn.Text = "Gestion Des Eleves";
        gestionElevesBtn.UseVisualStyleBackColor = false;
        gestionElevesBtn.Click += GestionElevesBtn_Click;
        // 
        // panel2
        // 
        panel2.Controls.Add(panel3);
        panel2.Controls.Add(searchByIdBtn);
        panel2.Controls.Add(textBox4);
        panel2.Controls.Add(UpdateBtn);
        panel2.Controls.Add(label6);
        panel2.Controls.Add(dataGridView1);
        panel2.Controls.Add(DeleteBtn);
        panel2.Controls.Add(textBox3);
        panel2.Controls.Add(SearchBtn);
        panel2.Controls.Add(label1);
        panel2.Controls.Add(AddBtn);
        panel2.Controls.Add(textBox2);
        panel2.Controls.Add(label2);
        panel2.Controls.Add(textBox1);
        panel2.Controls.Add(label3);
        panel2.Controls.Add(label4);
        panel2.Location = new System.Drawing.Point(207, 1);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(806, 726);
        panel2.TabIndex = 12;
        // 
        // welcomeLabel
        // 
        welcomeLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
        welcomeLabel.Font = new System.Drawing.Font("Monotype Corsiva", 25.800001F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        welcomeLabel.Location = new System.Drawing.Point(19, 21);
        welcomeLabel.Name = "welcomeLabel";
        welcomeLabel.Size = new System.Drawing.Size(487, 304);
        welcomeLabel.TabIndex = 16;
        welcomeLabel.Text = "Bienvenue Au Système De Gestion Des Absences Et des Elèves";
        welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // searchByIdBtn
        // 
        searchByIdBtn.Location = new System.Drawing.Point(519, 220);
        searchByIdBtn.Name = "searchByIdBtn";
        searchByIdBtn.Size = new System.Drawing.Size(184, 36);
        searchByIdBtn.TabIndex = 15;
        searchByIdBtn.Text = "Recherche par ID";
        searchByIdBtn.UseVisualStyleBackColor = true;
        searchByIdBtn.Click += searchByIdBtn_Click;
        // 
        // textBox4
        // 
        textBox4.Location = new System.Drawing.Point(231, 271);
        textBox4.Multiline = true;
        textBox4.Name = "textBox4";
        textBox4.Size = new System.Drawing.Size(227, 50);
        textBox4.TabIndex = 14;
        // 
        // UpdateBtn
        // 
        UpdateBtn.Location = new System.Drawing.Point(519, 155);
        UpdateBtn.Name = "UpdateBtn";
        UpdateBtn.Size = new System.Drawing.Size(184, 36);
        UpdateBtn.TabIndex = 13;
        UpdateBtn.Text = "Update";
        UpdateBtn.UseVisualStyleBackColor = true;
        UpdateBtn.Click += UpdateBtn_Click;
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(72, 337);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(274, 35);
        label6.TabIndex = 12;
        label6.Text = "label6";
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new System.Drawing.Point(72, 386);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.Size = new System.Drawing.Size(665, 326);
        dataGridView1.TabIndex = 11;
        dataGridView1.Text = "dataGridView1";
        // 
        // panel3
        // 
        panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
        panel3.Controls.Add(welcomeLabel);
        panel3.Location = new System.Drawing.Point(345, 155);
        panel3.Name = "panel3";
        panel3.Size = new System.Drawing.Size(521, 350);
        panel3.TabIndex = 17;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.ActiveCaption;
        ClientSize = new System.Drawing.Size(1019, 734);
        Controls.Add(panel1);
        Controls.Add(panel2);
        Controls.Add(panel3);
        Text = "WAIL HADAD";
        panel1.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        panel3.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panel3;

    private System.Windows.Forms.Label welcomeLabel;

    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.Button searchByIdBtn;

    // private System.Windows.Forms.Label welcomeLabel;
    //
    // private System.Windows.Forms.Label welcomeLabel;

    private System.Windows.Forms.Button AddBtn;

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button gestionAbsencesBtn;
    private System.Windows.Forms.Button gestionElevesBtn;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button UpdateBtn;
    private System.Windows.Forms.Button SearchBtn;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button DeleteBtn;

    #endregion
}