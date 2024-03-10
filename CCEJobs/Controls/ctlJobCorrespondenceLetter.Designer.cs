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
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobCorrespondenceLetterView, "ctlJobCorrespondenceLetter");
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
            this.grdJobCorrespondenceLetter = new DevExpress.XtraGrid.GridControl();
            this.grdJobCorrespondenceLetterView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repCorrespondenceLetterNote = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.repCostImpact = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.grdSubmittalDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panJobCorrespondenceLetter = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCorrespondenceLetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCorrespondenceLetterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCorrespondenceLetterNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCostImpact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panJobCorrespondenceLetter)).BeginInit();
            this.panJobCorrespondenceLetter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdJobCorrespondenceLetter
            // 
            this.grdJobCorrespondenceLetter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobCorrespondenceLetter.Location = new System.Drawing.Point(0, 23);
            this.grdJobCorrespondenceLetter.MainView = this.grdJobCorrespondenceLetterView;
            this.grdJobCorrespondenceLetter.Name = "grdJobCorrespondenceLetter";
            this.grdJobCorrespondenceLetter.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCorrespondenceLetterNote,
            this.repCostImpact});
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
            this.grdJobCorrespondenceLetterView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdJobCorrespondenceLetterView_KeyDown);
            this.grdJobCorrespondenceLetterView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdJobCorrespondenceLetterView_MouseUp);
            this.grdJobCorrespondenceLetterView.ColumnFilterChanged += new System.EventHandler(this.grdJobCorrespondenceLetterView_ColumnFilterChanged);
            this.grdJobCorrespondenceLetterView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdJobCorrespondenceLetterView_ColumnWidthChanged);
            // 
            // repCorrespondenceLetterNote
            // 
            this.repCorrespondenceLetterNote.Name = "repCorrespondenceLetterNote";
            // 
            // repCostImpact
            // 
            this.repCostImpact.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "No"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Free Format")});
            this.repCostImpact.Name = "repCostImpact";
            // 
            // grdSubmittalDetailView
            // 
            this.grdSubmittalDetailView.GridControl = this.grdJobCorrespondenceLetter;
            this.grdSubmittalDetailView.Name = "grdSubmittalDetailView";
            // 
            // panJobCorrespondenceLetter
            // 
            this.panJobCorrespondenceLetter.Controls.Add(this.hyperLinkEdit1);
            this.panJobCorrespondenceLetter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panJobCorrespondenceLetter.Location = new System.Drawing.Point(0, 0);
            this.panJobCorrespondenceLetter.Name = "panJobCorrespondenceLetter";
            this.panJobCorrespondenceLetter.Size = new System.Drawing.Size(974, 23);
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
            // ctlJobCorrespondenceLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdJobCorrespondenceLetter);
            this.Controls.Add(this.panJobCorrespondenceLetter);
            this.Name = "ctlJobCorrespondenceLetter";
            this.Size = new System.Drawing.Size(974, 551);
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCorrespondenceLetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCorrespondenceLetterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCorrespondenceLetterNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCostImpact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panJobCorrespondenceLetter)).EndInit();
            this.panJobCorrespondenceLetter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.PanelControl panJobCorrespondenceLetter;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
        private DevExpress.XtraGrid.GridControl grdJobCorrespondenceLetter;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobCorrespondenceLetterView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSubmittalDetailView;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repCorrespondenceLetterNote;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repCostImpact;
    }
}
