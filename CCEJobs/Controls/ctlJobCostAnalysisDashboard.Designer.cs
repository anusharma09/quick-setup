namespace CCEJobs.Controls
{
    partial class ctlJobCostAnalysisDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlJobCostAnalysisDashboard));
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panJob = new DevExpress.XtraEditors.PanelControl();
            this.grdJobList = new DevExpress.XtraGrid.GridControl();
            this.grdJobListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.panGridTitle = new DevExpress.XtraEditors.PanelControl();
            this.picList = new DevExpress.XtraEditors.PictureEdit();
            this.lblList = new DevExpress.XtraEditors.LabelControl();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panSearch = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.radioReport = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioStatus = new DevExpress.XtraEditors.RadioGroup();
            this.radioJob = new DevExpress.XtraEditors.RadioGroup();
            this.btnPrintSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockDashboard = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.imgDoc = new DevExpress.Utils.ImageCollection(this.components);
            this.docSearch = new DevExpress.XtraBars.Docking.DockPanel();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnArrangeColumns = new DevExpress.XtraBars.BarButtonItem();
            this.btnResetColumns = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomization = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestoreYourCustomization = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveYourCustomization = new DevExpress.XtraBars.BarButtonItem();
            this.mnuJobCostAnalysis = new DevExpress.XtraBars.PopupMenu(this.components);
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panJob)).BeginInit();
            this.panJob.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGridTitle)).BeginInit();
            this.panGridTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picList.Properties)).BeginInit();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panSearch)).BeginInit();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioJob.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDoc)).BeginInit();
            this.docSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuJobCostAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.AutoScrollMinSize = new System.Drawing.Size(500, 500);
            this.xtraScrollableControl1.Controls.Add(this.panJob);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(350, 719);
            this.xtraScrollableControl1.TabIndex = 10;
            // 
            // panJob
            // 
            this.panJob.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panJob.Controls.Add(this.panGridTitle);
            this.panJob.Controls.Add(this.grdJobList);
            this.panJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panJob.Location = new System.Drawing.Point(0, 0);
            this.panJob.Name = "panJob";
            this.panJob.Size = new System.Drawing.Size(500, 702);
            this.panJob.TabIndex = 11;
            // 
            // grdJobList
            // 
            this.grdJobList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobList.Location = new System.Drawing.Point(0, 0);
            this.grdJobList.MainView = this.grdJobListView;
            this.grdJobList.Name = "grdJobList";
            this.grdJobList.Size = new System.Drawing.Size(500, 702);
            this.grdJobList.TabIndex = 7;
            this.grdJobList.ToolTipController = this.toolTipController1;
            this.grdJobList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdJobListView});
            this.grdJobList.DoubleClick += new System.EventHandler(this.grdJobList_DoubleClick);
            // 
            // grdJobListView
            // 
            this.grdJobListView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobListView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdJobListView.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobListView.Appearance.GroupFooter.Options.UseFont = true;
            this.grdJobListView.GridControl = this.grdJobList;
            this.grdJobListView.Name = "grdJobListView";
            this.grdJobListView.OptionsBehavior.Editable = false;
            this.grdJobListView.OptionsMenu.EnableColumnMenu = false;
            this.grdJobListView.OptionsMenu.EnableFooterMenu = false;
            this.grdJobListView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdJobListView.OptionsView.ColumnAutoWidth = false;
            this.grdJobListView.OptionsView.ShowFooter = true;
            this.grdJobListView.OptionsView.ShowGroupPanel = false;
            this.grdJobListView.ColumnFilterChanged += new System.EventHandler(this.gridView1_ColumnFilterChanged);
            this.grdJobListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            this.grdJobListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseUp);
            // 
            // toolTipController1
            // 
            this.toolTipController1.AutoPopDelay = 5000000;
            // 
            // panGridTitle
            // 
            this.panGridTitle.Controls.Add(this.picList);
            this.panGridTitle.Controls.Add(this.lblList);
            this.panGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panGridTitle.Location = new System.Drawing.Point(0, 0);
            this.panGridTitle.Name = "panGridTitle";
            this.panGridTitle.Size = new System.Drawing.Size(500, 27);
            this.panGridTitle.TabIndex = 8;
            // 
            // picList
            // 
            this.picList.EditValue = ((object)(resources.GetObject("picList.EditValue")));
            this.picList.Location = new System.Drawing.Point(7, 3);
            this.picList.Name = "picList";
            this.picList.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picList.Size = new System.Drawing.Size(31, 23);
            this.picList.TabIndex = 1;
            // 
            // lblList
            // 
            this.lblList.Location = new System.Drawing.Point(53, 9);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(47, 13);
            this.lblList.TabIndex = 0;
            this.lblList.Text = "Jobs Cost";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(238, 677);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panSearch
            // 
            this.panSearch.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panSearch.Controls.Add(this.labelControl3);
            this.panSearch.Controls.Add(this.radioReport);
            this.panSearch.Controls.Add(this.labelControl2);
            this.panSearch.Controls.Add(this.labelControl1);
            this.panSearch.Controls.Add(this.radioStatus);
            this.panSearch.Controls.Add(this.radioJob);
            this.panSearch.Controls.Add(this.btnPrintSummary);
            this.panSearch.Controls.Add(this.btnProcess);
            this.panSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSearch.Location = new System.Drawing.Point(0, 0);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(238, 677);
            this.panSearch.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(4, 140);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 371;
            this.labelControl3.Text = "Report:";
            // 
            // radioReport
            // 
            this.radioReport.EditValue = 0;
            this.radioReport.Location = new System.Drawing.Point(45, 131);
            this.radioReport.Name = "radioReport";
            this.radioReport.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Detail"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Summary")});
            this.radioReport.Size = new System.Drawing.Size(186, 22);
            this.radioReport.TabIndex = 370;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(4, 112);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(35, 13);
            this.labelControl2.TabIndex = 369;
            this.labelControl2.Text = "Status:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 84);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 13);
            this.labelControl1.TabIndex = 368;
            this.labelControl1.Text = "Job:";
            // 
            // radioStatus
            // 
            this.radioStatus.EditValue = 0;
            this.radioStatus.Location = new System.Drawing.Point(45, 103);
            this.radioStatus.Name = "radioStatus";
            this.radioStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Open"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Closed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "All")});
            this.radioStatus.Size = new System.Drawing.Size(186, 22);
            this.radioStatus.TabIndex = 367;
            // 
            // radioJob
            // 
            this.radioJob.EditValue = 0;
            this.radioJob.Location = new System.Drawing.Point(45, 75);
            this.radioJob.Name = "radioJob";
            this.radioJob.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "4 Digits"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "5 Digits"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "All")});
            this.radioJob.Size = new System.Drawing.Size(186, 22);
            this.radioJob.TabIndex = 366;
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Image = global::CCEJobs.Properties.Resources.PrintHS;
            this.btnPrintSummary.Location = new System.Drawing.Point(150, 166);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(81, 26);
            this.btnPrintSummary.TabIndex = 12;
            this.btnPrintSummary.Text = "Report";
            this.btnPrintSummary.Click += new System.EventHandler(this.btnPrintSummary_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(45, 30);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(50, 21);
            this.btnProcess.TabIndex = 364;
            this.btnProcess.Text = "&Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(596, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 719);
            this.barDockControlBottom.Size = new System.Drawing.Size(596, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 719);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(596, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 719);
            // 
            // dockDashboard
            // 
            this.dockDashboard.DockingOptions.ShowCloseButton = false;
            this.dockDashboard.DockingOptions.ShowMaximizeButton = false;
            this.dockDashboard.DockMode = DevExpress.XtraBars.Docking.Helpers.DockMode.Standard;
            this.dockDashboard.Form = this;
            this.dockDashboard.Images = this.imgDoc;
            this.dockDashboard.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.docSearch});
            this.dockDashboard.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // imgDoc
            // 
            this.imgDoc.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgDoc.ImageStream")));
            // 
            // docSearch
            // 
            this.docSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.docSearch.Appearance.Image = global::CCEJobs.Properties.Resources.eventlog;
            this.docSearch.Appearance.Options.UseFont = true;
            this.docSearch.Appearance.Options.UseImage = true;
            this.docSearch.Appearance.Options.UseTextOptions = true;
            this.docSearch.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.docSearch.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.docSearch.AutoScroll = true;
            this.docSearch.Controls.Add(this.dockPanel1_Container);
            this.docSearch.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.docSearch.FloatVertical = true;
            this.docSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docSearch.ID = new System.Guid("9078e482-5f79-4927-baa7-c307b819fe85");
            this.docSearch.ImageIndex = 1;
            this.docSearch.Location = new System.Drawing.Point(350, 0);
            this.docSearch.Name = "docSearch";
            this.docSearch.Options.AllowDockBottom = false;
            this.docSearch.Options.AllowDockFill = false;
            this.docSearch.Options.AllowDockLeft = false;
            this.docSearch.Options.AllowDockTop = false;
            this.docSearch.Options.AllowFloating = false;
            this.docSearch.Options.FloatOnDblClick = false;
            this.docSearch.Options.ShowCloseButton = false;
            this.docSearch.Options.ShowMaximizeButton = false;
            this.docSearch.OriginalSize = new System.Drawing.Size(246, 719);
            this.docSearch.Size = new System.Drawing.Size(246, 719);
            this.docSearch.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Right;
            this.docSearch.TabText = "Search";
            this.docSearch.Text = "Search";
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
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.btnSaveYourCustomization});
            this.barManager1.MaxItemId = 10;
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
            // 
            // btnResetColumns
            // 
            this.btnResetColumns.Caption = "Reset Columns";
            this.btnResetColumns.Id = 1;
            this.btnResetColumns.ImageIndex = 2;
            this.btnResetColumns.Name = "btnResetColumns";
            this.btnResetColumns.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // btnCustomization
            // 
            this.btnCustomization.Caption = "Customization";
            this.btnCustomization.Id = 2;
            this.btnCustomization.ImageIndex = 4;
            this.btnCustomization.Name = "btnCustomization";
            this.btnCustomization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Caption = "Export To Excel";
            this.btnExportToExcel.Id = 3;
            this.btnExportToExcel.ImageIndex = 1;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // btnRestoreYourCustomization
            // 
            this.btnRestoreYourCustomization.Caption = "Restore Your Customization";
            this.btnRestoreYourCustomization.Id = 4;
            this.btnRestoreYourCustomization.ImageIndex = 3;
            this.btnRestoreYourCustomization.Name = "btnRestoreYourCustomization";
            this.btnRestoreYourCustomization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "btnRestoreYourCustomization";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 6;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Customization";
            this.barButtonItem3.Id = 7;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Export To Excel";
            this.barButtonItem4.Id = 8;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // btnSaveYourCustomization
            // 
            this.btnSaveYourCustomization.Caption = "Save Your Customization";
            this.btnSaveYourCustomization.Id = 9;
            this.btnSaveYourCustomization.ImageIndex = 3;
            this.btnSaveYourCustomization.Name = "btnSaveYourCustomization";
            this.btnSaveYourCustomization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // mnuJobCostAnalysis
            // 
            this.mnuJobCostAnalysis.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveYourCustomization),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRestoreYourCustomization),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResetColumns),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCustomization),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportToExcel)});
            this.mnuJobCostAnalysis.Manager = this.barManager1;
            this.mnuJobCostAnalysis.Name = "mnuJobCostAnalysis";
            // 
            // ctlJobCostAnalysisDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.docSearch);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ctlJobCostAnalysisDashboard";
            this.Size = new System.Drawing.Size(596, 719);
            this.Load += new System.EventHandler(this.ctlJobList_Load);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panJob)).EndInit();
            this.panJob.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdJobList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGridTitle)).EndInit();
            this.panGridTitle.ResumeLayout(false);
            this.panGridTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picList.Properties)).EndInit();
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panSearch)).EndInit();
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioJob.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDoc)).EndInit();
            this.docSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuJobCostAnalysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.PanelControl panJob;
        private DevExpress.XtraEditors.PanelControl panGridTitle;
        private DevExpress.XtraEditors.PictureEdit picList;
        private DevExpress.XtraEditors.LabelControl lblList;
        private DevExpress.XtraEditors.SimpleButton btnPrintSummary;
        private DevExpress.XtraGrid.GridControl grdJobList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobListView;
        private DevExpress.XtraBars.Docking.DockManager dockDashboard;
        private DevExpress.XtraBars.Docking.DockPanel docSearch;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.PanelControl panSearch;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.Utils.ImageCollection imgDoc;
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
        private DevExpress.XtraBars.PopupMenu mnuJobCostAnalysis;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem btnSaveYourCustomization;
        private DevExpress.XtraEditors.RadioGroup radioStatus;
        private DevExpress.XtraEditors.RadioGroup radioJob;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.RadioGroup radioReport;
    }
}
