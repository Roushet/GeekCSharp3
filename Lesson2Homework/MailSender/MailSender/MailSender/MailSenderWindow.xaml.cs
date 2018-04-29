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

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public ComboBoxItem SelectedItem()
        {
             return cmbServerName.SelectedItem as ComboBoxItem; 
        }

        private void OnTabSwitchBack(object sender, RoutedEventArgs e)
        {
            if (MainTabControl.SelectedIndex == 0) return;
            MainTabControl.SelectedIndex--;
        }

        private void OnTaSwitchForvard(object sender, RoutedEventArgs e)
        {
            if (MainTabControl.SelectedIndex == MainTabControl.Items.Count - 1) return;
            MainTabControl.SelectedIndex++;
        }

        public void GotoTab()
        {
            MainTabControl.SelectedIndex = 1;
        }

    }
}
