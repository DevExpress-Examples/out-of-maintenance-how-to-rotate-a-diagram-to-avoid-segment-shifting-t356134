using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Charts;
using System.Collections.Generic;

namespace ChartSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Chart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChartControl chartControl = (ChartControl)sender;
            ChartHitInfo hitInfo = chartControl.CalcHitInfo(e.GetPosition(chartControl));

            int pointIndex = series.Points.IndexOf(hitInfo.SeriesPoint);
            SeriesPoint point = hitInfo.SeriesPoint;

            double oldPointPercent=0;
            CalcPointPercent(pointIndex, ref oldPointPercent);
            point.Value++;

            double newPointPercent = 0;
            CalcPointPercent(pointIndex, ref newPointPercent);

            series.Rotation += 360 * (oldPointPercent - newPointPercent);
            if (series.Rotation > 360)
                series.Rotation %= 360;
        }
        private void CalcPointPercent(int pointIndex, ref double oldPointPercent)
        {
            for (int i = 0; i < pointIndex; i++)
                oldPointPercent += series.Points[i].Value;
            oldPointPercent /= series.Points.Sum(p => p.Value);
        }
    }
}
