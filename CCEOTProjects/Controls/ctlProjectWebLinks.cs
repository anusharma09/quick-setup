using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CCEOTProjects.BusinessLayer;



namespace CCEOTProjects.Controls
{
    public partial class ctlProjectWebLinks : UserControl
    {
        protected bool bColumnWidthChanged = false;
        DataTable webLinkTable; 
        private string otProjectID = "0";
        //
        public ctlProjectWebLinks()
        {
            InitializeComponent();

        }
        //
        public string OTProjectID
        {
            set
            {
                //if (otProjectID != value)
                {
                    otProjectID = value;
                    GetWebLinks();
                }
            }
        }
        //
        public DataTable WebLinkTable
        {
            get { return webLinkTable; }
        }
        //
        private void GetWebLinks()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdWebLinkView, "ctlProjectWebLinks");
                }

                webLinkTable = WebLink.GetWebLinks(otProjectID).Tables[0];
                grdWebLink.DataSource = webLinkTable;

                grdWebLinkView.Columns["Web Link"].ColumnEdit = repItem;
                grdWebLinkView.Columns["OTWebLinkID"].Visible = false;
                grdWebLinkView.Columns["OTProjectID"].Visible = false;
                grdWebLinkView.Columns["Web Link"].Width = 500;
                webBrowser.IsWebBrowserContextMenuEnabled = true;
                webBrowser.Navigate("", false);
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdWebLinkView, "ctlProjectWebLinks");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void repWebLink_MouseEnter(object sender, EventArgs e)
        {

        }
        //
        private void grdWebLinkView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        //
        private void grdWebLinkView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;

            DataRow r = grdWebLinkView.GetDataRow(grdWebLinkView.GetSelectedRows()[0]);
            if (r["Web Link"].ToString().Trim() == "")
            {
                valid = false;
            }
            if (valid)
            {
                try
                {
                    WebLink webLink = new WebLink(r["OTWebLinkID"].ToString(),
                                            otProjectID,
                                        r["Web Link"].ToString());
                    webLink.Save();
                    r["OTWebLinkID"] = webLink.WebLinkID;
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
            else
            {
                if (r["OTWebLinkID"] == DBNull.Value)
                {
                    grdWebLinkView.DeleteRow(e.RowHandle);
                    r.CancelEdit();
                }
                else
                    e.Valid = false;
            }

        }
        //
        private void grdWebLinkView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = grdWebLinkView.GetDataRow(e.FocusedRowHandle);
            if (r == null)
            {
                //repWebLink.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                grdWebLinkView.OptionsBehavior.Editable = true;
            }
            else
            {
                repWebLink.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                grdWebLinkView.OptionsBehavior.Editable = false;
            }

        }
        //
        private void grdWebLinkView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdWebLinkView.GetDataRow(grdWebLinkView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {
                    if (MessageBox.Show("Delete Selected Web Link?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            WebLink.Delete(r[0].ToString());
                            grdWebLinkView.DeleteRow(grdWebLinkView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }
        //
        private void grdWebLinkView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow r = grdWebLinkView.GetDataRow(grdWebLinkView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[2].ToString()))
                {
                    webBrowser.Navigate(r[2].ToString(), false);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void grdWebLinkView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
    }
}
