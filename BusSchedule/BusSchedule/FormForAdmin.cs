using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace BusSchedule
{
    public partial class FormForAdmin : Form
    {
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapter;
        string connectionString = "Data Source=KMILL;Initial Catalog=Timetable;Integrated Security=True";
        Main mainForm;

        public FormForAdmin()
        {
            InitializeComponent();
        }

        private void FormForAdmin_Load(object sender, EventArgs e)
        {
            printTransportsTable();
            printTrasportRoutesTable();
            printTransportStopsTable();
            printRouteStopLinkTable();
            printScheduleTable();
            fillTransportNamesComboBox();
            fillRouteNamesComboBox(routeNameComboBox);
            fillRouteNamesComboBox(routeNameForLinkComboBox);
            fillStopsComboBox(stopNameForLinkComboBox);
        }

        public void printTransportsTable()
        {
            string STransport = "Select transportID,transportName from Transport";
            adapter = new SqlDataAdapter(STransport, connectionString);
            ds = new DataSet();
            adapter.Fill(ds);
            gridForTransport.DataSource = ds.Tables[0];
            gridForTransport.Columns["transportID"].Visible = false;
            gridForTransport.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            gridForTransport.ClearSelection();


        }
        public void printTrasportRoutesTable()
        {
            string STransport = "Select tr.routeID, rN.routeName, t.transportID, t.transportName from Transport t right join TransportRoutes tr on tr.transportID = t.transportID left join routeName rN on tr.routeID = rN.routeID";
            adapter = new SqlDataAdapter(STransport, connectionString);
            ds = new DataSet();
            adapter.Fill(ds);
            gridForTransportRoutes.DataSource = ds.Tables[0];
            gridForTransportRoutes.Columns["transportID"].Visible = false;
            gridForTransportRoutes.Columns["routeID"].Width = 30;
            gridForTransportRoutes.Columns["transportName"].Width = 60;
            gridForTransportRoutes.ClearSelection();
            gridForTransportRoutes.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
        }
        public void printTransportStopsTable()
        {
            string STransport = "Select transportStopID,fullName from TransportStops";
            adapter = new SqlDataAdapter(STransport, connectionString);
            ds = new DataSet();
            adapter.Fill(ds);
            gridForTransportStops.DataSource = ds.Tables[0];
            gridForTransportStops.Columns["transportStopID"].Visible = false;
            gridForTransportStops.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            gridForTransportStops.ClearSelection();
        }
        public void printRouteStopLinkTable()
        {
            string STransport = "Select rsl.routeStopLinkID,rsl.routeID, rn.routeName as N'Название маршрута',ts.transportStopID,ts.fullName as N'Остановка', rsl.timeShift as N'Время до остановки',rsl.stopOrder as N'Номер остановки' from routeName rN left join RouteStopLink rsl on rN.routeID = rsl.routeID left join TransportStops ts on rsl.transportStopID = ts.transportStopID order by rsl.routeID, rsl.stopOrder";
            adapter = new SqlDataAdapter(STransport, connectionString);
            ds = new DataSet();
            adapter.Fill(ds);
            gridForRouteStopLink.DataSource = ds.Tables[0];
            gridForRouteStopLink.Columns["routeStopLinkID"].Visible = false;
            gridForRouteStopLink.Columns["transportStopID"].Visible = false;
            gridForRouteStopLink.ClearSelection();
            gridForRouteStopLink.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
        }
        public void printScheduleTable()
        {
            string STransport = "Select sc.scheduleID, rN.routeName as N'Маршрут', sc.routeID,sc.startTime as N'Старт маршрута',case when sc.direction=0 then N'0 - прямое' else N'1 - обратное' end N'Направление'from Schedule sc left join routeName rN on sc.routeID = rN.routeID";
            adapter = new SqlDataAdapter(STransport, connectionString);
            ds = new DataSet();
            adapter.Fill(ds);
            gridForSchedule.DataSource = ds.Tables[0];
            gridForSchedule.Columns["scheduleID"].Visible = false;
            gridForSchedule.Columns["routeID"].Visible = false;
            gridForSchedule.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            gridForSchedule.ClearSelection();

        }


        public void update()
        {
            int transportID = Convert.ToInt32(transportNameComboBox.SelectedValue);
            bool check = isTheSameElInTable(gridForTransportRoutes, transportID);
            if (transportNameComboBox.SelectedIndex != -1)
            {
                if (check == true)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {

                            string sql = $"insert into TransportRoutes(transportID) values({transportID})";
                            SqlCommand cmd = new SqlCommand(sql, connection);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Добавлено");
                            printTrasportRoutesTable();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Маршрут для данного транспорта существует");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        public void fillTransportNamesComboBox()
        {
            string queryForTrasnportName = "Select transportID,transportName from Transport";
            adapter = new SqlDataAdapter(queryForTrasnportName, connectionString);
            dt = new DataTable();
            adapter.Fill(dt);
            transportNameComboBox.DataSource = dt;
            transportNameComboBox.DisplayMember = "transportName";
            transportNameComboBox.ValueMember = "transportID";

        }
        public void fillRouteNamesComboBox(System.Windows.Forms.ComboBox comboBox)
        {
            string queryForTrasnportName = "Select tr.routeID,rN.routeName from routeName rN right join TransportRoutes tr on rN.routeID = tr.routeID";
            adapter = new SqlDataAdapter(queryForTrasnportName, connectionString);
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = "routeName";
            comboBox.ValueMember = "routeID";
            directionComboBox.SelectedIndex = 0;

        }
        public void fillStopsComboBox(System.Windows.Forms.ComboBox comboBox)
        {
            string queryForTrasnportName = "Select transportStopID,fullName from TransportStops";
            adapter = new SqlDataAdapter(queryForTrasnportName, connectionString);
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = "fullName";
            comboBox.ValueMember = "transportStopID";
            directionComboBox.SelectedIndex = 0;

        }

        public bool isTheSameName(DataGridView gridForCheck, int columnWithItem, string transportName)
        {
            bool check = true;
            for (int i = 0; i < gridForCheck.RowCount; i++)
            {
                if (gridForCheck.Rows[i].Cells[columnWithItem].Value.ToString() == transportName)
                {
                    check = false;
                }
            }
            return check;
        }
        public bool isTheSameElInTable(DataGridView gridForCheck, int selectedEl)
        {
            bool check = true;
            for (int i = 0; i < gridForCheck.RowCount; i++)
            {
                if (gridForCheck.Rows[i].Cells[2].Value.ToString() == selectedEl.ToString())
                {
                    check = false;
                }
            }
            return check;
        }
        private void checkBoxForAddTransortInRoute_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxForAddTransortInRoute.Checked == true)
            {
                transportNameComboBox.Enabled = true;
            }
            else
            {
                transportNameComboBox.Enabled = false;
            }
        }
        public bool checkIsInOrder(int order_)
        {
            bool check = true;
            for (int i = 0; i < gridForRouteStopLink.RowCount; i++)
            {
                if (gridForRouteStopLink.Rows[i].Cells[6].Value.ToString() == order_.ToString())
                {
                    check = false;
                }
            }

            return check;
        }
        public bool checkIsTheSameStopInRoute()
        {
            int routeID = Convert.ToInt32(routeNameForLinkComboBox.SelectedValue);
            int stopID = Convert.ToInt32(stopNameForLinkComboBox.SelectedValue);

            bool check = true;

            for (int i = 0; i < gridForRouteStopLink.RowCount; i++)
            {
                if (gridForRouteStopLink.Rows[i].Cells[1].Value.ToString() == routeID.ToString() && gridForRouteStopLink.Rows[i].Cells[3].Value.ToString() == stopID.ToString())
                {
                    check = false;
                }
            }
            return check;
        }
        public bool checkForSchedule()
        {
            int routeID = Convert.ToInt32(routeNameComboBox.SelectedValue);
            int dir = Convert.ToInt32(directionComboBox.SelectedValue);

            bool check = true;

            for (int i = 0; i < gridForSchedule.RowCount; i++)
            {
                if (gridForSchedule.Rows[i].Cells[2].Value.ToString() == routeID.ToString() && gridForSchedule.Rows[i].Cells[4].Value.ToString() == dir.ToString())
                {
                    check = false;
                }
            }
            return check;
        }

        private void buttonForAddTransport_Click(object sender, EventArgs e)
        {
            bool check = isTheSameName(gridForTransport, 1, textBoxForAddTransport.Text);
            if (textBoxForAddTransport.Text != "")
            {
                if (check == true)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string sql1 = $"insert into Transport(TransportName) values (N'{textBoxForAddTransport.Text}')";
                            SqlCommand cmd = new SqlCommand(sql1, connection);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Добавлено");
                            printTransportsTable();
                            fillTransportNamesComboBox();
                            textBoxForAddTransport.Text = "";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Такое название уже существует");
                }
            }
            else { MessageBox.Show("Заполните поле"); }
        }
        private void buttonForAddTransortInRoute_Click(object sender, EventArgs e)
        {
            int transportID = Convert.ToInt32(transportNameComboBox.SelectedValue);
            bool check = true;

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "";
                    if (checkBoxForAddTransortInRoute.Checked)
                    {
                        sql = $"insert into TransportRoutes(transportID) values({transportID})";
                        check = isTheSameElInTable(gridForTransportRoutes, transportID);
                    }
                    else
                    {
                        sql = $"insert into TransportRoutes(transportID) values(null)";
                        MessageBox.Show(sql);

                    }
                    if (check == true)
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Добавлено");
                        printTrasportRoutesTable();
                    }
                    else
                    {
                        MessageBox.Show("Такой транспорт уже присвоен какому-то маршруту");


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void buttonForAddTransportStop_Click(object sender, EventArgs e)
        {
            bool check = isTheSameName(gridForTransportStops, 1, textBoxForAddTransportStop.Text);
            if (textBoxForAddTransportStop.Text != "")
            {
                if (check == true)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string sql1 = $"insert into TransportStops(fullName) values(N'{textBoxForAddTransportStop.Text}')";
                            SqlCommand cmd = new SqlCommand(sql1, connection);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Добавлено");
                            printTransportStopsTable();
                            fillStopsComboBox(stopNameForLinkComboBox);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Такое название уже существует");
                }
            }
            else { MessageBox.Show("Заполните поле"); }
        }
        private void buttonForAddSchedule_Click(object sender, EventArgs e)
        {
            bool check = checkForSchedule();
            if (check)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    try
                    {

                        DateTime dateTime = DateTime.Parse(timePickerForSchedule.Text);
                        MessageBox.Show(timePickerForSchedule.Value.ToLongTimeString());
                        string sql1 = $"insert into Schedule(routeID,startTime,direction) values({Convert.ToInt32(routeNameComboBox.SelectedValue)},{timePickerForSchedule.Value.ToLongTimeString()},{directionComboBox.SelectedValue})";
                        SqlCommand cmd = new SqlCommand(sql1, connection);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Добавлено");
                        printScheduleTable();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Для данного маршрута уже существует расписание");
            }
        }
        private void buttonForAddRouteStopLink_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            string sqlForUpdate = "";
            int order_ = Convert.ToInt32(orderSelection.Value);

            bool checkOrder = checkIsInOrder(order_);
            bool checkSameStop = checkIsTheSameStopInRoute();
            if (checkSameStop)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (checkOrder == false)
                        {
                            dialogResult = MessageBox.Show("Вы действительно хотите присвоить остановке данный порядковый номер?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                sqlForUpdate = $"Update RouteStopLink set stopOrder=stopOrder+1 where stopOrder>={order_}";

                            }
                            else
                            {
                                return;
                            }

                        }

                        string sql1 = $"insert into RouteStopLink(routeID,transportStopID, timeShift,stopOrder) values({Convert.ToInt32(routeNameForLinkComboBox.SelectedValue)},{Convert.ToInt32(stopNameForLinkComboBox.SelectedValue)},{Convert.ToInt32(minCountToStop.Value)},{Convert.ToInt32(orderSelection.Value)})";
                        SqlCommand cmd = new SqlCommand(sql1 + sqlForUpdate, connection);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Добавлено");
                        printRouteStopLinkTable();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Для данного маршрута уже существует расписание");
            }


        }

        private int flagForTransport = 1;

        private void editTransportTable_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = gridForTransport.CurrentCell.RowIndex;
                string values = gridForTransport.Rows[rowIndex].Cells[1].Value.ToString();
                flagForTransport *= -1;
                if (flagForTransport == 1)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string sql1 = $"update Transport set transportName = {textBoxForAddTransport.Text} where transportID = {gridForTransport.Rows[rowIndex].Cells[0].Value} ";
                            SqlCommand cmd = new SqlCommand(sql1, connection);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Изменено");
                            printTransportsTable(); 
                            gridForTransport.ClearSelection(); 
                            fillTransportNamesComboBox();
                            editTransportTable.BackgroundImage = Properties.Resources.edit_;
                            textBoxForAddTransport.Text = "";

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    editTransportTable.BackgroundImage = Properties.Resources._2810399;
                    textBoxForAddTransport.Text = values;

                }
            }
            catch
            {
                MessageBox.Show("Выберите данные для редактирования");

            }
        }

        private void deleteTransport_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = gridForTransport.CurrentCell.RowIndex;
                string values = gridForTransport.Rows[rowIndex].Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить данный транспорт", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string sql = $"update TransportRoutes set transportID = null where transportID ={values}; Delete Transport where transportID ={values}; ";
                            SqlCommand cmd = new SqlCommand(sql, connection);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Удалено");
                            printTransportsTable();
                            printTrasportRoutesTable();
                            fillTransportNamesComboBox();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите данные для удаления");

            }
        }

        private int flagForTransportStop = 1;

        private void editTransportStopsTable_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = gridForTransportStops.CurrentCell.RowIndex;
                string values = gridForTransportStops.Rows[rowIndex].Cells[1].Value.ToString();
                flagForTransportStop *= -1;
                if (flagForTransportStop == 1)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string sql1 = $"update TransportStops set fullName = N'{textBoxForAddTransportStop.Text}' where transportStopID = {gridForTransportStops.Rows[rowIndex].Cells[0].Value} ";
                            SqlCommand cmd = new SqlCommand(sql1, connection);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Изменено");
                            printTransportStopsTable();
                            printRouteStopLinkTable();
                            fillStopsComboBox(stopNameForLinkComboBox);
                            editTransportStopsTable.BackgroundImage = Properties.Resources.edit_;
                            textBoxForAddTransportStop.Text = "";

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    editTransportStopsTable.BackgroundImage = Properties.Resources._2810399;
                    textBoxForAddTransportStop.Text = values;

                }
            }
            catch
            {
                MessageBox.Show("Выберите данные для редактирования");

            }
        }

        private void deleteTransportStopsTable_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = gridForTransportStops.CurrentCell.RowIndex;
                string values = gridForTransportStops.Rows[rowIndex].Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить данный транспорт", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string sql = $"Delete TransportStops where transportStopID ={values}; ";
                            SqlCommand cmd = new SqlCommand(sql, connection);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Удалено");
                            printTransportStopsTable();
                            printRouteStopLinkTable();
                            printScheduleTable();
                            fillStopsComboBox(stopNameForLinkComboBox);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите данные для удаления");

            }
        }
    }
}
