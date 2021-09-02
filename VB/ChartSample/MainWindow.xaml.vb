Imports System
Imports System.Linq
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Xpf.Charts
Imports System.Collections.Generic

Namespace ChartSample
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()

		End Sub
		Private Sub Chart_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim chartControl As ChartControl = DirectCast(sender, ChartControl)
			Dim hitInfo As ChartHitInfo = chartControl.CalcHitInfo(e.GetPosition(chartControl))

			Dim pointIndex As Integer = series.Points.IndexOf(hitInfo.SeriesPoint)
			Dim point As SeriesPoint = hitInfo.SeriesPoint

			Dim oldPointPercent As Double=0
			CalcPointPercent(pointIndex, oldPointPercent)
			point.Value += 1

			Dim newPointPercent As Double = 0
			CalcPointPercent(pointIndex, newPointPercent)

			series.Rotation += 360 * (oldPointPercent - newPointPercent)
			If series.Rotation > 360 Then
				series.Rotation = series.Rotation Mod 360
			End If
		End Sub
		Private Sub CalcPointPercent(ByVal pointIndex As Integer, ByRef oldPointPercent As Double)
			For i As Integer = 0 To pointIndex - 1
				oldPointPercent += series.Points(i).Value
			Next i
			oldPointPercent /= series.Points.Sum(Function(p) p.Value)
		End Sub
	End Class
End Namespace
