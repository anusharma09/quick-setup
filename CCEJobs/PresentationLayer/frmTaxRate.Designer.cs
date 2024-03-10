namespace CCEJobs.PresentationLayer
{
    partial class frmTaxRate
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.mnuFile = new DevExpress.XtraBars.BarSubItem();
            this.mnuExit = new DevExpress.XtraBars.BarStaticItem();
            this.mnuHelp = new DevExpress.XtraBars.BarSubItem();
            this.mnuAbout = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grdTaxRate = new DevExpress.XtraGrid.GridControl();
            this.grdTaxRateView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repLocation = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repTaxRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTaxRateView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTaxRate)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(670, 29);
            this.panelControl1.TabIndex = 452;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(12, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tax Rate";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.RotateWhenVertical = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar4
            // 
            this.bar4.BarName = "Main menu";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DrawDragBorder = false;
            this.bar4.OptionsBar.RotateWhenVertical = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Main menu";
            // 
            // bar5
            // 
            this.bar5.BarName = "Main menu";
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar5.OptionsBar.AllowQuickCustomization = false;
            this.bar5.OptionsBar.DrawDragBorder = false;
            this.bar5.OptionsBar.RotateWhenVertical = false;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Main menu";
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mnuFile,
            this.mnuExit,
            this.mnuHelp,
            this.mnuAbout});
            this.barManager.MainMenu = this.bar1;
            this.barManager.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuHelp)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.RotateWhenVertical = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // mnuFile
            // 
            this.mnuFile.Caption = "&File";
            this.mnuFile.Id = 0;
            this.mnuFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuExit)});
            this.mnuFile.Name = "mnuFile";
            // 
            // mnuExit
            // 
            this.mnuExit.Caption = "&Exit";
            this.mnuExit.Id = 1;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.TextAlignment = System.Drawing.StringAlignment.Near;
            this.mnuExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Caption = "&Help";
            this.mnuHelp.Id = 2;
            this.mnuHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuAbout)});
            this.mnuHelp.Name = "mnuHelp";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Caption = "&About";
            this.mnuAbout.Id = 3;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.TextAlignment = System.Drawing.StringAlignment.Near;
            this.mnuAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(670, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 449);
            this.barDockControlBottom.Size = new System.Drawing.Size(670, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 427);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(670, 22);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 427);
            // 
            // grdTaxRate
            // 
            this.grdTaxRate.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.grdTaxRate.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdTaxRate.Location = new System.Drawing.Point(0, 51);
            this.grdTaxRate.MainView = this.grdTaxRateView;
            this.grdTaxRate.Name = "grdTaxRate";
            this.grdTaxRate.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLocation,
            this.repTaxRate});
            this.grdTaxRate.Size = new System.Drawing.Size(670, 398);
            this.grdTaxRate.TabIndex = 453;
            this.grdTaxRate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdTaxRateView});
            // 
            // grdTaxRateView
            // 
            this.grdTaxRateView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdTaxRateView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdTaxRateView.GridControl = this.grdTaxRate;
            this.grdTaxRateView.Name = "grdTaxRateView";
            this.grdTaxRateView.OptionsView.ColumnAutoWidth = false;
            this.grdTaxRateView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdTaxRateView.OptionsView.ShowFooter = true;
            this.grdTaxRateView.OptionsView.ShowGroupPanel = false;
            this.grdTaxRateView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdTaxRateView_InvalidRowException);
            this.grdTaxRateView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdTaxRateView_ValidateRow);
            this.grdTaxRateView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdTaxRateView_KeyDown);
            // 
            // repLocation
            // 
            this.repLocation.AutoHeight = false;
            this.repLocation.MaxLength = 50;
            this.repLocation.Name = "repLocation";
            // 
            // repTaxRate
            // 
            this.repTaxRate.AutoHeight = false;
            this.repTaxRate.DisplayFormat.FormatString = "p4";
            this.repTaxRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repTaxRate.EditFormat.FormatString = "p4";
            this.repTaxRate.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repTaxRate.Mask.EditMask = "p4";
            this.repTaxRate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repTaxRate.Name = "repTaxRate";
            // 
            // frmTaxRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 449);
            this.Controls.Add(this.grdTaxRate);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTaxRate";
            this.Text = "Tax Rate";
            this.Load += new System.EventHandler(this.frmTaxRate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTaxRateView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTaxRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarSubItem mnuFile;
        private DevExpress.XtraBars.BarStaticItem mnuExit;
        private DevExpress.XtraBars.BarSubItem mnuHelp;
        private DevExpress.XtraBars.BarStaticItem mnuAbout;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl grdTaxRate;
        private DevExpress.XtraGrid.Views.Grid.GridView grdTaxRateView;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repLocation;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repTaxRate;
    }
}