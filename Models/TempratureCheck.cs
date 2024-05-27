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
                return "You have a fever.";
            }
            else if (temperature <= 35)
            {
                return "You have hypothermia.";
            }
            else
            {
                return "Your temperature is normal.";
            }
        }
    }
}
