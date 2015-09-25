using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Hardcodet.Wpf.TaskbarNotification;

namespace StressStat
{
    /// <summary>
    /// Interaction logic for AskDialog.xaml
    /// </summary>
    public partial class AskDialog : UserControl
    {
        private readonly Configuration _configuration;

        public Dictionary<string, string> People { get { return _configuration.People; } }

        public KeyValuePair<string,string> Selected { get; set; }
        

        public AskDialog(Configuration configuration)
        {
            this.DataContext = this;
            
            _configuration = configuration;
            Selected = configuration.People.FirstOrDefault(kvp => kvp.Key.Equals(configuration.DefaultId));
    
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
             var taskbarIcon = TaskbarIcon.GetParentTaskbarIcon(this);
             taskbarIcon.CloseBalloon();
        }
    }
}
