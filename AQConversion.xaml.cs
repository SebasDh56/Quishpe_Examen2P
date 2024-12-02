namespace AQAppExamen;

public partial class AQConversion : ContentPage
{
    public AQConversion()
    {
        InitializeComponent();

        // Opciones de unidades
        var units = new List<string> { "AQ Metros/segundo", "AQ Kilómetros/hora", "AQ Millas/hora" };
        FromPicker.ItemsSource = units;
        ToPicker.ItemsSource = units;
    }

    private void AQOnConvertClicked(object sender, EventArgs e)
    {
      
        if (!double.TryParse(SpeedEntry.Text, out double speed) ||
            FromPicker.SelectedItem == null ||
            ToPicker.SelectedItem == null)
        {
            DisplayAlert("AQ Error", "Por favor, completa todos los campos correctamente.", "OK");
            return;
        }

        string fromUnit = FromPicker.SelectedItem.ToString();
        string toUnit = ToPicker.SelectedItem.ToString();

       
        double result = ConvertSpeed(speed, fromUnit, toUnit);

       
        ResultLabel.Text = $"AQ {speed} {fromUnit} = {result:0.##} {toUnit}";
    }

    private void AQLimpiar(object sender, EventArgs e)
    {
        // Limpiar el campo de entrada
        SpeedEntry.Text = string.Empty;

        // Restablecer los Pickers
        FromPicker.SelectedIndex = -1;
        ToPicker.SelectedIndex = -1;

        // Limpiar el resultado
        ResultLabel.Text = "AQ Resultado aparecerá aquí";
    }

    private double ConvertSpeed(double value, string fromUnit, string toUnit)
    {
        // Convertir a base (metros/segundo)
        double baseValue = fromUnit switch
        {
            "AQ Metros/segundo" => value,
            "AQ Kilómetros/hora" => value / 3.6,
            "AQ Millas/hora" => value / 2.237,
            _ => 0
        };

        // Convertir desde la base a la unidad deseada
        return toUnit switch
        {
            "AQ Metros/segundo" => baseValue,
            "AQ Kilómetros/hora" => baseValue * 3.6,
            "AQ Millas/hora" => baseValue * 2.237,
            _ => 0
        };
    }
}
