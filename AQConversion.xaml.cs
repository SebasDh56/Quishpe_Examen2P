namespace AQAppExamen;

public partial class AQConversion : ContentPage
{
    public AQConversion()
    {
        InitializeComponent();

        // Opciones de unidades
        var units = new List<string> { "Metros/segundo", "Kilómetros/hora", "Millas/hora" };
        FromPicker.ItemsSource = units;
        ToPicker.ItemsSource = units;
    }

    private void OnConvertClicked(object sender, EventArgs e)
    {
        // Validar entrada
        if (!double.TryParse(SpeedEntry.Text, out double speed) ||
            FromPicker.SelectedItem == null ||
            ToPicker.SelectedItem == null)
        {
            DisplayAlert("Error", "Por favor, completa todos los campos correctamente.", "OK");
            return;
        }

        string fromUnit = FromPicker.SelectedItem.ToString();
        string toUnit = ToPicker.SelectedItem.ToString();

        // Realizar la conversión
        double result = ConvertSpeed(speed, fromUnit, toUnit);

        // Mostrar resultado
        ResultLabel.Text = $"{speed} {fromUnit} = {result:0.##} {toUnit}";
    }

    private double ConvertSpeed(double value, string fromUnit, string toUnit)
    {
        // Convertir a base (metros/segundo)
        double baseValue = fromUnit switch
        {
            "Metros/segundo" => value,
            "Kilómetros/hora" => value / 3.6,
            "Millas/hora" => value / 2.237,
            _ => 0
        };

        // Convertir desde la base a la unidad deseada
        return toUnit switch
        {
            "Metros/segundo" => baseValue,
            "Kilómetros/hora" => baseValue * 3.6,
            "Millas/hora" => baseValue * 2.237,
            _ => 0
        };
    }
}
