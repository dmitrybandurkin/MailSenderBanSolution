using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MailSenderLib;
using MailSenderLib.Models;
using MailSenderLib.Services;

namespace WPFSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Переключение на планировщик
        /// </summary>
        private void OnPlanningClickButton(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }
    }
}
