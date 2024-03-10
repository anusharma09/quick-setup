namespace CCEJobs.Controls
{
    partial class ctlJobCorrespondenceLetter
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
            this.grdJobCorrespondenceLetter = new DevExpress.XtraGrid.GridControl();
            this.grdJobCorrespondenceLetterView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkSelectedItem = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtUserDescription = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.txtMaterialCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtLaborCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtOtherCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtHours = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cboUnit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.txtUserDescription1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.panJobCorrespondenceLetter = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.grdSubmittalDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCorrespondenceLetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCorrespondenceLetterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panJobCorrespondenceLetter)).BeginInit();
            this.panJobCorrespondenceLetter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).BeginInit();
            this.SuspendLayout();
            // 
            // grdJobCorrespondenceLetter
            // 
            this.grdJobCorrespondenceLetter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobCorrespondenceLetter.EmbeddedNavigator.Name = "";
            this.grdJobCorrespondenceLetter.Location = new System.Drawing.Point(0, 23);
            this.grdJobCorrespondenceLetter.MainView = this.grdJobCorrespondenceLetterView;
            this.grdJobCorrespondenceLetter.Name = "grdJobCorrespondenceLetter";
            this.grdJobCorrespondenceLetter.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkSelectedItem,
            this.txtUserDescription,
            this.txtMaterialCost,
            this.txtLaborCost,
            this.txtOtherCost,
            this.txtQuantity,
            this.txtHours,
            this.cboUnit,
            this.txtUserDescription1});
            this.grdJobCorrespondenceLetter.Size = new System.Drawing.Size(974, 528);
            this.grdJobCorrespondenceLetter.TabIndex = 457;
            this.grdJobCorrespondenceLetter.ToolTipController = this.toolTipController1;
            this.grdJobCorrespondenceLetter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdJobCorrespondenceLetterView,
            this.grdSubmittalDetailView});
            // 
            // grdJobCorrespondenceLetterView
            // 
            this.grdJobCorrespondenceLetterView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdJobCorrespondenceLetterView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobCorrespondenceLetterView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdJobCorrespondenceLetterView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdJobCorrespondenceLetterView.GridControl = this.grdJobCorrespondenceLetter;
            this.grdJobCorrespondenceLetterView.Name = "grdJobCorrespondenceLetterView";
            this.grdJobCorrespondenceLetterView.OptionsBehavior.Editable = false;
            this.grdJobCorrespondenceLetterView.OptionsCustomization.AllowGroup = false;
            this.grdJobCorrespondenceLetterView.OptionsMenu.EnableColumnMenu = false;
            this.grdJobCorrespondenceLetterView.OptionsMenu.EnableFooterMenu = false;
            this.grdJobCorrespondenceLetterView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdJobCorrespondenceLetterView.OptionsView.ColumnAutoWidth = false;
            this.grdJobCorrespondenceLetterView.OptionsView.ShowFooter = true;
            this.grdJobCorrespondenceLetterView.OptionsView.ShowGroupPanel = false;
            this.grdJobCorrespondenceLetterView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdJobCorrespondenceLetterView_FocusedRowChanged);
            this.grdJobCorrespondenceLetterView.DoubleClick += new System.EventHandler(this.grdJobCorrespondenceLetterView_DoubleClick);
            this.grdJobCorrespondenceLetterView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdJobCorrespondenceLetterView_MouseUp);
            this.grdJobCorrespondenceLetterView.ColumnFilterChanged += new System.EventHandler(this.grdJobCorrespondenceLetterView_ColumnFilterChanged);
            // 
            // chkSelectedItem
            // 
            this.chkSelectedItem.AutoHeight = false;
            this.chkSelectedItem.Name = "chkSelectedItem";
            // 
            // txtUserDescription
            // 
            this.txtUserDescription.AutoHeight = false;
            this.txtUserDescription.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtUserDescription.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtUserDescription.MaxLength = 128;
            this.txtUserDescription.Name = "txtUserDescription";
            // 
            // txtMaterialCost
            // 
            this.txtMaterialCost.AutoHeight = false;
            this.txtMaterialCost.DisplayFormat.FormatString = "c2";
            this.txtMaterialCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMaterialCost.EditFormat.FormatString = "c2";
            this.txtMaterialCost.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMaterialCost.Mask.EditMask = "c2";
            this.txtMaterialCost.Mask.UseMaskAsDisplayFormat = true;
            this.txtMaterialCost.Name = "txtMaterialCost";
            // 
            // txtLaborCost
            // 
            this.txtLaborCost.AutoHeight = false;
            this.txtLaborCost.DisplayFormat.FormatString = "c2";
            this.txtLaborCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLaborCost.EditFormat.FormatString = "c2";
            this.txtLaborCost.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLaborCost.Mask.EditMask = "c2";
            this.txtLaborCost.Name = "txtLaborCost";
            // 
            // txtOtherCost
            // 
            this.txtOtherCost.AutoHeight = false;
            this.txtOtherCost.DisplayFormat.FormatString = "c2";
            this.txtOtherCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOtherCost.EditFormat.FormatString = "c2";
            this.txtOtherCost.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOtherCost.Mask.EditMask = "c2";
            this.txtOtherCost.Name = "txtOtherCost";
            // 
            // txtQuantity
            // 
            this.txtQuantity.AutoHeight = false;
            this.txtQuantity.DisplayFormat.FormatString = "n0";
            this.txtQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.EditFormat.FormatString = "n0";
            this.txtQuantity.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.Mask.EditMask = "n0";
            this.txtQuantity.Name = "txtQuantity";
            // 
            // txtHours
            // 
            this.txtHours.AutoHeight = false;
            this.txtHours.DisplayFormat.FormatString = "n0";
            this.txtHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHours.EditFormat.FormatString = "n0";
            this.txtHours.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHours.Mask.EditMask = "n0";
            this.txtHours.Name = "txtHours";
            // 
            // cboUnit
            // 
            this.cboUnit.AutoHeight = false;
            this.cboUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUnit.Items.AddRange(new object[] {
            "C",
            "E",
            "H",
            "M"});
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.cboUnit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // txtUserDescription1
            // 
            this.txtUserDescription1.AutoHeight = false;
            this.txtUserDescription1.MaxLength = 100;
            this.txtUserDescription1.Name = "txtUserDescription1";
            // 
            // panJobCorrespondenceLetter
            // 
            this.panJobCorrespondenceLetter.Controls.Add(this.hyperLinkEdit1);
            this.panJobCorrespondenceLetter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panJobCorrespondenceLetter.Location = new System.Drawing.Point(0, 0);
            this.panJobCorrespondenceLetter.Name = "panJobCorrespondenceLetter";
            this.panJobCorrespondenceLetter.Size = new System.Drawing.Size(974, 23);
            this.toolTipController1.SetSuperTip(this.panJobCorrespondenceLetter, null);
            this.panJobCorrespondenceLetter.TabIndex = 455;
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "New Letter...";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(5, 3);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(172, 18);
            this.hyperLinkEdit1.TabIndex = 8;
            this.hyperLinkEdit1.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // grdSubmittalDetailView
            // 
            this.grdSubmittalDetailView.GridControl = this.grdJobCorrespondenceLetter;
            this.grdSubmittalDetailView.Name = "grdSubmittalDetailView";
            // 
            // ctlJobCorrespondenceLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdJobCorrespondenceLetter);
            this.Controls.Add(this.panJobCorrespondenceLetter);
            this.Name = "ctlJobCorrespondenceLetter";
            this.Size = new System.Drawing.Size(974, 551);
            this.toolTipController1.SetSuperTip(this, null);
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCorrespondenceLetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCorrespondenceLetterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panJobCorrespondenceLetter)).EndInit();
            this.panJobCorrespondenceLetter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.PanelControl panJobCorrespondenceLetter;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
        private DevExpress.XtraGrid.GridControl grdJobCorrespondenceLetter;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobCorrespondenceLetterView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkSelectedItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit txtUserDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtMaterialCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtLaborCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtOtherCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtHours;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboUnit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtUserDescription1;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSubmittalDetailView;
    }
}
