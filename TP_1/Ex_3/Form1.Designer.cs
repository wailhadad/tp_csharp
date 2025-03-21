namespace Ex_3;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        textResult = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        NbrCopies = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // textResult
        // 
        textResult.BackColor = System.Drawing.SystemColors.ScrollBar;
        textResult.Cursor = System.Windows.Forms.Cursors.No;
        textResult.Font = new System.Drawing.Font("Segoe UI", 10.8F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        textResult.Location = new System.Drawing.Point(274, 265);
        textResult.Multiline = true;
        textResult.Name = "textResult";
        textResult.PlaceholderText = "Montant totale à payer...";
        textResult.Size = new System.Drawing.Size(364, 40);
        textResult.TabIndex = 6;
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
        button1.Cursor = System.Windows.Forms.Cursors.Hand;
        button1.Font = new System.Drawing.Font("Segoe UI", 13.200001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.Location = new System.Drawing.Point(93, 171);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(545, 49);
        button1.TabIndex = 7;
        button1.Text = "Calculer le montant totale";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button_Click;
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.SystemColors.HotTrack;
        label1.Cursor = System.Windows.Forms.Cursors.Default;
        label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        label1.Location = new System.Drawing.Point(93, 265);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(136, 40);
        label1.TabIndex = 9;
        label1.Text = "Résultat";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label2
        // 
        label2.BackColor = System.Drawing.SystemColors.HotTrack;
        label2.Cursor = System.Windows.Forms.Cursors.Default;
        label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        label2.Location = new System.Drawing.Point(93, 79);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(368, 40);
        label2.TabIndex = 11;
        label2.Text = "Entrer le nombre des photocopies";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // NbrCopies
        // 
        NbrCopies.BackColor = System.Drawing.SystemColors.ScrollBar;
        NbrCopies.Cursor = System.Windows.Forms.Cursors.IBeam;
        NbrCopies.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        NbrCopies.Location = new System.Drawing.Point(477, 79);
        NbrCopies.Multiline = true;
        NbrCopies.Name = "NbrCopies";
        NbrCopies.PlaceholderText = "Entrer un entier > 0 ...";
        NbrCopies.Size = new System.Drawing.Size(161, 40);
        NbrCopies.TabIndex = 12;
        NbrCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(725, 385);
        Controls.Add(NbrCopies);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(button1);
        Controls.Add(textResult);
        Text = "Exercice_3";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox NbrCopies;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textResult;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button button1;

    #endregion
}