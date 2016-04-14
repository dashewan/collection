using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCodeFirstConventions;
using EFCodeFirstConventions.Conventions;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using Model.SysManagement;

namespace Core.Entities
{
    public class DbContext : ExtendedDbContext
    {
        public DbContext()
            : base(ConfigurationManager.ConnectionStrings["Entities"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<HotSpot>()
            //.HasRequired(m => m.ProjectDetail)
            //.WithMany(t => t.HotSpot)
            //.HasForeignKey(m => m.ProjectDetailID)
            //.WillCascadeOnDelete(false);

            //modelBuilder.Entity<HotSpot>()
            //            .HasRequired(m => m.ProjectDetailIsLinked)
            //            .WithMany(t => t.HotSpotLinked)
            //            .HasForeignKey(m => m.LinkProjectDetailID)
            //            .WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        protected override void AddConventions()
        {
            AddConvention(new EtendedStringConvention());
            AddConvention(new GenericDecimalConvention());
            AddConvention(new PercentConvention());
            AddConvention(new ExtendedDecimalConvention());
        }

        public DbSet<SysException> SysException { get; set; }
        public DbSet<SysOrganization> SysOrganization { get; set; }
        public DbSet<SysRole> SysRole { get; set; }
        public DbSet<SysFunction> SysFunction { get; set; }
        public DbSet<SysRoleFunction> SysRoleFunction { get; set; }
        public DbSet<SysDataAuth> SysDataAuth { get; set; }
        //public DbSet<SysDataForwarder> SysDataForwarder { get; set; }
        public DbSet<SysUser> SysUser { get; set; }
        public DbSet<SysUserRole> SysUserRole { get; set; }
        public DbSet<SysModule> SysModule { get; set; }
        //public DbSet<CBasCity> BasCity { get; set; }
        //public DbSet<CBasVehicle> CBasVehicle { get; set; }//车辆信息
        //public DbSet<CBasPackage> CBasPackage { get; set; }//包装类型
        //public DbSet<CBasPackageOffice> CBasPackageOffice { get; set; }//包装类型明细
        //public DbSet<CBasAttachment> BasAttachment { get; set; }//附件信息

        //public DbSet<CBasProvince> CBasProvince { get; set; }//省份信息

        //public DbSet<CBasCodeType> CBasCodeType { get; set; }//数据字典
        //public DbSet<CBasCurrency> CBasCurrency { get; set; }//币别
        //public DbSet<CBasCodeDef> CBasCodeDef { get; set; }//数据字典明细
        //public DbSet<CBasFrtType> CBasFrtType { get; set; }//费用类型
        //public DbSet<CBasFrtDef> CBasFrtDef { get; set; }//费用名称

        //public DbSet<CAccFreight> CAccFreight { get; set; }//费用录入
        //public DbSet<CAccLedgerComp> CAccLedgerComp { get; set; }//成本对账
        //public DbSet<CAccLedgerCompDetail> CAccLedgerCompDetail { get; set; }//成本对账明细
        //public DbSet<CBasStatusType> CBasStatusType { get; set; }//状态管理
        //public DbSet<CBasStatusValue> CBasStatusValue { get; set; }//状态管理明细

        //public DbSet<CTmsOrderTrack> CTmsorderTrack { get; set; }//在途跟踪
        //public DbSet<CTmsOrderTrackNew> CTmsOrderTrackNew { get; set; }//在途跟踪新

        //public DbSet<CAccBudgetControl> CAccBudgetControl { get; set; }//预算控制

        //#region 客户、承运商
        //public DbSet<CCimCust> CimCust { get; set; }
        //public DbSet<CCimCustAdd> CimCustAdd { get; set; }
        //public DbSet<CCimRelatedOffice> CimRelatedOffice { get; set; }
        //public DbSet<CCimCustGroup> CimCustGroup { get; set; }
        //public DbSet<CCimCustGroup_Cust> CimCustGroup_Cust { get; set; }
        ////public DbSet<CCimCustGroup_TnType> CustGroup_TnType { get; set; }
        //#endregion

        //#region 运价合同
        //public DbSet<CCimCustContract> CimCustContract { get; set; }
        //public DbSet<CCimCustRoute> CimCustRoute { get; set; }
        //public DbSet<CCimCustRoutePoint> CimCustRoutePoint { get; set; }
        //public DbSet<CCimFreightProtocol> CimFreightProtocol { get; set; }
        //public DbSet<CCimFreightRate> CimFreightRate { get; set; }

        //public DbSet<Domain.CIMCs.CCimCustContractCs> CimCustContractCs { get; set; }
        //public DbSet<Domain.CIMCs.CCimCustRouteCs> CimCustRouteCs { get; set; }
        //public DbSet<Domain.CIMCs.CCimCustRoutePointCs> CimCustRoutePointCs { get; set; }
        //public DbSet<Domain.CIMCs.CCimFreightProtocolCs> CimFreightProtocolCs { get; set; }
        //public DbSet<Domain.CIMCs.CCimFreightRateCs> CimFreightRateCs { get; set; }
        //#endregion

        //#region 运单管理
        //public DbSet<CTmsOrder> CTmsOrder { get; set; }
        //public DbSet<CTmsOrderDetail> CTmsOrderDetail { get; set; }
        //public DbSet<CTmsOrderSign> CTmsOrderSign { get; set; }
        //public DbSet<CTmsDispatch> CTmsDispatch { get; set; }
        //public DbSet<CTmsOrderConditionConfig> CTmsOrderConditionConfig { get; set; }
        //#endregion

        //#region 投诉管理
        //public DbSet<CTmsComplaint> TmsComplaint { get; set; }
        //#endregion

        //#region 报表
        ////public DbSet<CCostReport> CostReport { get; set; }//成本报告
        //#endregion

        //#region 合同导入
        //public DbSet<CCustContractFtlTemplate> CustContractFtlTemplate { get; set; }
        //public DbSet<CCustContractNotFtlTemplate> CustContractNotFtlTemplate { get; set; }
        //public DbSet<Domain.CIMCs.CCustContractFtlTemplateCs> CustContractFtlTemplateCs { get; set; }
        //public DbSet<Domain.CIMCs.CCustContractNotFtlTemplateCs> CustContractNotFtlTemplateCs { get; set; }
        //#endregion

        //#region 城市距离信息
        //public DbSet<CBasCityWarehouseDistance> CBasCityWarehouseDistance { get; set; }
        //#endregion

        ///// <summary>
        ///// PDC-Forwarder配置
        ///// </summary>
        //public DbSet<CBasPdcForwarder> CBasPdcForwarder { get; set; }

        //public DbSet<CLogRecord> CLogRecord { get; set; }//日志表

        //#region 退回类型运单,上传方式创建
        //public DbSet<CTmsReturnUpload> CTmsReturnUpload { get; set; }//运单主表
        //public DbSet<CTmsReturnUploadDetail> CTmsReturnUploadDetail { get; set; }//运单从表
        //#endregion

        //#region 退回类型运单上传日志
        //public DbSet<CLogReturnTnUpload> CLogReturnTnUpload { get; set; }
        //#endregion
    }
}
