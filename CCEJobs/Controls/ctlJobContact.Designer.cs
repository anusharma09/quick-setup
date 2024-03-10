namespace CCEJobs.Controls
{
    partial class ctlJobContact
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdContactView, "ctlJobContact");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlJobContact));
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panSelect = new DevExpress.XtraEditors.PanelControl();
            this.grdContact = new DevExpress.XtraGrid.GridControl();
            this.grdContactView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkSelectedItem = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtUserDescription = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.txtMaterialCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtLaborCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtOtherCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtHours = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cboUnit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.txtUserDescription1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panContact = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboLastName = new DevExpress.XtraEditors.LookUpEdit();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.cboCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.chkSelected = new DevExpress.XtraEditors.CheckEdit();
            this.btuUpdateCostCodes = new DevExpress.XtraEditors.SimpleButton();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.xtraScrollableControl2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.txtOfficeFAXPhoneNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtOfficePhoneNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtOfficeCountry = new DevExpress.XtraEditors.TextEdit();
            this.txtOfficeZIP = new DevExpress.XtraEditors.TextEdit();
            this.txtOfficeState = new DevExpress.XtraEditors.TextEdit();
            this.txtOfficeCity = new DevExpress.XtraEditors.TextEdit();
            this.txtOfficeStreetAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.txtHomeFAXPhoneNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtCountry = new DevExpress.XtraEditors.TextEdit();
            this.txtZip = new DevExpress.XtraEditors.TextEdit();
            this.txtState = new DevExpress.XtraEditors.TextEdit();
            this.txtCity = new DevExpress.XtraEditors.TextEdit();
            this.txtHomeAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtCellPhoneNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtPhoneNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtCategories = new DevExpress.XtraEditors.TextEdit();
            this.txtCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.txtWebSite = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panSelect)).BeginInit();
            this.panSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContactView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panContact)).BeginInit();
            this.panContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelected.Properties)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            this.xtraScrollableControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeFAXPhoneNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficePhoneNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeZIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeStreetAddress.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHomeFAXPhoneNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHomeAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCellPhoneNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategories.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebSite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panSelect);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraScrollableControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(974, 551);
            this.splitContainerControl1.SplitterPosition = 224;
            this.splitContainerControl1.TabIndex = 13;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panSelect
            // 
            this.panSelect.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panSelect.Controls.Add(this.grdContact);
            this.panSelect.Controls.Add(this.panContact);
            this.panSelect.Controls.Add(this.btuUpdateCostCodes);
            this.panSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSelect.Location = new System.Drawing.Point(0, 0);
            this.panSelect.Name = "panSelect";
            this.panSelect.Size = new System.Drawing.Size(970, 220);
            this.panSelect.TabIndex = 12;
            // 
            // grdContact
            // 
            this.grdContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContact.Location = new System.Drawing.Point(0, 23);
            this.grdContact.MainView = this.grdContactView;
            this.grdContact.Name = "grdContact";
            this.grdContact.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkSelectedItem,
            this.txtUserDescription,
            this.txtMaterialCost,
            this.txtLaborCost,
            this.txtOtherCost,
            this.txtQuantity,
            this.txtHours,
            this.cboUnit,
            this.txtUserDescription1});
            this.grdContact.Size = new System.Drawing.Size(970, 197);
            this.grdContact.TabIndex = 456;
            this.grdContact.ToolTipController = this.toolTipController1;
            this.grdContact.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdContactView});
            // 
            // grdContactView
            // 
            this.grdContactView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdContactView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdContactView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdContactView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdContactView.GridControl = this.grdContact;
            this.grdContactView.Name = "grdContactView";
            this.grdContactView.OptionsCustomization.AllowFilter = false;
            this.grdContactView.OptionsCustomization.AllowGroup = false;
            this.grdContactView.OptionsMenu.EnableColumnMenu = false;
            this.grdContactView.OptionsMenu.EnableFooterMenu = false;
            this.grdContactView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdContactView.OptionsView.ColumnAutoWidth = false;
            this.grdContactView.OptionsView.ShowGroupPanel = false;
            this.grdContactView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridContactView_FocusedRowChanged);
            this.grdContactView.DoubleClick += new System.EventHandler(this.grdContactView_DoubleClick);
            this.grdContactView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdContactView_InvalidRowException);
            this.grdContactView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdContactView_ColumnWidthChanged);
            this.grdContactView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdContactView_ValidateRow);
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
            // panContact
            // 
            this.panContact.Controls.Add(this.hyperLinkEdit1);
            this.panContact.Controls.Add(this.labelControl1);
            this.panContact.Controls.Add(this.cboLastName);
            this.panContact.Controls.Add(this.btnProcess);
            this.panContact.Controls.Add(this.labelControl18);
            this.panContact.Controls.Add(this.cboCompany);
            this.panContact.Controls.Add(this.chkSelected);
            this.panContact.Dock = System.Windows.Forms.DockStyle.Top;
            this.panContact.Location = new System.Drawing.Point(0, 0);
            this.panContact.Name = "panContact";
            this.panContact.Size = new System.Drawing.Size(970, 23);
            this.panContact.TabIndex = 455;
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "New Contact ...";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(706, 3);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(93, 18);
            this.hyperLinkEdit1.TabIndex = 8;
            this.hyperLinkEdit1.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(412, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Last Name:";
            // 
            // cboLastName
            // 
            this.cboLastName.Location = new System.Drawing.Point(480, 0);
            this.cboLastName.Name = "cboLastName";
            this.cboLastName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLastName.Properties.NullText = "";
            this.cboLastName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboLastName.Size = new System.Drawing.Size(136, 20);
            this.cboLastName.TabIndex = 6;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(622, 0);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(55, 20);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "&Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Location = new System.Drawing.Point(118, 4);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(56, 13);
            this.labelControl18.TabIndex = 4;
            this.labelControl18.Text = "Company:";
            // 
            // cboCompany
            // 
            this.cboCompany.Location = new System.Drawing.Point(180, 0);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCompany.Properties.NullText = "";
            this.cboCompany.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboCompany.Size = new System.Drawing.Size(226, 20);
            this.cboCompany.TabIndex = 3;
            // 
            // chkSelected
            // 
            this.chkSelected.Location = new System.Drawing.Point(5, 0);
            this.chkSelected.Name = "chkSelected";
            this.chkSelected.Properties.Caption = "Selected Contacts";
            this.chkSelected.Size = new System.Drawing.Size(169, 19);
            this.chkSelected.TabIndex = 0;
            this.chkSelected.CheckedChanged += new System.EventHandler(this.chkSelected_CheckedChanged);
            // 
            // btuUpdateCostCodes
            // 
            this.btuUpdateCostCodes.Enabled = false;
            this.btuUpdateCostCodes.Image = ((System.Drawing.Image)(resources.GetObject("btuUpdateCostCodes.Image")));
            this.btuUpdateCostCodes.Location = new System.Drawing.Point(160, 230);
            this.btuUpdateCostCodes.Name = "btuUpdateCostCodes";
            this.btuUpdateCostCodes.Size = new System.Drawing.Size(0, 0);
            this.btuUpdateCostCodes.TabIndex = 454;
            this.btuUpdateCostCodes.Text = "Save";
            this.btuUpdateCostCodes.ToolTip = "Save Changed Items";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraScrollableControl1.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControl1.Controls.Add(this.xtraScrollableControl2);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(970, 317);
            this.xtraScrollableControl1.TabIndex = 19;
            // 
            // xtraScrollableControl2
            // 
            this.xtraScrollableControl2.Controls.Add(this.xtraTabControl1);
            this.xtraScrollableControl2.Controls.Add(this.panelControl1);
            this.xtraScrollableControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl2.Name = "xtraScrollableControl2";
            this.xtraScrollableControl2.Size = new System.Drawing.Size(970, 317);
            this.xtraScrollableControl2.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 123);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(970, 193);
            this.xtraTabControl1.TabIndex = 26;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.labelControl24);
            this.xtraTabPage1.Controls.Add(this.txtOfficeFAXPhoneNumber);
            this.xtraTabPage1.Controls.Add(this.txtOfficePhoneNumber);
            this.xtraTabPage1.Controls.Add(this.txtOfficeCountry);
            this.xtraTabPage1.Controls.Add(this.txtOfficeZIP);
            this.xtraTabPage1.Controls.Add(this.txtOfficeState);
            this.xtraTabPage1.Controls.Add(this.txtOfficeCity);
            this.xtraTabPage1.Controls.Add(this.txtOfficeStreetAddress);
            this.xtraTabPage1.Controls.Add(this.labelControl14);
            this.xtraTabPage1.Controls.Add(this.labelControl15);
            this.xtraTabPage1.Controls.Add(this.labelControl16);
            this.xtraTabPage1.Controls.Add(this.labelControl17);
            this.xtraTabPage1.Controls.Add(this.labelControl19);
            this.xtraTabPage1.Controls.Add(this.labelControl20);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(961, 162);
            this.xtraTabPage1.Text = "Business";
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(20, 138);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(56, 13);
            this.labelControl24.TabIndex = 48;
            this.labelControl24.Text = "Phone/Fax:";
            // 
            // txtOfficeFAXPhoneNumber
            // 
            this.txtOfficeFAXPhoneNumber.Location = new System.Drawing.Point(106, 131);
            this.txtOfficeFAXPhoneNumber.Name = "txtOfficeFAXPhoneNumber";
            this.txtOfficeFAXPhoneNumber.Properties.ReadOnly = true;
            this.txtOfficeFAXPhoneNumber.Size = new System.Drawing.Size(525, 20);
            this.txtOfficeFAXPhoneNumber.TabIndex = 47;
            // 
            // txtOfficePhoneNumber
            // 
            this.txtOfficePhoneNumber.Location = new System.Drawing.Point(106, 115);
            this.txtOfficePhoneNumber.Name = "txtOfficePhoneNumber";
            this.txtOfficePhoneNumber.Properties.ReadOnly = true;
            this.txtOfficePhoneNumber.Size = new System.Drawing.Size(525, 20);
            this.txtOfficePhoneNumber.TabIndex = 46;
            // 
            // txtOfficeCountry
            // 
            this.txtOfficeCountry.Location = new System.Drawing.Point(106, 96);
            this.txtOfficeCountry.Name = "txtOfficeCountry";
            this.txtOfficeCountry.Properties.ReadOnly = true;
            this.txtOfficeCountry.Size = new System.Drawing.Size(525, 20);
            this.txtOfficeCountry.TabIndex = 45;
            // 
            // txtOfficeZIP
            // 
            this.txtOfficeZIP.Location = new System.Drawing.Point(106, 77);
            this.txtOfficeZIP.Name = "txtOfficeZIP";
            this.txtOfficeZIP.Properties.ReadOnly = true;
            this.txtOfficeZIP.Size = new System.Drawing.Size(525, 20);
            this.txtOfficeZIP.TabIndex = 44;
            // 
            // txtOfficeState
            // 
            this.txtOfficeState.Location = new System.Drawing.Point(106, 58);
            this.txtOfficeState.Name = "txtOfficeState";
            this.txtOfficeState.Properties.ReadOnly = true;
            this.txtOfficeState.Size = new System.Drawing.Size(525, 20);
            this.txtOfficeState.TabIndex = 43;
            // 
            // txtOfficeCity
            // 
            this.txtOfficeCity.Location = new System.Drawing.Point(106, 39);
            this.txtOfficeCity.Name = "txtOfficeCity";
            this.txtOfficeCity.Properties.ReadOnly = true;
            this.txtOfficeCity.Size = new System.Drawing.Size(525, 20);
            this.txtOfficeCity.TabIndex = 42;
            // 
            // txtOfficeStreetAddress
            // 
            this.txtOfficeStreetAddress.Location = new System.Drawing.Point(106, 20);
            this.txtOfficeStreetAddress.Name = "txtOfficeStreetAddress";
            this.txtOfficeStreetAddress.Properties.ReadOnly = true;
            this.txtOfficeStreetAddress.Size = new System.Drawing.Size(525, 20);
            this.txtOfficeStreetAddress.TabIndex = 41;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(20, 118);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(30, 13);
            this.labelControl14.TabIndex = 40;
            this.labelControl14.Text = "Phone";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(20, 99);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(43, 13);
            this.labelControl15.TabIndex = 39;
            this.labelControl15.Text = "Country:";
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(20, 80);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(18, 13);
            this.labelControl16.TabIndex = 38;
            this.labelControl16.Text = "Zip:";
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(20, 61);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(30, 13);
            this.labelControl17.TabIndex = 37;
            this.labelControl17.Text = "State:";
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(20, 42);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(23, 13);
            this.labelControl19.TabIndex = 36;
            this.labelControl19.Text = "City:";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(20, 23);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(43, 13);
            this.labelControl20.TabIndex = 35;
            this.labelControl20.Text = "Address:";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.txtHomeFAXPhoneNumber);
            this.xtraTabPage2.Controls.Add(this.txtCountry);
            this.xtraTabPage2.Controls.Add(this.txtZip);
            this.xtraTabPage2.Controls.Add(this.txtState);
            this.xtraTabPage2.Controls.Add(this.txtCity);
            this.xtraTabPage2.Controls.Add(this.txtHomeAddress);
            this.xtraTabPage2.Controls.Add(this.labelControl13);
            this.xtraTabPage2.Controls.Add(this.labelControl12);
            this.xtraTabPage2.Controls.Add(this.labelControl11);
            this.xtraTabPage2.Controls.Add(this.labelControl10);
            this.xtraTabPage2.Controls.Add(this.labelControl9);
            this.xtraTabPage2.Controls.Add(this.labelControl8);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(961, 162);
            this.xtraTabPage2.Text = "Home";
            // 
            // txtHomeFAXPhoneNumber
            // 
            this.txtHomeFAXPhoneNumber.Location = new System.Drawing.Point(106, 117);
            this.txtHomeFAXPhoneNumber.Name = "txtHomeFAXPhoneNumber";
            this.txtHomeFAXPhoneNumber.Properties.ReadOnly = true;
            this.txtHomeFAXPhoneNumber.Size = new System.Drawing.Size(525, 20);
            this.txtHomeFAXPhoneNumber.TabIndex = 34;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(106, 98);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Properties.ReadOnly = true;
            this.txtCountry.Size = new System.Drawing.Size(525, 20);
            this.txtCountry.TabIndex = 33;
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(106, 79);
            this.txtZip.Name = "txtZip";
            this.txtZip.Properties.ReadOnly = true;
            this.txtZip.Size = new System.Drawing.Size(525, 20);
            this.txtZip.TabIndex = 32;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(106, 60);
            this.txtState.Name = "txtState";
            this.txtState.Properties.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(525, 20);
            this.txtState.TabIndex = 31;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(106, 41);
            this.txtCity.Name = "txtCity";
            this.txtCity.Properties.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(525, 20);
            this.txtCity.TabIndex = 30;
            // 
            // txtHomeAddress
            // 
            this.txtHomeAddress.Location = new System.Drawing.Point(106, 22);
            this.txtHomeAddress.Name = "txtHomeAddress";
            this.txtHomeAddress.Properties.ReadOnly = true;
            this.txtHomeAddress.Size = new System.Drawing.Size(525, 20);
            this.txtHomeAddress.TabIndex = 29;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(20, 120);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(56, 13);
            this.labelControl13.TabIndex = 28;
            this.labelControl13.Text = "Phone/Fax:";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(20, 101);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(43, 13);
            this.labelControl12.TabIndex = 27;
            this.labelControl12.Text = "Country:";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(20, 82);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(18, 13);
            this.labelControl11.TabIndex = 26;
            this.labelControl11.Text = "Zip:";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(20, 63);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(30, 13);
            this.labelControl10.TabIndex = 25;
            this.labelControl10.Text = "State:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(20, 44);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(23, 13);
            this.labelControl9.TabIndex = 24;
            this.labelControl9.Text = "City:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(20, 25);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(43, 13);
            this.labelControl8.TabIndex = 23;
            this.labelControl8.Text = "Address:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtCellPhoneNumber);
            this.panelControl1.Controls.Add(this.txtPhoneNumber);
            this.panelControl1.Controls.Add(this.txtCategories);
            this.panelControl1.Controls.Add(this.txtCompanyName);
            this.panelControl1.Controls.Add(this.txtWebSite);
            this.panelControl1.Controls.Add(this.txtEmail);
            this.panelControl1.Controls.Add(this.txtTitle);
            this.panelControl1.Controls.Add(this.txtLastName);
            this.panelControl1.Controls.Add(this.txtFirstName);
            this.panelControl1.Controls.Add(this.labelControl23);
            this.panelControl1.Controls.Add(this.labelControl22);
            this.panelControl1.Controls.Add(this.labelControl21);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(970, 123);
            this.panelControl1.TabIndex = 25;
            // 
            // txtCellPhoneNumber
            // 
            this.txtCellPhoneNumber.Location = new System.Drawing.Point(570, 68);
            this.txtCellPhoneNumber.Name = "txtCellPhoneNumber";
            this.txtCellPhoneNumber.Properties.ReadOnly = true;
            this.txtCellPhoneNumber.Size = new System.Drawing.Size(354, 20);
            this.txtCellPhoneNumber.TabIndex = 50;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(570, 49);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Properties.ReadOnly = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(354, 20);
            this.txtPhoneNumber.TabIndex = 49;
            // 
            // txtCategories
            // 
            this.txtCategories.Location = new System.Drawing.Point(570, 30);
            this.txtCategories.Name = "txtCategories";
            this.txtCategories.Properties.ReadOnly = true;
            this.txtCategories.Size = new System.Drawing.Size(354, 20);
            this.txtCategories.TabIndex = 48;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(570, 11);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Properties.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(354, 20);
            this.txtCompanyName.TabIndex = 47;
            // 
            // txtWebSite
            // 
            this.txtWebSite.Location = new System.Drawing.Point(87, 87);
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Properties.ReadOnly = true;
            this.txtWebSite.Size = new System.Drawing.Size(354, 20);
            this.txtWebSite.TabIndex = 46;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(87, 68);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(354, 20);
            this.txtEmail.TabIndex = 45;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(87, 49);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Properties.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(354, 20);
            this.txtTitle.TabIndex = 44;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(87, 30);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(354, 20);
            this.txtLastName.TabIndex = 43;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(87, 11);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(354, 20);
            this.txtFirstName.TabIndex = 42;
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(27, 90);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(47, 13);
            this.labelControl23.TabIndex = 27;
            this.labelControl23.Text = "Web Site:";
            // 
            // labelControl22
            // 
            this.labelControl22.Location = new System.Drawing.Point(515, 71);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(21, 13);
            this.labelControl22.TabIndex = 26;
            this.labelControl22.Text = "Cell:";
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(515, 52);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(34, 13);
            this.labelControl21.TabIndex = 25;
            this.labelControl21.Text = "Phone:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(515, 33);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 24;
            this.labelControl7.Text = "Category:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(515, 14);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(49, 13);
            this.labelControl6.TabIndex = 23;
            this.labelControl6.Text = "Company:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(27, 71);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 22;
            this.labelControl5.Text = "eMail:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(27, 52);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Title:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(27, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Last Name:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "First Name:";
            // 
            // ctlJobContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ctlJobContact";
            this.Size = new System.Drawing.Size(974, 551);
            this.Load += new System.EventHandler(this.ctlJobCostCodes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panSelect)).EndInit();
            this.panSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContactView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panContact)).EndInit();
            this.panContact.ResumeLayout(false);
            this.panContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelected.Properties)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeFAXPhoneNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficePhoneNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeZIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeStreetAddress.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHomeFAXPhoneNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHomeAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCellPhoneNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategories.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebSite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panSelect;
        private DevExpress.XtraEditors.SimpleButton btuUpdateCostCodes;
        private DevExpress.XtraGrid.GridControl grdContact;
        private DevExpress.XtraGrid.Views.Grid.GridView grdContactView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkSelectedItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit txtUserDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtMaterialCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtLaborCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtOtherCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtHours;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboUnit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtUserDescription1;
        private DevExpress.XtraEditors.PanelControl panContact;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboLastName;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LookUpEdit cboCompany;
        private DevExpress.XtraEditors.CheckEdit chkSelected;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.TextEdit txtOfficeFAXPhoneNumber;
        private DevExpress.XtraEditors.TextEdit txtOfficePhoneNumber;
        private DevExpress.XtraEditors.TextEdit txtOfficeCountry;
        private DevExpress.XtraEditors.TextEdit txtOfficeZIP;
        private DevExpress.XtraEditors.TextEdit txtOfficeState;
        private DevExpress.XtraEditors.TextEdit txtOfficeCity;
        private DevExpress.XtraEditors.TextEdit txtOfficeStreetAddress;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.TextEdit txtHomeFAXPhoneNumber;
        private DevExpress.XtraEditors.TextEdit txtCountry;
        private DevExpress.XtraEditors.TextEdit txtZip;
        private DevExpress.XtraEditors.TextEdit txtState;
        private DevExpress.XtraEditors.TextEdit txtCity;
        private DevExpress.XtraEditors.TextEdit txtHomeAddress;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtCellPhoneNumber;
        private DevExpress.XtraEditors.TextEdit txtPhoneNumber;
        private DevExpress.XtraEditors.TextEdit txtCategories;
        private DevExpress.XtraEditors.TextEdit txtCompanyName;
        private DevExpress.XtraEditors.TextEdit txtWebSite;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private DevExpress.XtraEditors.TextEdit txtFirstName;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
    }
}
