using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 包车扣费明细表
    /// </summary>
    public class Charter_Fee_Detail
    {
        /// <summary>
        /// 车单号
        /// </summary>
        public virtual Guid one_bill_ID { get; set; }

        /// <summary>
        /// 车队
        /// </summary>
        public virtual string motorcade { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public virtual string car_ID { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        public virtual string driver { get; set; }

        /// <summary>
        /// 运输量
        /// </summary>
        public virtual decimal transportation_volume { get; set; }

        /// <summary>
        /// 运输产值
        /// </summary>
        public virtual decimal transportation_production { get; set; }

        /// <summary>
        /// 集运量
        /// </summary>
        public virtual decimal Consolidation_volume { get; set; }

        /// <summary>
        /// 集运产值
        /// </summary>
        public virtual decimal Consolidation_production { get; set; }

        /// <summary>
        /// 司机比例
        /// </summary>
        public virtual decimal driver_ratio { get; set; }

        /// <summary>
        /// 包车费
        /// </summary>
        public virtual decimal package_fare { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string remark { get; set; }

        /// <summary>
        /// 扣费月份
        /// </summary>
        public virtual string fee_month { get; set; }

        /// <summary>
        /// 记账日期
        /// </summary>
        public virtual DateTime accounting_date { get; set; }

        /// <summary>
        /// 车队标识
        /// </summary>
        public virtual string motorcade_logo { get; set; }

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

        //此属性用于NHIBERNATE查询所需 扣费单号
        public virtual string bill_ID { get; set; }

    }
}
