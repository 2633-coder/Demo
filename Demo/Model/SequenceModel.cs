using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    /// <summary>
    /// 时序实体
    /// </summary>
    public class SequenceModel
    {
        /// <summary>
        /// 时序编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 实验ID
        /// </summary>
        public int TestId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime DateTimeStart { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime DateTimeEnd { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DateTimeCreate { get; set; }
    }
}
