using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Demo.Form_UI
{
    public partial class Form_ChartPoint : Form
    {
        public Form_ChartPoint()
        {
            InitializeComponent();

            chart1.ChartAreas[0].AxisY.Minimum = 0;
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_ChartPoint_Load(object sender, EventArgs e)
        {
            GroupDataBind();
        }

        #region 事件
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadData_Click(object sender, EventArgs e)
        {
            GroupDataBind();
        }

        /// <summary>
        /// 数值显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DataShow_Click(object sender, EventArgs e)
        {
            try
            {
                int index = cmb_CellType.SelectedIndex - 1;

                //非全选细胞类别
                if (index >= 0)
                {
                    chart1.Series[index].IsValueShownAsLabel = !chart1.Series[index].IsValueShownAsLabel;
                }
                else
                {
                    foreach (var item in chart1.Series)
                    {
                        item.IsValueShownAsLabel = !item.IsValueShownAsLabel;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置间隔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Interval_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                chart1.ChartAreas[0].AxisX.Interval = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置网格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MajorGrid_Click(object sender, EventArgs e)
        {
            try
            {
                //网格显示状态
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = !chart1.ChartAreas[0].AxisX.MajorGrid.Enabled;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveImg_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "JPEG文件|*.jpg";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                chart1.SaveImage(savefile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        /// <summary>
        /// 隐藏未选中细胞数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_CellType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmb_CellType.SelectedIndex - 1;

            //显示全部
            if (index < 0)
            {
                foreach (var item in chart1.Series)
                {
                    item.Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < chart1.Series.Count; i++)
                {
                    //隐藏非选中细胞类型
                    if (i != index)
                    {
                        chart1.Series[i].Enabled = false;
                    }
                    else
                    {
                        chart1.Series[i].Enabled = true;
                    }
                }
            }
        }
        #endregion

        #region 数据处理

        /// <summary>
        /// 读取数据库数据
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            return dt;
        }

        private void ComboBoxBind(List<StatementKey> statementKeys)
        {
            try
            {
                statementKeys.Insert(0, new StatementKey { CellTypeId = 0, CellName = "ALL" });

                this.Invoke(new Action(() =>
                {
                    cmb_CellType.DisplayMember = "CellName";
                    cmb_CellType.ValueMember = "CellTypeId";
                    cmb_CellType.DataSource = statementKeys;
                }));

                //cmb_CellType.Items.Clear();
                //this.Invoke(new Action(() =>
                //{
                //    cmb_CellType.Items.Add("ALL");

                //    foreach (var item in statementKeys)
                //    {
                //        cmb_CellType.Items.Add(item.CellName);
                //    }
                //}));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void GroupDataBind()
        {
            try
            {
                Task.Run(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        pbxWatingScan.Visible = true;
                    }));

                    Dictionary<int, List<Statement>> dic_statements = new Dictionary<int, List<Statement>>();
                    List<StatementKey> statementKeys = new List<StatementKey>();
                    List<Statement> statements = new List<Statement>();
                    DataTable dt = GetDataTable();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //dt 转 List
                    }
                    else
                    {
                        #region 测试数据

                        statements = new List<Statement> {
                new Statement{ Titer="9.242",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP01A1",SrcBarcode="96WP01",SrcWell="A1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="7.174",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP01B1",SrcBarcode="96WP01",SrcWell="B1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="1.46",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP01C1",SrcBarcode="96WP01",SrcWell="C1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="6.892",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP01D1",SrcBarcode="96WP01",SrcWell="D1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="0.796",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP01E1",SrcBarcode="96WP01",SrcWell="E1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="2.469",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP01F1",SrcBarcode="96WP01",SrcWell="F1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="8.094",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP01G1",SrcBarcode="96WP01",SrcWell="G1",Action=1,Method=1,TestId=1,Well="00"},

                new Statement{ Titer="4.493",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP02A1",SrcBarcode="96WP02",SrcWell="A1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="2.497",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP02B1",SrcBarcode="96WP02",SrcWell="B1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="2.581",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP02C1",SrcBarcode="96WP02",SrcWell="C1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="6.004",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP02D1",SrcBarcode="96WP02",SrcWell="D1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="5.311",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP02E1",SrcBarcode="96WP02",SrcWell="E1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="5.727",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP02F1",SrcBarcode="96WP02",SrcWell="F1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="3.869",Cell_Name="CellName1",CellTypeId=1,BarcodeWell="96WP02G1",SrcBarcode="96WP02",SrcWell="G1",Action=1,Method=1,TestId=1,Well="00"},

                new Statement{ Titer="5.913",Cell_Name="CellName2",CellTypeId=2,BarcodeWell="96WP11A1",SrcBarcode="96WP11",SrcWell="A1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="8.249",Cell_Name="CellName2",CellTypeId=2,BarcodeWell="96WP11B1",SrcBarcode="96WP11",SrcWell="B1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="6.597",Cell_Name="CellName2",CellTypeId=2,BarcodeWell="96WP11C1",SrcBarcode="96WP11",SrcWell="C1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="3.815",Cell_Name="CellName2",CellTypeId=2,BarcodeWell="96WP11D1",SrcBarcode="96WP11",SrcWell="D1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="9.496",Cell_Name="CellName2",CellTypeId=2,BarcodeWell="96WP11E1",SrcBarcode="96WP11",SrcWell="E1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="0.606",Cell_Name="CellName2",CellTypeId=2,BarcodeWell="96WP11F1",SrcBarcode="96WP11",SrcWell="F1",Action=1,Method=1,TestId=1,Well="00"},
                new Statement{ Titer="1.182",Cell_Name="CellName2",CellTypeId=2,BarcodeWell="96WP11G1",SrcBarcode="96WP11",SrcWell="G1",Action=1,Method=1,TestId=1,Well="00"},
                };

                        #endregion
                    }

                    //读取Titer值为0则替换为0.0001 （从数据库取出时就可替换）
                    foreach (Statement statement in statements.Where(m => m.Titer.Equals("0")))
                    {
                        statement.Titer = "0.0001";
                    }

                    //按细胞种类分组
                    foreach (var item in statements.GroupBy(m => m.CellTypeId))
                    {
                        dic_statements.Add(item.Key, item.ToList());
                        statementKeys.Add(new StatementKey
                        {
                            CellTypeId = item.Key,
                            CellName = item.FirstOrDefault(m => m.CellTypeId.Equals(item.Key)).Cell_Name
                        });
                    }

                    //生成Series
                    for (int i = 1; i <= dic_statements.Count; i++)
                    {
                        double[] titerArr = new double[statements.Count];
                        string[] keyArr = new string[statements.Count];

                        int index = 0;
                        //填充X轴数据
                        foreach (Statement statement in statements)
                        {
                            keyArr[index++] = statement.BarcodeWell;
                        }

                        index = 0;
                        if (i == 1)
                        {
                            index = 0;
                        }
                        else
                        {
                            foreach (var item in dic_statements.Where(m => m.Key < i))
                            {
                                index += item.Value.Count();
                            }
                        }

                        //填充Y轴数据
                        foreach (Statement statement in dic_statements[i])
                        {
                            titerArr[index] = Convert.ToDouble(statement.Titer);
                            index++;
                        }

                        Series series = new Series()
                        {
                            ChartType = SeriesChartType.Point,
                            Name = dic_statements[i][0].Cell_Name + "_" + i,
                            MarkerSize = 9,
                            ToolTip = "当前：#VAL\n最高：#MAX\n最低：#MIN"
                        };
                        series.Points.DataBindXY(keyArr, titerArr);

                        foreach (DataPoint item in series.Points)
                        {
                            if (item.XValue == 0 && item.YValues[0] == 0)
                            {
                                item.YValues[0] = -1;
                            }
                        }

                        this.Invoke((Action)(() =>
                        {
                            chart1.Series.Add(series);
                        }));
                    }

                    //下拉绑定
                    ComboBoxBind(statementKeys);

                    this.Invoke(new Action(() =>
                    {
                        pbxWatingScan.Visible = false;
                    }));
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                this.Invoke((Action)(() =>
                {
                    pbxWatingScan.Visible = false;
                }));
            }
        }

        #endregion

  
    }

    public class Statement
    {
        public string SrcBarcode { get; set; }
        public string SrcWell { get; set; }
        public int Action { get; set; }
        public int Method { get; set; }
        public int TestId { get; set; }
        public string BarcodeWell { get; set; }
        public string Well { get; set; }
        public string Titer { get; set; }
        public int CellTypeId { get; set; }
        public string Cell_Name { get; set; }
    }

    public class StatementKey
    {
        public int CellTypeId { get; set; }
        public string CellName { get; set; }
    }
}
