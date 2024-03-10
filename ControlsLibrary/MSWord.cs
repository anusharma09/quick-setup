using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlsLibrary
{
    public partial class MSWord : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string myText;
        public MSWord()
        {
            DevExpress.XtraSpellChecker.SpellChecker checker = new DevExpress.XtraSpellChecker.SpellChecker();
            InitializeComponent();

            System.Globalization.CultureInfo usCulture = new System.Globalization.CultureInfo("en-us");
            DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary dictionary = new DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary
                (@"Dictionaries\american.xlg", @"Dictionaries\english.aff", usCulture);
            dictionary.AlphabetPath = @"Dictionaries\EnglishAlphabet.txt";
            checker.Dictionaries.Add(dictionary);
            DevExpress.XtraSpellChecker.SpellCheckerCustomDictionary customDictionary = new DevExpress.XtraSpellChecker.SpellCheckerCustomDictionary
                (@"Dictionaries\CustomEnglish.dic", usCulture);
            checker.Dictionaries.Add(customDictionary);
            checker.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType;
            checker.Culture = new System.Globalization.CultureInfo("en-us");

            RichTextEditor.SpellChecker = checker;
        }

        public string MyText
        {
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
                MemoryStream m = new MemoryStream(Encoding.UTF8.GetBytes(myText));
                m.Seek(0, SeekOrigin.Begin);
                try
                {
                    RichTextEditor.LoadDocument(m, DocumentFormat.Rtf);
                }
                catch
                {
                    RichTextEditor.LoadDocument(m, DocumentFormat.PlainText);

                }

            }
        }
    }
}
