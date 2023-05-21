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

namespace calculation
{
    public partial class MainWindow : Window
    {
        private CalculationObjectPool objectPool;
        public MainWindow()
        {
            InitializeComponent();
            objectPool = new CalculationObjectPool(10); // Créez un pool avec une taille appropriée
        }

        private void AdditionButton_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(Operand1TextBox.Text, out int operand1) && int.TryParse(Operand2TextBox.Text, out int operand2))
            {
                CalculationObject calculationObject = objectPool.AcquireObject();

                calculationObject.Operand1 = operand1;
                calculationObject.Operand2 = operand2;
                calculationObject.Calculate(new AdditionStrategy());

                int result = calculationObject.Result;

                ResultSingleton resultSingleton = ResultSingleton.GetInstance();
                resultSingleton.Result = result;

                ResultTextBox.Text = result.ToString();

                objectPool.ReleaseObject(calculationObject);
            }
            else 
            {
                MessageBox.Show("Veuillez saisir des valeurs entières valides.");
            }
        }


        private void SubtractionButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Operand1TextBox.Text, out int operand1) && int.TryParse(Operand2TextBox.Text, out int operand2))
            {
                CalculationObject calculationObject = objectPool.AcquireObject();

                calculationObject.Operand1 = operand1;
                calculationObject.Operand2 = operand2;
                calculationObject.Calculate(new SubtractionStrategy());

                int result = calculationObject.Result;

                ResultSingleton resultSingleton = ResultSingleton.GetInstance();
                resultSingleton.Result = result;

                ResultTextBox.Text = result.ToString();

                objectPool.ReleaseObject(calculationObject);
            }
            else
            {
                MessageBox.Show("Veuillez saisir des valeurs entières valides.");
            }
        }
        private void MultiplicationButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Operand1TextBox.Text, out int operand1) && int.TryParse(Operand2TextBox.Text, out int operand2))
            {
                CalculationObject calculationObject = objectPool.AcquireObject();

                calculationObject.Operand1 = operand1;
                calculationObject.Operand2 = operand2;
                calculationObject.Calculate(new MultiplicationStrategy());

                int result = calculationObject.Result;

                ResultSingleton resultSingleton = ResultSingleton.GetInstance();
                resultSingleton.Result = result;

                ResultTextBox.Text = result.ToString();

                objectPool.ReleaseObject(calculationObject);
            }
            else
            {
                MessageBox.Show("Veuillez saisir des valeurs entières valides.");
            }
        }
        private void DivisionButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Operand1TextBox.Text, out int operand1) && int.TryParse(Operand2TextBox.Text, out int operand2) && operand2 != 0)
            {
                CalculationObject calculationObject = objectPool.AcquireObject();

                calculationObject.Operand1 = operand1;
                calculationObject.Operand2 = operand2;
                calculationObject.Calculate(new DivisionStrategy());

                int result = calculationObject.Result;

                ResultSingleton resultSingleton = ResultSingleton.GetInstance();
                resultSingleton.Result = result;

                ResultTextBox.Text = result.ToString();

                objectPool.ReleaseObject(calculationObject);
            }
            else
            {
                MessageBox.Show("Veuillez saisir des valeurs entières valides.");
            }
        }

    }
}
