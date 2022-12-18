Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Xpf.Charts

Namespace ChartSample

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub Chart_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            Dim chartControl As ChartControl = CType(sender, ChartControl)
            Dim hitInfo As ChartHitInfo = chartControl.CalcHitInfo(e.GetPosition(chartControl))
            Dim pointIndex As Integer = Me.series.Points.IndexOf(hitInfo.SeriesPoint)
            Dim point As SeriesPoint = hitInfo.SeriesPoint
            Dim oldPointPercent As Double = 0
            CalcPointPercent(pointIndex, oldPointPercent)
            point.Value += 1
            Dim newPointPercent As Double = 0
            CalcPointPercent(pointIndex, newPointPercent)
            Me.series.Rotation += 360 * (oldPointPercent - newPointPercent)
            If Me.series.Rotation > 360 Then Me.series.Rotation = Me.series.Rotation Mod 360
        End Sub

        Private Sub CalcPointPercent(ByVal pointIndex As Integer, ByRef oldPointPercent As Double)
            For i As Integer = 0 To pointIndex - 1
                oldPointPercent += Me.series.Points(i).Value
            Next

            oldPointPercent /= Me.series.Points.Sum(Function(p) p.Value)
        End Sub
    End Class
End Namespace
