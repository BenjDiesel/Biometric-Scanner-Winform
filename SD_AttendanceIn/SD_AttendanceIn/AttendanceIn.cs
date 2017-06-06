using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SD_AttendanceIn
{
    public partial class AttendanceIn : Form
    {
        public AttendanceIn()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = (3 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            getAttendance();
            // timer_Tick();
            ValidateUser();
        }
        protected void getAttendance()
        {
            //string constring = @"Server=localhost; Database=sdtestdb; UID =root; PWD=1234;";
            MySqlConnection con = new MySqlConnection(Helper.GetConnection());
            MySqlCommand com = new MySqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT employeeID, concat(lastName, ', ', firstName) As FullName, division, timeIn FROM employee " +
                                "INNER JOIN employeeattendance ON employee.employeeID = employeeattendance.employee_employeeID WHERE DATE_FORMAT(timeIn, '%Y-%m-%d') = curdate() ORDER BY employeeattendanceID desc ";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.Columns[0].Name = "employeeID";
            dataGridView1.Columns[0].HeaderText = "Employee ID";
            dataGridView1.Columns[0].DataPropertyName = "employeeID";

            dataGridView1.Columns[1].Name = "FullName";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[1].DataPropertyName = "FullName";

            /* dataGridView1.Columns[2].Name = "lastName";
             dataGridView1.Columns[2].HeaderText = "Last Name";
             dataGridView1.Columns[2].DataPropertyName = "lastName";*/

            dataGridView1.Columns[2].Name = "division";
            dataGridView1.Columns[2].HeaderText = "Division";
            dataGridView1.Columns[2].DataPropertyName = "division";

            dataGridView1.Columns[3].Name = "timeIn";
            dataGridView1.Columns[3].HeaderText = "Time In";
            dataGridView1.Columns[3].DataPropertyName = "timeIn";

            dataGridView1.DataSource = dt;
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            getAttendance();
        }

        void ValidateUser()
        {
           // string constring = @"Server=localhost; Database=sdtestdb; UID =root; PWD=1234;";
            using (MySqlConnection con = new MySqlConnection(Helper.GetConnection()))
            {
                con.Open();
                string query = @"SELECT employeeID, rightThumb FROM employee where rightThumb is not null";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader data = cmd.ExecuteReader())
                    {

                        while (data.Read())
                        {
                            byte[] fingerPrint = (byte[])data["rightThumb"];
                            //if (fingerPrint = DBNull.Value)
                              //  break;
                            int employeeID = (int)data["employeeID"];
                            attendanceInUserControl1.Samples.Add(new DPFP.Template(new MemoryStream(fingerPrint)), employeeID);

                        }
                    }
                }
            }

        }

    }
}
