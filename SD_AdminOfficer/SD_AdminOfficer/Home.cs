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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
           // getEmployees();
        }

        private void enrollFingerprintsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Enrolment ee = new Enrolment();
            ee.ShowDialog();
        }

        private void attendanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClockIn form = new ClockIn();
            form.ShowDialog();
        }

        private void attendanceTimeOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClockOut form = new ClockOut();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
        
    }
}
