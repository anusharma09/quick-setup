namespace JCCPurchasing.Controls
{
    partial class ctlAdHocReport
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
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.lblReportFormat = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.radioOption = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.radioOption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(155, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(54, 27);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblReportFormat
            // 
            this.lblReportFormat.Location = new System.Drawing.Point(3, 97);
            this.lblReportFormat.Name = "lblReportFormat";
            this.lblReportFormat.Size = new System.Drawing.Size(128, 13);
            this.lblReportFormat.TabIndex = 1;
            this.lblReportFormat.Text = "When Summary is selected";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 138);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(206, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "   in the Grid grouped by the selected view ";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 189);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(111, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "When Detail is selected";
            // 
            // radioOption
            // 
            this.radioOption.EditValue = 0;
            this.radioOption.Location = new System.Drawing.Point(4, 36);
            this.radioOption.Name = "radioOption";
            this.radioOption.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioOption.Properties.Appearance.Options.UseFont = true;
            this.radioOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Summary"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Detail"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Bottom Line")});
            this.radioOption.Size = new System.Drawing.Size(229, 23);
            this.radioOption.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(4, 119);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(115, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "    A list for all the items ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 208);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(151, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "    The detailed POs for all items";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(1, 157);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(146, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "   will be viewed and or printed";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(4, 227);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(194, 13);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "    in the grid will be viewd and or printed";
            // 
            // ctlAdHocReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.radioOption);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblReportFormat);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlAdHocReport";
            this.Size = new System.Drawing.Size(239, 300);
            ((System.ComponentModel.ISupportInitialize)(this.radioOption.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.LabelControl lblReportFormat;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.RadioGroup radioOption;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
