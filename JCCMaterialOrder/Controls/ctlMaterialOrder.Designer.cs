namespace JCCMaterialOrder.Controls
{
    partial class ctlMaterialOrder
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
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;

                     Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobMaterialOrderView, "ctlMaterialOrder");
  

                }
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
            this.grdJobMaterialOrder = new DevExpress.XtraGrid.GridControl();
            this.grdJobMaterialOrderView = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.grdSubmittalDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panJobMaterialOrder = new DevExpress.XtraEditors.PanelControl();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.txtItemDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtOrderDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobMaterialOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobMaterialOrderView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panJobMaterialOrder)).BeginInit();
            this.panJobMaterialOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdJobMaterialOrder
            // 
            this.grdJobMaterialOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobMaterialOrder.Location = new System.Drawing.Point(0, 23);
            this.grdJobMaterialOrder.MainView = this.grdJobMaterialOrderView;
            this.grdJobMaterialOrder.Name = "grdJobMaterialOrder";
            this.grdJobMaterialOrder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkSelectedItem,
            this.txtUserDescription,
            this.txtMaterialCost,
            this.txtLaborCost,
            this.txtOtherCost,
            this.txtQuantity,
            this.txtHours,
            this.cboUnit,
            this.txtUserDescription1});
            this.grdJobMaterialOrder.Size = new System.Drawing.Size(974, 528);
            this.grdJobMaterialOrder.TabIndex = 457;
            this.grdJobMaterialOrder.ToolTipController = this.toolTipController1;
            this.grdJobMaterialOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdJobMaterialOrderView,
            this.grdSubmittalDetailView});
            // 
            // grdJobMaterialOrderView
            // 
            this.grdJobMaterialOrderView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdJobMaterialOrderView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobMaterialOrderView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdJobMaterialOrderView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdJobMaterialOrderView.GridControl = this.grdJobMaterialOrder;
            this.grdJobMaterialOrderView.Name = "grdJobMaterialOrderView";
            this.grdJobMaterialOrderView.OptionsBehavior.Editable = false;
            this.grdJobMaterialOrderView.OptionsCustomization.AllowGroup = false;
            this.grdJobMaterialOrderView.OptionsMenu.EnableColumnMenu = false;
            this.grdJobMaterialOrderView.OptionsMenu.EnableFooterMenu = false;
            this.grdJobMaterialOrderView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdJobMaterialOrderView.OptionsView.ColumnAutoWidth = false;
            this.grdJobMaterialOrderView.OptionsView.ShowFooter = true;
            this.grdJobMaterialOrderView.OptionsView.ShowGroupPanel = false;
            this.grdJobMaterialOrderView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdMaterialOrderView_FocusedRowChanged);
            this.grdJobMaterialOrderView.DoubleClick += new System.EventHandler(this.grdMaterialOrderView_DoubleClick);
            this.grdJobMaterialOrderView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdMaterialOrderView_MouseUp);
            this.grdJobMaterialOrderView.ColumnFilterChanged += new System.EventHandler(this.grdMaterialOrderView_ColumnFilterChanged);
            this.grdJobMaterialOrderView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdJobMaterialOrderView_ColumnWidthChanged);
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
            // grdSubmittalDetailView
            // 
            this.grdSubmittalDetailView.GridControl = this.grdJobMaterialOrder;
            this.grdSubmittalDetailView.Name = "grdSubmittalDetailView";
            // 
            // panJobMaterialOrder
            // 
            this.panJobMaterialOrder.Controls.Add(this.btnProcess);
            this.panJobMaterialOrder.Controls.Add(this.txtItemDescription);
            this.panJobMaterialOrder.Controls.Add(this.txtOrderDescription);
            this.panJobMaterialOrder.Controls.Add(this.labelControl1);
            this.panJobMaterialOrder.Controls.Add(this.labelControl18);
            this.panJobMaterialOrder.Controls.Add(this.hyperLinkEdit1);
            this.panJobMaterialOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panJobMaterialOrder.Location = new System.Drawing.Point(0, 0);
            this.panJobMaterialOrder.Name = "panJobMaterialOrder";
            this.panJobMaterialOrder.Size = new System.Drawing.Size(974, 23);
            this.panJobMaterialOrder.TabIndex = 455;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(766, 4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(55, 20);
            this.btnProcess.TabIndex = 13;
            this.btnProcess.Text = "&Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.Location = new System.Drawing.Point(523, 1);
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.Properties.MaxLength = 100;
            this.txtItemDescription.Size = new System.Drawing.Size(201, 20);
            this.txtItemDescription.TabIndex = 12;
            // 
            // txtOrderDescription
            // 
            this.txtOrderDescription.Location = new System.Drawing.Point(246, 3);
            this.txtOrderDescription.Name = "txtOrderDescription";
            this.txtOrderDescription.Properties.MaxLength = 100;
            this.txtOrderDescription.Size = new System.Drawing.Size(201, 20);
            this.txtOrderDescription.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(453, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Item Desc.:";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Location = new System.Drawing.Point(172, 4);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(68, 13);
            this.labelControl18.TabIndex = 9;
            this.labelControl18.Text = "Order Desc.:";
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "New Material Order...";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(5, 3);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(172, 18);
            this.hyperLinkEdit1.TabIndex = 8;
            this.hyperLinkEdit1.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // ctlMaterialOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdJobMaterialOrder);
            this.Controls.Add(this.panJobMaterialOrder);
            this.Name = "ctlMaterialOrder";
            this.Size = new System.Drawing.Size(974, 551);
            ((System.ComponentModel.ISupportInitialize)(this.grdJobMaterialOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobMaterialOrderView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panJobMaterialOrder)).EndInit();
            this.panJobMaterialOrder.ResumeLayout(false);
            this.panJobMaterialOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.PanelControl panJobMaterialOrder;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
        private DevExpress.XtraGrid.GridControl grdJobMaterialOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobMaterialOrderView;
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
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit txtItemDescription;
        private DevExpress.XtraEditors.TextEdit txtOrderDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
    }
}
