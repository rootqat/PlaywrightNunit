using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlaywrightPOMUnit.Config
{
    public static class ConfigReader
    {
        public static TestSettings ReadConfig()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = workingDirectory.Substring(0, workingDirectory.IndexOf("bin"));

            var configFile = File.ReadAllText(projectDirectory+ "/appsettings.json");
           
            var jsonSerializerSettings = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            jsonSerializerSettings.Converters.Add(new JsonStringEnumConverter());

            return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerSettings);

        }
    }
}
