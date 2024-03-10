namespace JCCContactManagement.Controls
{
    partial class ctlCompanyContacts
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
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grdDataView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repPurchaseCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControlNewTool = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPurchaseCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlNewTool)).BeginInit();
            this.panelControlNewTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.EmbeddedNavigator.Name = "";
            this.grdData.Location = new System.Drawing.Point(0, 27);
            this.grdData.MainView = this.grdDataView;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repPurchaseCost});
            this.grdData.Size = new System.Drawing.Size(720, 536);
            this.grdData.TabIndex = 450;
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
            this.grdDataView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdDataView_MouseUp);
            this.grdDataView.ColumnFilterChanged += new System.EventHandler(this.grdDataView_ColumnFilterChanged);
            // 
            // repPurchaseCost
            // 
            this.repPurchaseCost.AutoHeight = false;
            this.repPurchaseCost.DisplayFormat.FormatString = "c2";
            this.repPurchaseCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repPurchaseCost.EditFormat.FormatString = "c2";
            this.repPurchaseCost.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repPurchaseCost.Mask.EditMask = "c2";
            this.repPurchaseCost.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repPurchaseCost.Mask.UseMaskAsDisplayFormat = true;
            this.repPurchaseCost.MaxLength = 20;
            this.repPurchaseCost.Name = "repPurchaseCost";
            // 
            // panelControlNewTool
            // 
            this.panelControlNewTool.Controls.Add(this.hyperLinkEdit1);
            this.panelControlNewTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlNewTool.Location = new System.Drawing.Point(0, 0);
            this.panelControlNewTool.Name = "panelControlNewTool";
            this.panelControlNewTool.Size = new System.Drawing.Size(720, 27);
            this.panelControlNewTool.TabIndex = 451;
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "New Contact ...";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(7, 4);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(92, 18);
            this.hyperLinkEdit1.TabIndex = 3;
            this.hyperLinkEdit1.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // ctlCompanyContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.panelControlNewTool);
            this.Name = "ctlCompanyContacts";
            this.Size = new System.Drawing.Size(720, 563);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPurchaseCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlNewTool)).EndInit();
            this.panelControlNewTool.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDataView;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repPurchaseCost;
        private DevExpress.XtraEditors.PanelControl panelControlNewTool;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;

    }
}
