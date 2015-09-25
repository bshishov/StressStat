using System;
using System.Collections.Generic;
using System.Linq;

namespace StressStat
{
    public class Configuration
    {
        public readonly bool ShowPeopleSelector;
        public readonly Dictionary<string, string> People;
        public readonly string DefaultId;
        public readonly int AfterHours;
        public readonly int AfterMinutes;
        public readonly string LogPath;

        /// <summary>
        /// Default configuration
        /// </summary>
        public Configuration()
        {
            ShowPeopleSelector = true;
            People = new Dictionary<string, string>()
            {
                {"test1", "test value 1"},
                {"test2", "test value 2"},
                {"test3", "test value 3"},
            };
            DefaultId = People.First().Key;
            AfterHours = 0;
            AfterMinutes = 1;
            LogPath = "";
        }
    }
}
