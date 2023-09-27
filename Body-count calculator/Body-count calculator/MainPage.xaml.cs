using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Body_count_calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            double height = Convert.ToDouble(heightEn.Text) / 100;
            double weight = Convert.ToDouble(weightEn.Text);
            double index = weight / Math.Pow(2, height);
            string result = string.Format("{0:f}", index);
            if (index < 18.5)
            {
                imt.Text = result + "    Недостаток веса";
                imt.TextColor = Color.Blue;
            }
            else if (index >= 18.5 & index <= 25)
            {
                imt.Text = result + "    Норма";
                imt.TextColor = Color.Green;
            }
            else if (index > 25)
            {
                imt.Text = result + "    Переизбыток веса";
                imt.TextColor = Color.Red;
            }

            imt.IsVisible = true;

        }
    }
}
