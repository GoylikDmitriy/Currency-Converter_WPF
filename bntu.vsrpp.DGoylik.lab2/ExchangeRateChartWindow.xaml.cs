using bntu.vsrpp.DGoylik.Core.lab2.api.loaders;
using bntu.vsrpp.DGoylik.Core.lab2.chart;
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

namespace bntu.vsrpp.DGoylik.lab2
{
    /// <summary>
    /// Interaction logic for ExchangeRateChartWindow.xaml
    /// </summary>
    public partial class ExchangeRateChartWindow : Window
    {
        public ExchangeRateChartWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            DrawChartAsync();
        }

        private async void DrawChartAsync()
        {
            await ChartHandler.DrawChart(this.chart);

            this.AvgTextBlock.Text = ChartHandler.FindAverageOfThePeriod().ToString() + " " + ChartHandler.rate.Cur_Abbreviation;
            this.MaxTextBlock.Text = ChartHandler.FindDateWithMax().ToString("MM/dd/yyyy");
            this.MinTextBlock.Text = ChartHandler.FindDateWithMin().ToString("MM/dd/yyyy");
        }
    }
}
