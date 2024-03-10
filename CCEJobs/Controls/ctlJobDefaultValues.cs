using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace CCEJobs.Controls
{

    public partial class ctlJobDefaultValues : UserControl
    {
        //
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private string jobID;
        //
        public ctlJobDefaultValues()
        {
            InitializeComponent();
        }
        //
        public Security.Security.JobCaller JobCaller
        {
            set
            {
                jobCaller = value;
            }
        }
        //
        public string JobID
        {
            set
            {
                jobID = value;
                if (jobID == "")
                    jobID = "0";
                GetJobDefaultValue();
                SetControlAccess();
            }
        }
        //
        private void GetJobDefaultValue()
        {
            try
            {

                DataTable t = JobDefaultValues.GetJobDefaultValues(jobID).Tables[0];
                DataSet j = JobSystemDefaultValues.GetJobSystemDefaultValues();

                if (t.Rows.Count > 0)
                {
                    DataRow r = JobDefaultValues.GetJobDefaultValues(jobID).Tables[0].Rows[0];
                    txtChangeOrderStipulationsParagraph1.Text = r["ChangeOrderStipulationsParagraph1"].ToString();
                    txtChangeOrderStipulationsParagraph2.Text = r["ChangeOrderStipulationsParagraph2"].ToString();
                    txtMajorPONote.Text = r["MajorPONote"].ToString();
                    txtSmallPONote.Text = r["SmallPONote"].ToString();
                    txtSundriesPercentOfMaterial.Text = r["SundriesPercentOfMaterial"].ToString();
                    txtSalesTaxPercent.Text = r["SalesTaxPercent"].ToString();
                    txtAsBuiltsEngineeringPercent.Text = r["AsBuiltsEngineeringPercent"].ToString();
                    txtStoragePercent.Text = r["StoragePercent"].ToString();
                    txtSmallToolsPercent.Text = r["SmallToolsPercent"].ToString();
                    txtCartigeHandlingPercent.Text = r["CartigeHandlingPercent"].ToString();
                    txtForemanPercentOfLabor.Text = r["ForemanPercentOfLabor"].ToString();
                    txtGeneralForemanPercentOfLabor.Text = r["GeneralForemanPercentOfLabor"].ToString();
                    txtSuperintendentPercentOfLabor.Text = r["SuperintendentPercentOfLabor"].ToString();
                    txtProjectManagerPercentOfLabor.Text = r["ProjectManagerPercentOfLabor"].ToString();
                    txtProjectEngineerPercentOfLabor.Text = r["ProjectEngineerPercentOfLabor"].ToString();
                    txtSafetyMeetingPercent.Text = r["SafetyMeetingPercent"].ToString();
                    txtFringeBenefitsPercent.Text = r["FringeBenefitsPercent"].ToString();
                    txtOverheadPercent.Text = r["OverheadPercent"].ToString();
                    txtProfitPercent.Text = r["ProfitPercent"].ToString();
                    txtSubcontractAdministrationPercent.Text = r["SubcontractAdministrationPercent"].ToString();
                    txtWarrantyPercent.Text = r["WarrantyPercent"].ToString();
                    txtBondPercent.Text = r["BondPercent"].ToString();

                    txtBIMRate.Text = r["BIMRate"].ToString();
                    txtApprenticeLaborRate.Text = r["ApprenticeLaborRate"].ToString();
                    txtElectricianLaborRate.Text = r["ElectricianLaborRate"].ToString();
                    txtForemanLaborRate.Text = r["ForemanLaborRate"].ToString();
                    txtGeneralForemanLaborRate.Text = r["GeneralForemanLaborRate"].ToString();
                    txtSuperintendentLaborRate.Text = r["SuperintendentLaborRate"].ToString();
                    txtProjectManagerLaborRate.Text = r["ProjectManagerLaborRate"].ToString();
                    txtProjectEngineerLaborRate.Text = r["ProjectEngineerLaborRate"].ToString();
                    txtSafetyMeetingsLaborRate.Text = r["SafetyMeetingsLaborRate"].ToString();
                    txtPremiumTimeLaborRate.Text = r["PremiumTimeLaborRate"].ToString();
                    txtRFIDefaultContact.Text = r["RFIDefaultContact"].ToString();
                    txtRFIDefaultContactCompany.Text = r["RFIDefaultContactCompany"].ToString();
                    txtChangeOrderDefaultContact.Text = r["ChangeOrderDefaultContact"].ToString();
                    txtChangeOrderDefaultContactCompany.Text = r["ChangeOrderDefaultContactCompany"].ToString();
                    txtJobDefaultFrom.Text = r["JobDefaultFrom"].ToString();
                    txtJobForeman.Text = r["JobForeman"].ToString();

                    txtBIMRateOT.Text = r["BIMRateOT"].ToString();
                    txtApprenticeLaborRateOT.Text = r["ApprenticeLaborRateOT"].ToString();
                    txtElectricianLaborRateOT.Text = r["ElectricianLaborRateOT"].ToString();
                    txtForemanLaborRateOT.Text = r["ForemanLaborRateOT"].ToString();
                    txtGeneralForemanLaborRateOT.Text = r["GeneralForemanLaborRateOT"].ToString();
                    txtSuperintendentLaborRateOT.Text = r["SuperintendentLaborRateOT"].ToString();
                    txtProjectManagerLaborRateOT.Text = r["ProjectManagerLaborRateOT"].ToString();
                    txtProjectEngineerLaborRateOT.Text = r["ProjectEngineerLaborRateOT"].ToString();
                    txtSafetyMeetingsLaborRateOT.Text = r["SafetyMeetingsLaborRateOT"].ToString();
                    txtPremiumTimeLaborRateOT.Text = r["PremiumTimeLaborRateOT"].ToString();

                    txtBIMRateDT.Text = r["BIMRateDT"].ToString();
                    txtApprenticeLaborRateDT.Text = r["ApprenticeLaborRateDT"].ToString();
                    txtElectricianLaborRateDT.Text = r["ElectricianLaborRateDT"].ToString();
                    txtForemanLaborRateDT.Text = r["ForemanLaborRateDT"].ToString();
                    txtGeneralForemanLaborRateDT.Text = r["GeneralForemanLaborRateDT"].ToString();
                    txtSuperintendentLaborRateDT.Text = r["SuperintendentLaborRateDT"].ToString();
                    txtProjectManagerLaborRateDT.Text = r["ProjectManagerLaborRateDT"].ToString();
                    txtProjectEngineerLaborRateDT.Text = r["ProjectEngineerLaborRateDT"].ToString();
                    txtSafetyMeetingsLaborRateDT.Text = r["SafetyMeetingsLaborRateDT"].ToString();
                    txtPremiumTimeLaborRateDT.Text = r["PremiumTimeLaborRateDT"].ToString();

                    //labelControl35.Text =  r["BIMRate_Label"].ToString().Trim();
                    if (r["BIMRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl35.Text = string.Empty; }
                    else
                    {
                        labelControl35.Text = Convert.ToString(r["BIMRate_Label"]).Trim();
                    }
                    //labelControl34.Text =  r["ApprenticeLaborRate_Label"].ToString().Trim();
                    if (r["ApprenticeLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl34.Text = string.Empty; }
                    else
                    {
                        labelControl34.Text = Convert.ToString(r["ApprenticeLaborRate_Label"]).Trim();
                    }
                    //labelControl119.Text = r["ElectricianLaborRate_Label"].ToString().Trim();
                    if (r["ElectricianLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl119.Text = string.Empty; }
                    else
                    {
                        labelControl119.Text = Convert.ToString(r["ElectricianLaborRate_Label"]).Trim();
                    }


                    //labelControl118.Text = r["ForemanLaborRate_Label"].ToString().Trim();
                    if (r["ForemanLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl118.Text = string.Empty; }
                    else
                    {
                        labelControl118.Text = Convert.ToString(r["ForemanLaborRate_Label"]).Trim();
                    }


                    //labelControl117.Text = r["GeneralForemanLaborRate_Label"].ToString().Trim();
                    if (r["GeneralForemanLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl117.Text = string.Empty; }
                    else
                    {
                        labelControl117.Text = Convert.ToString(r["GeneralForemanLaborRate_Label"]).Trim();
                    }

                    //labelControl116.Text = r["SuperintendentLaborRate_Label"].ToString().Trim();
                    if (r["SuperintendentLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl116.Text = string.Empty; }
                    else
                    {
                        labelControl116.Text = Convert.ToString(r["SuperintendentLaborRate_Label"]).Trim();
                    }

                    //labelControl115.Text = r["ProjectManagerLaborRate_Label"].ToString().Trim();
                    if (r["ProjectManagerLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl115.Text = string.Empty; }
                    else
                    {
                        labelControl115.Text = Convert.ToString(r["ProjectManagerLaborRate_Label"]).Trim();
                    }

                   // labelControl120.Text = r["ProjectEngineerLaborRate_Label"].ToString().Trim();
                    if (r["ProjectEngineerLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl120.Text = string.Empty; }
                    else
                    {
                        labelControl120.Text = Convert.ToString(r["ProjectEngineerLaborRate_Label"]).Trim();
                    }

                    if (r["SafetyMeetingsLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl114.Text = string.Empty; }
                    else
                    {
                        labelControl114.Text = Convert.ToString(r["SafetyMeetingsLaborRate_Label"]).Trim();
                    }
                    //labelControl114.Text = r["SafetyMeetingsLaborRate_Label"].ToString().Trim();
                    labelControl113.Text = r["PremiumTimeLaborRate_Label"].ToString().Trim();
                    if (r["PremiumTimeLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl113.Text = string.Empty; }
                    else
                    {
                        labelControl113.Text = Convert.ToString(r["PremiumTimeLaborRate_Label"]).Trim();
                    }

                   // labelControl15.Text = r["FringeBenefitsPercent_Label"].ToString().Trim();
                    if (r["FringeBenefitsPercent_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl15.Text = string.Empty; }
                    else
                    {
                        labelControl15.Text = Convert.ToString(r["FringeBenefitsPercent_Label"]).Trim();
                    }

                    labelControl16.Text = r["SafetyMeetingPercent_Label"].ToString().Trim().Trim();
                    if (r["SafetyMeetingPercent_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl16.Text = string.Empty; }
                    else
                    {
                        labelControl16.Text = Convert.ToString(r["SafetyMeetingPercent_Label"]).Trim();
                    }

                }
                else
                {
                    txtChangeOrderStipulationsParagraph1.Text = "";
                    txtChangeOrderStipulationsParagraph2.Text = "";
                    txtSundriesPercentOfMaterial.Text = "";
                    txtSalesTaxPercent.Text = "";
                    txtSmallPONote.Text = "";
                    txtAsBuiltsEngineeringPercent.Text = "";
                    txtStoragePercent.Text = "";
                    txtSmallToolsPercent.Text = "";
                    txtCartigeHandlingPercent.Text = "";
                    txtForemanPercentOfLabor.Text = "";
                    txtGeneralForemanPercentOfLabor.Text = "";
                    txtSuperintendentPercentOfLabor.Text = "";
                    txtProjectManagerPercentOfLabor.Text = "";
                    txtProjectEngineerPercentOfLabor.Text = "";
                    txtSafetyMeetingPercent.Text = "";
                    txtFringeBenefitsPercent.Text = "";
                    txtOverheadPercent.Text = "";
                    txtProfitPercent.Text = "";
                    txtSubcontractAdministrationPercent.Text = "";
                    txtWarrantyPercent.Text = "";
                    txtBondPercent.Text = "";

                    txtBIMRate.Text = "";
                    txtApprenticeLaborRate.Text = "";
                    txtElectricianLaborRate.Text = "";
                    txtForemanLaborRate.Text = "";
                    txtGeneralForemanLaborRate.Text = "";
                    txtSuperintendentLaborRate.Text = "";
                    txtProjectManagerLaborRate.Text = "";
                    txtProjectEngineerLaborRate.Text = "";
                    txtSafetyMeetingsLaborRate.Text = "";
                    txtPremiumTimeLaborRate.Text = "";
                    txtRFIDefaultContact.Text = "";
                    txtRFIDefaultContactCompany.Text = "";
                    txtChangeOrderDefaultContact.Text = "";
                    txtChangeOrderDefaultContactCompany.Text = "";
                    txtJobDefaultFrom.Text = "";
                    txtJobForeman.Text = "";


                    txtBIMRateOT.Text = "";
                    txtApprenticeLaborRateOT.Text = "";
                    txtElectricianLaborRateOT.Text = "";
                    txtForemanLaborRateOT.Text = "";
                    txtGeneralForemanLaborRateOT.Text = "";
                    txtSuperintendentLaborRateOT.Text = "";
                    txtProjectManagerLaborRateOT.Text = "";
                    txtProjectEngineerLaborRateOT.Text = "";
                    txtSafetyMeetingsLaborRateOT.Text = "";
                    txtPremiumTimeLaborRateOT.Text = "";

                    txtBIMRateDT.Text = "";
                    txtApprenticeLaborRateDT.Text = "";
                    txtElectricianLaborRateDT.Text = "";
                    txtForemanLaborRateDT.Text = "";
                    txtGeneralForemanLaborRateDT.Text = "";
                    txtSuperintendentLaborRateDT.Text = "";
                    txtProjectManagerLaborRateDT.Text = "";
                    txtProjectEngineerLaborRateDT.Text = "";
                    txtSafetyMeetingsLaborRateDT.Text = "";
                    txtPremiumTimeLaborRateDT.Text = "";

                    if (j.Tables[0].Rows.Count > 0)
                    {
                        DataRow r1 = j.Tables[0].Rows[0];
                        labelControl35.Text = r1["BIMRate_Label"].ToString().Trim();
                        labelControl34.Text = r1["ApprenticeLaborRate_Label"].ToString().Trim();
                        labelControl119.Text =r1["ElectricianLaborRate_Label"].ToString().Trim();
                        labelControl118.Text =r1["ForemanLaborRate_Label"].ToString().Trim();
                        labelControl117.Text =r1["GeneralForemanLaborRate_Label"].ToString().Trim();
                        labelControl116.Text =r1["SuperintendentLaborRate_Label"].ToString().Trim();
                        labelControl115.Text =r1["ProjectManagerLaborRate_Label"].ToString().Trim();
                        labelControl120.Text =r1["ProjectEngineerLaborRate_Label"].ToString().Trim();
                        //labelControl114.Text =r1["SafetyMeetingsLaborRate_Label"].ToString().Trim();
                        if (r1["SafetyMeetingsLaborRate_Label"].ToString().Trim() == "Null".ToString())
                        { labelControl114.Text  = string.Empty; }
                        else
                        {
                            labelControl114.Text = Convert.ToString(r1["SafetyMeetingsLaborRate_Label"]).Trim();
                        }
                        labelControl113.Text =r1["PremiumTimeLaborRate_Label"].ToString().Trim();
                        labelControl15.Text = r1["FringeBenefitsPercent_Label"].ToString().Trim();
                        labelControl16.Text = r1["SafetyMeetingPercent_Label"].ToString().Trim();
                    }
                }
                GetSubmittalSpec();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        private void GetSubmittalSpec()
        {
            try
            {
                this.grdSubmittal.DataSource = JobSubmittalSpec.GetJobSubmittalSpec(jobID).Tables[0];
                gridSubmittal.Columns["JobSubmittalSpecID"].Visible = false;
                gridSubmittal.Columns["JobSubmittalSpecSection"].Caption = "Section";
                gridSubmittal.Columns["JobSubmittalSpecDescription"].Caption = "Description";
                gridSubmittal.Columns["JobSubmittalSpecDescription"].ColumnEdit = repDescription;
                //gridSubmittal.Columns["JobSubmittalSpecSection"].ColumnEdit = repSection;
                gridSubmittal.Columns["JobSubmittalSpecDescription"].Width = 400;
                gridSubmittal.Columns["JobSubmittalSpecSection"].Width = 100;

                gridSubmittal.OptionsBehavior.Editable = false;
                gridSubmittal.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
            {
                panRFI.Visible = false;
            }
            else
            {
                panRFI.Visible = true;
            }
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmJobSystemDefaultValues f = new frmJobSystemDefaultValues(jobID);
            f.ShowDialog();
            GetJobDefaultValue();
        }

        private void hyperLinkEdit3_Click(object sender, EventArgs e)
        {
            try
            {
                openFile.FileName = "*.xls";
                openFile.Filter = "Excel Files|*.xls";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    ImportSubmittal import = new ImportSubmittal();
                    import.Import(@openFile.FileName, jobID);
                    GetSubmittalSpec();
                    //  GetJobSubmittal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void labelControl35_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl35.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl34_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl34.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl119_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl119.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl118_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl118.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl117_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl117.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl116_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl116.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl115_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl115.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl120_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl120.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl114_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl114.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl113_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl113.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl16.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl15.Text.Length) > 26))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}
