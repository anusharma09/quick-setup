namespace ControlsLibrary
{
    partial class RichBoxEditor
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
            DevExpress.XtraSpellChecker.OptionsSpelling optionsSpelling1 = new DevExpress.XtraSpellChecker.OptionsSpelling();
            this.RichTextEditor = new DevExpress.XtraRichEdit.RichEditControl();
            this.spellChecker1 = new DevExpress.XtraSpellChecker.SpellChecker(this.components);
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.repositoryItemRichEditFontSizeEdit1 = new DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit();
            this.repositoryItemRichEditStyleEdit1 = new DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit();
            this.repositoryItemRichEditStyleEdit2 = new DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit();
            this.paragraphBar1 = new DevExpress.XtraRichEdit.UI.ParagraphBar();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditFontSizeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // RichTextEditor
            // 
            this.RichTextEditor.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.RichTextEditor.Appearance.Text.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextEditor.Appearance.Text.Options.UseFont = true;
            this.RichTextEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextEditor.EnableToolTips = true;
            this.RichTextEditor.Location = new System.Drawing.Point(0, 0);
            this.RichTextEditor.Name = "RichTextEditor";
            this.RichTextEditor.Options.Bookmarks.AllowNameResolution = false;
            this.RichTextEditor.ReadOnly = true;
            this.RichTextEditor.Size = new System.Drawing.Size(570, 440);
           // this.RichTextEditor.SpellChecker = this.spellChecker1;
           // this.spellChecker1.SetSpellCheckerOptions(this.RichTextEditor, optionsSpelling1);
            this.RichTextEditor.TabIndex = 0;
            this.RichTextEditor.PopupMenuShowing += new DevExpress.XtraRichEdit.PopupMenuShowingEventHandler(this.RichTextEditor_PopupMenuShowing);
            // 
            // spellChecker1
            // 
            this.spellChecker1.CheckAsYouTypeOptions.CheckControlsInParentContainer = true;
            this.spellChecker1.Culture = new System.Globalization.CultureInfo("en-US");
            this.spellChecker1.ParentContainer = null;
            this.spellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType;
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // repositoryItemRichEditFontSizeEdit1
            // 
            this.repositoryItemRichEditFontSizeEdit1.AutoHeight = false;
            this.repositoryItemRichEditFontSizeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRichEditFontSizeEdit1.Control = null;
            this.repositoryItemRichEditFontSizeEdit1.Name = "repositoryItemRichEditFontSizeEdit1";
            // 
            // repositoryItemRichEditStyleEdit1
            // 
            this.repositoryItemRichEditStyleEdit1.AutoHeight = false;
            this.repositoryItemRichEditStyleEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRichEditStyleEdit1.Control = null;
            this.repositoryItemRichEditStyleEdit1.Name = "repositoryItemRichEditStyleEdit1";
            // 
            // repositoryItemRichEditStyleEdit2
            // 
            this.repositoryItemRichEditStyleEdit2.AutoHeight = false;
            this.repositoryItemRichEditStyleEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRichEditStyleEdit2.Control = null;
            this.repositoryItemRichEditStyleEdit2.Name = "repositoryItemRichEditStyleEdit2";
            // 
            // paragraphBar1
            // 
            this.paragraphBar1.BarName = "";
            this.paragraphBar1.Control = null;
            this.paragraphBar1.DockCol = 4;
            this.paragraphBar1.DockRow = 0;
            this.paragraphBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.paragraphBar1.Offset = 231;
            this.paragraphBar1.OptionsBar.AllowQuickCustomization = false;
            this.paragraphBar1.OptionsBar.DrawDragBorder = false;
            this.paragraphBar1.Text = "";
            // 
            // RichBoxEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RichTextEditor);
            this.Name = "RichBoxEditor";
            this.Size = new System.Drawing.Size(570, 440);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditFontSizeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit repositoryItemRichEditFontSizeEdit1;
        private DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit repositoryItemRichEditStyleEdit1;
        private DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit repositoryItemRichEditStyleEdit2;
        private DevExpress.XtraRichEdit.UI.ParagraphBar paragraphBar1;
        public DevExpress.XtraRichEdit.RichEditControl RichTextEditor;
        private DevExpress.XtraSpellChecker.SpellChecker spellChecker1;
    }
}
