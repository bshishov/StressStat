using System.Collections.Generic;
using System.Linq;

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
        public Configuration()
        {
            ShowPeopleSelector = true;
            HighValueLabel = "Высокий";
            LowValueLabel = "Низкий";
            Label = "Оцените уровень своей напряженности";
            People = new Dictionary<string, string>()
            {
                {"test1", "Иванов Иван Иванович"},
                {"test2", "test value 2"},
                {"test3", "test value 3"},
            };
            DefaultId = People.First().Key;
            AfterHours = 0;
            AfterMinutes = 1;
            LogPath = "";
            StartAfterMinutes = 0;
        }
    }
}
