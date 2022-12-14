using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace BusSchedule
{
    public partial class Main : Form
    {
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapter;
        string connection = "Data Source=KMILL;Initial Catalog=Timetable;Integrated Security=True";
        string STransport = "Select * from Transport";
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            printTransport();
        }
        public void printTransport()
        {
            string STransport = "Select * from Transport";
            adapter = new SqlDataAdapter(STransport, connection);
            ds = new DataSet();
            adapter.Fill(ds);
            gridForTransportList.DataSource = ds.Tables[0];
            gridForTransportList.Columns["transportID"].Visible = false;
            gridForTransportList.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

        }

        public void printRouteName(string transportID)
        {

            string queryForRouteName = $"Select rn.routeName as routeName,rn.routeNameBack as routeNameBack from routeName rn left join TransportRoutes tr on rn.routeID = tr.routeID where tr.transportID ={Convert.ToInt32(transportID)}";
            adapter = new SqlDataAdapter(queryForRouteName, connection);
            try
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                routeName.Text = dt.Rows[0]["routeName"].ToString();
                routeNameBack.Text = dt.Rows[0]["routeNameBack"].ToString();
            }
            catch
            {
                MessageBox.Show("Для данного транспорта не существует маршрут");
                routeName.Text = "Маршрут";
                routeNameBack.Text = "Маршрут";
            }
        }

        public void printTransportStops(string transportID)
        {
            string queryForTransportSpots = $"Select ts.transportStopID as transportStopID, ts.fullName as fullName from TransportStops ts left join RouteStopLink rsl on ts.transportStopID = rsl.transportStopID left join TransportRoutes tr on rsl.routeID = tr.routeID where tr.transportID = {Convert.ToInt32(transportID)}";
            adapter = new SqlDataAdapter(queryForTransportSpots, connection);
            ds = new DataSet();
            adapter.Fill(ds);
            gridForTransportStopsList.DataSource = ds.Tables[0];
            gridForTransportStopsList.Columns["transportStopID"].Visible = false;
            gridForTransportStopsList.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

        }
        public void printTransportStopsBack(string transportID)
        {
            string queryForTransportSpotsBack = $"Select ts.transportStopID as transportStopID, ts.fullName as fullName from TransportStops ts left join RouteStopLink rsl on ts.transportStopID = rsl.transportStopID left join TransportRoutes tr on rsl.routeID = tr.routeID where tr.transportID = {Convert.ToInt32(transportID)} order by rsl.transportStopID desc;";
            adapter = new SqlDataAdapter(queryForTransportSpotsBack, connection);
            ds = new DataSet();
            adapter.Fill(ds);
            gridForTransportStopsBackList.DataSource = ds.Tables[0];
            gridForTransportStopsBackList.Columns["transportStopID"].Visible = false;
            gridForTransportStopsBackList.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void transportSearch_TextChanged(object sender, EventArgs e)
        {
            string queryForRouteName = $"Select * from Transport where transportName like '{transportSearch.Text}%'";
            adapter = new SqlDataAdapter(queryForRouteName, connection);
            ds = new DataSet();
            adapter.Fill(ds);
            gridForTransportList.DataSource = ds.Tables[0];
        }

        private void gridForTransportList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxForTimetable.Clear();
            int rowIndex = gridForTransportList.CurrentCell.RowIndex;
            string values = gridForTransportList.Rows[rowIndex].Cells[0].Value.ToString();
            printRouteName(values);
            printTransportStops(values);
            printTransportStopsBack(values);
        }

        private void gridForTransportStopsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string routeID = gridForTransportList.Rows[gridForTransportList.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string transportStopID = gridForTransportStopsList.Rows[gridForTransportStopsList.CurrentCell.RowIndex].Cells[0].Value.ToString();
            printTimeOnSpots(Convert.ToInt32(routeID), Convert.ToInt32(transportStopID), 0);
            transportStop.Text = gridForTransportStopsList.Rows[gridForTransportStopsList.CurrentCell.RowIndex].Cells[1].Value.ToString();
            transportRoute.Text = routeName.Text;
        }
        private void gridForTransportStopsBackList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string routeID = gridForTransportList.Rows[gridForTransportList.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string transportStopID = gridForTransportStopsBackList.Rows[gridForTransportStopsBackList.CurrentCell.RowIndex].Cells[0].Value.ToString();
            printTimeOnSpots(Convert.ToInt32(routeID), Convert.ToInt32(transportStopID), 1);
            transportStop.Text = gridForTransportStopsBackList.Rows[gridForTransportStopsBackList.CurrentCell.RowIndex].Cells[1].Value.ToString();
            transportRoute.Text = routeNameBack.Text;
        }

        public void printTimeOnSpots(int routeID, int transportStopID, int direction)
        {
            string queryForTimeOnStop = $"select routeID, transportStopID, timeOnStop from transportOnStops where routeID = {routeID} and transportStopID = {transportStopID} and direction = {direction} order by scheduleID,stopOrder;";
            adapter = new SqlDataAdapter(queryForTimeOnStop, connection);
            dt = new DataTable();
            adapter.Fill(dt);
            DateTime time = Convert.ToDateTime(dt.Rows[0]["timeOnStop"].ToString());
            textBoxForTimetable.Text = time.ToString("HH:mm");
            for (int i = 1; i < gridForTransportStopsList.RowCount; i++)
            {
                time = time.AddMinutes(15);
                if (i % 9 == 0)
                {
                    textBoxForTimetable.Text += "\n" + time.ToString("HH:mm");
                }
                else
                {
                    textBoxForTimetable.Text += "\t" + time.ToString("HH:mm");
                }
            }

        }


    }
}
