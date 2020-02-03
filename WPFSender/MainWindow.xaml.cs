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

        /// <summary>
        /// Отправка письма
        /// </summary>
        private void SendMailButton_Click(object sender, RoutedEventArgs e)
        {
            if (SubjectBox.Text == "" || BodyMailBox.Text == "")
            {
                StatusBox.Text = $"Заголовок письма или тело письма пустые";
                tabControl.SelectedIndex = 2;
                return;
            }

            var recipient = RecipientBox.SelectedItem as Recipient;
            if (recipient == null)
            {
                StatusBox.Text = $"Не выбран получатель";
                tabControl.SelectedIndex = 0;
                return;
            }
            StatusBox.Text = recipient.Address;


            var senderAddress = LogBox.SelectedItem as Sender;
            var server = ServerBox.SelectedItem as Server;

                      //encrypt and decrypt must work with password from another window
            SendService mailsender = new SendService(server.Login, PassCrypter.Decrypt(PassCrypter.Encrypt(PassBox.Password)), server.Port, server.Address);
            try
            {
                mailsender.SendEMail(senderAddress.Address, recipient.Address, SubjectBox.Text, BodyMailBox.Text);
                StatusBox.Text = $"Письмо успешно отправлено";
            }
            catch (Exception ex)
            {
                StatusBox.Text = $"{ ex.Message}";
            }

        }
    }
}
