using Demo.Form_UI;
using Demo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.UserControls
{
    public partial class SequenceInfo : UserControl
    {
        public SequenceModel m_Sequence { get; set; }

        public delegate void DelegateCalender(object sender, EventArgs e);
        public event DelegateCalender EventBind;

        public SequenceInfo(SequenceModel sequence)
        {
            InitializeComponent();

            m_Sequence = sequence;
            //时间控件的启用
            dtp_Start.ShowUpDown = dtp_End.ShowUpDown = true;

            GetUserTestInfo(sequence);
        }

        /// <summary>
        /// 获取用户实验信息
        /// </summary>
        private void GetUserTestInfo(SequenceModel sequence)
        {
            if (sequence != null)
            {
                lbl_TestNo.Text = sequence.TestName;
                lbl_UserName.Text = sequence.UserName;
                dtp_Start.Value = sequence.DateTimeStart;
                dtp_End.Value = sequence.DateTimeEnd;

                //超级管理员 或 用户本身显示修改按钮
                //if (Shared.UserAuthority == 1 || Shared.UserID == sequence.UserId)
                {
                    pic_UptSequence.Visible = true;
                    pic_DelSequence.Visible = true;
                }
            }

        }

        /// <summary>
        /// 修改预约时间段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_UptSequence_Click(object sender, EventArgs e)
        {
            DateTime nst = Convert.ToDateTime(dtp_Start.Text);
            DateTime net = Convert.ToDateTime(dtp_End.Text);

            //预约时间不能小于当前时间
            if (nst < DateTime.Now)
            {
                MessageBox.Show("预约时间不能小于当前时间!!!");
                return;
            }

            //结束时间不能小于开始时间
            if (net < nst)
            {
                MessageBox.Show("结束时间不能小于开始时间!!!");
                return;
            }

            //是否被预约过
            if (Form_Calender.IsCreateSequence(dtp_Start.Text, dtp_End.Text, m_Sequence.TestId))
            {
                MessageBox.Show(" 更新排期失败,此时间段内已有排期 ");
                return;
            }

            DialogResult dialog = MessageBox.Show("确认更新排期吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult.OK == dialog)
            {
                Form_Calender.list_Sequence.FirstOrDefault(m => m.UserId == m_Sequence.UserId && m.TestId == m_Sequence.TestId).DateTimeStart = Convert.ToDateTime(dtp_Start.Text);
                Form_Calender.list_Sequence.FirstOrDefault(m => m.UserId == m_Sequence.UserId && m.TestId == m_Sequence.TestId).DateTimeEnd = Convert.ToDateTime(dtp_End.Text);

                if (Form_Calender.list_Sequence.Where(m => m.UserId == m_Sequence.UserId && m.TestId == m_Sequence.TestId && m.DateTimeStart == Convert.ToDateTime(dtp_Start.Text) && m.DateTimeEnd == Convert.ToDateTime(dtp_End.Text)).Count() > 0)
                {
                    MessageBox.Show(" 更新排期成功 ");

                    EventBind?.Invoke(sender, e);
                }
                else
                {
                    MessageBox.Show(" 更新排期失败 ");
                }

                //sqlcm sqlHeper = new sqlcm();
                //string sql = $" Update T_Sequence Set DateTimeStart='{dtp_Start.Text}',DateTimeEnd='{dtp_End.Text}' Where UserId={m_Sequence.UserId} And TestId={m_Sequence.TestId} ";

                //int flag = sqlHeper.UpdataSql(sql);

                //if (flag > 0)
                //{
                //    MessageBox.Show(" 更新排期成功 ");

                //    if (EventBind != null)
                //    {
                //        EventBind(sender, e);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show(" 更新排期失败 ");
                //}
            }

        }

        private void pic_DelSequence_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("确认删除排期吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult.OK == dialog)
            {
                int flag = Form_Calender.list_Sequence.Count;

                Form_Calender.list_Sequence.Remove(Form_Calender.list_Sequence.FirstOrDefault(m => m.UserId == m_Sequence.UserId && m.TestId == m_Sequence.TestId));

                if (flag - Form_Calender.list_Sequence.Count > 0)
                {
                    MessageBox.Show(" 删除排期成功 ");

                    EventBind?.Invoke(sender, e);
                }
                else
                {
                    MessageBox.Show(" 删除排期失败 ");
                }

                //sqlcm sqlHeper = new sqlcm();
                //string sql = $" Delete T_Sequence Where UserId={m_Sequence.UserId} And TestId={m_Sequence.TestId} ";

                //int flag = sqlHeper.UpdataSql(sql);

                //if (flag > 0)
                //{
                //    MessageBox.Show(" 删除排期成功 ");

                //    if (EventBind != null)
                //    {
                //        EventBind(sender, e);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show(" 删除排期失败 ");
                //}
            }
        }
    }
}
