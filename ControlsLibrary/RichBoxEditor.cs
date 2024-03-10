using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSpellChecker;
using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Menu;
using DevExpress.XtraRichEdit.API.Native;

namespace ControlsLibrary
{
    public delegate void TextChangedHandler(object source, EventArgs e);


    public partial class RichBoxEditor : UserControl
    {
        public event TextChangedHandler OnTextChanged;
        //System.Drawing.Font font;

        DevExpress.XtraSpellChecker.SpellChecker checker = new DevExpress.XtraSpellChecker.SpellChecker();

        public string myText;
        private int myLength;

        public RichBoxEditor()
        {
            InitializeComponent();          
        }      

        public bool ReadOnly
        {
            get { return RichTextEditor.ReadOnly; }
            set { RichTextEditor.ReadOnly = value; }
        }

        public int length
        {
            get
            {
                DocumentRange range = RichTextEditor.Document.Range;
                return range.Length;
            }
            set
            {
                myLength = value;
            }
        }
        //
        public string Text {
            get 
            { 
                MemoryStream m = new MemoryStream();
                try
                {
                    RichTextEditor.SaveDocument(m, DocumentFormat.Rtf);
                }
                catch
                {
                    RichTextEditor.SaveDocument(m, DocumentFormat.PlainText);
                }
                byte[] buffer = new byte[m.Length];
                m.Seek(0, SeekOrigin.Begin);
                m.Read(buffer, 0, (int)m.Length);
                myText = System.Text.Encoding.Default.GetString(buffer);
                return myText;
            }
            set 
            { 
                myText = value;
                MemoryStream m = new MemoryStream( Encoding.UTF8.GetBytes(myText));
                m.Seek(0, SeekOrigin.Begin);
                try
                {
                    if (myText.StartsWith(@"{\rtf"))
                        RichTextEditor.LoadDocument(m, DocumentFormat.Rtf);
                    else
                        RichTextEditor.LoadDocument(m, DocumentFormat.PlainText);
                }
                catch {
                    RichTextEditor.LoadDocument(m, DocumentFormat.PlainText);
                
                }
                
            }
        }
        //
        private void RichTextEditor_ContentChanged(object sender, EventArgs e)
        {
            if (OnTextChanged != null)
            {
                OnTextChanged(this, e);
            }
        }

        private void RichTextEditor_PopupMenuShowing(object sender, DevExpress.XtraRichEdit.PopupMenuShowingEventArgs e)
        {
            if (RichTextEditor.SpellChecker.SpellCheckMode == SpellCheckMode.OnDemand)
            {
                IRichEditCommandFactoryService service = (IRichEditCommandFactoryService)RichTextEditor.GetService(typeof(IRichEditCommandFactoryService));
                RichEditCommand cmd = service.CreateCommand(RichEditCommandId.CheckSpelling);
                RichEditMenuItemCommandWinAdapter menuItemCommandAdapter = new RichEditMenuItemCommandWinAdapter(cmd);
                RichEditMenuItem menuItem = (RichEditMenuItem)menuItemCommandAdapter.CreateMenuItem(DevExpress.Utils.Menu.DXMenuItemPriority.Normal);
                menuItem.BeginGroup = true;
                menuItem.Caption = "Check Spelling";
                e.Menu.Items.Add(menuItem);
            }
        }
    }
}
