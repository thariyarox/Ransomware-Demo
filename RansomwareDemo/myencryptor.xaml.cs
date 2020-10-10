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
using RansomwareDemo.ransomware;

namespace RansomwareDemo
{
    /// <summary>
    /// Interaction logic for myencryptor.xaml
    /// </summary>
    public partial class myencryptor : Window
    {
        public myencryptor()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RansomwareDemo.ransomware.EncryptionUtil ru = new EncryptionUtil();
            ru.startAction();
        }
    }
}
