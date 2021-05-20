using System;
using System.Collections.Generic;
using System.Text;

namespace MQTT
{
    public class ChuteData
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
        /// 格口
        /// </summary>
        private Dictionary<String,int> chutes;

        public DateTime StartDateTime { get => startDateTime; set => startDateTime = value; }
        public DateTime EndDateTime { get => endDateTime; set => endDateTime = value; }
        public int Period { get => period; set => period = value; }
        public Dictionary<String, int> Chutes { get => chutes; set => chutes = value; }
    }
}
