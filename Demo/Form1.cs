using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //记录位置
            int locationFlag = 1;
            //读取设备
            Dictionary<int, string> dic_Keys = new Dictionary<int, string>() { { 1, "设备1" }, { 2, "设备2" } };

            //遍历生成设备label
            foreach (var item in dic_Keys)
            {
                Label label = new Label
                {
                    Name = "lbl_Test" + item.Key,
                    Location = new Point { X = 100 * locationFlag, Y = 10 },
                    Text = item.Value,

                };

                //增加按下事件
                label.MouseDown += new MouseEventHandler(LabelMouseDown);

                //加入控件
                panel1.Controls.Add(label);

                locationFlag++;
            }
        }

        //label按下事件
        private void LabelMouseDown(object sender, MouseEventArgs e)
        {
            var lbl = (Label)sender;
            lbl.Tag = e.Location;
            DoDragDrop(lbl, DragDropEffects.Move);
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            Label label = (Label)e.Data.GetData(typeof(Label));

            //设置label距离容器上边缘之间的距离
            label.Top = this.PointToClient(new Point(e.X, e.Y)).Y - ((Point)label.Tag).Y;
            //设置label距离容器左边缘之间的距离
            label.Left = this.PointToClient(new Point(e.X, e.Y)).X - ((Point)label.Tag).X;

        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            //将拖到源的数据移动到放置目标
            e.Effect = DragDropEffects.Move;
        }

        private void panel1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Cursor.Current = Cursor;
        }
    }
}
