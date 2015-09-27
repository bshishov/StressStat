using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Hardcodet.Wpf.TaskbarNotification;

namespace StressStat
{
    /// <summary>
    /// Interaction logic for AskDialog.xaml
    /// </summary>
    public partial class AskDialog : UserControl
    {
        public class Score
        {
            public int Value { get; private set; }
            public bool IsChecked { get; set; }
            public Brush BgrBrush { get; private set; }

            public Score(int value)
            {
                Value = value;
                BgrBrush = new SolidColorBrush(ColorScale.HeatMap.Get(Value/9.0));
            }
        }

        private readonly DateTime _created = DateTime.Now;

        public Configuration Configuration { get; private set; }
        public Dictionary<string, string> People { get { return Configuration.People; } }
        public KeyValuePair<string,string> Selected { get; set; }
        public ObservableCollection<Score> Scores { get; set; }
        public bool ShowPeopleSelector { get { return Configuration.ShowPeopleSelector; } }
        public string Label { get { return Configuration.Label; } }
        public string LowValueLabel { get { return Configuration.LowValueLabel; } }
        public string HighValueLabel { get { return Configuration.HighValueLabel; } }

        public AskDialog(Configuration configuration)
        {
            Scores = new ObservableCollection<Score>
            {
                new Score(1),
                new Score(2),
                new Score(3),
                new Score(4),
                new Score(5),
                new Score(6),
                new Score(7),
                new Score(8),
                new Score(9),
            };

            Configuration = configuration;
            Selected = configuration.People.FirstOrDefault(kvp => kvp.Key.Equals(configuration.DefaultId));

            this.DataContext = this;
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var score = Scores.FirstOrDefault(sc => sc.IsChecked);
            if (score != null)
            {
                WriteData(score.Value);
                var taskbarIcon = TaskbarIcon.GetParentTaskbarIcon(this);
                taskbarIcon.CloseBalloon();
            }
        }

        private void WriteData(int score)
        {
            Configuration.DefaultId = Selected.Key;
            var fileName = Selected.Key + ".csv";
            var path = Path.Combine(Configuration.LogPath, fileName);
            var reaction = DateTime.Now.Subtract(_created).TotalSeconds;
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine("{0};{1};{2};{3};{4}", _created, DateTime.Now, Selected.Key, reaction, score);
                writer.Close();
            }
        }
    }
}
