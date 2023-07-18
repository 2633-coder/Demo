namespace Demo.Form_UI
{
    partial class Form_Calender
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
            this.components = new System.ComponentModel.Container();
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_SequenceAdd = new System.Windows.Forms.Button();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelMonthInfo = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_Start
            // 
            this.dtp_Start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Start.Location = new System.Drawing.Point(43, 6);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(161, 21);
            this.dtp_Start.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_SequenceAdd);
            this.panel1.Controls.Add(this.dtp_End);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.dtp_Start);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 32);
            this.panel1.TabIndex = 6;
            // 
            // btn_SequenceAdd
            // 
            this.btn_SequenceAdd.Location = new System.Drawing.Point(640, 5);
            this.btn_SequenceAdd.Name = "btn_SequenceAdd";
            this.btn_SequenceAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_SequenceAdd.TabIndex = 7;
            this.btn_SequenceAdd.Text = "增加预约";
            this.btn_SequenceAdd.UseVisualStyleBackColor = true;
            this.btn_SequenceAdd.Click += new System.EventHandler(this.btn_SequenceAdd_Click);
            // 
            // dtp_End
            // 
            this.dtp_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_End.Location = new System.Drawing.Point(310, 6);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(161, 21);
            this.dtp_End.TabIndex = 6;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Demo.Properties.Resources.开始时间;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Demo.Properties.Resources.结束时间;
            this.pictureBox2.Location = new System.Drawing.Point(263, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // panelMonthInfo
            // 
            this.panelMonthInfo.BackColor = System.Drawing.Color.White;
            this.panelMonthInfo.Location = new System.Drawing.Point(0, 33);
            this.panelMonthInfo.Name = "panelMonthInfo";
            this.panelMonthInfo.Size = new System.Drawing.Size(633, 467);
            this.panelMonthInfo.TabIndex = 7;
            this.panelMonthInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMonthInfo_Paint);
            this.panelMonthInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMonthInfo_MouseClick);
            this.panelMonthInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelMonthInfo_MouseDoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(640, 34);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(290, 466);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_Calender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 502);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelMonthInfo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_Calender";
            this.Text = "时序管理-未完成";
            this.Load += new System.EventHandler(this.Calender_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.Button btn_SequenceAdd;
        private System.Windows.Forms.Panel panelMonthInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
    }
}