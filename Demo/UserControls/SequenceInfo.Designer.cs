namespace Demo.UserControls
{
    partial class SequenceInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_TestNo = new System.Windows.Forms.Label();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.pic_UptSequence = new System.Windows.Forms.PictureBox();
            this.pic_DelSequence = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_UptSequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DelSequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_TestNo
            // 
            this.lbl_TestNo.AutoSize = true;
            this.lbl_TestNo.Location = new System.Drawing.Point(72, 77);
            this.lbl_TestNo.Name = "lbl_TestNo";
            this.lbl_TestNo.Size = new System.Drawing.Size(83, 12);
            this.lbl_TestNo.TabIndex = 4;
            this.lbl_TestNo.Text = "2023071700001";
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Location = new System.Drawing.Point(72, 126);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(35, 12);
            this.lbl_UserName.TabIndex = 5;
            this.lbl_UserName.Text = "用户1";
            // 
            // dtp_Start
            // 
            this.dtp_Start.CustomFormat = " yyyy-MM-dd HH:mm:ss";
            this.dtp_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Start.Location = new System.Drawing.Point(71, 173);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(167, 21);
            this.dtp_Start.TabIndex = 6;
            // 
            // dtp_End
            // 
            this.dtp_End.CustomFormat = " yyyy-MM-dd HH:mm:ss";
            this.dtp_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_End.Location = new System.Drawing.Point(71, 223);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(167, 21);
            this.dtp_End.TabIndex = 7;
            // 
            // pic_UptSequence
            // 
            this.pic_UptSequence.Image = global::Demo.Properties.Resources.修改;
            this.pic_UptSequence.Location = new System.Drawing.Point(150, 16);
            this.pic_UptSequence.Name = "pic_UptSequence";
            this.pic_UptSequence.Size = new System.Drawing.Size(30, 30);
            this.pic_UptSequence.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_UptSequence.TabIndex = 9;
            this.pic_UptSequence.TabStop = false;
            this.pic_UptSequence.Tag = "实验编号";
            this.pic_UptSequence.Visible = false;
            this.pic_UptSequence.Click += new System.EventHandler(this.pic_UptSequence_Click);
            // 
            // pic_DelSequence
            // 
            this.pic_DelSequence.Image = global::Demo.Properties.Resources.删除;
            this.pic_DelSequence.Location = new System.Drawing.Point(206, 15);
            this.pic_DelSequence.Name = "pic_DelSequence";
            this.pic_DelSequence.Size = new System.Drawing.Size(32, 32);
            this.pic_DelSequence.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_DelSequence.TabIndex = 8;
            this.pic_DelSequence.TabStop = false;
            this.pic_DelSequence.Tag = "实验编号";
            this.pic_DelSequence.Visible = false;
            this.pic_DelSequence.Click += new System.EventHandler(this.pic_DelSequence_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Demo.Properties.Resources.结束时间;
            this.pictureBox2.Location = new System.Drawing.Point(18, 217);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Demo.Properties.Resources.开始时间;
            this.pictureBox3.Location = new System.Drawing.Point(18, 167);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Demo.Properties.Resources.实验室人员;
            this.pictureBox1.Location = new System.Drawing.Point(18, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pic
            // 
            this.pic.Image = global::Demo.Properties.Resources.实验编号;
            this.pic.Location = new System.Drawing.Point(18, 67);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(32, 32);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Tag = "实验编号";
            // 
            // SequenceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pic_UptSequence);
            this.Controls.Add(this.pic_DelSequence);
            this.Controls.Add(this.dtp_End);
            this.Controls.Add(this.dtp_Start);
            this.Controls.Add(this.lbl_UserName);
            this.Controls.Add(this.lbl_TestNo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pic);
            this.Name = "SequenceInfo";
            this.Size = new System.Drawing.Size(260, 264);
            ((System.ComponentModel.ISupportInitialize)(this.pic_UptSequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DelSequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbl_TestNo;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.PictureBox pic_DelSequence;
        private System.Windows.Forms.PictureBox pic_UptSequence;
    }
}
