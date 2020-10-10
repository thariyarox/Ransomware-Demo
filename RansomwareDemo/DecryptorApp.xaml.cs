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
using System.Windows.Shapes;

namespace RansomwareDemo
{
    /// <summary>
    /// Interaction logic for DecryptorApp.xaml
    /// </summary>
    public partial class DecryptorApp : Window
    {
        public DecryptorApp()
        {
            InitializeComponent();
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            lblMessage.Content = "";
            String key = this.txtKey.Text;

            if (key == null || "".Equals(key))
            {
                lblMessage.Content = "Please enter the key to decrypt files !";
            }
            else
            {
                ransomware.DecryptionUtil du = new ransomware.DecryptionUtil();
                du.startAction(key);

                lblMessage.Content = "Decryption done !";
            }            

        }

        private void decryptAppWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            lblMessage.Content = "";
        }

        private void btnEncryptor_Click(object sender, RoutedEventArgs e)
        {
            myencryptor m = new myencryptor();
            m.Show();
        }
    }
}
