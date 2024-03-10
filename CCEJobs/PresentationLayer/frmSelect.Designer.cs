namespace CCEJobs.PresentationLayer
{
    partial class frmSelect
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
            this.components = new System.ComponentModel.Container();
            this.cboSelect = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.cboRevision = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioSelect = new DevExpress.XtraEditors.RadioGroup();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRevision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSelect
            // 
            this.cboSelect.Location = new System.Drawing.Point(26, 73);
            this.cboSelect.Name = "cboSelect";
            this.cboSelect.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSelect.Properties.NullText = "";
            this.cboSelect.Size = new System.Drawing.Size(241, 20);
            this.cboSelect.TabIndex = 0;
            this.cboSelect.EditValueChanged += new System.EventHandler(this.cboSelect_EditValueChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(26, 10);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(61, 25);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "&Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(103, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(32, 113);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(42, 13);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Message";
            // 
            // cboRevision
            // 
            this.cboRevision.Location = new System.Drawing.Point(123, 167);
            this.cboRevision.Name = "cboRevision";
            this.cboRevision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRevision.Properties.NullText = "";
            this.cboRevision.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboRevision.Size = new System.Drawing.Size(144, 20);
            this.cboRevision.TabIndex = 4;
            this.cboRevision.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.cboRevision_ProcessNewValue);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(65, 170);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Revision:";
            // 
            // radioSelect
            // 
            this.radioSelect.EditValue = 0;
            this.radioSelect.Location = new System.Drawing.Point(26, 48);
            this.radioSelect.Name = "radioSelect";
            this.radioSelect.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Estimate"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Job")});
            this.radioSelect.Size = new System.Drawing.Size(136, 19);
            this.radioSelect.TabIndex = 216;
            this.radioSelect.SelectedIndexChanged += new System.EventHandler(this.radioSelect_SelectedIndexChanged);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // frmSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 220);
            this.Controls.Add(this.radioSelect);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboRevision);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.cboSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSelect_FormClosing);
            this.Load += new System.EventHandler(this.frmSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRevision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboSelect;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.LookUpEdit cboRevision;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup radioSelect;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}