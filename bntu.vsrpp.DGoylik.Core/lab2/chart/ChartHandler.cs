using bntu.vsrpp.DGoylik.Core.lab2.api.loaders;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using bntu.vsrpp.DGoylik.Core.lab2.api;

namespace bntu.vsrpp.DGoylik.Core.lab2.chart
{
    public static class ChartHandler
    {
        public static Rate rate { get; set; }
        public static DateTime fromDate {  get; set; }
        public static DateTime toDate { get; set; }

        public static async Task LoadRateShort()
        {
            await RatesLoader.loadRateShort(rate.Cur_ID, fromDate, toDate);
        }

        public static DateTime FindDateWithMax()
        {
            decimal? maxOfficialRate = RatesLoader.RATES_SHORT.Max(r => r.Cur_OfficialRate);
            return RatesLoader.RATES_SHORT.FirstOrDefault(r => r.Cur_OfficialRate == maxOfficialRate)?.Date ?? DateTime.MinValue;
        }

        public static DateTime FindDateWithMin()
        {
            decimal? minOfficialRate = RatesLoader.RATES_SHORT.Min(r => r.Cur_OfficialRate);
            return RatesLoader.RATES_SHORT.FirstOrDefault(r => r.Cur_OfficialRate == minOfficialRate)?.Date ?? DateTime.MinValue;
        }

        public static decimal? FindAverageOfThePeriod()
        {
            decimal? average = RatesLoader.RATES_SHORT.Average(r => r.Cur_OfficialRate);
            return Math.Round(average.Value, 2);
        }

        public static async Task DrawChart(Canvas canvas)
        {
            await LoadRateShort();

            double canvasWidth = canvas.Width;
            double canvasHeight = canvas.Height;

            decimal? maxOfficialRate = RatesLoader.RATES_SHORT.Max(r => r.Cur_OfficialRate);
            decimal? minOfficialRate = RatesLoader.RATES_SHORT.Min(r => r.Cur_OfficialRate);

            double xScale = canvasWidth / (toDate - fromDate).TotalDays;
            double yScale = canvasHeight / (double)(maxOfficialRate - minOfficialRate);

            int segmentCount = RatesLoader.RATES_SHORT.Count;
            double segmentSpacing = canvasWidth / (segmentCount - 1);

            Path path = new Path();
            path.Stroke = Brushes.LightBlue;
            path.StrokeThickness = 2;

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();

            double startX = 0;
            double startY = canvasHeight - ((double)(RatesLoader.RATES_SHORT[0].Cur_OfficialRate - minOfficialRate.Value) * yScale);
            pathFigure.StartPoint = new Point(startX, startY);

            TextBlock label = new TextBlock();
            label.Text = RatesLoader.RATES_SHORT[0].Date.ToString("yyyy-MM-dd");
            label.Margin = new Thickness(startX - 20, canvasHeight + 10, 0, 0);
            label.FontSize = 15;
            label.FontWeight = FontWeights.Bold;
            label.Foreground = Brushes.LightGreen;
            canvas.Children.Add(label);

            for (int i = 1; i < segmentCount; i++)
            {
                double x = i * segmentSpacing;
                double y = canvasHeight - ((double)(RatesLoader.RATES_SHORT[i].Cur_OfficialRate - minOfficialRate.Value) * yScale);
                pathFigure.Segments.Add(new LineSegment(new Point(x, y), true));

                if (i % 3 == 0 && segmentCount - i > 3)
                {
                    label = new TextBlock();
                    label.Text = RatesLoader.RATES_SHORT[i].Date.ToString("yyyy-MM-dd");
                    label.Margin = new Thickness(x - 20, canvasHeight + 10, 0, 0);
                    label.FontSize = 15;
                    label.FontWeight = FontWeights.Bold;
                    label.Foreground = Brushes.LightGreen;
                    canvas.Children.Add(label);
                }
            }

            label = new TextBlock();
            label.Text = RatesLoader.RATES_SHORT[segmentCount - 1].Date.ToString("yyyy-MM-dd");
            label.Margin = new Thickness(canvasWidth - 70, canvasHeight + 10, 0, 0);
            label.FontSize = 15;
            label.FontWeight = FontWeights.Bold;
            label.Foreground = Brushes.LightGreen;
            canvas.Children.Add(label);

            pathGeometry.Figures.Add(pathFigure);

            path.Data = pathGeometry;

            canvas.Children.Add(path);
        }

        public static bool CheckDates(DateTime? from, DateTime? to)
        {
            return from < to;
        }
    }
}
