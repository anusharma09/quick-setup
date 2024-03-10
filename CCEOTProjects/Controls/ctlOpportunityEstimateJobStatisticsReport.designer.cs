namespace CCEOTProjects.Controls
{
    partial class ctlOpportunityEstimateJobStatisticsReport
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
            this.lstWorkType = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.lstOffice = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.lstDepartment = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lstWorkType)).BeginInit();
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
            // lstWorkType
            // 
            this.lstWorkType.Location = new System.Drawing.Point(70, 247);
            this.lstWorkType.Name = "lstWorkType";
            this.lstWorkType.Size = new System.Drawing.Size(153, 110);
            this.lstWorkType.TabIndex = 398;
            this.lstWorkType.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstWorkType_ItemCheck);
            // 
            // lstOffice
            // 
            this.lstOffice.Location = new System.Drawing.Point(70, 54);
            this.lstOffice.Name = "lstOffice";
            this.lstOffice.Size = new System.Drawing.Size(153, 81);
            this.lstOffice.TabIndex = 400;
            this.lstOffice.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstOffice_ItemCheck);
            // 
            // lstDepartment
            // 
            this.lstDepartment.Location = new System.Drawing.Point(72, 141);
            this.lstDepartment.Name = "lstDepartment";
            this.lstDepartment.Size = new System.Drawing.Size(153, 100);
            this.lstDepartment.TabIndex = 401;
            this.lstDepartment.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstDepartment_ItemCheck);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 247);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 403;
            this.labelControl1.Text = "Work Type:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 54);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(33, 13);
            this.labelControl4.TabIndex = 406;
            this.labelControl4.Text = "Office:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 141);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 13);
            this.labelControl5.TabIndex = 407;
            this.labelControl5.Text = "Department:";
            // 
            // ctlOpportunityEstimateJobStatisticsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lstDepartment);
            this.Controls.Add(this.lstOffice);
            this.Controls.Add(this.lstWorkType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlOpportunityEstimateJobStatisticsReport";
            this.Size = new System.Drawing.Size(226, 374);
            ((System.ComponentModel.ISupportInitialize)(this.lstWorkType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDepartment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.CheckedListBoxControl lstWorkType;
        private DevExpress.XtraEditors.CheckedListBoxControl lstOffice;
        private DevExpress.XtraEditors.CheckedListBoxControl lstDepartment;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}
