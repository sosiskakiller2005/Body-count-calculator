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
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;

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
                imt.Text = result + "  -  Недостаток веса";
                imt.TextColor = Color.FromRgb(125, 132, 178);
            }
            else if (index >= 18.5 & index <= 25)
            {
                imt.Text = result + "  -  Норма";
                imt.TextColor = Color.FromRgb(53, 206, 141);
            }
            else if (index > 25)
            {
                imt.Text = result + "  -  Переизбыток веса";
                imt.TextColor = Color.FromRgb(192, 50, 33);
            }

            List<Entry> entries = new List<Entry>
            {
                new Entry(18.5f)
                {
                    Color = SKColor.Parse("#7D84B2"),
                    Label = "Недостаток веса",
                    ValueLabel="18,5",
                    ValueLabelColor = SKColor.Parse("#7D84B2"),
                },
                new Entry(25f)
                {
                    Color = SKColor.Parse("#35ce8d"),
                    Label = "Норма",
                    ValueLabel="19-25",
                    ValueLabelColor = SKColor.Parse("#35ce8d"),
                },
                new Entry(Convert.ToSingle(index))
                {
                    Color = SKColor.Parse("#fcfafa"),
                    Label = "Ваш индекс массы тела",
                    ValueLabel = String.Format("{0:f1}", index),
                    ValueLabelColor = SKColor.Parse("#fcfafa"),
                    
                },
                new Entry(30f)
                {
                    Color = SKColor.Parse("#c03221"),
                    Label = "Переизбыток веса",
                    ValueLabelColor = SKColor.Parse("#c03221"),
                    ValueLabel="30",
                }
            };
            imtChart.Chart = new BarChart { Entries = entries, LabelOrientation = Orientation.Horizontal, 
                ValueLabelOrientation = Orientation.Horizontal, Margin = 15,
                LabelTextSize = 25, BackgroundColor = SKColor.Parse("#373e40")
            };

            imtChart.IsVisible = true;
            imt.IsVisible = true;

        }
    }
}
