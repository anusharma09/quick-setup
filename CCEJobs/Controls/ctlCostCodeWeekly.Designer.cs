namespace CCEJobs.Controls
{
    partial class ctlCostCodeWeekly
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
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;

                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdCostCodesWeeklyView, "ctlCostCodeWeekly");

            }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCostCodeWeekly));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnUpdateTimeSheet = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNewWeek = new DevExpress.XtraEditors.HyperLinkEdit();
            this.cboCostCodesWeekly = new DevExpress.XtraEditors.LookUpEdit();
            this.lblWeek = new DevExpress.XtraEditors.LabelControl();
            this.grdCostCodesWeekly = new DevExpress.XtraGrid.GridControl();
            this.grdCostCodesWeeklyView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCostCodesWeekly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCostCodesWeekly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCostCodesWeeklyView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnUpdateTimeSheet);
            this.panelControl1.Controls.Add(this.btnAddNewWeek);
            this.panelControl1.Controls.Add(this.cboCostCodesWeekly);
            this.panelControl1.Controls.Add(this.lblWeek);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(803, 28);
            this.panelControl1.TabIndex = 13;
            // 
            // btnUpdateTimeSheet
            // 
            this.btnUpdateTimeSheet.Enabled = false;
            this.btnUpdateTimeSheet.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateTimeSheet.Image")));
            this.btnUpdateTimeSheet.Location = new System.Drawing.Point(43, 2);
            this.btnUpdateTimeSheet.Name = "btnUpdateTimeSheet";
            this.btnUpdateTimeSheet.Size = new System.Drawing.Size(0, 0);
            this.btnUpdateTimeSheet.TabIndex = 6;
            this.btnUpdateTimeSheet.Text = "Save";
            this.btnUpdateTimeSheet.ToolTip = "Save Changed Items";
            this.btnUpdateTimeSheet.Visible = false;
            this.btnUpdateTimeSheet.Click += new System.EventHandler(this.btnUpdateTimeSheet_Click);
            // 
            // btnAddNewWeek
            // 
            this.btnAddNewWeek.EditValue = "Generate Time Sheet ...";
            this.btnAddNewWeek.Location = new System.Drawing.Point(607, 6);
            this.btnAddNewWeek.Name = "btnAddNewWeek";
            this.btnAddNewWeek.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.btnAddNewWeek.Properties.Appearance.Options.UseForeColor = true;
            this.btnAddNewWeek.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnAddNewWeek.Size = new System.Drawing.Size(127, 18);
            this.btnAddNewWeek.TabIndex = 4;
            this.btnAddNewWeek.Visible = false;
            this.btnAddNewWeek.Click += new System.EventHandler(this.btnAddNewWeek_Click);
            // 
            // cboCostCodesWeekly
            // 
            this.cboCostCodesWeekly.Location = new System.Drawing.Point(327, 6);
            this.cboCostCodesWeekly.Name = "cboCostCodesWeekly";
            this.cboCostCodesWeekly.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCostCodesWeekly.Properties.DisplayFormat.FormatString = "d";
            this.cboCostCodesWeekly.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboCostCodesWeekly.Properties.EditFormat.FormatString = "d";
            this.cboCostCodesWeekly.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboCostCodesWeekly.Properties.NullText = "";
            this.cboCostCodesWeekly.Size = new System.Drawing.Size(127, 20);
            this.cboCostCodesWeekly.TabIndex = 3;
            this.cboCostCodesWeekly.EditValueChanged += new System.EventHandler(this.cboCostCodesWeekly_EditValueChanged);
            // 
            // lblWeek
            // 
            this.lblWeek.Location = new System.Drawing.Point(243, 8);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(72, 13);
            this.lblWeek.TabIndex = 2;
            this.lblWeek.Text = "Select a Week:";
            // 
            // grdCostCodesWeekly
            // 
            this.grdCostCodesWeekly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCostCodesWeekly.Location = new System.Drawing.Point(0, 28);
            this.grdCostCodesWeekly.MainView = this.grdCostCodesWeeklyView;
            this.grdCostCodesWeekly.Name = "grdCostCodesWeekly";
            this.grdCostCodesWeekly.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5});
            this.grdCostCodesWeekly.Size = new System.Drawing.Size(803, 505);
            this.grdCostCodesWeekly.TabIndex = 12;
            this.grdCostCodesWeekly.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdCostCodesWeeklyView});
            // 
            // grdCostCodesWeeklyView
            // 
            this.grdCostCodesWeeklyView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdCostCodesWeeklyView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdCostCodesWeeklyView.GridControl = this.grdCostCodesWeekly;
            this.grdCostCodesWeeklyView.Name = "grdCostCodesWeeklyView";
            this.grdCostCodesWeeklyView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grdCostCodesWeeklyView.OptionsCustomization.AllowFilter = false;
            this.grdCostCodesWeeklyView.OptionsCustomization.AllowGroup = false;
            this.grdCostCodesWeeklyView.OptionsMenu.EnableColumnMenu = false;
            this.grdCostCodesWeeklyView.OptionsMenu.EnableFooterMenu = false;
            this.grdCostCodesWeeklyView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdCostCodesWeeklyView.OptionsView.ColumnAutoWidth = false;
            this.grdCostCodesWeeklyView.OptionsView.ShowFooter = true;
            this.grdCostCodesWeeklyView.OptionsView.ShowGroupPanel = false;
            this.grdCostCodesWeeklyView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdCostCodesWeeklyView_CellValueChanged);
            this.grdCostCodesWeeklyView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdCostCodesWeeklyView_ColumnWidthChanged);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "c2";
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.Mask.EditMask = "c2";
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit3.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit3.Mask.EditMask = "c2";
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit4.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit4.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit4.Mask.EditMask = "n0";
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit5.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit5.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit5.Mask.EditMask = "n0";
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // ctlCostCodeWeekly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdCostCodesWeekly);
            this.Controls.Add(this.panelControl1);
            this.Name = "ctlCostCodeWeekly";
            this.Size = new System.Drawing.Size(803, 533);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCostCodesWeekly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCostCodesWeekly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCostCodesWeeklyView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.HyperLinkEdit btnAddNewWeek;
        private DevExpress.XtraEditors.LookUpEdit cboCostCodesWeekly;
        private DevExpress.XtraEditors.LabelControl lblWeek;
        private DevExpress.XtraGrid.GridControl grdCostCodesWeekly;
        private DevExpress.XtraGrid.Views.Grid.GridView grdCostCodesWeeklyView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraEditors.SimpleButton btnUpdateTimeSheet;
    }
}
