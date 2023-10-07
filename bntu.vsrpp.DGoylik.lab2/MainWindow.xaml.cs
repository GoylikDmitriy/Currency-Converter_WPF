using bntu.vsrpp.DGoylik.Core.lab2.api;
using bntu.vsrpp.DGoylik.Core.lab2.api.exceptions;
using bntu.vsrpp.DGoylik.Core.lab2.api.loaders;
using bntu.vsrpp.DGoylik.Core.lab2.chart;
using bntu.vsrpp.DGoylik.Core.lab2.converter;
using bntu.vsrpp.DGoylik.Core.lab2.converter.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace bntu.vsrpp.DGoylik.lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            // await FillWithCurrency();
            await LoadRates();
        }

        private async Task FillWithCurrency()
        {
            this.FromCurrencyComboBox.Items.Clear();
            this.FromToCurrencyComboBox.Items.Clear();
            this.ToCurrencyComboBox.Items.Clear();
            this.ToFromCurrencyComboBox.Items.Clear();

            try
            {
                await CurrencyLoader.loadCurrency();
                if (CurrencyLoader.CURRENCIES != null)
                {
                    foreach (var currency in CurrencyLoader.CURRENCIES)
                    {
                        if (!this.FromCurrencyComboBox.Items.Contains(currency.Cur_Abbreviation))
                        {
                            this.FromCurrencyComboBox.Items.Add(currency.Cur_Abbreviation);
                            this.FromToCurrencyComboBox.Items.Add(currency.Cur_Abbreviation);
                            this.ToCurrencyComboBox.Items.Add(currency.Cur_Abbreviation);
                            this.ToFromCurrencyComboBox.Items.Add(currency.Cur_Abbreviation);
                        }
                    }
                }
            }
            catch (CurrencyLoadException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadRates()
        {
            this.FromCurrencyComboBox.Items.Clear();
            this.FromToCurrencyComboBox.Items.Clear();
            this.ToCurrencyComboBox.Items.Clear();
            this.ToFromCurrencyComboBox.Items.Clear();
            this.RateChartComboBox.Items.Clear();

            try
            {
                await RatesLoader.loadRate();
                foreach (var rate in RatesLoader.RATES)
                {
                    if (!this.FromCurrencyComboBox.Items.Contains(rate.Cur_Abbreviation))
                    {
                        this.FromCurrencyComboBox.Items.Add(rate.Cur_Abbreviation);
                        this.FromToCurrencyComboBox.Items.Add(rate.Cur_Abbreviation);
                        this.ToCurrencyComboBox.Items.Add(rate.Cur_Abbreviation);
                        this.ToFromCurrencyComboBox.Items.Add(rate.Cur_Abbreviation);
                        this.RateChartComboBox.Items.Add(rate.Cur_Abbreviation);
                    }
                }
            }
            catch (RatesLoadException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnShowExchangeRate_Click(object sender, RoutedEventArgs e)
        {
            new ExchangeRateWindow().Show();
        }

        private void BtnShowChart_Click(object sender, RoutedEventArgs e)
        {
            if (ChartHandler.CheckDates(this.FromDatePicker.SelectedDate, this.ToDatePicker.SelectedDate))
            {
                ChartHandler.fromDate = this.FromDatePicker.SelectedDate.Value;
                ChartHandler.toDate = this.ToDatePicker.SelectedDate.Value;
                ChartHandler.rate = RatesLoader.RATES.Where(r => r.Cur_Abbreviation == this.RateChartComboBox.SelectedItem.ToString()).FirstOrDefault();
                new ExchangeRateChartWindow().Show();
            }
            else
            {
                MessageBox.Show("From date cannot be more than to date.", "Warning", MessageBoxButton.OK);
            }
        }

        private void BtnConvertCurrency_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ToFromCurrencyTextBox.Text = CurrencyConverter.ConvertCurrency(
                    this.FromToCurrencyComboBox.SelectedItem.ToString(),
                    this.ToFromCurrencyComboBox.SelectedItem.ToString(),
                    this.FromToCurrencyTextBox.Text);
            }
            catch (CurrencyConvertException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnConvertToBYN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ToBYNTextBox.Text = CurrencyConverter.ConvertToBYN(this.FromCurrencyComboBox.SelectedItem.ToString(), this.FromCurrencyTextBox.Text);
            }
            catch (CurrencyConvertException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnConvertFromBYN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ToCurrencyTextBox.Text = CurrencyConverter.ConvertFromBYN(this.ToCurrencyComboBox.SelectedItem.ToString(), this.FromBYNTextBox.Text);
            }
            catch (CurrencyConvertException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
