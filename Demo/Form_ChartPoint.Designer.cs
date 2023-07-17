namespace Demo
{
    partial class Form_ChartPoint
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel_Head = new System.Windows.Forms.Panel();
            this.btn_DataShow = new System.Windows.Forms.Button();
            this.cmb_CellType = new System.Windows.Forms.ComboBox();
            this.btn_Interval = new System.Windows.Forms.Button();
            this.btn_MajorGrid = new System.Windows.Forms.Button();
            this.btn_SaveImg = new System.Windows.Forms.Button();
            this.btn_LoadData = new System.Windows.Forms.Button();
            this.pbxWatingScan = new System.Windows.Forms.PictureBox();
            this.panel_Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel_Head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxWatingScan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Body
            // 
            this.panel_Body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Body.Controls.Add(this.chart1);
            this.panel_Body.Location = new System.Drawing.Point(0, 50);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(800, 400);
            this.panel_Body.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea6.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea6);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(800, 400);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // panel_Head
            // 
            this.panel_Head.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Head.BackColor = System.Drawing.Color.White;
            this.panel_Head.Controls.Add(this.pbxWatingScan);
            this.panel_Head.Controls.Add(this.btn_LoadData);
            this.panel_Head.Controls.Add(this.btn_DataShow);
            this.panel_Head.Controls.Add(this.cmb_CellType);
            this.panel_Head.Controls.Add(this.btn_Interval);
            this.panel_Head.Controls.Add(this.btn_MajorGrid);
            this.panel_Head.Controls.Add(this.btn_SaveImg);
            this.panel_Head.Location = new System.Drawing.Point(0, 0);
            this.panel_Head.Name = "panel_Head";
            this.panel_Head.Size = new System.Drawing.Size(800, 51);
            this.panel_Head.TabIndex = 2;
            // 
            // btn_DataShow
            // 
            this.btn_DataShow.Location = new System.Drawing.Point(241, 11);
            this.btn_DataShow.Name = "btn_DataShow";
            this.btn_DataShow.Size = new System.Drawing.Size(75, 30);
            this.btn_DataShow.TabIndex = 4;
            this.btn_DataShow.Text = "显示值";
            this.btn_DataShow.UseVisualStyleBackColor = true;
            this.btn_DataShow.Click += new System.EventHandler(this.btn_DataShow_Click);
            // 
            // cmb_CellType
            // 
            this.cmb_CellType.FormattingEnabled = true;
            this.cmb_CellType.Location = new System.Drawing.Point(109, 16);
            this.cmb_CellType.Name = "cmb_CellType";
            this.cmb_CellType.Size = new System.Drawing.Size(121, 20);
            this.cmb_CellType.TabIndex = 3;
            this.cmb_CellType.SelectedIndexChanged += new System.EventHandler(this.cmb_CellType_SelectedIndexChanged);
            // 
            // btn_Interval
            // 
            this.btn_Interval.Location = new System.Drawing.Point(327, 11);
            this.btn_Interval.Name = "btn_Interval";
            this.btn_Interval.Size = new System.Drawing.Size(75, 30);
            this.btn_Interval.TabIndex = 2;
            this.btn_Interval.Text = "间隔";
            this.btn_Interval.UseVisualStyleBackColor = true;
            this.btn_Interval.Click += new System.EventHandler(this.btn_Interval_Click);
            // 
            // btn_MajorGrid
            // 
            this.btn_MajorGrid.Location = new System.Drawing.Point(413, 11);
            this.btn_MajorGrid.Name = "btn_MajorGrid";
            this.btn_MajorGrid.Size = new System.Drawing.Size(75, 30);
            this.btn_MajorGrid.TabIndex = 1;
            this.btn_MajorGrid.Text = "网格";
            this.btn_MajorGrid.UseVisualStyleBackColor = true;
            this.btn_MajorGrid.Click += new System.EventHandler(this.btn_MajorGrid_Click);
            // 
            // btn_SaveImg
            // 
            this.btn_SaveImg.Location = new System.Drawing.Point(499, 11);
            this.btn_SaveImg.Name = "btn_SaveImg";
            this.btn_SaveImg.Size = new System.Drawing.Size(75, 30);
            this.btn_SaveImg.TabIndex = 0;
            this.btn_SaveImg.Text = "保存图片";
            this.btn_SaveImg.UseVisualStyleBackColor = true;
            this.btn_SaveImg.Click += new System.EventHandler(this.btn_SaveImg_Click);
            // 
            // btn_LoadData
            // 
            this.btn_LoadData.Location = new System.Drawing.Point(12, 10);
            this.btn_LoadData.Name = "btn_LoadData";
            this.btn_LoadData.Size = new System.Drawing.Size(75, 30);
            this.btn_LoadData.TabIndex = 5;
            this.btn_LoadData.Text = "数据加载";
            this.btn_LoadData.UseVisualStyleBackColor = true;
            this.btn_LoadData.Click += new System.EventHandler(this.btn_LoadData_Click);
            // 
            // pbxWatingScan
            // 
            this.pbxWatingScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxWatingScan.Image = global::Demo.Properties.Resources.loading1;
            this.pbxWatingScan.Location = new System.Drawing.Point(690, -29);
            this.pbxWatingScan.Name = "pbxWatingScan";
            this.pbxWatingScan.Size = new System.Drawing.Size(110, 110);
            this.pbxWatingScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxWatingScan.TabIndex = 6;
            this.pbxWatingScan.TabStop = false;
            // 
            // Form_ChartPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_Head);
            this.Controls.Add(this.panel_Body);
            this.Name = "Form_ChartPoint";
            this.Text = "绘制散点图";
            this.Load += new System.EventHandler(this.Form_ChartPoint_Load);
            this.panel_Body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel_Head.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxWatingScan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Body;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel_Head;
        private System.Windows.Forms.ComboBox cmb_CellType;
        private System.Windows.Forms.Button btn_Interval;
        private System.Windows.Forms.Button btn_MajorGrid;
        private System.Windows.Forms.Button btn_SaveImg;
        private System.Windows.Forms.Button btn_DataShow;
        private System.Windows.Forms.Button btn_LoadData;
        private System.Windows.Forms.PictureBox pbxWatingScan;
    }
}