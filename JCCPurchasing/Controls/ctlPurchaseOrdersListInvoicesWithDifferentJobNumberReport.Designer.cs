namespace JCCPurchasing.Controls
{
    partial class ctlPurchaseOrdersListInvoicesWithDifferentJobNumberReport
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
            this.txtJobNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblJobNumber = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboProjectManager = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblWarning = new DevExpress.XtraEditors.LabelControl();
            this.txtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.lblStartDate = new DevExpress.XtraEditors.LabelControl();
            this.txtEndDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectManager.Properties)).BeginInit();
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
            // txtJobNumber
            // 
            this.txtJobNumber.Location = new System.Drawing.Point(71, 57);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Properties.MaxLength = 5;
            this.txtJobNumber.Size = new System.Drawing.Size(68, 20);
            this.txtJobNumber.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 179);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(202, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Enter a Job Number or a Project Manager ";
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.Location = new System.Drawing.Point(3, 60);
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(61, 13);
            this.lblJobNumber.TabIndex = 11;
            this.lblJobNumber.Text = "Job Number:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 86);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 400;
            this.labelControl3.Text = "Proj Mgr.:";
            // 
            // cboProjectManager
            // 
            this.cboProjectManager.Location = new System.Drawing.Point(71, 83);
            this.cboProjectManager.Name = "cboProjectManager";
            this.cboProjectManager.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProjectManager.Properties.NullText = "";
            this.cboProjectManager.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboProjectManager.Size = new System.Drawing.Size(151, 20);
            this.cboProjectManager.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 198);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 401;
            this.labelControl2.Text = "For the List";
            // 
            // lblWarning
            // 
            this.lblWarning.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblWarning.Appearance.Options.UseFont = true;
            this.lblWarning.Appearance.Options.UseForeColor = true;
            this.lblWarning.Location = new System.Drawing.Point(12, 226);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(185, 13);
            this.lblWarning.TabIndex = 402;
            this.lblWarning.Text = "Enter a Job # or a Proj. Manager ";
            this.lblWarning.Visible = false;
            // 
            // txtStartDate
            // 
            this.txtStartDate.EditValue = new System.DateTime(((long)(0)));
            this.txtStartDate.Location = new System.Drawing.Point(71, 109);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtStartDate.Properties.NullText = " ";
            this.txtStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtStartDate.Size = new System.Drawing.Size(96, 20);
            this.txtStartDate.TabIndex = 2;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(11, 138);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(48, 13);
            this.lblEndDate.TabIndex = 404;
            this.lblEndDate.Text = "End Date:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(11, 112);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(54, 13);
            this.lblStartDate.TabIndex = 403;
            this.lblStartDate.Text = "Start Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.EditValue = new System.DateTime(((long)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(71, 135);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEndDate.Properties.NullText = " ";
            this.txtEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtEndDate.Size = new System.Drawing.Size(96, 20);
            this.txtEndDate.TabIndex = 3;
            // 
            // ctlPurchaseOrdersListInvoicesWithDifferentJobNumberReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboProjectManager);
            this.Controls.Add(this.txtJobNumber);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblJobNumber);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlPurchaseOrdersListInvoicesWithDifferentJobNumberReport";
            this.Size = new System.Drawing.Size(225, 263);
            this.Load += new System.EventHandler(this.ctlPurchaseOrdersListInvoicesWithDifferentJobNumberReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtJobNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectManager.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.TextEdit txtJobNumber;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblJobNumber;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit cboProjectManager;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblWarning;
        private DevExpress.XtraEditors.DateEdit txtStartDate;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.LabelControl lblStartDate;
        private DevExpress.XtraEditors.DateEdit txtEndDate;
    }
}
