namespace MvcAssagnment1.Models
{
    public static class TemperatureCheck
    {
        public static string CheckTemperature(float temperature, string scale)
        {
            if (scale == "Fahrenheit")
            {
                temperature = (temperature - 32) * 5 / 9; // Convert to Celsius
            }

            if (temperature >= 38)
            {
                return "Du har feber !!.";
            }
            else if (temperature <= 35)
            {
                return "Du fryser innombords!!.";
            }
            else
            {
                return "Du är ok !!.";
            }
        }
    }
}
