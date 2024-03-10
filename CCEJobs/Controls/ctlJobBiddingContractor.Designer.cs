namespace CCEJobs.Controls
{
    partial class ctlJobBiddingContractor
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
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobBiddingContractorView, "ctlJobBiddingContractor");
            }
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
            this.grdJobBiddingContractor = new DevExpress.XtraGrid.GridControl();
            this.grdJobBiddingContractorView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repStatus = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repEstimator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repContractor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.grdSubmittalDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobBiddingContractor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobBiddingContractorView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEstimator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repContractor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).BeginInit();
            this.SuspendLayout();
            // 
            // grdJobBiddingContractor
            // 
            this.grdJobBiddingContractor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobBiddingContractor.Location = new System.Drawing.Point(0, 0);
            this.grdJobBiddingContractor.MainView = this.grdJobBiddingContractorView;
            this.grdJobBiddingContractor.Name = "grdJobBiddingContractor";
            this.grdJobBiddingContractor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repStatus,
            this.repEstimator,
            this.repContractor,
            this.repAmount});
            this.grdJobBiddingContractor.Size = new System.Drawing.Size(974, 551);
            this.grdJobBiddingContractor.TabIndex = 457;
            this.grdJobBiddingContractor.ToolTipController = this.toolTipController1;
            this.grdJobBiddingContractor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdJobBiddingContractorView,
            this.grdSubmittalDetailView});
            // 
            // grdJobBiddingContractorView
            // 
            this.grdJobBiddingContractorView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdJobBiddingContractorView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobBiddingContractorView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdJobBiddingContractorView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdJobBiddingContractorView.GridControl = this.grdJobBiddingContractor;
            this.grdJobBiddingContractorView.Name = "grdJobBiddingContractorView";
            this.grdJobBiddingContractorView.OptionsBehavior.Editable = false;
            this.grdJobBiddingContractorView.OptionsCustomization.AllowGroup = false;
            this.grdJobBiddingContractorView.OptionsMenu.EnableColumnMenu = false;
            this.grdJobBiddingContractorView.OptionsMenu.EnableFooterMenu = false;
            this.grdJobBiddingContractorView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdJobBiddingContractorView.OptionsView.ColumnAutoWidth = false;
            this.grdJobBiddingContractorView.OptionsView.ShowFooter = true;
            this.grdJobBiddingContractorView.OptionsView.ShowGroupPanel = false;
            this.grdJobBiddingContractorView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdJobBiddingContractorView_InvalidRowException);
            this.grdJobBiddingContractorView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdJobBiddingContractorView_KeyUp);
            this.grdJobBiddingContractorView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdJobBiddingContractorView_ColumnWidthChanged);
            this.grdJobBiddingContractorView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdJobBiddingContractorView_ValidateRow);
            // 
            // repStatus
            // 
            this.repStatus.AutoHeight = false;
            this.repStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repStatus.Items.AddRange(new object[] {
            "WON",
            "LOST"});
            this.repStatus.Name = "repStatus";
            this.repStatus.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repEstimator
            // 
            this.repEstimator.AutoHeight = false;
            this.repEstimator.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repEstimator.Name = "repEstimator";
            this.repEstimator.NullText = "";
            // 
            // repContractor
            // 
            this.repContractor.AutoHeight = false;
            this.repContractor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repContractor.Name = "repContractor";
            this.repContractor.NullText = "";
            // 
            // repAmount
            // 
            this.repAmount.AutoHeight = false;
            this.repAmount.Mask.EditMask = "c2";
            this.repAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repAmount.Mask.UseMaskAsDisplayFormat = true;
            this.repAmount.Name = "repAmount";
            // 
            // grdSubmittalDetailView
            // 
            this.grdSubmittalDetailView.GridControl = this.grdJobBiddingContractor;
            this.grdSubmittalDetailView.Name = "grdSubmittalDetailView";
            // 
            // ctlJobBiddingContractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdJobBiddingContractor);
            this.Name = "ctlJobBiddingContractor";
            this.Size = new System.Drawing.Size(974, 551);
            ((System.ComponentModel.ISupportInitialize)(this.grdJobBiddingContractor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobBiddingContractorView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEstimator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repContractor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraGrid.GridControl grdJobBiddingContractor;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobBiddingContractorView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSubmittalDetailView;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repEstimator;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repContractor;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repAmount;
    }
}
