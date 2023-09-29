using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microcharts;
using Entry = Microcharts.ChartEntry;
using SkiaSharp;
using System.IO;


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

            List<Entry> entries = new List<Entry>
            {
                new Entry(18.5f)
                {
                    Color = SKColor.Parse("#6369D1"),
                    Label = "Недостаток веса",
                    ValueLabel="18,5",
                    ValueLabelColor = SKColor.Parse("#6369D1"),
                },
                new Entry(25f)
                {
                    Color = SKColor.Parse("#AAFAC8"),
                    Label = "Норма",
                    ValueLabel="19-25",
                    ValueLabelColor = SKColor.Parse("#AAFAC8"),
                },
                new Entry(30f)
                {
                    Color = SKColor.Parse("#EF798A"),
                    Label = "Переизбыток веса",
                    ValueLabelColor = SKColor.Parse("#EF798A"),
                    ValueLabel="30",
                },
                new Entry(Convert.ToSingle(index))
                {
                    Color = SKColor.Parse("#6369D1"),
                    Label = "Ваш индекс массы тела",
                    ValueLabel = String.Format("{0:f1}", index),
                    ValueLabelColor = SKColor.Parse("#6369D1"),
                    
                }
            };
            imtChart.Chart = new BarChart { Entries = entries, LabelOrientation = Orientation.Horizontal, 
                ValueLabelOrientation = Orientation.Horizontal, Margin = 15,
                LabelTextSize = 25};

            imtChart.IsVisible = true;
            imt.IsVisible = true;

        }
    }
}
