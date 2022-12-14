namespace BusSchedule
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timetableDataSet = new BusSchedule.TimetableDataSet();
            this.timetableDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.routeName = new System.Windows.Forms.Label();
            this.routeNameBack = new System.Windows.Forms.Label();
            this.transportSearch = new System.Windows.Forms.TextBox();
            this.textBoxForTimetable = new System.Windows.Forms.RichTextBox();
            this.gridForTransportList = new System.Windows.Forms.DataGridView();
            this.gridForTransportStopsList = new System.Windows.Forms.DataGridView();
            this.gridForTransportStopsBackList = new System.Windows.Forms.DataGridView();
            this.transportStop = new System.Windows.Forms.Label();
            this.transportRoute = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timetableDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridForTransportList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridForTransportStopsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridForTransportStopsBackList)).BeginInit();
            this.SuspendLayout();
            // 
            // timetableDataSet
            // 
            this.timetableDataSet.DataSetName = "TimetableDataSet";
            this.timetableDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timetableDataSetBindingSource
            // 
            this.timetableDataSetBindingSource.DataSource = this.timetableDataSet;
            this.timetableDataSetBindingSource.Position = 0;
            // 
            // routeName
            // 
            this.routeName.AutoSize = true;
            this.routeName.Location = new System.Drawing.Point(358, 65);
            this.routeName.Name = "routeName";
            this.routeName.Size = new System.Drawing.Size(66, 16);
            this.routeName.TabIndex = 4;
            this.routeName.Text = "Маршрут";
            // 
            // routeNameBack
            // 
            this.routeNameBack.AutoSize = true;
            this.routeNameBack.Location = new System.Drawing.Point(687, 65);
            this.routeNameBack.Name = "routeNameBack";
            this.routeNameBack.Size = new System.Drawing.Size(66, 16);
            this.routeNameBack.TabIndex = 5;
            this.routeNameBack.Text = "Маршрут";
            // 
            // transportSearch
            // 
            this.transportSearch.Location = new System.Drawing.Point(93, 59);
            this.transportSearch.Name = "transportSearch";
            this.transportSearch.Size = new System.Drawing.Size(178, 22);
            this.transportSearch.TabIndex = 7;
            this.transportSearch.TextChanged += new System.EventHandler(this.transportSearch_TextChanged);
            // 
            // textBoxForTimetable
            // 
            this.textBoxForTimetable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxForTimetable.Location = new System.Drawing.Point(361, 342);
            this.textBoxForTimetable.Name = "textBoxForTimetable";
            this.textBoxForTimetable.ReadOnly = true;
            this.textBoxForTimetable.Size = new System.Drawing.Size(621, 175);
            this.textBoxForTimetable.TabIndex = 8;
            this.textBoxForTimetable.Text = "";
            // 
            // gridForTransportList
            // 
            this.gridForTransportList.AllowUserToAddRows = false;
            this.gridForTransportList.AllowUserToResizeColumns = false;
            this.gridForTransportList.AllowUserToResizeRows = false;
            this.gridForTransportList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridForTransportList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.gridForTransportList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridForTransportList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.gridForTransportList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridForTransportList.ColumnHeadersVisible = false;
            this.gridForTransportList.Location = new System.Drawing.Point(93, 103);
            this.gridForTransportList.MultiSelect = false;
            this.gridForTransportList.Name = "gridForTransportList";
            this.gridForTransportList.ReadOnly = true;
            this.gridForTransportList.RowHeadersVisible = false;
            this.gridForTransportList.RowHeadersWidth = 51;
            this.gridForTransportList.RowTemplate.Height = 24;
            this.gridForTransportList.Size = new System.Drawing.Size(178, 156);
            this.gridForTransportList.TabIndex = 9;
            this.gridForTransportList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridForTransportList_CellClick);
            // 
            // gridForTransportStopsList
            // 
            this.gridForTransportStopsList.AllowUserToAddRows = false;
            this.gridForTransportStopsList.AllowUserToResizeColumns = false;
            this.gridForTransportStopsList.AllowUserToResizeRows = false;
            this.gridForTransportStopsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridForTransportStopsList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.gridForTransportStopsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridForTransportStopsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gridForTransportStopsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridForTransportStopsList.ColumnHeadersVisible = false;
            this.gridForTransportStopsList.Location = new System.Drawing.Point(361, 103);
            this.gridForTransportStopsList.MultiSelect = false;
            this.gridForTransportStopsList.Name = "gridForTransportStopsList";
            this.gridForTransportStopsList.ReadOnly = true;
            this.gridForTransportStopsList.RowHeadersVisible = false;
            this.gridForTransportStopsList.RowHeadersWidth = 50;
            this.gridForTransportStopsList.RowTemplate.Height = 24;
            this.gridForTransportStopsList.Size = new System.Drawing.Size(292, 156);
            this.gridForTransportStopsList.TabIndex = 10;
            this.gridForTransportStopsList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridForTransportStopsList_CellClick);
            // 
            // gridForTransportStopsBackList
            // 
            this.gridForTransportStopsBackList.AllowUserToAddRows = false;
            this.gridForTransportStopsBackList.AllowUserToResizeColumns = false;
            this.gridForTransportStopsBackList.AllowUserToResizeRows = false;
            this.gridForTransportStopsBackList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridForTransportStopsBackList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.gridForTransportStopsBackList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridForTransportStopsBackList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.gridForTransportStopsBackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridForTransportStopsBackList.ColumnHeadersVisible = false;
            this.gridForTransportStopsBackList.Location = new System.Drawing.Point(690, 103);
            this.gridForTransportStopsBackList.MultiSelect = false;
            this.gridForTransportStopsBackList.Name = "gridForTransportStopsBackList";
            this.gridForTransportStopsBackList.ReadOnly = true;
            this.gridForTransportStopsBackList.RowHeadersVisible = false;
            this.gridForTransportStopsBackList.RowHeadersWidth = 51;
            this.gridForTransportStopsBackList.RowTemplate.Height = 24;
            this.gridForTransportStopsBackList.Size = new System.Drawing.Size(292, 156);
            this.gridForTransportStopsBackList.TabIndex = 11;
            this.gridForTransportStopsBackList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridForTransportStopsBackList_CellClick);
            // 
            // transportStop
            // 
            this.transportStop.AutoSize = true;
            this.transportStop.Location = new System.Drawing.Point(687, 314);
            this.transportStop.Name = "transportStop";
            this.transportStop.Size = new System.Drawing.Size(78, 16);
            this.transportStop.TabIndex = 12;
            this.transportStop.Text = "Остановка";
            // 
            // transportRoute
            // 
            this.transportRoute.AutoSize = true;
            this.transportRoute.Location = new System.Drawing.Point(358, 314);
            this.transportRoute.Name = "transportRoute";
            this.transportRoute.Size = new System.Drawing.Size(66, 16);
            this.transportRoute.TabIndex = 13;
            this.transportRoute.Text = "Маршрут";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 565);
            this.Controls.Add(this.transportRoute);
            this.Controls.Add(this.transportStop);
            this.Controls.Add(this.gridForTransportStopsBackList);
            this.Controls.Add(this.gridForTransportStopsList);
            this.Controls.Add(this.gridForTransportList);
            this.Controls.Add(this.textBoxForTimetable);
            this.Controls.Add(this.transportSearch);
            this.Controls.Add(this.routeNameBack);
            this.Controls.Add(this.routeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "TimeTable";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timetableDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridForTransportList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridForTransportStopsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridForTransportStopsBackList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.BindingSource timetableDataSetBindingSource;
        private TimetableDataSet timetableDataSet;
        private System.Windows.Forms.Label routeName;
        private System.Windows.Forms.Label routeNameBack;
        private System.Windows.Forms.TextBox transportSearch;
        private System.Windows.Forms.RichTextBox textBoxForTimetable;
        private System.Windows.Forms.DataGridView gridForTransportList;
        private System.Windows.Forms.DataGridView gridForTransportStopsList;
        private System.Windows.Forms.DataGridView gridForTransportStopsBackList;
        private System.Windows.Forms.Label transportStop;
        private System.Windows.Forms.Label transportRoute;
    }
}

