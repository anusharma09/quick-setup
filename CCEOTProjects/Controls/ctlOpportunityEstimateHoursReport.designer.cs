namespace CCEOTProjects.Controls
{
    partial class ctlOpportunityEstimateHoursReport
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
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtBidDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.txtBidDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lstProjectStatus = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl134 = new DevExpress.XtraEditors.LabelControl();
            this.lstOffice = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.lstDepartment = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtBidDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBidDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBidDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBidDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstProjectStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOffice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDepartment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(18, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(54, 27);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(128, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 21);
            this.btnClear.TabIndex = 366;
            this.btnClear.Text = "&Clear";
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(153, 36);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(14, 13);
            this.labelControl12.TabIndex = 374;
            this.labelControl12.Text = "To";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(68, 36);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(29, 13);
            this.labelControl11.TabIndex = 373;
            this.labelControl11.Text = "From";
            // 
            // txtBidDateFrom
            // 
            this.txtBidDateFrom.EditValue = null;
            this.txtBidDateFrom.Location = new System.Drawing.Point(55, 55);
            this.txtBidDateFrom.Name = "txtBidDateFrom";
            this.txtBidDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBidDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtBidDateFrom.Size = new System.Drawing.Size(81, 20);
            this.txtBidDateFrom.TabIndex = 375;
            this.txtBidDateFrom.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // txtBidDateTo
            // 
            this.txtBidDateTo.EditValue = null;
            this.txtBidDateTo.Location = new System.Drawing.Point(142, 55);
            this.txtBidDateTo.Name = "txtBidDateTo";
            this.txtBidDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBidDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtBidDateTo.Size = new System.Drawing.Size(81, 20);
            this.txtBidDateTo.TabIndex = 376;
            this.txtBidDateTo.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(5, 58);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(44, 13);
            this.labelControl7.TabIndex = 377;
            this.labelControl7.Text = "Bid Date:";
            // 
            // lstProjectStatus
            // 
            this.lstProjectStatus.Location = new System.Drawing.Point(68, 274);
            this.lstProjectStatus.Name = "lstProjectStatus";
            this.lstProjectStatus.Size = new System.Drawing.Size(153, 110);
            this.lstProjectStatus.TabIndex = 398;
            this.lstProjectStatus.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstProjectStatus_ItemCheck);
            // 
            // labelControl134
            // 
            this.labelControl134.Location = new System.Drawing.Point(5, 293);
            this.labelControl134.Name = "labelControl134";
            this.labelControl134.Size = new System.Drawing.Size(35, 13);
            this.labelControl134.TabIndex = 399;
            this.labelControl134.Text = "Status:";
            // 
            // lstOffice
            // 
            this.lstOffice.Location = new System.Drawing.Point(68, 81);
            this.lstOffice.Name = "lstOffice";
            this.lstOffice.Size = new System.Drawing.Size(153, 81);
            this.lstOffice.TabIndex = 400;
            this.lstOffice.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstOffice_ItemCheck);
            // 
            // lstDepartment
            // 
            this.lstDepartment.Location = new System.Drawing.Point(70, 168);
            this.lstDepartment.Name = "lstDepartment";
            this.lstDepartment.Size = new System.Drawing.Size(153, 100);
            this.lstDepartment.TabIndex = 401;
            this.lstDepartment.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstDepartment_ItemCheck);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 274);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 403;
            this.labelControl1.Text = "Opportunity";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 81);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(33, 13);
            this.labelControl4.TabIndex = 406;
            this.labelControl4.Text = "Office:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(5, 168);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 13);
            this.labelControl5.TabIndex = 407;
            this.labelControl5.Text = "Department:";
            // 
            // ctlOpportunityEstimateHoursReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lstDepartment);
            this.Controls.Add(this.lstOffice);
            this.Controls.Add(this.lstProjectStatus);
            this.Controls.Add(this.labelControl134);
            this.Controls.Add(this.txtBidDateFrom);
            this.Controls.Add(this.txtBidDateTo);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlOpportunityEstimateHoursReport";
            this.Size = new System.Drawing.Size(226, 401);
            ((System.ComponentModel.ISupportInitialize)(this.txtBidDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBidDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBidDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBidDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstProjectStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDepartment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.DateEdit txtBidDateFrom;
        private DevExpress.XtraEditors.DateEdit txtBidDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.CheckedListBoxControl lstProjectStatus;
        private DevExpress.XtraEditors.LabelControl labelControl134;
        private DevExpress.XtraEditors.CheckedListBoxControl lstOffice;
        private DevExpress.XtraEditors.CheckedListBoxControl lstDepartment;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}
