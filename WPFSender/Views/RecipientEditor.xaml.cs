using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFSender.Views
{
    /// <summary>
    /// Логика взаимодействия для RecipientEditor.xaml
    /// </summary>
    public partial class RecipientEditor : UserControl
    {
        public RecipientEditor()
        {
            InitializeComponent();
        }
        private void OnDatavalidationError(object sender, ValidationErrorEventArgs e)
        {
            if (!(e.Source is Control control)) return;
            if (e.Action == ValidationErrorEventAction.Added) control.ToolTip = e.Error.ErrorContent.ToString();
            else control.ClearValue(ToolTipProperty);
        }
    }
}
