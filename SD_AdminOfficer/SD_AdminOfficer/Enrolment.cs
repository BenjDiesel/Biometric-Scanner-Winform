using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;
namespace SD_AdminOfficer
{
    public partial class Enrolment : Form
    {
        public Enrolment()
        {
            InitializeComponent();
            getEmployees();
        }
        protected void getEmployees()
        {
            //string constring = @"Server=localhost; Database=sdtestdb; UID =root; PWD=1234;";
            MySqlConnection con = new MySqlConnection(Helper.GetConnection());
            MySqlCommand com = new MySqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT employeeID, firstName, lastName, division FROM employee";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ////Set AutoGenerateColumns False
            //dataGridView1.AutoGenerateColumns = false;

            ////Set Columns Count
            //dataGridView1.ColumnCount = 5;

            dataGridView1.Columns[0].Name = "employeeID";
            dataGridView1.Columns[0].HeaderText = "Employee ID";
            dataGridView1.Columns[0].DataPropertyName = "employeeID";

            dataGridView1.Columns[1].Name = "firstName";
            dataGridView1.Columns[1].HeaderText = "First Name";
            dataGridView1.Columns[1].DataPropertyName = "firstName";

            dataGridView1.Columns[2].Name = "lastName";
            dataGridView1.Columns[2].HeaderText = "Last Name";
            dataGridView1.Columns[2].DataPropertyName = "lastName";

            dataGridView1.Columns[3].Name = "division";
            dataGridView1.Columns[3].HeaderText = "Division";
            dataGridView1.Columns[3].DataPropertyName = "division";

            
            dataGridView1.DataSource = dt;
           // Column5.Text = "Enrol";



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var row = dataGridView1.CurrentRow.Cells;

                    string id = Convert.ToString(row["employeeID"].Value);
                    string firstName = Convert.ToString(row["firstName"].Value);
                    string lastName = Convert.ToString(row["lastName"].Value);
                    string division = Convert.ToString(row["division"].Value);

                    Enrolment2 f2 = new Enrolment2(id, firstName, lastName, division);
                    f2.ShowDialog();
                }
            }
        }
       /* private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var row = dataGridView1.CurrentRow.Cells;

                    string id = Convert.ToString(row["employeeID"].Value);
                    string firstName = Convert.ToString(row["firstName"].Value);
                    string lastName = Convert.ToString(row["lastName"].Value);
                    string division = Convert.ToString(row["division"].Value);

                    Enrolment2 f2 = new Enrolment2 (id, firstName, lastName, division);
                    f2.ShowDialog();
                }
            }
        }*/
    }
}
