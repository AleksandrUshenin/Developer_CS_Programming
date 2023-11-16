using Calculator.Logik;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculatorClass calc;
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Calculator";
            calc = new CalculatorClass();
            LabelResult.Content = calc.Result;
            calc.MyEventHandler += Calc_MyEventHandler;
        }
        private void Calc_MyEventHandler(object? sender, EventArgs e)
        {
            if (sender is CalculatorClass)
            {
                LabelResult.Content = ((CalculatorClass)sender).Result;
                TextBoxNumber.Text = "";
            }
            Console.WriteLine(((CalculatorClass)sender).Result);
        }
        private double GetNum()
        {
            double res = 0;
            double.TryParse(TextBoxNumber.Text, out res);
            if (!MyDouble.DoubleTryPars(TextBoxNumber.Text, out res))
            {
                TextBoxNumber.Background = Brushes.Red;
                MessageBox.Show("Ошибка преобразования стоки в число!", "Double Try Pars");
            }
            else
                TextBoxNumber.Background = Brushes.White;
            return res;
        }
        private bool CheckingNumber(double result)
        {
            try
            {
                return MyDouble.CheckingForPositiveNumber(result);
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
        private void ButtonSum_Click(object sender, RoutedEventArgs e)
        {
            //int res = (int)LabelResult.Content;
            calc.Sum(GetNum());
        }

        private void ButtonSub_Click(object sender, RoutedEventArgs e)
        {
            double res = GetNum();
            if (!CheckingNumber(res))
                MessageBox.Show("Число отрицательное", "Checking For А Positive Number");
            else
                calc.Sub(res);
        }

        private void ButtonMult_Click(object sender, RoutedEventArgs e)
        {
            calc.Multy(GetNum());
        }

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            calc.Cansale();
        }

        private void ButtonDiv_Click(object sender, RoutedEventArgs e)
        {
            double res = GetNum();
            if (!CheckingNumber(res))
                MessageBox.Show("Число отрицательное", "Checking For А Positive Number");
            else
                calc.Divide(res);
        }
    }
}
