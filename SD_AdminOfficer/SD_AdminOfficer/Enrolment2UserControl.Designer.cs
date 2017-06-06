namespace SD_AdminOfficer
{
    partial class Enrolment2UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Prompt = new System.Windows.Forms.Label();
            this.SamplesNeeded = new System.Windows.Forms.Label();
            this.FingerPrintPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FingerPrintPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.Location = new System.Drawing.Point(3, 307);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(51, 20);
            this.Prompt.TabIndex = 8;
            this.Prompt.Text = "label1";
            // 
            // SamplesNeeded
            // 
            this.SamplesNeeded.AutoSize = true;
            this.SamplesNeeded.Location = new System.Drawing.Point(3, 269);
            this.SamplesNeeded.Name = "SamplesNeeded";
            this.SamplesNeeded.Size = new System.Drawing.Size(124, 20);
            this.SamplesNeeded.TabIndex = 7;
            this.SamplesNeeded.Text = "Samples added:";
            // 
            // FingerPrintPicture
            // 
            this.FingerPrintPicture.BackColor = System.Drawing.SystemColors.Window;
            this.FingerPrintPicture.Location = new System.Drawing.Point(55, 14);
            this.FingerPrintPicture.Name = "FingerPrintPicture";
            this.FingerPrintPicture.Size = new System.Drawing.Size(170, 237);
            this.FingerPrintPicture.TabIndex = 6;
            this.FingerPrintPicture.TabStop = false;
            // 
            // Enrolment2UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Prompt);
            this.Controls.Add(this.SamplesNeeded);
            this.Controls.Add(this.FingerPrintPicture);
            this.Name = "Enrolment2UserControl";
            this.Size = new System.Drawing.Size(283, 405);
            ((System.ComponentModel.ISupportInitialize)(this.FingerPrintPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.Label SamplesNeeded;
        private System.Windows.Forms.PictureBox FingerPrintPicture;
    }
}
