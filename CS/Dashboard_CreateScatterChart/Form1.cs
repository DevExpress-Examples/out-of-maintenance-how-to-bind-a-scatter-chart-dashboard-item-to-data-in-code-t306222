using System;
using DevExpress.DashboardCommon;

namespace Dashboard_CreateScatterChart {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Creates a new dashboard and data source for this dashboard.
            Dashboard dashboard = new Dashboard();

            // Creates an OLAP dashboard data source based on the connection string 
            // stored in the app.config file.
            DashboardOlapDataSource olapDataSource = new DashboardOlapDataSource();
            olapDataSource.ConnectionName = "AdventureWorksString";
            dashboard.DataSources.Add(olapDataSource);

            // Creates a scatter chart and binds it to data.
            ScatterChartDashboardItem scatterChart = new ScatterChartDashboardItem();
            scatterChart.DataSource = olapDataSource;
            scatterChart.AxisXMeasure = new Measure("[Measures].[Sales Amount]");
            scatterChart.AxisYMeasure = new Measure("[Measures].[Gross Profit Margin]");
            scatterChart.Arguments.Add(new Dimension("[Product].[Category].[Category]"));
            scatterChart.Weight = new Measure("[Measures].[Gross Profit]");

            // Adds the scatter chart to the dashboard and opens this
            // dashboard in the Dashboard Viewer.
            dashboard.Items.Add(scatterChart);
            dashboardViewer1.Dashboard = dashboard;
        }
    }
}
