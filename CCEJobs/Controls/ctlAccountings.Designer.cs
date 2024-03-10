namespace CCEJobs.Controls
{
    partial class ctlAccountings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlAccountings));
            this.panGrid = new DevExpress.XtraEditors.PanelControl();
            this.grdJobList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repPercent = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panGridTitle = new DevExpress.XtraEditors.PanelControl();
            this.picList = new DevExpress.XtraEditors.PictureEdit();
            this.lblList = new DevExpress.XtraEditors.LabelControl();
            this.panUtil = new DevExpress.XtraEditors.PanelControl();
            this.panSearch = new DevExpress.XtraEditors.PanelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.panReportParamters = new DevExpress.XtraEditors.PanelControl();
            this.panReport = new DevExpress.XtraEditors.PanelControl();
            this.cboReport = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.imgDoc = new DevExpress.Utils.ImageCollection(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.docPrint = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.docSearchPrint = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.panGrid)).BeginInit();
            this.panGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGridTitle)).BeginInit();
            this.panGridTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panUtil)).BeginInit();
            this.panUtil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panSearch)).BeginInit();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panReportParamters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panReport)).BeginInit();
            this.panReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDoc)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.docPrint.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            this.docSearchPrint.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // panGrid
            // 
            this.panGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGrid.Controls.Add(this.grdJobList);
            this.panGrid.Controls.Add(this.panGridTitle);
            this.panGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGrid.Location = new System.Drawing.Point(0, 0);
            this.panGrid.Name = "panGrid";
            this.panGrid.Size = new System.Drawing.Size(283, 719);
            this.panGrid.TabIndex = 7;
            // 
            // grdJobList
            // 
            this.grdJobList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobList.EmbeddedNavigator.Name = "";
            this.grdJobList.Location = new System.Drawing.Point(0, 27);
            this.grdJobList.MainView = this.gridView1;
            this.grdJobList.Name = "grdJobList";
            this.grdJobList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repPercent});
            this.grdJobList.Size = new System.Drawing.Size(283, 692);
            this.grdJobList.TabIndex = 7;
            this.grdJobList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.GridControl = this.grdJobList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // repPercent
            // 
            this.repPercent.AutoHeight = false;
            this.repPercent.Mask.EditMask = "p";
            this.repPercent.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repPercent.Mask.UseMaskAsDisplayFormat = true;
            this.repPercent.Name = "repPercent";
            // 
            // panGridTitle
            // 
            this.panGridTitle.Controls.Add(this.picList);
            this.panGridTitle.Controls.Add(this.lblList);
            this.panGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panGridTitle.Location = new System.Drawing.Point(0, 0);
            this.panGridTitle.Name = "panGridTitle";
            this.panGridTitle.Size = new System.Drawing.Size(283, 27);
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
            this.lblList.Size = new System.Drawing.Size(41, 13);
            this.lblList.TabIndex = 0;
            this.lblList.Text = "Jobs List";
            // 
            // panUtil
            // 
            this.panUtil.Controls.Add(this.panSearch);
            this.panUtil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panUtil.Location = new System.Drawing.Point(0, 0);
            this.panUtil.Name = "panUtil";
            this.panUtil.Size = new System.Drawing.Size(250, 668);
            this.panUtil.TabIndex = 8;
            // 
            // panSearch
            // 
            this.panSearch.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panSearch.Controls.Add(this.btnClear);
            this.panSearch.Controls.Add(this.btnProcess);
            this.panSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSearch.Location = new System.Drawing.Point(2, 2);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(246, 540);
            this.panSearch.TabIndex = 10;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(140, 27);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 21);
            this.btnClear.TabIndex = 365;
            this.btnClear.Text = "&Clear";
            this.btnClear.Visible = false;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(69, 27);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(50, 21);
            this.btnProcess.TabIndex = 364;
            this.btnProcess.Text = "&Process";
            // 
            // panReportParamters
            // 
            this.panReportParamters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panReportParamters.Location = new System.Drawing.Point(0, 72);
            this.panReportParamters.Name = "panReportParamters";
            this.panReportParamters.Size = new System.Drawing.Size(250, 596);
            this.panReportParamters.TabIndex = 12;
            // 
            // panReport
            // 
            this.panReport.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panReport.Controls.Add(this.cboReport);
            this.panReport.Controls.Add(this.labelControl6);
            this.panReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.panReport.Location = new System.Drawing.Point(0, 0);
            this.panReport.Name = "panReport";
            this.panReport.Size = new System.Drawing.Size(250, 72);
            this.panReport.TabIndex = 11;
            // 
            // cboReport
            // 
            this.cboReport.Location = new System.Drawing.Point(12, 35);
            this.cboReport.Name = "cboReport";
            this.cboReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboReport.Properties.DropDownRows = 15;
            this.cboReport.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboReport.Size = new System.Drawing.Size(197, 20);
            this.cboReport.TabIndex = 366;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 16);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(78, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Select a Report:";
            // 
            // dockManager1
            // 
            this.dockManager1.DockingOptions.ShowCloseButton = false;
            this.dockManager1.DockingOptions.ShowMaximizeButton = false;
            this.dockManager1.DockMode = DevExpress.XtraBars.Docking.Helpers.DockMode.Standard;
            this.dockManager1.Form = this;
            this.dockManager1.Images = this.imgDoc;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // imgDoc
            // 
            this.imgDoc.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgDoc.ImageStream")));
            // 
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.docSearchPrint;
            this.panelContainer1.Controls.Add(this.docSearchPrint);
            this.panelContainer1.Controls.Add(this.docPrint);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.FloatVertical = true;
            this.panelContainer1.ID = new System.Guid("8574cc42-1edc-4df3-9532-1c4983315e6f");
            this.panelContainer1.Location = new System.Drawing.Point(283, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.Size = new System.Drawing.Size(256, 719);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.Text = "panelContainer1";
            // 
            // docPrint
            // 
            this.docPrint.Controls.Add(this.controlContainer1);
            this.docPrint.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.docPrint.ID = new System.Guid("a2cc42cd-3e07-4640-95d8-38420987eaed");
            this.docPrint.ImageIndex = 0;
            this.docPrint.Location = new System.Drawing.Point(3, 25);
            this.docPrint.Name = "docPrint";
            this.docPrint.Options.AllowDockBottom = false;
            this.docPrint.Options.AllowDockLeft = false;
            this.docPrint.Options.AllowDockTop = false;
            this.docPrint.Options.AllowFloating = false;
            this.docPrint.Options.FloatOnDblClick = false;
            this.docPrint.Options.ShowCloseButton = false;
            this.docPrint.Options.ShowMaximizeButton = false;
            this.docPrint.Size = new System.Drawing.Size(250, 668);
            this.docPrint.Text = "Print";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.panReportParamters);
            this.controlContainer1.Controls.Add(this.panReport);
            this.controlContainer1.Location = new System.Drawing.Point(0, 0);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(250, 668);
            this.controlContainer1.TabIndex = 0;
            // 
            // docSearchPrint
            // 
            this.docSearchPrint.Controls.Add(this.dockPanel1_Container);
            this.docSearchPrint.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.docSearchPrint.FloatVertical = true;
            this.docSearchPrint.ID = new System.Guid("dea7b5b2-10b1-4803-be85-c4773c2c65a2");
            this.docSearchPrint.ImageIndex = 1;
            this.docSearchPrint.Location = new System.Drawing.Point(3, 25);
            this.docSearchPrint.Name = "docSearchPrint";
            this.docSearchPrint.Options.AllowDockBottom = false;
            this.docSearchPrint.Options.AllowDockLeft = false;
            this.docSearchPrint.Options.AllowDockTop = false;
            this.docSearchPrint.Options.AllowFloating = false;
            this.docSearchPrint.Options.FloatOnDblClick = false;
            this.docSearchPrint.Options.ShowCloseButton = false;
            this.docSearchPrint.Options.ShowMaximizeButton = false;
            this.docSearchPrint.Size = new System.Drawing.Size(250, 668);
            this.docSearchPrint.Text = "Search";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panUtil);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(250, 668);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ctlAccountings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGrid);
            this.Controls.Add(this.panelContainer1);
            this.Name = "ctlAccountings";
            this.Size = new System.Drawing.Size(539, 719);
            ((System.ComponentModel.ISupportInitialize)(this.panGrid)).EndInit();
            this.panGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdJobList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGridTitle)).EndInit();
            this.panGridTitle.ResumeLayout(false);
            this.panGridTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panUtil)).EndInit();
            this.panUtil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panSearch)).EndInit();
            this.panSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panReportParamters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panReport)).EndInit();
            this.panReport.ResumeLayout(false);
            this.panReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDoc)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.docPrint.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            this.docSearchPrint.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panGrid;
        private DevExpress.XtraEditors.PanelControl panGridTitle;
        private DevExpress.XtraEditors.PictureEdit picList;
        private DevExpress.XtraEditors.LabelControl lblList;
        private DevExpress.XtraGrid.GridControl grdJobList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panUtil;
        private DevExpress.XtraEditors.PanelControl panSearch;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.PanelControl panReport;
        private DevExpress.XtraEditors.ComboBoxEdit cboReport;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.PanelControl panReportParamters;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel docSearchPrint;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.Utils.ImageCollection imgDoc;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel docPrint;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repPercent;
    }
}
