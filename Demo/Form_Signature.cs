using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form_Signature : Form
    {
        #region 定义变量

        private System.Drawing.Drawing2D.GraphicsPath mousePath = new System.Drawing.Drawing2D.GraphicsPath();
        //画笔透明度
        private int myAlpha = 100;
        //画笔颜色对象
        private Color myUserColor = new Color();
        //画笔宽度
        private int myPenWidth = 3;
        //签名的图片对象
        public Bitmap SavedBitmap;

        #endregion 

        public Form_Signature()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Savec_Click(object sender, EventArgs e)
        {
            try
            {
                SavedBitmap = new Bitmap(pic_Signature.Width, pic_Signature.Height);
                pic_Signature.DrawToBitmap(SavedBitmap, new Rectangle(0, 0, pic_Signature.Width, pic_Signature.Height));

                #region 保存为透明的png图片

                Bitmap bmp = SavedBitmap;
                BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                int length = data.Stride * data.Height;
                IntPtr ptr = data.Scan0;
                byte[] buff = new byte[length];
                Marshal.Copy(ptr, buff, 0, length);
                for (int i = 3; i < length; i += 4)
                {
                    if (buff[i - 1] >= 230 && buff[i - 2] >= 230 && buff[i - 3] >= 230)
                    {
                        buff[i] = 0;
                    }
                }
                Marshal.Copy(buff, 0, ptr, length);
                bmp.UnlockBits(data);
                bmp.Save(@"D:\Test\TestSaveImg.png", ImageFormat.Png);

                MessageBox.Show("保存成功");
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败，" + ex.Message);
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            pic_Signature.CreateGraphics().Clear(Color.White);
            mousePath.Reset();
        }

        private void pic_Signature_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                try
                {
                    mousePath.AddLine(e.X, e.Y, e.X, e.Y);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            pic_Signature.Invalidate();
        }

        private void pic_Signature_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mousePath.StartFigure();
            }
        }

        private void pic_Signature_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                myUserColor = System.Drawing.Color.Blue;
                myAlpha = 255;
                Pen CurrentPen = new Pen(Color.FromArgb(myAlpha, myUserColor), myPenWidth);
                e.Graphics.DrawPath(CurrentPen, mousePath);
            }
            catch { }
        }
    }
}
