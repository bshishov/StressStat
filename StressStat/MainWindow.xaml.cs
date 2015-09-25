using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using Newtonsoft.Json;

namespace StressStat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string ConfigurationFile = "configurations.json";
        private readonly Configuration _configuration;
        private readonly Timer _timer;

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(ConfigurationFile))
            {
                try
                {
                    _configuration =JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(ConfigurationFile));
                }
                catch (Exception)
                {
                    Debug.WriteLine("Cannot load configuration file {0}", ConfigurationFile);
                }
            }

            if (_configuration == null)
            {
                _configuration = new Configuration();
                File.WriteAllText(ConfigurationFile, JsonConvert.SerializeObject(_configuration));
            }

            DataContext = this;

            _timer = new Timer(ShowBalloon);
            _timer.Change(TimeSpan.Zero,
                TimeSpan.FromHours(_configuration.AfterHours).Add(TimeSpan.FromMinutes(_configuration.AfterMinutes)));
        }

        private void ShowBalloon(object state)
        {
            Dispatcher.Invoke(() => 
            TaskbarIcon.ShowCustomBalloon(new AskDialog(_configuration), PopupAnimation.Slide, Int32.MaxValue));
        }

        public void OnExitClicked(object sender, RoutedEventArgs routedEventArgs)
        {
            if (_timer != null)
                _timer.Dispose();
            this.Close();
        }
    }
}
