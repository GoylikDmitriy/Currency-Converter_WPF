using bntu.vsrpp.DGoylik.Core.lab2.api.loaders;
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
    /// Interaction logic for ExchangeRateWindow.xaml
    /// </summary>
    public partial class ExchangeRateWindow : Window
    {
        public ExchangeRateWindow()
        {
            InitializeComponent();
            this.ShowExchangeRate();
        }

        private void ShowExchangeRate()
        {
            int count = 2;
            if (RatesLoader.RATES != null)
            {
                foreach (var rate in RatesLoader.RATES)
                {
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(35);
                    this.RateGrid.RowDefinitions.Add(row);

                    Border border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.LightBlue);
                    border.BorderThickness = new Thickness(1);

                    TextBlock number = new TextBlock();
                    number.Text = (count - 1).ToString();
                    number.HorizontalAlignment = HorizontalAlignment.Center;
                    number.VerticalAlignment = VerticalAlignment.Center;
                    number.FontSize = 15;
                    number.FontWeight = FontWeights.Bold;
                    number.Foreground = new SolidColorBrush(Colors.LightBlue);
                    number.Margin = new Thickness(1, 0, 0, 0);

                    border.Child = number;

                    Grid.SetRow(border, count);
                    Grid.SetColumn(border, 0);

                    this.RateGrid.Children.Add(border);

                    border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.LightBlue);
                    border.BorderThickness = new Thickness(1);

                    TextBlock abbrev = new TextBlock();
                    abbrev.Text = rate.Cur_Abbreviation;
                    abbrev.HorizontalAlignment = HorizontalAlignment.Center;
                    abbrev.VerticalAlignment = VerticalAlignment.Center;
                    abbrev.FontSize = 15;
                    abbrev.FontWeight = FontWeights.Bold;
                    abbrev.Foreground = new SolidColorBrush(Colors.LightBlue);
                    abbrev.Margin = new Thickness(1, 0, 0, 0);

                    border.Child = abbrev;

                    Grid.SetRow(border, count);
                    Grid.SetColumn(border, 1);

                    this.RateGrid.Children.Add(border);

                    border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.LightBlue);
                    border.BorderThickness = new Thickness(1);

                    TextBlock curName = new TextBlock();
                    curName.Text = rate.Cur_Name;
                    curName.HorizontalAlignment = HorizontalAlignment.Left;
                    curName.VerticalAlignment = VerticalAlignment.Center;
                    curName.FontSize = 15;
                    curName.FontWeight = FontWeights.Bold;
                    curName.Foreground = new SolidColorBrush(Colors.LightBlue);
                    curName.Margin = new Thickness(5, 0, 0, 0);

                    border.Child = curName;

                    Grid.SetRow(border, count);
                    Grid.SetColumn(border, 2);

                    this.RateGrid.Children.Add(border);

                    border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.LightBlue);
                    border.BorderThickness = new Thickness(1);

                    TextBlock currency = new TextBlock();
                    currency.Text = rate.Cur_Scale.ToString();
                    currency.HorizontalAlignment = HorizontalAlignment.Center;
                    currency.VerticalAlignment = VerticalAlignment.Center;
                    currency.FontSize = 15;
                    currency.FontWeight = FontWeights.ExtraBold;
                    currency.Foreground = new SolidColorBrush(Colors.LightPink);
                    currency.Margin = new Thickness(1, 0, 0, 0);

                    border.Child = currency;

                    Grid.SetRow(border, count);
                    Grid.SetColumn(border, 3);

                    this.RateGrid.Children.Add(border);

                    border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.LightBlue);
                    border.BorderThickness = new Thickness(1);

                    TextBlock byn = new TextBlock();
                    byn.Text = rate.Cur_OfficialRate.ToString();
                    byn.HorizontalAlignment = HorizontalAlignment.Center;
                    byn.VerticalAlignment = VerticalAlignment.Center;
                    byn.FontSize = 15;
                    byn.FontWeight = FontWeights.ExtraBold;
                    byn.Foreground = new SolidColorBrush(Colors.LightPink);
                    byn.Margin = new Thickness(1, 0, 0, 0);

                    border.Child = byn;

                    Grid.SetRow(border, count);
                    Grid.SetColumn(border, 4);

                    this.RateGrid.Children.Add(border);

                    count++;
                }
            }
        }
    }
}
