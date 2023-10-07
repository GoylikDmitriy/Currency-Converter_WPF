using bntu.vsrpp.DGoylik.Core.lab2.api.loaders;
using bntu.vsrpp.DGoylik.Core.lab2.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using bntu.vsrpp.DGoylik.Core.lab2.converter.exceptions;

namespace bntu.vsrpp.DGoylik.Core.lab2.converter
{
    public static class CurrencyConverter
    {
        public static string ConvertCurrency(string fromCurrencyAbbr, string toCurrencyAbbr, string value)
        {
            var fromCurrency = GetCurrency(fromCurrencyAbbr);
            var toCurrency = GetCurrency(toCurrencyAbbr);
            if (fromCurrency != null && toCurrency != null)
            {
                var fromRate = fromCurrency.Cur_OfficialRate;
                var fromScale = fromCurrency.Cur_Scale;
                var toRate = toCurrency.Cur_OfficialRate;
                var toScale = toCurrency.Cur_Scale;
                if (decimal.TryParse(value, out decimal val))
                {
                    return (val * ((fromRate / fromScale) / (toRate / toScale))).ToString();
                }
                else
                {
                    throw new CurrencyConvertException("Value is an incorrect number.");
                }
            }
            else
            {
                throw new CurrencyConvertException("Unable to find currencies for conversion.");
            }
        }

        public static string ConvertToBYN(string fromCurrencyAbbr, string value)
        {
            var currency = GetCurrency(fromCurrencyAbbr);
            if (currency != null)
            {
                var rate = currency.Cur_OfficialRate;
                var scale = currency.Cur_Scale;
                if (decimal.TryParse(value, out decimal val))
                {
                    return (val * (rate / scale)).ToString();
                }
                else
                {
                    throw new CurrencyConvertException("Value is an incorrect number.");
                }
            }
            else
            {
                throw new CurrencyConvertException("Unable to find currency for conversion.");
            }
        }

        public static string ConvertFromBYN(string toCurrencyAbbr, string value)
        {
            var currency = GetCurrency(toCurrencyAbbr);
            if (currency != null)
            {
                var rate = currency.Cur_OfficialRate;
                var scale = currency.Cur_Scale;
                if (decimal.TryParse(value, out decimal val))
                {
                    return (val / (rate / scale)).ToString();
                }
                else
                {
                    throw new CurrencyConvertException("Value is an incorrect number.");
                }
            }
            else
            {
                throw new CurrencyConvertException("Unable to find currency for conversion.");
            }
        }

        private static Rate GetCurrency(string currencyAbbreviation)
        {
            return RatesLoader.RATES.FirstOrDefault(rate => rate.Cur_Abbreviation == currencyAbbreviation);
        }
    }
}
