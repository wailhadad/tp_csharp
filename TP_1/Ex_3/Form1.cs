namespace Ex_3;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        textResult.ReadOnly = true;
    }


    private void button_Click(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(NbrCopies.Text, out int nbrPhotocopies) || nbrPhotocopies <= 0)
                MessageBox.Show("le nombre de photocopies saisi est invalide");
            double totalCost = CalculateCost(nbrPhotocopies);
            textResult.Text = $"Total : {totalCost:F2} Dhs";
            NbrCopies.Clear();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static double CalculateCost(int nbrPhotocopies)
    {
        return nbrPhotocopies switch
        {
            <= 10 => 0.5 * nbrPhotocopies,
            <= 30 => 0.5 * 10 + 0.25 * (nbrPhotocopies-10),
            _ => 0.5 * 10 + 0.25 * 20 + 0.10 * (nbrPhotocopies-30)
        };
    }
}