namespace CCEJobs.Controls
{
    partial class ctlLaborPerformanceFactor
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
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.grdLaborPerformanceback = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.chartLaborPerformanceback = new DevExpress.XtraCharts.ChartControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdLaborPerformanceback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborPerformanceback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdLaborPerformanceback
            // 
            this.grdLaborPerformanceback.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdLaborPerformanceback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLaborPerformanceback.Location = new System.Drawing.Point(0, 0);
            this.grdLaborPerformanceback.Name = "grdLaborPerformanceback";
            this.grdLaborPerformanceback.OptionsMenu.EnableFieldValueMenu = false;
            this.grdLaborPerformanceback.OptionsMenu.EnableHeaderAreaMenu = false;
            this.grdLaborPerformanceback.OptionsMenu.EnableHeaderMenu = false;
            this.grdLaborPerformanceback.OptionsView.ShowColumnHeaders = false;
            this.grdLaborPerformanceback.OptionsView.ShowDataHeaders = false;
            this.grdLaborPerformanceback.OptionsView.ShowFilterHeaders = false;
            this.grdLaborPerformanceback.Size = new System.Drawing.Size(725, 274);
            this.grdLaborPerformanceback.TabIndex = 2;
            // 
            // chartLaborPerformanceback
            // 
            this.chartLaborPerformanceback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLaborPerformanceback.Legend.MaxHorizontalPercentage = 75;
            this.chartLaborPerformanceback.Location = new System.Drawing.Point(0, 0);
            this.chartLaborPerformanceback.Name = "chartLaborPerformanceback";
            this.chartLaborPerformanceback.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartLaborPerformanceback.SeriesTemplate.View = lineSeriesView1;
            this.chartLaborPerformanceback.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.chartLaborPerformanceback.Size = new System.Drawing.Size(725, 175);
            this.chartLaborPerformanceback.TabIndex = 1;
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 12F);
            chartTitle1.Text = "Labor Performance History";
            this.chartLaborPerformanceback.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdLaborPerformanceback);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chartLaborPerformanceback);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(729, 463);
            this.splitContainerControl1.SplitterPosition = 278;
            this.splitContainerControl1.TabIndex = 16;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ctlLaborPerformanceFactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ctlLaborPerformanceFactor";
            this.Size = new System.Drawing.Size(729, 463);
            ((System.ComponentModel.ISupportInitialize)(this.grdLaborPerformanceback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborPerformanceback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl grdLaborPerformanceback;
        private DevExpress.XtraCharts.ChartControl chartLaborPerformanceback;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}
