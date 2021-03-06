﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DPFP.Error;
using System.IO;
using System.Data.SqlClient;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace SD_AttendanceOut
{
    public partial class AttendanceOutUserControl : UserControl, IComponent, DPFP.Capture.EventHandler
    {
        protected void getAttendance1()
        {
            //string constring = @"Server=localhost; Database=sdtestdb; UID =root; PWD=1234;";
            MySqlConnection con = new MySqlConnection(Helper.GetConnection());
            MySqlCommand com = new MySqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT employeeID, firstName, middleName, lastName, division, timeIn FROM employee " +
                                "INNER JOIN employeeattendance ON employee.employeeID = employeeattendance.employee_employeeID ORDER BY employeeattendanceID desc";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ////Set AutoGenerateColumns False
            //dataGridView1.AutoGenerateColumns = false;

            ////Set Columns Count
            //dataGridView1.ColumnCount = 5;

                 }
        public AttendanceOutUserControl()
        {
            InitializeComponent();
            getAttendance1();
            this.Load += new EventHandler(FingerPrintVerificationUserControl_Load);
            this.HandleDestroyed += new EventHandler(FingerPrintVerificationUserControl_HandleDestroyed);
        }
        private bool isVerificationComplete = false;
        public bool IsVerificationComplete
        {
            get { return this.isVerificationComplete; }
            set
            {
                if (value != this.isVerificationComplete)
                {
                    this.isVerificationComplete = value;
                    if (this.VerificationStatusChanged != null)
                    {
                        this.VerificationStatusChanged(this, new StatusChangedEventArgs(value));
                    }
                }
            }

        }

        public object VerifiedObject
        {
            get;
            private set;
        }
        private DPFP.Capture.Capture Capturer;
        public Dictionary<DPFP.Template, int> Samples = new Dictionary<DPFP.Template, int>();
        // public Dictionary<int[], int> SamplesID = new Dictionary<int[], int>();
        private DPFP.Verification.Verification Verificator;

        public event StatusChangedEventHandler VerificationStatusChanged;

        delegate void Function();
        #region Form Event Handlers:
        private void FingerPrintVerificationUserControl_Load(object sender, EventArgs e)
        {
            Init();
            Start();
        }

        private void FingerPrintVerificationUserControl_HandleDestroyed(object sender, EventArgs e)
        {
            Stop();
        }

        #endregion
        #region FingerPrint Handlers

        protected virtual void Process(DPFP.Sample Sample)
        {
            DrawPicture(FingerprintUtility.ConvertSampleToBitmap(Sample));

            //try
            //{
            DPFP.FeatureSet features = FingerprintUtility.ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
            SetPanelColor(System.Drawing.SystemColors.Control);
            SetPrompt("Verifying...");
            if (features != null)
            {
                // Compare the feature set with our template
                bool verified = false;
                foreach (DPFP.Template template in this.Samples.Keys)
                {

                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, template, ref result);
                    if (result.Verified)
                    {
                        this.VerifiedObject = Samples[template];
                        //
                        int value = 0;
                        //get employeeID --> value from template fingerprint
                        bool hasValue = Samples.TryGetValue(template, out value);
                        if (hasValue)
                            Model.employeeNo = value.ToString();
                        //MessageBox.Show("EmployeeID: " + Model.employeeNo);
                        insertAttendanceTimeIn(Model.employeeNo);
                        verified = true;
                        SetPrompt("Verified.");
                        //Stop();
                    }
                }
                this.IsVerificationComplete = verified;
                if (!verified)
                {
                    SetPrompt("Finger print not recognised.");
                }
            }
            else
            {
                SetPrompt("Can't recognize as a fingerprint.");
            }
            //}
            //catch (Exception)
            //{
            //    SetPrompt("Error!");
            //}
        }
        private void insertAttendanceTimeIn(string employeeid)
        {
            //string constring = @"Server=localhost; Database=sdtestdb; UID =root; PWD=1234;";
            MySqlConnection con = new MySqlConnection(Helper.GetConnection());
            {
                con.Open();
                string query = @"UPDATE employeeattendance SET timeOut=@timeOut WHERE employee_employeeID=@empID";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                   // MessageBox.Show(Model.employeeNo);
                    cmd.Parameters.AddWithValue("@timeOut", DateTime.Now);
                    cmd.Parameters.AddWithValue("@empID", employeeid);
                    cmd.ExecuteNonQuery();
                   
                }

            }
            MessageBox.Show("Successful time out!");
        }
        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();
                Verificator = new DPFP.Verification.Verification();
                if (null != Capturer)
                {
                    Capturer.EventHandler = this;
                }
                else
                {
                    MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("Give fingerprint samples.");
                }
                catch
                {
                    SetPrompt("Can't initiate capture!");
                }
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetPrompt("Can't terminate capture!");
                }
            }
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            SetPrompt("Fingerprint scan complete.");
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            SetPrompt("Finger removed.");
            SetPanelColor(System.Drawing.SystemColors.Control);
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {

            SetPrompt("Finger touched.");
            SetPanelColor(Color.Red);
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            SetPrompt("Fingerprint reader connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            SetPrompt("Fingerprint reader disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                SetPrompt("Good scan.");
            else
                SetPrompt("Poor scan.");
        }

        #endregion
        private void SetPrompt(string prompt)
        {
            this.Invoke(new Function(delegate()
            {
                Prompt.Text = prompt;
            }));
        }

        private void SetPanelColor(Color color)
        {
            this.Invoke(new Function(delegate()
            {
                this.BackColor = color;
            }));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Function(delegate()
            {
                FingerPrintPicture.Image = new Bitmap(bitmap, FingerPrintPicture.Size);	// fit the image into the picture box
            }));
        }

        private void ClearFPSamples_Click(object sender)
        {
            this.IsVerificationComplete = false;
            SetPrompt("Give fingerprint sample.");
            FingerPrintPicture.Image = null;
            Start();
        }

    }
}
