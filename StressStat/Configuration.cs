using System.Collections.Generic;

namespace StressStat
{
    public class Configuration
    {
        public string Label;
        public string LowValueLabel;
        public string HighValueLabel;
        public bool ShowPeopleSelector;
        public int AfterHours;
        public int AfterMinutes;
        public string LogPath;
        public int StartAfterMinutes;
        public string DefaultId;
        public Dictionary<string, string> People;

        /// <summary>
        /// Default configuration
        /// </summary>
        public static Configuration Default = new Configuration()
        {
            ShowPeopleSelector = true,
            HighValueLabel = "Высокий",
            LowValueLabel = "Низкий",
            Label = "Оцените уровень своей напряженности",
            People = new Dictionary<string, string>()
            {
                {"test1", "Иванов Иван Иванович"},
                {"test2", "test value 2"},
                {"test3", "test value 3"},
            },
            DefaultId = "test1",
            AfterHours = 0,
            AfterMinutes = 1,
            LogPath = "",
            StartAfterMinutes = 0
        };
    }
}
