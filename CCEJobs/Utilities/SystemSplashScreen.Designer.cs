namespace CCEJobs.Utilities
{
    partial class SystemSplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemSplashScreen));
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelProductName = new DevExpress.XtraEditors.LabelControl();
            this.labelProductVersion = new DevExpress.XtraEditors.LabelControl();
            this.labelProductCopyright = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(12, 198);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(232, 10);
            this.marqueeProgressBarControl1.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 179);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Starting...";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(232, 51);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelProductName.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.labelProductName.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.labelProductName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelProductName.Location = new System.Drawing.Point(26, 87);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(217, 19);
            this.labelProductName.TabIndex = 27;
            this.labelProductName.Text = "Job  Cost Management System";
            // 
            // labelProductVersion
            // 
            this.labelProductVersion.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelProductVersion.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductVersion.Location = new System.Drawing.Point(93, 112);
            this.labelProductVersion.Name = "labelProductVersion";
            this.labelProductVersion.Size = new System.Drawing.Size(70, 14);
            this.labelProductVersion.TabIndex = 28;
            this.labelProductVersion.Text = "labelControl1";
            // 
            // labelProductCopyright
            // 
            this.labelProductCopyright.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelProductCopyright.Location = new System.Drawing.Point(100, 132);
            this.labelProductCopyright.Name = "labelProductCopyright";
            this.labelProductCopyright.Size = new System.Drawing.Size(63, 13);
            this.labelProductCopyright.TabIndex = 29;
            this.labelProductCopyright.Text = "labelControl1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SystemSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 220);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.labelProductVersion);
            this.Controls.Add(this.labelProductCopyright);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Name = "SystemSplashScreen";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.frmSplash_Activated);
            this.Load += new System.EventHandler(this.frmSplash_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelProductName;
        private DevExpress.XtraEditors.LabelControl labelProductVersion;
        private DevExpress.XtraEditors.LabelControl labelProductCopyright;
        private System.Windows.Forms.Timer timer1;
    }
}
