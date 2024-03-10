namespace JCCContactManagement.Controls
{
    partial class ctlStaticTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlStaticTables));
            this.treeTables = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControlItem = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grdDataView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repCertificationRenewalUnits = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.imgDoc = new DevExpress.Utils.ImageCollection(this.components);
            this.mnuMenuToolWatch = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnSaveYourCustomization = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestoreYourCustomization = new DevExpress.XtraBars.BarButtonItem();
            this.btnResetColumns = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomization = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnDailySheet = new DevExpress.XtraBars.BarButtonItem();
            this.btnDailyReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnWeeklyEquipment = new DevExpress.XtraBars.BarButtonItem();
            this.btnWeeklyLaborByCraft = new DevExpress.XtraBars.BarButtonItem();
            this.btnWeeklyLaborByEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditEquipment = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintInvoiceDetail = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintInvoiceWorkSheet = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintEquipment = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panGridTitle = new DevExpress.XtraEditors.PanelControl();
            this.picList = new DevExpress.XtraEditors.PictureEdit();
            this.lblList = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlItem)).BeginInit();
            this.panelControlItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCertificationRenewalUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenuToolWatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGridTitle)).BeginInit();
            this.panGridTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeTables
            // 
            this.treeTables.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeTables.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeTables.FixedLineWidth = 1;
            this.treeTables.Location = new System.Drawing.Point(0, 54);
            this.treeTables.Name = "treeTables";
            this.treeTables.BeginUnboundLoad();
            this.treeTables.AppendNode(new object[] {
            "Activity Type"}, -1, 0, 0, 6);
            this.treeTables.AppendNode(new object[] {
            "Department"}, -1, 0, 0, 6);
            this.treeTables.AppendNode(new object[] {
            "Industry"}, -1, 0, 0, 6);
            this.treeTables.AppendNode(new object[] {
            "Referred By"}, -1, 0, 0, 6);
            this.treeTables.AppendNode(new object[] {
            "Status"}, -1, 0, 0, 6);
            this.treeTables.AppendNode(new object[] {
            "Territory"}, -1, 0, 0, 6);
            this.treeTables.AppendNode(new object[] {
            "Title"}, -1, 0, 0, 6);
            this.treeTables.EndUnboundLoad();
            this.treeTables.OptionsBehavior.Editable = false;
            this.treeTables.OptionsView.ShowColumns = false;
            this.treeTables.OptionsView.ShowHorzLines = false;
            this.treeTables.OptionsView.ShowIndicator = false;
            this.treeTables.OptionsView.ShowRoot = false;
            this.treeTables.OptionsView.ShowVertLines = false;
            this.treeTables.Size = new System.Drawing.Size(196, 448);
            this.treeTables.StateImageList = this.imageCollection2;
            this.treeTables.TabIndex = 0;
            this.treeTables.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeTables_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 132;
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            // 
            // panelControlItem
            // 
            this.panelControlItem.Controls.Add(this.hyperLinkEdit1);
            this.panelControlItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlItem.Location = new System.Drawing.Point(0, 27);
            this.panelControlItem.Name = "panelControlItem";
            this.panelControlItem.Size = new System.Drawing.Size(501, 27);
            this.panelControlItem.TabIndex = 453;
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.hyperLinkEdit1.EditValue = "New Activity Type ...";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(2, 2);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(114, 18);
            this.hyperLinkEdit1.TabIndex = 3;
            this.hyperLinkEdit1.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // grdData
            // 
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.EmbeddedNavigator.Name = "";
            this.grdData.Location = new System.Drawing.Point(196, 54);
            this.grdData.MainView = this.grdDataView;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCertificationRenewalUnits});
            this.grdData.Size = new System.Drawing.Size(305, 448);
            this.grdData.TabIndex = 454;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDataView});
            // 
            // grdDataView
            // 
            this.grdDataView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdDataView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdDataView.GridControl = this.grdData;
            this.grdDataView.Name = "grdDataView";
            this.grdDataView.OptionsBehavior.Editable = false;
            this.grdDataView.OptionsCustomization.AllowGroup = false;
            this.grdDataView.OptionsView.ColumnAutoWidth = false;
            this.grdDataView.OptionsView.ShowGroupPanel = false;
            this.grdDataView.DoubleClick += new System.EventHandler(this.grdDataView_DoubleClick);
            this.grdDataView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdDataView_MouseDown);
            // 
            // repCertificationRenewalUnits
            // 
            this.repCertificationRenewalUnits.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Days"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Weeks"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Months"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Years")});
            this.repCertificationRenewalUnits.Name = "repCertificationRenewalUnits";
            // 
            // dockManager1
            // 
            this.dockManager1.DockingOptions.ShowCloseButton = false;
            this.dockManager1.DockingOptions.ShowMaximizeButton = false;
            this.dockManager1.DockMode = DevExpress.XtraBars.Docking.Helpers.DockMode.Standard;
            this.dockManager1.Images = this.imgDoc;
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
            // mnuMenuToolWatch
            // 
            this.mnuMenuToolWatch.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveYourCustomization, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRestoreYourCustomization),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResetColumns),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCustomization),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportToExcel)});
            this.mnuMenuToolWatch.Manager = this.barManager1;
            this.mnuMenuToolWatch.Name = "mnuMenuToolWatch";
            // 
            // btnSaveYourCustomization
            // 
            this.btnSaveYourCustomization.Caption = "Save your Customization";
            this.btnSaveYourCustomization.Id = 8;
            this.btnSaveYourCustomization.ImageIndex = 2;
            this.btnSaveYourCustomization.Name = "btnSaveYourCustomization";
            this.btnSaveYourCustomization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // btnRestoreYourCustomization
            // 
            this.btnRestoreYourCustomization.Caption = "Restore Your Customization";
            this.btnRestoreYourCustomization.Id = 9;
            this.btnRestoreYourCustomization.ImageIndex = 2;
            this.btnRestoreYourCustomization.Name = "btnRestoreYourCustomization";
            this.btnRestoreYourCustomization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // btnResetColumns
            // 
            this.btnResetColumns.Caption = "Reset Columns";
            this.btnResetColumns.Id = 10;
            this.btnResetColumns.ImageIndex = 5;
            this.btnResetColumns.Name = "btnResetColumns";
            this.btnResetColumns.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // btnCustomization
            // 
            this.btnCustomization.Caption = "Customization";
            this.btnCustomization.Id = 11;
            this.btnCustomization.ImageIndex = 3;
            this.btnCustomization.Name = "btnCustomization";
            this.btnCustomization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Caption = "Export To Excel";
            this.btnExportToExcel.Id = 12;
            this.btnExportToExcel.ImageIndex = 4;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
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
            this.btnDailySheet,
            this.btnDailyReport,
            this.btnWeeklyEquipment,
            this.btnWeeklyLaborByCraft,
            this.btnWeeklyLaborByEmployee,
            this.btnEditEquipment,
            this.btnPrintInvoiceDetail,
            this.btnPrintInvoiceWorkSheet,
            this.btnSaveYourCustomization,
            this.btnRestoreYourCustomization,
            this.btnResetColumns,
            this.btnCustomization,
            this.btnExportToExcel,
            this.btnPrintEquipment});
            this.barManager1.MaxItemId = 14;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // btnDailySheet
            // 
            this.btnDailySheet.Caption = "Daily Sheet";
            this.btnDailySheet.Id = 0;
            this.btnDailySheet.ImageIndex = 0;
            this.btnDailySheet.Name = "btnDailySheet";
            // 
            // btnDailyReport
            // 
            this.btnDailyReport.Caption = "Daily Report";
            this.btnDailyReport.Id = 1;
            this.btnDailyReport.ImageIndex = 0;
            this.btnDailyReport.Name = "btnDailyReport";
            // 
            // btnWeeklyEquipment
            // 
            this.btnWeeklyEquipment.Caption = "Weekly Equipment";
            this.btnWeeklyEquipment.Id = 2;
            this.btnWeeklyEquipment.ImageIndex = 0;
            this.btnWeeklyEquipment.Name = "btnWeeklyEquipment";
            // 
            // btnWeeklyLaborByCraft
            // 
            this.btnWeeklyLaborByCraft.Caption = "Weekly Labor by Craft";
            this.btnWeeklyLaborByCraft.Id = 3;
            this.btnWeeklyLaborByCraft.ImageIndex = 0;
            this.btnWeeklyLaborByCraft.Name = "btnWeeklyLaborByCraft";
            // 
            // btnWeeklyLaborByEmployee
            // 
            this.btnWeeklyLaborByEmployee.Caption = "Weekly Labor by Employee";
            this.btnWeeklyLaborByEmployee.Id = 4;
            this.btnWeeklyLaborByEmployee.ImageIndex = 0;
            this.btnWeeklyLaborByEmployee.Name = "btnWeeklyLaborByEmployee";
            // 
            // btnEditEquipment
            // 
            this.btnEditEquipment.Caption = "Edit Equipment";
            this.btnEditEquipment.Id = 5;
            this.btnEditEquipment.ImageIndex = 1;
            this.btnEditEquipment.Name = "btnEditEquipment";
            // 
            // btnPrintInvoiceDetail
            // 
            this.btnPrintInvoiceDetail.Caption = "Print Invoice Detail";
            this.btnPrintInvoiceDetail.Id = 6;
            this.btnPrintInvoiceDetail.ImageIndex = 0;
            this.btnPrintInvoiceDetail.Name = "btnPrintInvoiceDetail";
            // 
            // btnPrintInvoiceWorkSheet
            // 
            this.btnPrintInvoiceWorkSheet.Caption = "Print Invoice Work Sheet";
            this.btnPrintInvoiceWorkSheet.Id = 7;
            this.btnPrintInvoiceWorkSheet.ImageIndex = 0;
            this.btnPrintInvoiceWorkSheet.Name = "btnPrintInvoiceWorkSheet";
            // 
            // btnPrintEquipment
            // 
            this.btnPrintEquipment.Caption = "Print Equipment Sheet";
            this.btnPrintEquipment.Id = 13;
            this.btnPrintEquipment.ImageIndex = 0;
            this.btnPrintEquipment.Name = "btnPrintEquipment";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // panGridTitle
            // 
            this.panGridTitle.Controls.Add(this.picList);
            this.panGridTitle.Controls.Add(this.lblList);
            this.panGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panGridTitle.Location = new System.Drawing.Point(0, 0);
            this.panGridTitle.Name = "panGridTitle";
            this.panGridTitle.Size = new System.Drawing.Size(501, 27);
            this.panGridTitle.TabIndex = 9;
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
            this.lblList.Size = new System.Drawing.Size(71, 13);
            this.lblList.TabIndex = 0;
            this.lblList.Text = "Categories List";
            // 
            // ctlStaticTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.treeTables);
            this.Controls.Add(this.panelControlItem);
            this.Controls.Add(this.panGridTitle);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ctlStaticTables";
            this.Size = new System.Drawing.Size(501, 502);
            ((System.ComponentModel.ISupportInitialize)(this.treeTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlItem)).EndInit();
            this.panelControlItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCertificationRenewalUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenuToolWatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGridTitle)).EndInit();
            this.panGridTitle.ResumeLayout(false);
            this.panGridTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picList.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeTables;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraEditors.PanelControl panelControlItem;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDataView;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.Utils.ImageCollection imgDoc;
        private DevExpress.XtraBars.PopupMenu mnuMenuToolWatch;
        private DevExpress.XtraBars.BarButtonItem btnSaveYourCustomization;
        private DevExpress.XtraBars.BarButtonItem btnRestoreYourCustomization;
        private DevExpress.XtraBars.BarButtonItem btnResetColumns;
        private DevExpress.XtraBars.BarButtonItem btnCustomization;
        private DevExpress.XtraBars.BarButtonItem btnExportToExcel;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.BarButtonItem btnDailySheet;
        private DevExpress.XtraBars.BarButtonItem btnDailyReport;
        private DevExpress.XtraBars.BarButtonItem btnWeeklyEquipment;
        private DevExpress.XtraBars.BarButtonItem btnWeeklyLaborByCraft;
        private DevExpress.XtraBars.BarButtonItem btnWeeklyLaborByEmployee;
        private DevExpress.XtraBars.BarButtonItem btnEditEquipment;
        private DevExpress.XtraBars.BarButtonItem btnPrintInvoiceDetail;
        private DevExpress.XtraBars.BarButtonItem btnPrintInvoiceWorkSheet;
        private DevExpress.XtraBars.BarButtonItem btnPrintEquipment;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repCertificationRenewalUnits;
        private DevExpress.XtraEditors.PanelControl panGridTitle;
        private DevExpress.XtraEditors.PictureEdit picList;
        private DevExpress.XtraEditors.LabelControl lblList;
    }
}
