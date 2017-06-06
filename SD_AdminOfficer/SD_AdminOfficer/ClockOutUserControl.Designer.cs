namespace SD_AdminOfficer
{
    partial class ClockOutUserControl
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
            this.FingerPrintPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FingerPrintPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Prompt.Location = new System.Drawing.Point(21, 323);
            this.Prompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(56, 20);
            this.Prompt.TabIndex = 32;
            this.Prompt.Text = "Status";
            // 
            // FingerPrintPicture
            // 
            this.FingerPrintPicture.BackColor = System.Drawing.SystemColors.Window;
            this.FingerPrintPicture.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FingerPrintPicture.Location = new System.Drawing.Point(10, 28);
            this.FingerPrintPicture.Name = "FingerPrintPicture";
            this.FingerPrintPicture.Size = new System.Drawing.Size(217, 278);
            this.FingerPrintPicture.TabIndex = 31;
            this.FingerPrintPicture.TabStop = false;
            // 
            // ClockOutUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Prompt);
            this.Controls.Add(this.FingerPrintPicture);
            this.Name = "ClockOutUserControl";
            this.Size = new System.Drawing.Size(236, 378);
            ((System.ComponentModel.ISupportInitialize)(this.FingerPrintPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.PictureBox FingerPrintPicture;
    }
}
