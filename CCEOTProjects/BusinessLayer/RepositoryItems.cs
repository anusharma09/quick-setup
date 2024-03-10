using System;
using System.Data;
using System.Drawing;
using System.Collections;
using DevExpress.XtraEditors.Repository;



namespace CCEOTProjects.BusinessLayer
{
    public class RepositoryItems
    {
        public static RepositoryItemLookUpEdit OwnerClass;
     
        //
        public static void UpdateRepositoryItems()
        {
            PopulateOwnerClass();
        
        }
        //
        private static void PopulateOwnerClass()
        {
          /*  DataTable tbl;
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            OwnerClass = new RepositoryItemLookUpEdit();
            tbl = StaticTables.OwnerClass;
            OwnerClass.DataSource = tbl;
            OwnerClass.DisplayMember = "Description";
            OwnerClass.ValueMember = "OwnerClassID";
            col.Caption = "ID";
            col.FieldName = "OwnerClassID";
            col.Visible = false;
            OwnerClass.Columns.Add(col);
            col1.Caption = "Owner Class";
            col1.FieldName = "Description";
            col1.Visible = true;
            OwnerClass.Columns.Add(col1);
           */
        }
    }
}
