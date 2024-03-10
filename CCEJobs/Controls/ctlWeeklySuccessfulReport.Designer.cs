namespace CCEJobs.Controls
{
    partial class ctlWeeklySuccessfulReport
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
            this.lblStartDate = new DevExpress.XtraEditors.LabelControl();
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.txtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.txtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(141, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(54, 27);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(12, 43);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(54, 13);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Start Date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(12, 69);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(48, 13);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "End Date:";
            // 
            // txtStartDate
            // 
            this.txtStartDate.EditValue = new System.DateTime(2008, 3, 3, 17, 7, 56, 126);
            this.txtStartDate.Location = new System.Drawing.Point(72, 40);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtStartDate.Size = new System.Drawing.Size(96, 20);
            this.txtStartDate.TabIndex = 5;
            // 
            // txtEndDate
            // 
            this.txtEndDate.EditValue = new System.DateTime(2008, 3, 3, 17, 8, 6, 986);
            this.txtEndDate.Location = new System.Drawing.Point(72, 66);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtEndDate.Size = new System.Drawing.Size(96, 20);
            this.txtEndDate.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 119);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Report Date Range:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 138);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(177, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "(Use Monday through Sunday dates)";
            // 
            // ctlWeeklySuccessfulReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlWeeklySuccessfulReport";
            this.Size = new System.Drawing.Size(207, 263);
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.LabelControl lblStartDate;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.DateEdit txtStartDate;
        private DevExpress.XtraEditors.DateEdit txtEndDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}