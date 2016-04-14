using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Enumeration
{
    public enum RoleType
    {
        Warehouse = 0,
        Forwarder = 1,
        WTM = 2,
        Dealer = 3,
        Finance = 4,
        Cim = 5
    }

    public enum AuthType
    {
        Operator = 0,
        Supervisor = 1
    }

    [Flags]
    public enum RegionType
    {
        Beijing = 1,
        Shanghai = 2,
        Yangzhou = 4,
        Guangzhou = 8
    }

    public enum Language
    {
        /// <summary>
        /// 英文
        /// </summary>
        English = 0,

        /// <summary>
        ///简体中文
        /// </summary>
        SimplifiedChinese = 1
    }

    /// <summary>
    /// 主页面左侧功能菜单
    /// </summary>
    public enum FunctionGroupType
    {
        /// <summary>
        ///基础信息
        /// </summary>
        BaseInfor = 1,
        /// <summary>
        /// 运单管理
        /// </summary>
        TN = 2,
        /// <summary>
        /// 在途管理
        /// </summary>
        TrackManagement = 3,
        /// <summary>
        /// 成本管理
        /// </summary>
        CostManagement = 4,
        /// <summary>
        /// 投诉管理
        /// </summary>
        Complaint = 5,
        /// <summary>
        /// 运输质量管理
        /// </summary>
        TransportQuality = 6,
        /// <summary>
        /// 运单调整
        /// </summary>
        TnAdjusting = 7,
        /// <summary>
        /// 报表
        /// </summary>
        Report = 8,
        /// <summary>
        /// 系统管理
        /// </summary>
        System = 9
    }
    

    public enum FuntionType
    {
        Function = 0,
        Page = 1
    }
}
