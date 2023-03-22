using Syncfusion.Maui.DataForm;

namespace CustomizeCheckBoxColor
{
    public class ItemSourceProvider : IDataFormSourceProvider
    {
        public object GetSource(string sourceName)
        {
            if (sourceName == "Country")
            {
                List<string> country = new List<string>() { "USA", "Italy", "India" };
                return country;
            }

            if (sourceName == "City")
            {
                List<string> city = new List<string>() { "Delhi", "Paris", "Boston", "Mumbai", "New York" };
                return city;
            }

            return new List<string>();
        }
    }
}