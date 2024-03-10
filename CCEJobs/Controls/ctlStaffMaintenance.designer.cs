namespace WindowsClient.Controls
{
    partial class ctlStaffMaintenance
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlStaffMaintenance));
            this.cardView = new DevExpress.XtraGrid.Views.Card.CardView();
            this.grdStaff = new DevExpress.XtraGrid.GridControl();
            this.grdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.staffRepository = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.radReport = new DevExpress.XtraEditors.RadioGroup();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboStaffReport = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.defaultToolTipController1 = new DevExpress.Utils.DefaultToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cardView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffRepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStaffReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // cardView
            // 
            this.cardView.Appearance.Card.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cardView.Appearance.Card.Options.UseFont = true;
            this.cardView.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cardView.Appearance.CardCaption.Options.UseFont = true;
            this.cardView.Appearance.FieldCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cardView.Appearance.FieldCaption.Options.UseFont = true;
            this.cardView.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cardView.Appearance.FieldValue.Options.UseFont = true;
            this.cardView.FocusedCardTopFieldIndex = 0;
            this.cardView.GridControl = this.grdStaff;
            this.cardView.Name = "cardView";
            this.cardView.OptionsBehavior.AllowExpandCollapse = false;
            this.cardView.OptionsBehavior.Editable = false;
            this.cardView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.cardView.OptionsFilter.AllowFilterEditor = false;
            this.cardView.OptionsFilter.AllowMRUFilterList = false;
            this.cardView.OptionsFilter.ColumnFilterPopupMaxRecordsCount = 3;
            this.cardView.OptionsView.ShowCardExpandButton = false;
            this.cardView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.cardView.OptionsView.ShowHorzScrollBar = false;
            this.cardView.OptionsView.ShowQuickCustomizeButton = false;
            // 
            // grdStaff
            // 
            this.grdStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStaff.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdStaff.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdStaff.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grdStaff.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdStaff.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grdStaff.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdStaff.EmbeddedNavigator.Name = "";
            gridLevelNode1.LevelTemplate = this.cardView;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            gridLevelNode3.RelationName = "Level3";
            this.grdStaff.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3});
            this.grdStaff.Location = new System.Drawing.Point(0, 54);
            this.grdStaff.MainView = this.grdView;
            this.grdStaff.Name = "grdStaff";
            this.grdStaff.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.staffRepository});
            this.grdStaff.Size = new System.Drawing.Size(360, 187);
            this.grdStaff.TabIndex = 5;
            this.grdStaff.UseEmbeddedNavigator = true;
            this.grdStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView,
            this.cardView});
            this.grdStaff.DoubleClick += new System.EventHandler(this.grdStaff_DoubleClick);
            this.grdStaff.Load += new System.EventHandler(this.grdStaff_Load);
            // 
            // grdView
            // 
            this.grdView.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.LightSteelBlue;
            this.grdView.Appearance.FocusedCell.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.grdView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdView.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.grdView.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.LightSteelBlue;
            this.grdView.Appearance.FocusedRow.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.grdView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdView.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.grdView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdView.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.LightSteelBlue;
            this.grdView.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.grdView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grdView.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.grdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.grdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdView.GridControl = this.grdStaff;
            this.grdView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "", "Count")});
            this.grdView.Images = this.imageCollection1;
            this.grdView.Name = "grdView";
            this.grdView.OptionsBehavior.AutoExpandAllGroups = true;
            this.grdView.OptionsBehavior.Editable = false;
            this.grdView.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.grdView.OptionsMenu.EnableColumnMenu = false;
            this.grdView.OptionsMenu.EnableFooterMenu = false;
            this.grdView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdView.OptionsView.ColumnAutoWidth = false;
            this.grdView.OptionsView.ShowGroupPanel = false;
            this.grdView.OptionsView.ShowIndicator = false;
            this.grdView.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.ColumnEdit = this.staffRepository;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // staffRepository
            // 
            this.staffRepository.AutoHeight = false;
            this.staffRepository.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.staffRepository.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.staffRepository.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.staffRepository.Images = this.imageCollection1;
            this.staffRepository.Name = "staffRepository";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(45, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 16);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Staff";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 25);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl1.Location = new System.Drawing.Point(5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(178, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Double Click Here to Add a New Staff";
            this.labelControl1.DoubleClick += new System.EventHandler(this.labelControl1_DoubleClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 33);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(360, 21);
            this.panelControl2.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.Controls.Add(this.radReport);
            this.panelControl3.Controls.Add(this.btnProcess);
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Controls.Add(this.cboStaffReport);
            this.panelControl3.Controls.Add(this.panelControl4);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(360, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(272, 241);
            this.panelControl3.TabIndex = 6;
            // 
            // radReport
            // 
            this.radReport.EditValue = 1;
            this.radReport.Location = new System.Drawing.Point(16, 99);
            this.radReport.Name = "radReport";
            this.radReport.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Preview"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Print")});
            this.radReport.Properties.LookAndFeel.SkinName = "Office 2007 Silver";
            this.radReport.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.radReport.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.radReport.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.radReport.Size = new System.Drawing.Size(105, 48);
            this.radReport.TabIndex = 6;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(214, 68);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(53, 25);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(16, 54);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(78, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Select a Report:";
            // 
            // cboStaffReport
            // 
            this.cboStaffReport.EditValue = "Staff By Role";
            this.cboStaffReport.Location = new System.Drawing.Point(16, 73);
            this.cboStaffReport.Name = "cboStaffReport";
            this.cboStaffReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStaffReport.Properties.Items.AddRange(new object[] {
            "Staff By Role",
            "Staff By System Users",
            "Staff By User Access",
            "Staff List",
            "Staff List with Accounts"});
            this.cboStaffReport.Size = new System.Drawing.Size(195, 20);
            this.cboStaffReport.TabIndex = 2;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.labelControl2);
            this.panelControl4.Controls.Add(this.pictureBox2);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(4, 4);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(264, 33);
            this.panelControl4.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(45, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Staff Reports";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::WindowsClient.PrintRibbonControllerResources.RibbonPrintPreview_PrintDirect;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Location = new System.Drawing.Point(4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 25);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // defaultToolTipController1
            // 
            // 
            // 
            // 
            this.defaultToolTipController1.DefaultController.AutoPopDelay = 10000;
            // 
            // ctlStaffMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdStaff);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl3);
            this.Name = "ctlStaffMaintenance";
            this.Size = new System.Drawing.Size(632, 241);
            ((System.ComponentModel.ISupportInitialize)(this.cardView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffRepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStaffReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl grdStaff;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit staffRepository;
        private DevExpress.XtraGrid.Views.Card.CardView cardView;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.ComboBoxEdit cboStaffReport;
        private DevExpress.Utils.DefaultToolTipController defaultToolTipController1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.RadioGroup radReport;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
    }
}
