using System;
using System.Data;
using System.Drawing;
using System.Collections;
using DevExpress.XtraEditors.Repository;



namespace JCCBusinessLayer
{
    public class RepositoryItems
    {
        public static RepositoryItemLookUpEdit OwnerClass;
        public static RepositoryItemComboBox phase100;
        public static RepositoryItemComboBox phase500;
        public static RepositoryItemComboBox phase400;
        public static RepositoryItemComboBox phase800;
        public static RepositoryItemLookUpEdit ArchivePeriod;
        public static RepositoryItemComboBox changeOrderDescription;
        public static RepositoryItemComboBox unitOfMeasurements;
        public static RepositoryItemComboBox subcontractNumber;
        public static bool isLoaded = false;
        //
        public static void UpdateRepositoryItems()
        {
            PopulateOwnerClass();
            PopulatePhase100();
            PopulatePhase400();
            PopulatePhase500();
            PopulatePhase800();
            PopulateArchivePeriod();
            PopulateChangeOrderDescription();
            PopulateUniteOfMeasurements();
            PopulateSubcontractNumber();
            isLoaded = true;

        }
        //
        private static void PopulateOwnerClass()
        {
            DataTable tbl;
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
        }
        //
        private static void PopulateArchivePeriod()
        {
            DataTable tbl;
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            ArchivePeriod = new RepositoryItemLookUpEdit();
            tbl = StaticTables.ArchivePeriod;
            ArchivePeriod.DataSource = tbl;
            ArchivePeriod.DisplayMember = "Description";
            ArchivePeriod.ValueMember = "OwnerClassID";
            col.Caption = "ID";
            col.FieldName = "Period";
            col.Visible = true;
            ArchivePeriod.Columns.Add(col);
        }
        //
        private static void PopulatePhase100()
        {
            phase100 = new RepositoryItemComboBox();
            phase100.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            for (int i = 100; i < 200; i++)
            {
                phase100.Items.Add(i.ToString());
            }   
        }

        private static void PopulatePhase500()
        {
            phase500 = new RepositoryItemComboBox();
            phase500.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            for (int i = 500; i < 600; i++)
            {
                phase500.Items.Add(i.ToString());
            }
        }


        //
        private static void PopulatePhase400()
        {
            phase400 = new RepositoryItemComboBox();
            phase400.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            for (int i = 400; i < 500; i++)
            {
                phase400.Items.Add(i.ToString());
            }
        }
        private static void PopulatePhase800()
        {
            phase800 = new RepositoryItemComboBox();
            phase800.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            for (int i = 800; i < 900; i++)
            {
                phase800.Items.Add(i.ToString());
            }
        }
        //
        private static void PopulateChangeOrderDescription()
        {
            changeOrderDescription = new RepositoryItemComboBox();
            changeOrderDescription.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            changeOrderDescription.Items.Add("B~ Appr.");
            changeOrderDescription.Items.Add("C~ Pending With Proc.");
            changeOrderDescription.Items.Add("D~ Pending No Proc.");
            changeOrderDescription.Items.Add("E~ Time & Material Appr.");
            changeOrderDescription.Items.Add("F~ Time & Material Pend.");
            changeOrderDescription.Items.Add("G~ Other Trades Appr.");
            changeOrderDescription.Items.Add("H~ Other Trades Pend.");
            changeOrderDescription.Items.Add("I~ Allowance Appr.");
            changeOrderDescription.Items.Add("J~ Allowance Pend.");
            changeOrderDescription.Items.Add("K~ Negotiated With Proc.");
            changeOrderDescription.Items.Add("L~ Negotiated No Proc.");
            changeOrderDescription.Items.Add("M~ Tanent Extra Appr.");
            changeOrderDescription.Items.Add("N~ Tanent Extra Pend.");
            changeOrderDescription.Items.Add("X~ Cancelled");            
        }
        //
        private static void PopulateUniteOfMeasurements()
        {
            unitOfMeasurements = new RepositoryItemComboBox();
            unitOfMeasurements.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            unitOfMeasurements.Items.Add(" ");
            unitOfMeasurements.Items.Add("EA");
            unitOfMeasurements.Items.Add("FT");
            unitOfMeasurements.Items.Add("HR");
            unitOfMeasurements.Items.Add("SF");
            unitOfMeasurements.Items.Add("WK");
        }
        //
        private static void PopulateSubcontractNumber()
        {
            subcontractNumber = new RepositoryItemComboBox();
            subcontractNumber.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
           
            subcontractNumber.Items.Add("");
            subcontractNumber.Items.Add("01");
            subcontractNumber.Items.Add("02");
            subcontractNumber.Items.Add("03");
            subcontractNumber.Items.Add("04");
            subcontractNumber.Items.Add("05");
            subcontractNumber.Items.Add("06");
            subcontractNumber.Items.Add("07");
            subcontractNumber.Items.Add("08");
            subcontractNumber.Items.Add("09");

            subcontractNumber.Items.Add("10");
            subcontractNumber.Items.Add("11");
            subcontractNumber.Items.Add("12");
            subcontractNumber.Items.Add("13");
            subcontractNumber.Items.Add("14");
            subcontractNumber.Items.Add("15");
            subcontractNumber.Items.Add("16");
            subcontractNumber.Items.Add("17");
            subcontractNumber.Items.Add("18");
            subcontractNumber.Items.Add("19");

            subcontractNumber.Items.Add("20");
            subcontractNumber.Items.Add("21");
            subcontractNumber.Items.Add("22");
            subcontractNumber.Items.Add("23");
            subcontractNumber.Items.Add("24");
            subcontractNumber.Items.Add("25");
            subcontractNumber.Items.Add("26");
            subcontractNumber.Items.Add("27");
            subcontractNumber.Items.Add("28");
            subcontractNumber.Items.Add("29");

            subcontractNumber.Items.Add("30");
            subcontractNumber.Items.Add("31");
            subcontractNumber.Items.Add("32");
            subcontractNumber.Items.Add("33");
            subcontractNumber.Items.Add("34");
            subcontractNumber.Items.Add("35");
            subcontractNumber.Items.Add("36");
            subcontractNumber.Items.Add("37");
            subcontractNumber.Items.Add("38");
            subcontractNumber.Items.Add("39");

            subcontractNumber.Items.Add("40");
            subcontractNumber.Items.Add("41");
            subcontractNumber.Items.Add("42");
            subcontractNumber.Items.Add("43");
            subcontractNumber.Items.Add("44");
            subcontractNumber.Items.Add("45");
            subcontractNumber.Items.Add("46");
            subcontractNumber.Items.Add("47");
            subcontractNumber.Items.Add("48");
            subcontractNumber.Items.Add("49");
            subcontractNumber.Items.Add("50");
        }
    }
}
