using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace wpf_my_form
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
        private void showAdd1Message_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is my default message");
        }

        private void showAdd2Message_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is my enother default message");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showMessage_Click(object sender, RoutedEventArgs e)
        {
            string str = textEnter.Text;
            MessageBox.Show(str);
        }

        private void doOperation_Click(object sender, RoutedEventArgs e) // operation executor button 
        {
            string operation = comboBox.Text;
           

            if (operation == "Clear field")
            {
                textEnter.Text = String.Empty;
            }
            else if (operation == "Copy text")
            {
              Clipboard.SetText(textEnter.Text);
            }
            else if (operation == "Paste text")
            {
                
               textEnter.Text = Clipboard.GetText();
            }
        }

        private void showP_A_Checked(object sender, RoutedEventArgs e) // Show Program Actions "show" method
        {
            comboBox.Visibility = Visibility.Visible;
            doOperation.Visibility = Visibility.Visible;
        }
        private void showP_A_Unchecked(object sender, RoutedEventArgs e)// Show Program Actions "Hide" method
        {
            comboBox.Visibility = Visibility.Hidden;
            doOperation.Visibility = Visibility.Hidden;
        }

        private void showM_A_Checked(object sender, RoutedEventArgs e) // Show Message Actions "show" method
        {
            showMessage.Visibility = Visibility.Visible;
            textEnter.Visibility = Visibility.Visible;
            showAdd1Message.Visibility = Visibility.Visible;
            showAdd2Message.Visibility = Visibility.Visible;
        }
        private void showM_A_Unchecked(object sender, RoutedEventArgs e) // Show Message Actions "hide" method
        {
            showMessage.Visibility = Visibility.Hidden;
            textEnter.Visibility = Visibility.Hidden;
            showAdd1Message.Visibility = Visibility.Hidden;
            showAdd2Message.Visibility = Visibility.Hidden;
        }


        private void enableM_A_Checked(object sender, RoutedEventArgs e) // Enable Message Action "Enable" method
        {
            textEnter.IsEnabled = true;
            showMessage.IsEnabled = true;
            showAdd1Message.IsEnabled = true;
            showAdd2Message.IsEnabled = true;
        }
        private void enableM_A_Unchecked(object sender, RoutedEventArgs e) // Enable Message Action "Disable" method
        {
            textEnter.IsEnabled = false;
            showMessage.IsEnabled = false;
            showAdd1Message.IsEnabled = false;
            showAdd2Message.IsEnabled = false;
        }

        private void enableP_A_Checked(object sender, RoutedEventArgs e) // Enable Program Action "Enable" method
        {
            comboBox.IsEnabled = true;
            doOperation.IsEnabled = true;
        }
        private void enableP_A_Unchecked(object sender, RoutedEventArgs e) // Enable Program Action "Disable" method
        {
            comboBox.IsEnabled = false;
            doOperation.IsEnabled = false;
        }

        private void sysPath_Click(object sender, RoutedEventArgs e)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uriBuilder = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uriBuilder.Path);
            path = System.IO.Path.GetDirectoryName(path);
            MessageBox.Show(path);
        }
    }
    
}
