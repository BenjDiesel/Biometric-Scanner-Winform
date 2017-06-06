using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SD_AdminOfficer
{
    public partial class Enrolment2 : Form
    {
        public Enrolment2(string id, string firstName, string lastName, string division)
        {
            InitializeComponent();
            label1.Text = id;
            label2.Text = firstName;
            label4.Text = lastName;
            label5.Text = division;

            Model.employeeNo = label1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
