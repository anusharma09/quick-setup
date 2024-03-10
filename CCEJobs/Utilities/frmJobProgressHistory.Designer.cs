namespace CCEJobs.Utilities
{
    partial class frmJobProgressHistory
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
            this.btnArchive = new DevExpress.XtraEditors.SimpleButton();
            this.txtArchivePeriod = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPreviousArchiveDate = new DevExpress.XtraEditors.TextEdit();
            this.lblCurrentPeriod = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPayrollHistoryDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivePeriod.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivePeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreviousArchiveDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayrollHistoryDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayrollHistoryDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnArchive
            // 
            this.btnArchive.Location = new System.Drawing.Point(188, 133);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(61, 25);
            this.btnArchive.TabIndex = 1;
            this.btnArchive.Text = "&Process";
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // txtArchivePeriod
            // 
            this.txtArchivePeriod.EditValue = null;
            this.txtArchivePeriod.Location = new System.Drawing.Point(149, 48);
            this.txtArchivePeriod.Name = "txtArchivePeriod";
            this.txtArchivePeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtArchivePeriod.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtArchivePeriod.Size = new System.Drawing.Size(100, 20);
            this.txtArchivePeriod.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(117, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Previous Archive Period:";
            // 
            // txtPreviousArchiveDate
            // 
            this.txtPreviousArchiveDate.Location = new System.Drawing.Point(149, 12);
            this.txtPreviousArchiveDate.Name = "txtPreviousArchiveDate";
            this.txtPreviousArchiveDate.Properties.ReadOnly = true;
            this.txtPreviousArchiveDate.Size = new System.Drawing.Size(100, 20);
            this.txtPreviousArchiveDate.TabIndex = 5;
            // 
            // lblCurrentPeriod
            // 
            this.lblCurrentPeriod.Location = new System.Drawing.Point(26, 51);
            this.lblCurrentPeriod.Name = "lblCurrentPeriod";
            this.lblCurrentPeriod.Size = new System.Drawing.Size(92, 13);
            this.lblCurrentPeriod.TabIndex = 6;
            this.lblCurrentPeriod.Text = "Select Period Date:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 82);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(99, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Payroll History Date:";
            // 
            // txtPayrollHistoryDate
            // 
            this.txtPayrollHistoryDate.EditValue = null;
            this.txtPayrollHistoryDate.Location = new System.Drawing.Point(149, 79);
            this.txtPayrollHistoryDate.Name = "txtPayrollHistoryDate";
            this.txtPayrollHistoryDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtPayrollHistoryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPayrollHistoryDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPayrollHistoryDate.Size = new System.Drawing.Size(100, 20);
            this.txtPayrollHistoryDate.TabIndex = 8;
            // 
            // frmJobProgressHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 170);
            this.Controls.Add(this.txtPayrollHistoryDate);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblCurrentPeriod);
            this.Controls.Add(this.txtPreviousArchiveDate);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtArchivePeriod);
            this.Controls.Add(this.btnArchive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmJobProgressHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Progress History Archive";
            this.Load += new System.EventHandler(this.frmSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivePeriod.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivePeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreviousArchiveDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayrollHistoryDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayrollHistoryDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnArchive;
        private DevExpress.XtraEditors.DateEdit txtArchivePeriod;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPreviousArchiveDate;
        private DevExpress.XtraEditors.LabelControl lblCurrentPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtPayrollHistoryDate;
    }
}