using Demo.Common;
using Demo.Model;
using Demo.Properties;
using Demo.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.Form_UI
{
    /// <summary>
    /// 预约实验排期
    /// </summary>
    public partial class Form_Calender : Form
    {
        private DateTime dtNow = DateTime.Now;   //初始化当天日期
        private int daysOfMonth = 30;     //初始化每月天数
        private int weekOfFirstDay = 1;   //初始化某月第一天的星期
        private int selectYear;     //初始化选择年份
        private int selectMonth;   //初始化选择月份
        private DateTime dtInfo = DateTime.Now;    //初始化日期信息
        private string[,] dateArray = new string[7, 6];   //记录日期信息
        Panel panelDateInfo = null;
        private bool flag = true; //标记是否重绘panel

        private SequenceModel _Sequence;

        Icon _Icon = Icon.FromHandle(Resources.实验室人员.GetHicon());

        /// <summary>
        /// 模拟数据
        /// </summary>
        List<SequenceModel> list_Sequence = new List<SequenceModel>() {
        new SequenceModel () {Id=1,TestId=1,TestName="TestName1",UserId=1,UserName="用户1",
            DateTimeStart=Convert.ToDateTime("2023-07-01 12:33:02"),
            DateTimeEnd=Convert.ToDateTime("2023-07-01 12:33:02"),
            DateTimeCreate=Convert.ToDateTime("2023-07-01 13:33:02")},

        new SequenceModel () {Id=2,TestId=2,TestName="TestName2",UserId=1,UserName="用户1",
            DateTimeStart=Convert.ToDateTime("2023-07-03 14:33:02"),
            DateTimeEnd=Convert.ToDateTime("2023-07-03 15:33:02"),
            DateTimeCreate=Convert.ToDateTime("2023-07-01 12:33:02")},

         new SequenceModel () {Id=3,TestId=3,TestName="TestName3",UserId=2,UserName="用户2",
             DateTimeStart=Convert.ToDateTime("2023-07-05 14:33:02"),
             DateTimeEnd=Convert.ToDateTime("2023-07-05 15:33:02"),
             DateTimeCreate=Convert.ToDateTime("2023-07-01 12:33:02")},

         new SequenceModel () {Id=4,TestId=4,TestName="TestName4",UserId=1,UserName="用户1",
             DateTimeStart=Convert.ToDateTime("2023-07-10 14:33:02"),
             DateTimeEnd=Convert.ToDateTime("2023-07-10 15:33:02"),
             DateTimeCreate=Convert.ToDateTime("2023-07-01 12:33:02")},


         new SequenceModel () {Id=5,TestId=5,TestName="TestName5",UserId=2,UserName="用户2",
             DateTimeStart=Convert.ToDateTime("2023-07-11 14:33:02"),
             DateTimeEnd=Convert.ToDateTime("2023-07-11 15:33:02"),
             DateTimeCreate=Convert.ToDateTime("2023-07-01 12:33:02")},
        };


        //static sqlcm sqlHelper = new sqlcm();

        public Button btnSequenceAdd
        {
            get
            {
                return btn_SequenceAdd;
            }

            set
            {
                btn_SequenceAdd = btnSequenceAdd;
            }
        }

        public Form_Calender(SequenceModel _sequence)
        {
            _Sequence = _sequence;
            InitializeComponent();

            GetUserTestInfo();
            DrawControls();

            //控制日期或时间的显示格式
            dtp_Start.CustomFormat = dtp_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            //使用自定义格式
            dtp_Start.Format = dtp_End.Format = DateTimePickerFormat.Custom;
            //时间控件的启用
            dtp_Start.ShowUpDown = dtp_End.ShowUpDown = true;

            dtp_Start.Value = DateTime.Now.AddMinutes(1);
            dtp_End.Value = DateTime.Now.AddMinutes(60);
        }

        private void Calender_Load(object sender, EventArgs e)
        {
            //查询排期
            SelectSequence();

            Control.ControlCollection controls = panelMonthInfo.Controls;
            foreach (Control control in controls)
            {
                if (control.GetType() == typeof(Panel))
                {
                    panelDateInfo = control as Panel;
                }
            }
        }

        #region 绘制控件
        //绘制控件
        private void DrawControls()
        {
            var btnToday = new Button();
            btnToday.Location = new System.Drawing.Point(300, 15);
            btnToday.Name = "btnToday";
            btnToday.Size = new System.Drawing.Size(80, 21);
            btnToday.TabIndex = 0;
            btnToday.Text = "跳转到今天";
            btnToday.UseVisualStyleBackColor = true;
            btnToday.Click += new System.EventHandler(this.btnToday_Click);

            var lblYear = new Label();
            lblYear.Name = "lblYear";
            lblYear.Text = "年份";
            lblYear.Location = new Point(91, 19);
            lblYear.Size = new Size(29, 20);
            lblYear.BackColor = Color.Transparent;

            var lblMonth = new Label();
            lblMonth.Name = "lblMonth";
            lblMonth.Text = "月份";
            lblMonth.Location = new Point(190, 19);
            lblMonth.Size = new Size(29, 20);
            lblMonth.BackColor = Color.Transparent;

            var cmbSelectYear = new ComboBox();
            cmbSelectYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectYear.FormattingEnabled = true;
            cmbSelectYear.Location = new Point(120, 15);
            cmbSelectYear.Name = "cmbSelectYear";
            cmbSelectYear.AutoSize = false;
            cmbSelectYear.Size = new Size(50, 20);
            cmbSelectYear.TabIndex = 0;
            cmbSelectYear.SelectionChangeCommitted += new EventHandler(cmbSelectYear_SelectionChangeCommitted);

            var cmbSelectMonth = new ComboBox();
            cmbSelectMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectMonth.FormattingEnabled = true;
            cmbSelectMonth.Location = new Point(220, 15);
            cmbSelectMonth.Name = "cmbSelectYear";
            cmbSelectMonth.AutoSize = false;
            cmbSelectMonth.Size = new Size(50, 20);
            cmbSelectMonth.TabIndex = 0;
            cmbSelectMonth.SelectionChangeCommitted += new EventHandler(cmbSelectMonth_SelectionChangeCommitted);

            var panelDateInfo = new Panel();
            panelDateInfo.BackColor = Color.White;
            panelDateInfo.Location = new Point(575, 45);
            panelDateInfo.Size = new Size(265, 390);
            panelDateInfo.Paint += new PaintEventHandler(panelDateInfo_Paint);

            var lblShowTime = new Label();
            lblShowTime.Location = new Point(600, 470);
            lblShowTime.BackColor = Color.Transparent;
            lblShowTime.AutoSize = true;
            lblShowTime.Name = "lblShowTime";

            for (int i = 1949; i <= 2049; i++)
            {
                cmbSelectYear.Items.Add(i);
                if (i == dtNow.Year)
                {
                    cmbSelectYear.SelectedItem = i;
                    selectYear = i;
                }
            }
            for (int i = 1; i <= 12; i++)
            {
                cmbSelectMonth.Items.Add(i);
                if (i == dtNow.Month)
                {
                    cmbSelectMonth.SelectedItem = i;
                    selectMonth = i;
                }
            }
            panelMonthInfo.Controls.Add(btnToday);
            panelMonthInfo.Controls.Add(lblMonth);
            panelMonthInfo.Controls.Add(lblYear);
            panelMonthInfo.Controls.Add(cmbSelectYear);
            panelMonthInfo.Controls.Add(cmbSelectMonth);
            panelMonthInfo.Controls.Add(panelDateInfo);
            panelMonthInfo.Controls.Add(lblShowTime);
        }
        #endregion

        /// <summary>
        /// 主窗体绘制月历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelMonthInfo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var pen1 = new Pen(Color.Blue, 2);
            var pen = new Pen(Color.FromArgb(201, 205, 212), 1);
            var tb = new TextureBrush(global::Demo.Properties.Resources.loading1, WrapMode.TileFlipXY);
            g.FillRectangle(tb, 0, 0, 750, 475);
            g.FillRectangle(new SolidBrush(Color.White), 5, 40, 740, 400);

            SolidBrush sb = new SolidBrush(Color.FromArgb(50, 255, 247, 241));
            g.FillRectangle(sb, 10, 45, 560, 30);

            //画横线
            g.DrawLine(pen, 10, 45, 570, 45);
            g.DrawLine(pen, 10, 75, 570, 75);
            for (int i = 1; i < 7; i++)
            {
                g.DrawLine(pen, 10, 75 + 60 * i, 570, 75 + 60 * i);
            }

            //画竖线
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(pen, 10 + 80 * i, 45, 10 + 80 * i, 435);
            }

            var solidBrushWeekday = new SolidBrush(Color.Gray);
            var solidBrushWeekend = new SolidBrush(Color.Chocolate);
            g.DrawString("日", new Font("微软雅黑", 12), solidBrushWeekend, 35, 50);
            g.DrawString("一", new Font("微软雅黑", 12), solidBrushWeekday, 115, 50);
            g.DrawString("二", new Font("微软雅黑", 12), solidBrushWeekday, 195, 50);
            g.DrawString("三", new Font("微软雅黑", 12), solidBrushWeekday, 275, 50);
            g.DrawString("四", new Font("微软雅黑", 12), solidBrushWeekday, 355, 50);
            g.DrawString("五", new Font("微软雅黑", 12), solidBrushWeekday, 435, 50);
            g.DrawString("六", new Font("微软雅黑", 12), solidBrushWeekend, 515, 50);

            if (flag)
            {
                //获取某月首日星期及某月天数
                GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, dtNow.Year, dtNow.Month);
                //绘制月历日期
                DrawDateNum(weekOfFirstDay, daysOfMonth, dtNow.Year, dtNow.Month);
                //DrawDateInfo(dtNow);
            }
        }

        /// <summary>
        /// 绘制日期信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelDateInfo_Paint(object sender, PaintEventArgs e)
        {
            if (list_Sequence != null)
            {
                List<SequenceModel> sequences = list_Sequence.Where(m => m.DateTimeStart.Date <= dtInfo.Date && m.DateTimeEnd.Date >= dtInfo.Date).ToList();

                if (sequences.Count > 0)
                {
                    foreach (var item in sequences)
                    {
                        SequenceInfo sequence = new SequenceInfo(item);
                        sequence.EventBind += btnToday_Click;
                        flowLayoutPanel1.Controls.Add(sequence);
                    }
                }
            }
        }

        /// <summary>
        /// 月份更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSelectMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flag = false;
            var cmbSelectMonth = sender as ComboBox;
            selectMonth = (int)cmbSelectMonth.SelectedItem;
            panelMonthInfo.Refresh();
            //获取某月首日星期及某月天数
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, selectYear, selectMonth);
            //绘制月历日期
            DrawDateNum(weekOfFirstDay, daysOfMonth, selectYear, selectMonth);
        }

        /// <summary>
        /// 年份更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSelectYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flag = false;
            var cmbSelectYear = sender as ComboBox;
            selectYear = (int)cmbSelectYear.SelectedItem;
            panelMonthInfo.Refresh();
            //获取某月首日星期及某月天数
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, selectYear, selectMonth);
            //绘制月历日期
            DrawDateNum(weekOfFirstDay, daysOfMonth, selectYear, selectMonth);
        }

        /// <summary>
        /// 右击日期事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelMonthInfo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X < 10 || e.X > 575)
                {
                    return;
                }
                if (e.Y < 75 || e.Y > 435)
                {
                    return;
                }
                int x = (e.X - 10) / 80;
                int y = (e.Y - 75) / 60;
                if (dateArray[x, y] == null)
                {
                    return;
                }
                DateTime dtSelect = DateTime.Parse(dateArray[x, y]);
                dtInfo = dtSelect;
            }
            flowLayoutPanel1.Controls.Clear();
            panelDateInfo.Refresh();
        }

        /// <summary>
        /// 双击日期事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelMonthInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// 日期点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToday_Click(object sender, EventArgs e)
        {
            flag = false;

            panelMonthInfo.Refresh();
            //获取某月首日星期及某月天数
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, dtNow.Year, dtNow.Month);
            //绘制月历日期
            DrawDateNum(weekOfFirstDay, daysOfMonth, dtNow.Year, dtNow.Month);
            dtInfo = dtNow;

            flowLayoutPanel1.Controls.Clear();
            panelDateInfo.Refresh();
        }

        /// <summary>
        /// 绘制月历日期
        /// </summary>
        /// <param name="firstDayofWeek"></param>
        /// <param name="endMonthDay"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        private void DrawDateNum(int firstDayofWeek, int endMonthDay, int year, int month)
        {
            DateTime dtNow = DateTime.Parse(DateTime.Now.ToShortDateString());

            var font = new Font("", 14);
            var solidBrushWeekdays = new SolidBrush(Color.Gray);
            var solidBrushWeekend = new SolidBrush(Color.Chocolate);
            var solidBrushHoliday = new SolidBrush(Color.BurlyWood);
            Graphics g = panelMonthInfo.CreateGraphics();
            int num = 1;

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (j == 0 && i < firstDayofWeek) //定义当月第一天的星期的位置
                    {
                        continue;
                    }
                    else
                    {
                        if (num > endMonthDay) //定义当月最后一天的位置
                        {
                            break;
                        }
                        //string cMonth = null;
                        //string cDay = null;
                        string cHoliday = null;
                        //string ccHoliday = null;

                        DateTime dt = DateTime.Parse(year + "-" + month + "-" + num);
                        //TimeSpan ts = dt - dtNow;
                        dateArray[i, j] = dt.ToShortDateString();

                        if (list_Sequence != null)
                        {
                            foreach (var item in list_Sequence)
                            {
                                //绘日期-图标
                                if (item.DateTimeStart.Date <= dt.Date && item.DateTimeEnd.Date >= dt.Date)
                                {
                                    //g.DrawEllipse(new Pen(Color.Chocolate, 3), (50 + 80 * i), (80 + 60 * j), 30, 15);
                                    g.DrawIcon(_Icon, (50 + 80 * i), (80 + 60 * j));
                                }
                            }
                        }

                        //cDay = ChineseDate.GetDay(dt);
                        cHoliday = ChineseDate.GetHoliday(dt);

                        if (cHoliday != null)
                        {
                            //绘阳历节日
                            //g.DrawString(cHoliday.Length > 3 ? cHoliday.Substring(0, 3) : cHoliday, new Font("", 9),solidBrushHoliday, (40 + 80 * i), (90 + 60 * j));
                        }

                        //绘日期-数值
                        g.DrawString(num.ToString(CultureInfo.InvariantCulture), font, solidBrushWeekdays, (15 + 80 * i), (105 + 60 * j));

                        num++;
                    }
                }
            }
        }

        /// <summary>
        /// 获取某月首日星期及某月天数
        /// </summary>
        /// <param name="weekOfFirstDay"></param>
        /// <param name="daysOfMonth"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        private void GetWeekInfo(ref int weekOfFirstDay, ref int daysOfMonth, int year = 1900, int month = 2, int day = 1)
        {
            DateTime dt = DateTime.Parse(year.ToString(CultureInfo.InvariantCulture) + "-" + month.ToString(CultureInfo.InvariantCulture) + "-" + day.ToString(CultureInfo.InvariantCulture));
            weekOfFirstDay = (int)dt.DayOfWeek;
            daysOfMonth = (int)DateTime.DaysInMonth(year, month);
        }

        /// <summary>
        /// 添加排期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SequenceAdd_Click(object sender, EventArgs e)
        {
            //预约时间不能小于当前时间
            if (dtp_Start.Value < DateTime.Now)
            {
                MessageBox.Show("预约时间不能小于当前时间!!!");
                return;
            }

            //结束时间不能小于开始时间
            if (dtp_End.Value < dtp_Start.Value)
            {
                MessageBox.Show("结束时间不能小于开始时间!!!");
                return;
            }

            //是否被预约排期
            if (IsCreateSequence(dtp_Start.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtp_End.Value.ToString("yyyy-MM-dd HH:mm:ss")))
            {
                MessageBox.Show("此时间段已有排期，请检查!!!");
                return;
            }

            DialogResult dialog = MessageBox.Show("确认增加排期吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult.OK == dialog)
            {
                SequenceModel sequence = new SequenceModel()
                {
                    Id = list_Sequence.Count + 1,
                    TestId = _Sequence.TestId,
                    UserId = _Sequence.UserId == 0 ? 1 : _Sequence.UserId,
                    DateTimeStart = dtp_Start.Value,
                    DateTimeEnd = dtp_End.Value,
                    DateTimeCreate = DateTime.Now,
                    UserName = _Sequence.UserName,
                    TestName = _Sequence.TestName,
                };

                //添加到数据库
                int flag = CreateSequence(sequence);

                if (flag > 0)
                {
                    MessageBox.Show("添加排期成功");
                    btn_SequenceAdd.Enabled = false;
                    btnToday_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("添加排期失败");
                }
            }

            flowLayoutPanel1.Controls.Clear();
        }

        /// <summary>
        /// 刷新排期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            SelectSequence();
        }

        /// <summary>
        /// 查询排期
        /// </summary>
        private void SelectSequence()
        {
            //string sql = " Select a.Id,a.UserId,a.TestId,a.DateTimeStart,a.DateTimeEnd,a.DateTimeCreate,b.TestName,c.UserName From T_Sequence a Join tp_testinfo b On a.TestId=b.Id Join t_userinfo c On a.UserId=c.Id ";

            //DataTable dt = sqlHelper.getTable(sql);
            //list_Sequence = DataTableExtend.ToDataList<SequenceModel>(dt);

            //if (list_Sequence == null)
            //{
            //    list_Sequence = new List<SequenceModel>();

            //    //未添加排期的实验可以在此处添加
            //    btnSequenceAdd.Enabled = true;
            //}

            //if (list_Sequence.Where(m => m.TestId == _Sequence.TestId).Count() == 0)
            //{
            //    btnSequenceAdd.Enabled = true;
            //}
            //else
            //{
            //    btnSequenceAdd.Enabled = false;
            //}
        }

        /// <summary>
        /// 添加排期
        /// </summary>
        /// <param name="sequence">排期信息</param>
        /// <returns></returns>
        private int CreateSequence(SequenceModel sequence)
        {
            //string sql = $" Insert Into T_Sequence(UserId,TestId,DateTimeStart,DateTimeEnd) Values({sequence.UserId},{sequence.TestId},'{sequence.DateTimeStart}','{sequence.DateTimeEnd}') ";

            //int flag = sqlHelper.UpdataSql_new(sql);

            //return flag;

            return 0;
        }

        /// <summary>
        /// 是否被预约排期
        /// </summary>
        /// <param name="nst">开始时间</param>
        /// <param name="net">结束时间</param>
        /// <returns></returns>
        public static bool IsCreateSequence(string nst, string net, int testId = 0)
        {
            //string sql = $" Select Count(*) From T_Sequence Where '{nst}' <=DateTimeEnd  And DateTimeStart <= '{net}' And TestId != {testId} ";

            //int flag = sqlHelper.getFristScalar(sql);

            //return flag != 0;

            return false;
        }

        /// <summary>
        /// 是否已有预约并在当前时间段内
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="testId">实验Id</param>
        /// <param name="message">out 错误消息</param>
        /// <returns></returns>
        public static bool IsSequence(int userId, int testId, out string message)
        {
            //是否有此实验的预约
            //string sql = $" Select Count(1) From T_Sequence Where UserId={userId} And TestId={testId} ";

            //if (sqlHelper.getFristScalar(sql) > 0)
            //{
            //    if (sqlHelper.getFristScalar($" {sql} And DateTimeStart<='{DateTime.Now}' And DateTimeEnd >='{DateTime.Now}' ") > 0)
            //    {
            //        message = " 有此实验并在当前时间段内 ";
            //        return true;
            //    }
            //    else
            //    {
            //        message = " 不在预约时间段内 ";
            //        return false;
            //    }
            //}
            //else
            //{
            //    message = " 此实验未预约排期 ";
            //    return false;
            //}
            message = "";
            return false;
        }

        /// <summary>
        /// 获取用户实验信息
        /// </summary>
        private void GetUserTestInfo()
        {
            //HXAWS.sqlcm sqlHelper = new HXAWS.sqlcm();

            //DataTable dt = sqlHelper.getTable($" select a.TestName,b.Id UserId,b.UserName from tp_testinfo a join t_userinfo b on a.userId=b.Id where a.Id = {_Sequence.TestId} ");

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    _Sequence.TestName = dt.Rows[0]["TestName"].ToString();
            //    _Sequence.UserName = dt.Rows[0]["UserName"].ToString();
            //}
            //else
            //{
            //    _Sequence.TestName = "实验项目0000001";
            //    _Sequence.UserName = "XXX";
            //}
        }

    }
}
