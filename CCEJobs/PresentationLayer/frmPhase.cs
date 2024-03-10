using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using DevExpress.XtraEditors.Repository;

namespace CCEJobs.PresentationLayer
{
    public partial class frmPhase : Form
    {
        DataTable phaseTable;
        private string jobID;
        private string phase;
        RepositoryItemComboBox phaseRep;
        
        public frmPhase()
        {
            InitializeComponent();
        }
        public frmPhase(string type, string code, string title, string jobID, string phase)
        {
            InitializeComponent();
            txtType.Text = type;
            txtCode.Text = code;
            txtTitle.Text = title;
            this.jobID = jobID;
            this.phase = phase;
            GetCostCodePhases();
            this.ShowDialog();
        }

        private void GetCostCodePhases()
        {
            try
            {
                phaseTable = CostCode.GetCostCodePhasesProc(txtType.Text, txtCode.Text, jobID, phase.Substring(0,1)).Tables[0];

               // phaseTable.PrimaryKey.SetValue("Phase", 0);
               // phaseTable.Columns["Phase"].Unique = true;

                DataColumn column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Phase";
                DataColumn[] keys = new DataColumn[1];
                keys[0] = phaseTable.Columns["Phase"];

                phaseTable.PrimaryKey = keys;

                this.grdCostCode.DataSource = phaseTable.DefaultView;
                gridView1.Columns["ID"].Visible = false;
                gridView1.Columns["New?"].Visible = false;
                gridView1.Columns["Phase"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["Description"].ColumnEdit = txtDescription;
                gridView1.Columns["Description"].OptionsColumn.AllowEdit = true;
               // gridView1.Columns["ValueAdjustment"].Visible = false;
                switch (txtType.Text)
                {
                    case "L":
                        if (phase.Substring(0, 1) == "1")
                            phaseRep = RepositoryItems.phase100;
                        else
                            phaseRep = RepositoryItems.phase500;
                        break;
                    case "S":
                        phaseRep = RepositoryItems.phase400;
                        break;
                    case "O":
                        phaseRep = RepositoryItems.phase800;
                        break;
                }
                gridView1.Columns["Phase"].ColumnEdit = phaseRep;
                gridView1.BestFitColumns();
                /*
                if (txtType.Text == "L")
                    phaseRep =  RepositoryItems.phase100;
                else
                    phaseRep = RepositoryItems.phase400;
                gridView1.Columns["Phase"].ColumnEdit = phaseRep;
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            
          
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            
            if (!e.Valid )
                return;
          DataRow r;

          r = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);
            if (r != null)
            {
                try
                {
                    string phase = r["Phase"].ToString();

                    if (phaseTable.Rows.Contains(phase))
                        return;
                    if (String.IsNullOrEmpty(r["Phase"].ToString()) || String.IsNullOrEmpty(r["Description"].ToString()))
                    {
                        MessageBox.Show("Must enter Phase & Description", CCEApplication.ApplicationName);
                        return;
                    }

                    CostCode costCode = new CostCode(r["ID"].ToString(),
                                                     txtType.Text,
                                                     r["Phase"].ToString(),
                                                     txtCode.Text, txtTitle.Text, r["Description"].ToString(), 
                                                     jobID, "0","0", 
                                                     "0");
                    costCode.Save();
                    r["ID"] = costCode.JobCostCodePhaseID;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    e.Valid = false;
                }
            }
        }

 
        private void gridView1_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string newPhase = "";
            if (gridView1.SelectedRowsCount <= 0)
                return;

            try
            {
                DataRow dataRow = null;
                dataRow = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);
                if (dataRow == null)
                {
                    gridView1.OptionsBehavior.Editable = true;
                    txtDescription.ReadOnly = false;
                    phaseRep.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick;
                    gridView1.Columns["Phase"].OptionsColumn.AllowEdit = true;
                    return;

                }

                if (!dataRow.IsNull("New?"))
                {
                    newPhase = dataRow["New?"].ToString();
                    if (newPhase == "N")
                    {
                        gridView1.OptionsBehavior.Editable = false;
                        txtDescription.ReadOnly = true;
                        phaseRep.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
                        phaseRep.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        gridView1.Columns["Phase"].OptionsColumn.AllowEdit = false; 

                    }
                    else
                    {
                        try
                        {
                            gridView1.OptionsBehavior.Editable = true;
                            txtDescription.ReadOnly = false;
                            phaseRep.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick;
                            gridView1.Columns["Phase"].OptionsColumn.AllowEdit = true; 

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            } 
        }

        private void frmPhase_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            gridView1.MoveFirst();
        }

        private void frmPhase_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridView1.MoveNext();
        }
       
    }
}