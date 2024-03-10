namespace CCEJobs.Controls
{
    partial class ctlJobProgressWIP
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlJobProgressWIP));
            this.grdJobProgressPhaseView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdJobProgress = new DevExpress.XtraGrid.GridControl();
            this.grdJobProgressComment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdJobProgressView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repComment = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cboPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPeriod = new DevExpress.XtraEditors.LabelControl();
            this.radioDataType = new DevExpress.XtraEditors.RadioGroup();
            this.btnUpdateJobProgress = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressPhaseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioDataType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdJobProgressPhaseView
            // 
            this.grdJobProgressPhaseView.GridControl = this.grdJobProgress;
            this.grdJobProgressPhaseView.Name = "grdJobProgressPhaseView";
            this.grdJobProgressPhaseView.OptionsBehavior.Editable = false;
            // 
            // grdJobProgress
            // 
            this.grdJobProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobProgress.EmbeddedNavigator.Name = "";
            gridLevelNode1.LevelTemplate = this.grdJobProgressPhaseView;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.LevelTemplate = this.grdJobProgressComment;
            gridLevelNode2.RelationName = "Level2";
            this.grdJobProgress.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.grdJobProgress.Location = new System.Drawing.Point(0, 36);
            this.grdJobProgress.MainView = this.grdJobProgressView;
            this.grdJobProgress.Name = "grdJobProgress";
            this.grdJobProgress.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repComment,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5});
            this.grdJobProgress.Size = new System.Drawing.Size(803, 497);
            this.grdJobProgress.TabIndex = 12;
            this.grdJobProgress.ToolTipController = this.toolTipController1;
            this.grdJobProgress.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdJobProgressComment,
            this.grdJobProgressView,
            this.grdJobProgressPhaseView});
            // 
            // grdJobProgressComment
            // 
            this.grdJobProgressComment.GridControl = this.grdJobProgress;
            this.grdJobProgressComment.Name = "grdJobProgressComment";
            this.grdJobProgressComment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // grdJobProgressView
            // 
            this.grdJobProgressView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdJobProgressView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobProgressView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdJobProgressView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdJobProgressView.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobProgressView.Appearance.GroupFooter.Options.UseFont = true;
            this.grdJobProgressView.GridControl = this.grdJobProgress;
            this.grdJobProgressView.Name = "grdJobProgressView";
            this.grdJobProgressView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grdJobProgressView.OptionsCustomization.AllowColumnMoving = false;
            this.grdJobProgressView.OptionsCustomization.AllowFilter = false;
            this.grdJobProgressView.OptionsCustomization.AllowGroup = false;
            this.grdJobProgressView.OptionsCustomization.AllowSort = false;
            this.grdJobProgressView.OptionsMenu.EnableColumnMenu = false;
            this.grdJobProgressView.OptionsMenu.EnableFooterMenu = false;
            this.grdJobProgressView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdJobProgressView.OptionsView.ColumnAutoWidth = false;
            this.grdJobProgressView.OptionsView.ShowFooter = true;
            this.grdJobProgressView.OptionsView.ShowGroupPanel = false;
            this.grdJobProgressView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdJobProgressView_CellValueChanged);
            this.grdJobProgressView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdJobProgressView_CellValueChanging);
            this.grdJobProgressView.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.grdJobProgressView_CustomSummaryCalculate);
            this.grdJobProgressView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdJobProgressView_MasterRowExpanded);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repComment
            // 
            this.repComment.AutoHeight = false;
            this.repComment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.repComment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repComment.Name = "repComment";
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
            // toolTipController1
            // 
            this.toolTipController1.AutoPopDelay = 5000000;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.cboPeriod);
            this.panelControl1.Controls.Add(this.lblPeriod);
            this.panelControl1.Controls.Add(this.radioDataType);
            this.panelControl1.Controls.Add(this.btnUpdateJobProgress);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(803, 36);
            this.toolTipController1.SetSuperTip(this.panelControl1, null);
            this.panelControl1.TabIndex = 13;
            // 
            // cboPeriod
            // 
            this.cboPeriod.Location = new System.Drawing.Point(322, 7);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPeriod.Properties.DisplayFormat.FormatString = "d";
            this.cboPeriod.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboPeriod.Properties.EditFormat.FormatString = "d";
            this.cboPeriod.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboPeriod.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.cboPeriod.Properties.NullText = " ";
            this.cboPeriod.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Flat;
            this.cboPeriod.Size = new System.Drawing.Size(141, 20);
            this.cboPeriod.TabIndex = 10;
            this.cboPeriod.EditValueChanged += new System.EventHandler(this.cboPeriod_EditValueChanged);
            // 
            // lblPeriod
            // 
            this.lblPeriod.Location = new System.Drawing.Point(283, 10);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(34, 13);
            this.lblPeriod.TabIndex = 9;
            this.lblPeriod.Text = "Period:";
            // 
            // radioDataType
            // 
            this.radioDataType.EditValue = 0;
            this.radioDataType.Location = new System.Drawing.Point(20, 7);
            this.radioDataType.Name = "radioDataType";
            this.radioDataType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Current Period"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Archived Period")});
            this.radioDataType.Size = new System.Drawing.Size(226, 23);
            this.radioDataType.TabIndex = 8;
            this.radioDataType.SelectedIndexChanged += new System.EventHandler(this.radioDataType_SelectedIndexChanged);
            // 
            // btnUpdateJobProgress
            // 
            this.btnUpdateJobProgress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdateJobProgress.Enabled = false;
            this.btnUpdateJobProgress.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateJobProgress.Image")));
            this.btnUpdateJobProgress.Location = new System.Drawing.Point(39, 3);
            this.btnUpdateJobProgress.Name = "btnUpdateJobProgress";
            this.btnUpdateJobProgress.Size = new System.Drawing.Size(0, 0);
            this.btnUpdateJobProgress.TabIndex = 7;
            this.btnUpdateJobProgress.Text = "&Save";
            this.btnUpdateJobProgress.ToolTip = "Save Changed Items";
            this.btnUpdateJobProgress.Visible = false;
            this.btnUpdateJobProgress.Click += new System.EventHandler(this.btnUpdateJobProgress_Click);
            // 
            // ctlJobProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdJobProgress);
            this.Controls.Add(this.panelControl1);
            this.Name = "ctlJobProgress";
            this.Size = new System.Drawing.Size(803, 533);
            this.toolTipController1.SetSuperTip(this, null);
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressPhaseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioDataType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdJobProgress;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repComment;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraEditors.SimpleButton btnUpdateJobProgress;
        private DevExpress.XtraEditors.RadioGroup radioDataType;
        private DevExpress.XtraEditors.LookUpEdit cboPeriod;
        private DevExpress.XtraEditors.LabelControl lblPeriod;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressPhaseView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressComment;
    }
}
