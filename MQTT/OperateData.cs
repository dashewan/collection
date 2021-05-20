using System;
using System.Collections.Generic;
using System.Text;

namespace MQTT
{
    public class OperateData
    {
        /// <summary>
        /// 统计开始时间
        /// </summary>
        private DateTime startDateTime;
        /// <summary>
        /// 统计结束时间
        /// </summary>
        private DateTime endDateTime;
        /// <summary>
        /// 统计周期
        /// </summary>
        private int period;
        /// <summary>
        /// 供件量
        /// </summary>
        private int supplyCount;
        /// <summary>
        /// 读码量
        /// </summary>
        private int readCount;
        /// <summary>
        /// 多条码
        /// </summary>
        private int mulIDCount;
        /// <summary>
        /// 分拣量
        /// </summary>
        private int sortCount;
        /// <summary>
        /// 异常量
        /// </summary>
        private int exceptionCount;
        public DateTime StartDateTime { get => startDateTime; set => startDateTime = value; }
        public DateTime EndDateTime { get => endDateTime; set => endDateTime = value; }
        public int Period { get => period; set => period = value; }
        public int SupplyCount { get => supplyCount; set => supplyCount = value; }
        public int ReadCount { get => readCount; set => readCount = value; }
        public int MulIDCount { get => mulIDCount; set => mulIDCount = value; }
        public int SortCount { get => sortCount; set => sortCount = value; }
        public int ExceptionCount { get => exceptionCount; set => exceptionCount = value; }
    }
}
