using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage1 : ContentPage
    {
        //Label resultText;
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;
        public MainPage1()
        {
            InitializeComponent();
            OnClear(this, null);
        }
        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            if(this.resultText.Text =="0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }
            this.resultText.Text += pressed;
            double number;
            if(double.TryParse(this.resultText.Text,out number))
            {
                this.resultText.Text = number.ToString("NO");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else {
                    secondNumber = number;
                }
            }

        }
        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }
        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }
        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);

                this.resultText.Text = result.ToString("N0");
                firstNumber = result;
                currentState = -1;
            }
        }
    }
}