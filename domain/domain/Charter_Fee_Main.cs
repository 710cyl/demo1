using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 包车扣费主表
    /// </summary>
    public class Charter_Fee_Main
    {
        /// <summary>
        /// 扣费单号
        /// </summary>
        public virtual string bill_ID { get; set; }

        /// <summary>
        /// 扣费月份
        /// </summary>
        public virtual string fee_month { get; set; }

        /// <summary>
        /// 记账日期
        /// </summary>
        public virtual DateTime accounting_date { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime start_time { get; set; }

        /// <summary>
        /// 录入人
        /// </summary>
        public virtual string inputer { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public virtual string input_time { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual string mender { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime modification_time { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public virtual DateTime deadline { get; set; }

        //一对多(需要隐藏)
        public virtual IList<Charter_Fee_Detail> cfd { get; set; }


    }
}
