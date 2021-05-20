using System;
using System.Collections.Generic;
using System.Text;

namespace MQTT
{
    public class ExceptionData
    {
        public ExceptionData()
        {
            int[] codes = { 401, 402, 403, 406, 407, 408, 409, 411, 413, 414, 416, 417, 418, 419, 420, 421, 500, 501, 502, 503, 504, 505, 10000 };
            Dictionary<int, int> codeDictionary = new Dictionary<int, int>();
            for (int i = 0; i < codes.Length; i++)
            {
                codeDictionary.Add(codes[i], 0);
            }
            exceptionCode = codeDictionary;
            ///// <summary>
            ///// 无此运单信息
            ///// </summary>
            //private int Code401;
            ///// <summary>
            ///// 没有对应的分拣计划！
            ///// </summary>
            //private int Code402;
            ///// <summary>
            ///// 存在箱号数据，确认是否是重复建包或使用了旧箱号
            ///// </summary>
            //private int Code403;
            ///// <summary>
            ///// 请先称重
            ///// </summary>
            //private int Code406;
            ///// <summary>
            ///// 运单被拦截，请使用 pda 操作确认
            ///// </summary>
            //private int Code407;

            ///// <summary>
            ///// 检测到多条码上传
            ///// </summary>
            //private int Code408;
            ///// <summary>
            ///// 不是一单一件外单，不能按运单分拣
            ///// </summary>
            //private int Code409;
            ///// <summary>
            ///// 为加盟运单，未交接
            ///// </summary>
            //private int Code411;
            ///// <summary>
            ///// B网未称重量方运单，请先称重量方!
            ///// </summary>
            //private int Code413;
            ///// <summary>
            ///// 网运费寄付运单，无运费金额无法分拣!
            ///// </summary>
            //private int Code414;
            ///// <summary>
            ///// B网临时欠款运单，无重量或体积，请称重或量方
            ///// </summary>
            //private int Code416;
            ///// <summary>
            ///// B网包装服务运单，未确认包装完成，请确认!
            ///// </summary>
            //private int Code417;
            ///// <summary>
            ///// xxxx x 此单未付尾款，异常处理选 24 预售原因，换单回仓！
            ///// </summary>
            //private int Code418;
            ///// <summary>
            /////xxxx 此单为预售未付全款，需要拦截暂存，等付全款后可 继续操作！
            ///// </summary>
            //private int Code419;
            ///// <summary>
            /////没有对应的机器编码，请确认
            ///// </summary>
            //private int Code420;
            ///// <summary>
            /////分拣机不支持称重量方功能
            ///// </summary>
            //private int Code421;
            ///// <summary>
            /////内部错误
            ///// </summary>
            //private int Code500;
            ///// <summary>
            /////网络故障
            ///// </summary>
            //private int Code501;
            ///// <summary>
            /////格口故障（含格口满）
            ///// </summary>
            //private int Code502;
            ///// <summary>
            /////WCS故障
            ///// </summary>
            //private int Code503;
            ///// <summary>
            /////读码器故障
            ///// </summary>
            //private int Code504;
            ///// <summary>
            /////单件分离故障
            ///// </summary>
            //private int Code505;
            ///// <summary>
            /////参数错误
            ///// </summary>
            //private int Code10000;
        }
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
        private Dictionary<int, int> exceptionCode;
        ///// <summary>
        ///// 无此运单信息
        ///// </summary>
        //private int Code401;
        ///// <summary>
        ///// 没有对应的分拣计划！
        ///// </summary>
        //private int Code402;
        ///// <summary>
        ///// 存在箱号数据，确认是否是重复建包或使用了旧箱号
        ///// </summary>
        //private int Code403;
        ///// <summary>
        ///// 请先称重
        ///// </summary>
        //private int Code406;
        ///// <summary>
        ///// 运单被拦截，请使用 pda 操作确认
        ///// </summary>
        //private int Code407;

        ///// <summary>
        ///// 检测到多条码上传
        ///// </summary>
        //private int Code408;
        ///// <summary>
        ///// 不是一单一件外单，不能按运单分拣
        ///// </summary>
        //private int Code409;
        ///// <summary>
        ///// 为加盟运单，未交接
        ///// </summary>
        //private int Code411;
        ///// <summary>
        ///// B网未称重量方运单，请先称重量方!
        ///// </summary>
        //private int Code413;
        ///// <summary>
        ///// 网运费寄付运单，无运费金额无法分拣!
        ///// </summary>
        //private int Code414;
        ///// <summary>
        ///// B网临时欠款运单，无重量或体积，请称重或量方
        ///// </summary>
        //private int Code416;
        ///// <summary>
        ///// B网包装服务运单，未确认包装完成，请确认!
        ///// </summary>
        //private int Code417;
        ///// <summary>
        ///// xxxx x 此单未付尾款，异常处理选 24 预售原因，换单回仓！
        ///// </summary>
        //private int Code418;
        ///// <summary>
        /////xxxx 此单为预售未付全款，需要拦截暂存，等付全款后可 继续操作！
        ///// </summary>
        //private int Code419;
        ///// <summary>
        /////没有对应的机器编码，请确认
        ///// </summary>
        //private int Code420;
        ///// <summary>
        /////分拣机不支持称重量方功能
        ///// </summary>
        //private int Code421;
        ///// <summary>
        /////内部错误
        ///// </summary>
        //private int Code500;
        ///// <summary>
        /////网络故障
        ///// </summary>
        //private int Code501;
        ///// <summary>
        /////格口故障（含格口满）
        ///// </summary>
        //private int Code502;
        ///// <summary>
        /////WCS故障
        ///// </summary>
        //private int Code503;
        ///// <summary>
        /////读码器故障
        ///// </summary>
        //private int Code504;
        ///// <summary>
        /////单件分离故障
        ///// </summary>
        //private int Code505;
        ///// <summary>
        /////参数错误
        ///// </summary>
        //private int Code10000;
        public DateTime StartDateTime { get => startDateTime; set => startDateTime = value; }
        public DateTime EndDateTime { get => endDateTime; set => endDateTime = value; }
        public int Period { get => period; set => period = value; }
        public Dictionary<int, int> ExceptionCode { get => exceptionCode; set => exceptionCode = value; }
    }
}
