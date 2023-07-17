namespace Demo
{
    partial class Form_Signature
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
            this.pic_Signature = new System.Windows.Forms.PictureBox();
            this.btn_Savec = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Signature)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Signature
            // 
            this.pic_Signature.BackColor = System.Drawing.Color.White;
            this.pic_Signature.Location = new System.Drawing.Point(12, 12);
            this.pic_Signature.Name = "pic_Signature";
            this.pic_Signature.Size = new System.Drawing.Size(776, 369);
            this.pic_Signature.TabIndex = 0;
            this.pic_Signature.TabStop = false;
            this.pic_Signature.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_Signature_Paint);
            this.pic_Signature.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_Signature_MouseDown);
            this.pic_Signature.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_Signature_MouseMove);
            // 
            // btn_Savec
            // 
            this.btn_Savec.Location = new System.Drawing.Point(167, 397);
            this.btn_Savec.Name = "btn_Savec";
            this.btn_Savec.Size = new System.Drawing.Size(75, 35);
            this.btn_Savec.TabIndex = 1;
            this.btn_Savec.Text = "保 存";
            this.btn_Savec.UseVisualStyleBackColor = true;
            this.btn_Savec.Click += new System.EventHandler(this.btn_Savec_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(569, 397);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 35);
            this.btn_Clear.TabIndex = 2;
            this.btn_Clear.Text = "清 除";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // Form_Signature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Savec);
            this.Controls.Add(this.pic_Signature);
            this.Name = "Form_Signature";
            this.Text = "绘制电子签名";
            ((System.ComponentModel.ISupportInitialize)(this.pic_Signature)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Signature;
        private System.Windows.Forms.Button btn_Savec;
        private System.Windows.Forms.Button btn_Clear;
    }
}