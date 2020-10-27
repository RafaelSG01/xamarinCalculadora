using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCalculadora
{
    public partial class MainPage : ContentPage
    {
        int CurrentState = 1;
        string MathOperator;
        double FirstNumber, SecondNumber;

        public MainPage()
        {
            InitializeComponent();
            OnClear(new object(), new EventArgs());
        }

        public void OnClear(object sender, EventArgs e)
        {
            FirstNumber = 0;
            SecondNumber = 0;
            CurrentState = 1;
            this.resultText.Text = "0";
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            if(this.resultText.Text == "0" || CurrentState < 0)
            {
                this.resultText.Text = "";
                if(CurrentState < 0)
                {
                    CurrentState *= -1;
                }
            }

            this.resultText.Text += pressed;

            double number;
            if(double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                if(CurrentState == 1)
                {
                    FirstNumber = number;
                }
                else
                {
                    SecondNumber = number;
                }
            }
        }

        public void OnSelectOperator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            if (CurrentState == 2)
            {                
                double result = 0;
                if (MathOperator == "+")
                {
                    result = FirstNumber + SecondNumber;
                }
                if (MathOperator == "-")
                {
                    result = FirstNumber - SecondNumber;
                }
                if (MathOperator == "/")
                {
                    result = FirstNumber / SecondNumber;
                }
                if (MathOperator == "X")
                {
                    result = FirstNumber * SecondNumber;
                }

                this.resultText.Text = result.ToString("N0");
                FirstNumber = result;
                CurrentState = -1;
            }
            CurrentState = -2;
            MathOperator = pressed;
        }

        public void OnCalculator(object sender, EventArgs e)
        {
            if(CurrentState == 2)
            {
                double result = 0;
                if(MathOperator == "+")
                {
                    result = FirstNumber + SecondNumber;
                }
                if (MathOperator == "-")
                {
                    result = FirstNumber - SecondNumber;
                }
                if (MathOperator == "/")
                {
                    result = FirstNumber / SecondNumber;
                }
                if (MathOperator == "X")
                {
                    result = FirstNumber * SecondNumber;
                }

                this.resultText.Text = result.ToString("N0");
                FirstNumber = result;
                CurrentState = -1;
            }
        }
    }
}
