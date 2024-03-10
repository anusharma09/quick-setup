namespace CCEJobs.Controls
{
    partial class ctlJobProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlJobProgress));
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cboPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPeriod = new DevExpress.XtraEditors.LabelControl();
            this.radioDataType = new DevExpress.XtraEditors.RadioGroup();
            this.btnUpdateJobProgress = new DevExpress.XtraEditors.SimpleButton();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnArrangeColumns = new DevExpress.XtraBars.BarButtonItem();
            this.btnResetColumns = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomization = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestoreYourCustomization = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveYourCustomization = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.mnuJobProgress = new DevExpress.XtraBars.PopupMenu(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuJobProgress)).BeginInit();
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
            this.grdJobProgressView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grdJobProgressView_RowCellStyle);
            this.grdJobProgressView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdJobProgressView_RowStyle);
            this.grdJobProgressView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdJobProgressView_MasterRowExpanded);
            this.grdJobProgressView.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.grdJobProgressView_CustomSummaryCalculate);
            this.grdJobProgressView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdJobProgressView_CellValueChanged);
            this.grdJobProgressView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdJobProgressView_CellValueChanging);
            this.grdJobProgressView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdJobProgressView_MouseDown);
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
            this.btnUpdateJobProgress.Click += new System.EventHandler(this.btnUpdateJobProgress_Click);
            // 
            // toolTipController1
            // 
            this.toolTipController1.AutoPopDelay = 5000000;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(803, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 533);
            this.barDockControlBottom.Size = new System.Drawing.Size(803, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 533);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(803, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 533);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnArrangeColumns,
            this.btnResetColumns,
            this.btnCustomization,
            this.btnExportToExcel,
            this.btnRestoreYourCustomization,
            this.btnSaveYourCustomization,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 7;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // btnArrangeColumns
            // 
            this.btnArrangeColumns.Caption = "Arrange Columns";
            this.btnArrangeColumns.Id = 0;
            this.btnArrangeColumns.ImageIndex = 3;
            this.btnArrangeColumns.Name = "btnArrangeColumns";
            this.btnArrangeColumns.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnArrangeColumns_ItemClick);
            // 
            // btnResetColumns
            // 
            this.btnResetColumns.Caption = "Reset Columns";
            this.btnResetColumns.Id = 1;
            this.btnResetColumns.ImageIndex = 2;
            this.btnResetColumns.Name = "btnResetColumns";
            this.btnResetColumns.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResetColumns_ItemClick);
            // 
            // btnCustomization
            // 
            this.btnCustomization.Caption = "Customization";
            this.btnCustomization.Id = 2;
            this.btnCustomization.ImageIndex = 4;
            this.btnCustomization.Name = "btnCustomization";
            this.btnCustomization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomization_ItemClick);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Caption = "Export To Excel";
            this.btnExportToExcel.Id = 3;
            this.btnExportToExcel.ImageIndex = 1;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportToExcel_ItemClick);
            // 
            // btnRestoreYourCustomization
            // 
            this.btnRestoreYourCustomization.Caption = "Restore Your Customization";
            this.btnRestoreYourCustomization.Id = 4;
            this.btnRestoreYourCustomization.ImageIndex = 3;
            this.btnRestoreYourCustomization.Name = "btnRestoreYourCustomization";
            this.btnRestoreYourCustomization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRestoreYourCustomization_ItemClick);
            // 
            // btnSaveYourCustomization
            // 
            this.btnSaveYourCustomization.Caption = "Save Your Customization";
            this.btnSaveYourCustomization.Id = 5;
            this.btnSaveYourCustomization.ImageIndex = 3;
            this.btnSaveYourCustomization.Name = "btnSaveYourCustomization";
            this.btnSaveYourCustomization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveYourCustomization_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Arrange Columns";
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // mnuJobProgress
            // 
            this.mnuJobProgress.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnArrangeColumns),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveYourCustomization),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRestoreYourCustomization),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResetColumns),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCustomization),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportToExcel)});
            this.mnuJobProgress.Manager = this.barManager1;
            this.mnuJobProgress.Name = "mnuJobProgress";
            // 
            // ctlJobProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdJobProgress);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ctlJobProgress";
            this.Size = new System.Drawing.Size(803, 533);
            this.Load += new System.EventHandler(this.ctlJobProgress_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuJobProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressPhaseView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressComment;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.BarButtonItem btnArrangeColumns;
        private DevExpress.XtraBars.BarButtonItem btnResetColumns;
        private DevExpress.XtraBars.BarButtonItem btnCustomization;
        private DevExpress.XtraBars.BarButtonItem btnExportToExcel;
        private DevExpress.XtraBars.BarButtonItem btnRestoreYourCustomization;
        private DevExpress.XtraBars.BarButtonItem btnSaveYourCustomization;
        private DevExpress.XtraBars.PopupMenu mnuJobProgress;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}