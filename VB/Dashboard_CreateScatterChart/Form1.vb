Imports System
Imports DevExpress.DashboardCommon

Namespace Dashboard_CreateScatterChart
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			Dim dashboard As New Dashboard()

			' Create an OLAP dashboard data source with the connection string 
			' stored in the app.config file.
			Dim olapDataSource As New DashboardOlapDataSource()
			olapDataSource.ConnectionName = "AdventureWorksString"
			dashboard.DataSources.Add(olapDataSource)

			' Create a scatter chart and binds it to data.
			Dim scatterChart As New ScatterChartDashboardItem()
			scatterChart.DataSource = olapDataSource
			scatterChart.AxisXMeasure = New Measure("[Measures].[Sales Amount]")
			scatterChart.AxisYMeasure = New Measure("[Measures].[Gross Profit Margin]")
			scatterChart.Arguments.Add(New Dimension("[Product].[Category].[Category]"))
			scatterChart.Weight = New Measure("[Measures].[Gross Profit]")

			' Add the scatter chart to the dashboard and
			' display the dashboard in the Dashboard Viewer.
			dashboard.Items.Add(scatterChart)
			dashboardViewer1.Dashboard = dashboard
		End Sub
	End Class
End Namespace
