using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Data;
using System.Collections.Generic;

namespace Core.Utility
{
    public class NPOIHelper
    {
        private static HSSFWorkbook hssfworkbook;

        /// <summary>
        /// 初始化Excel文件
        /// </summary>
        /// <param name="path"></param>
        private static void InitializeWorkbook(string path)
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
        }

        /// <summary>
        /// 读取Excel文件内容转换为DataTable对象
        /// </summary>
        /// <returns></returns>
        public static DataSet ConvertToDataTable(List<string> paths)
        {
            //初始化返回对象
            DataSet ds = new DataSet();
            //表一(主表)
            DataTable dt = new DataTable();
            #region 创建表头(20列)
            dt.Columns.Add("TN_TYPE");
            dt.Columns.Add("CONSIGNEE");
            dt.Columns.Add("CONSIGNEE_CITY");
            dt.Columns.Add("CONSIGNEE_ADDRESS");
            dt.Columns.Add("CONSIGNEE_CONTACT_PERSON");
            dt.Columns.Add("CONSIGNEE_PHONE_NO");
            dt.Columns.Add("DEALER_CODE");
            dt.Columns.Add("SHIPPER");
            dt.Columns.Add("SHIPPER_CITY");
            dt.Columns.Add("SHIPPER_ADDRESS");
            dt.Columns.Add("SHIPPER_CONTACT");
            dt.Columns.Add("SHIPPER_PHONE_NO");
            dt.Columns.Add("TN_PROPERTY");
            dt.Columns.Add("LIQUID_GOODS");
            dt.Columns.Add("DANGEROUS_GOODS");
            dt.Columns.Add("BULKY_GOODS");
            dt.Columns.Add("TOTAL_PACKGE");
            dt.Columns.Add("TOTAL_CBM");
            dt.Columns.Add("TOTAL_WEIGHT");
            dt.Columns.Add("TN_ID");//主表ID
            dt.Columns.Add("TRUCK_TYPE");
            dt.Columns.Add("RT_NO");
            dt.Columns.Add("TRANSPORT_MODE");
            dt.Columns.Add("TRANSPORT_TYPE");
            dt.Columns.Add("PICKUP_TIME");//退回时间
            dt.Columns.Add("FORWARDER");
            dt.Columns.Add("IS_TEMP_ADDRESS");
            dt.Columns.Add("IS_FRAGILE");//易碎
            #endregion

            //表二(详细条目)
            DataTable dt2 = new DataTable();
            #region 创建表行头
            dt2.Columns.Add("Line");//行
            dt2.Columns.Add("CaseNum");//箱号
            dt2.Columns.Add("CaseType");//包装类型
            dt2.Columns.Add("Length");//长
            dt2.Columns.Add("Width");//宽
            dt2.Columns.Add("Height");//高
            dt2.Columns.Add("Weight");//重量
            dt2.Columns.Add("ReturnType");//退回类型
            dt2.Columns.Add("Remark");//备注
            dt2.Columns.Add("TN_ID");//关联的主表ID
            dt2.Columns.Add("ErrMark");//有错误信息时的标记
            dt2.Columns.Add("ErrMsg");//记录错误信息
            #endregion

            //表三(存储货物详细的错误信息)
            DataTable dt3 = new DataTable();
            #region 创建表行头
            dt3.Columns.Add("Line");//行
            dt3.Columns.Add("CaseNum");//箱号
            dt3.Columns.Add("CaseType");//包装类型
            dt3.Columns.Add("Length");//长
            dt3.Columns.Add("Width");//宽
            dt3.Columns.Add("Height");//高
            dt3.Columns.Add("Weight");//重量
            dt3.Columns.Add("ReturnType");//退回类型
            dt3.Columns.Add("Remark");//备注
            dt3.Columns.Add("TN_ID");//关联的主表ID
            dt3.Columns.Add("ErrMark");//有错误信息时的标记
            dt3.Columns.Add("ErrMsg");//记录错误信息
            #endregion


            #region 循环多个上传的文件(处理批量上传和单文件上传)
            for (int l = 0; l < paths.Count; l++)
            {
                //初始化一个主表行ID
                string tnid = Guid.NewGuid().ToString();

                //根据给定的文件路径,初始化Excel到NPOI组件
                InitializeWorkbook(paths[l]);

                //获取Excel中的Sheet数量
                int sheetNum = hssfworkbook.NumberOfSheets;

                #region 读取第一张Sheet(主表)
                ISheet sheet = hssfworkbook.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                #region 添加表详细(多行数据整合成一行数据)
                //读取一行
                rows.MoveNext();//跳过一行,标题行
                rows.MoveNext();//真正的内容行
                IRow row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();

                #region 固定格式读取主表列信息

                #region 读取第一列:运单类型的值
                ICell cell = row.GetCell(1);//第二行第二格
                if (cell == null)
                {
                    dr[0] = null;
                }
                else
                {
                    dr[0] = cell.ToString();
                }
                #endregion

                //移动一行
                rows.MoveNext();
                row = (HSSFRow)rows.Current;

                #region 读取第二列:收货单位的值
                cell = row.GetCell(1);//第三行第二格
                if (cell == null)
                {
                    dr[1] = null;
                }
                else
                {
                    dr[1] = cell.ToString();
                }
                #endregion

                #region 读取第三列:收货城市的值
                cell = row.GetCell(3);
                if (cell == null)
                {
                    dr[2] = null;
                }
                else
                {
                    dr[2] = cell.ToString();
                }
                #endregion

                #region 读取第四列:收货地址的值
                cell = row.GetCell(5);
                if (cell == null)
                {
                    dr[3] = null;
                }
                else
                {
                    dr[3] = cell.ToString();
                }
                #endregion

                #region 读取第五列:联系人的值
                cell = row.GetCell(7);
                if (cell == null)
                {
                    dr[4] = null;
                }
                else
                {
                    dr[4] = cell.ToString();
                }
                #endregion

                #region 读取第六列:收货方联系电话的值
                cell = row.GetCell(9);
                if (cell == null)
                {
                    dr[5] = null;
                }
                else
                {
                    dr[5] = cell.ToString();
                }
                #endregion

                //移动一行
                rows.MoveNext();
                row = (HSSFRow)rows.Current;

                #region 读取第七列:Dealer Code的值
                cell = row.GetCell(1);
                if (cell == null)
                {
                    dr[6] = null;
                }
                else
                {
                    dr[6] = cell.ToString();
                }
                #endregion

                #region 读取第八列:发货单位的值
                cell = row.GetCell(3);
                if (cell == null)
                {
                    dr[7] = null;
                }
                else
                {
                    dr[7] = cell.ToString();
                }
                #endregion

                #region 读取第九列:发货城市的值
                cell = row.GetCell(5);
                if (cell == null)
                {
                    dr[8] = null;
                }
                else
                {
                    dr[8] = cell.ToString();
                }
                #endregion

                #region 读取第十列:发货地址的值
                cell = row.GetCell(7);
                if (cell == null)
                {
                    dr[9] = null;
                }
                else
                {
                    dr[9] = cell.ToString();
                }
                #endregion

                #region 读取第十一列:发货联系人的值
                cell = row.GetCell(9);
                if (cell == null)
                {
                    dr[10] = null;
                }
                else
                {
                    dr[10] = cell.ToString();
                }
                #endregion

                //移动一行
                rows.MoveNext();
                row = (HSSFRow)rows.Current;

                #region 读取第十二列:发货方联系电话的值
                cell = row.GetCell(1);
                if (cell == null)
                {
                    dr[11] = null;
                }
                else
                {
                    dr[11] = cell.ToString();
                }
                #endregion

                #region 读取第十三列:货物属性的值
                cell = row.GetCell(3);
                if (cell == null)
                {
                    dr[12] = null;
                }
                else
                {
                    dr[12] = cell.ToString();
                }
                #endregion

                //移动一行
                rows.MoveNext();//空一行
                rows.MoveNext();
                row = (HSSFRow)rows.Current;

                #region 读取第十四列:有液体的值
                cell = row.GetCell(1);
                if (cell == null)
                {
                    dr[13] = null;
                }
                else
                {
                    dr[13] = cell.ToString();
                }
                #endregion

                #region 读取第十五列:有危险品的值
                cell = row.GetCell(3);
                if (cell == null)
                {
                    dr[14] = null;
                }
                else
                {
                    dr[14] = cell.ToString();
                }
                #endregion

                #region 读取第十六列:超大货的值
                cell = row.GetCell(5);
                if (cell == null)
                {
                    dr[15] = null;
                }
                else
                {
                    dr[15] = cell.ToString();
                }
                #endregion

                //移动一行
                rows.MoveNext();
                row = (HSSFRow)rows.Current;

                #region 读取第十七列:总体积的值
                cell = row.GetCell(1);
                if (cell == null)
                {
                    dr[16] = null;
                }
                else
                {
                    dr[16] = cell.ToString();
                }
                #endregion

                #region 读取第十八列:总体积的值
                cell = row.GetCell(3);
                if (cell == null)
                {
                    dr[17] = null;
                }
                else
                {
                    dr[17] = cell.ToString();
                }
                #endregion

                #region 读取第十九列:总重量的值
                cell = row.GetCell(5);
                if (cell == null)
                {
                    dr[18] = null;
                }
                else
                {
                    dr[18] = cell.ToString();
                }
                #endregion

                dr["TN_ID"] = tnid;//主表ID列

                dt.Rows.Add(dr);
                #endregion
                #endregion

                #endregion

                #region 读取主表中的 箱内明细
                //读取一行
                rows.MoveNext();//跳过一行,标题行
                rows.MoveNext();//跳过一行,表头行

                //主表有二十行箱内明细的数据
                for (int i = 0; i < 20; i++)
                {
                    rows.MoveNext();//真正的内容行
                    row = (HSSFRow)rows.Current;
                    DataRow dr2 = dt2.NewRow();

                    //循环行单元格
                    for (int k = 0; k < row.LastCellNum; k++)
                    {
                        ICell cell2 = row.GetCell(k);
                        if (cell2 == null)
                        {
                            dr2[k] = null;
                        }
                        else
                        {
                            dr2[k] = cell2.ToString();
                        }
                    }
                    dr2["TN_ID"] = tnid;//关联的主表ID
                    //跳过空行
                    if (dr2["CaseNum"].ToString() != "" && dr2["CaseType"].ToString() != "" && dr2["Length"].ToString() != "" && dr2["Width"].ToString() != "" && dr2["Weight"].ToString() != "")
                    {
                        dt2.Rows.Add(dr2);
                    }
                    else
                    {
                        //筛选信息不全的行,做提示用
                        if (dr2["CaseNum"].ToString() != "" || dr2["CaseType"].ToString() != "" || dr2["Length"].ToString() != "" || dr2["Width"].ToString() != "" || dr2["Weight"].ToString() != "")
                        {
                            dr2["ErrMsg"] = string.Format("货品行号:{0};", dr2["Line"].ToString());
                            if (dr2["CaseNum"].ToString() == "")
                            {
                                dr2["ErrMark"] = 1;
                                dr2["ErrMsg"] += "箱号为空;";
                            }
                            if (dr2["CaseType"].ToString() == "")
                            {
                                dr2["ErrMark"] = 1;
                                dr2["ErrMsg"] += "箱子类型为空;";
                            }
                            if (dr2["Length"].ToString() == "")
                            {
                                dr2["ErrMark"] = 1;
                                dr2["ErrMsg"] += "箱子长度为空;";
                            }
                            if (dr2["Width"].ToString() == "")
                            {
                                dr2["ErrMark"] = 1;
                                dr2["ErrMsg"] += "箱子宽度为空;";
                            }
                            if (dr2["Weight"].ToString() == "")
                            {
                                dr2["ErrMark"] = 1;
                                dr2["ErrMsg"] += "箱子重量为空;";
                            }
                            dr2["ErrMsg"] = dr2["ErrMsg"].ToString().TrimEnd(';');
                            dt3.Rows.Add(dr2.ItemArray);
                        }
                    }

                }

                #endregion

                //移动一行
                rows.MoveNext();
                rows.MoveNext();
                rows.MoveNext();
                row = (HSSFRow)rows.Current;

                #region 读取第二十列 车辆类型
                cell = row.GetCell(6);
                if (cell == null)
                {
                    dr["TRUCK_TYPE"] = null;
                }
                else
                {
                    dr["TRUCK_TYPE"] = cell.ToString();
                }
                #endregion

                #region 读取第二十一列 RT NO
                cell = row.GetCell(8);
                if (cell == null)
                {
                    dr["RT_NO"] = null;
                }
                else
                {
                    dr["RT_NO"] = cell.ToString();
                }
                #endregion

                rows.MoveNext();
                rows.MoveNext();
                row = (HSSFRow)rows.Current;
                #region 读取第二十二列 运输模式
                cell = row.GetCell(6);
                if (cell == null)
                {
                    dr["TRANSPORT_MODE"] = null;
                }
                else
                {
                    dr["TRANSPORT_MODE"] = cell.ToString();
                }
                #endregion

                #region 读取第二十三列 运输类型
                cell = row.GetCell(8);
                if (cell == null)
                {
                    dr["TRANSPORT_TYPE"] = null;
                }
                else
                {
                    dr["TRANSPORT_TYPE"] = cell.ToString();
                }
                #endregion

                rows.MoveNext();
                rows.MoveNext();
                row = (HSSFRow)rows.Current;

                #region 读取第二十四列 退回日期
                cell = row.GetCell(6);
                if (cell == null)
                {
                    dr["PICKUP_TIME"] = null;
                }
                else
                {
                    dr["PICKUP_TIME"] = cell.DateCellValue.ToString();
                }
                #endregion

                rows.MoveNext();
                rows.MoveNext();
                row = (HSSFRow)rows.Current;

                #region 读取第二十五列 承运商
                cell = row.GetCell(6);
                if (cell == null)
                {
                    dr["FORWARDER"] = null;
                }
                else
                {
                    dr["FORWARDER"] = cell.ToString();
                }
                #endregion

                rows.MoveNext();
                rows.MoveNext();
                row = (HSSFRow)rows.Current;

                #region 读取第二十六列 临时地址
                cell = row.GetCell(6);
                if (cell == null)
                {
                    dr["IS_TEMP_ADDRESS"] = null;
                }
                else
                {
                    dr["IS_TEMP_ADDRESS"] = cell.ToString();
                }
                #endregion

                #region 读取第二十七列 易碎
                cell = row.GetCell(8);
                if (cell == null)
                {
                    dr["IS_FRAGILE"] = null;
                }
                else
                {
                    dr["IS_FRAGILE"] = cell.ToString();
                }
                #endregion

                #region 获取余下多个从Sheet里的详细条目,增加到表二
                //跳过第一个Sheet(第一个Sheet规定为主表),循环剩余的Sheet(规定为详细条目);


                for (int i = 1; i < 5; i++)
                {
                    //拿到当前循环到的Sheet
                    sheet = hssfworkbook.GetSheetAt(i);
                    //读取Sheet行
                    rows = sheet.GetRowEnumerator();

                    #region 循环增加内容
                    rows.MoveNext();//跳过表头行
                    while (rows.MoveNext())
                    {
                        //拿到当前行
                        IRow row2 = (HSSFRow)rows.Current;
                        //表二创建一行
                        DataRow dr2 = dt2.NewRow();

                        //循环行单元格
                        for (int k = 0; k < row2.LastCellNum; k++)
                        {
                            ICell cell2 = row2.GetCell(k);
                            if (cell2 == null)
                            {
                                dr2[k] = null;
                            }
                            else
                            {
                                dr2[k] = cell2.ToString();
                            }
                        }
                        dr2["TN_ID"] = tnid;//关联的主表ID

                        //跳过空行
                        if (dr2["CaseNum"].ToString() != "" && dr2["CaseType"].ToString() != "" && dr2["Length"].ToString() != "" && dr2["Width"].ToString() != "" && dr2["Height"].ToString() != "" && dr2["Weight"].ToString() != "")
                        {
                            dt2.Rows.Add(dr2);
                        }
                        else
                        {
                            //筛选信息不全的行,做提示用
                            if (dr2["CaseNum"].ToString() != "" || dr2["CaseType"].ToString() != "" || dr2["Length"].ToString() != "" || dr2["Width"].ToString() != "" || dr2["Weight"].ToString() != "")
                            {
                                dr2["ErrMsg"] = string.Format("货品行号:{0};", dr2["Line"].ToString());
                                if (dr2["CaseNum"].ToString() == "")
                                {
                                    dr2["ErrMark"] = 1;
                                    dr2["ErrMsg"] += "箱号为空;";
                                }
                                if (dr2["CaseType"].ToString() == "")
                                {
                                    dr2["ErrMark"] = 1;
                                    dr2["ErrMsg"] += "箱子类型为空;";
                                }
                                if (dr2["Length"].ToString() == "")
                                {
                                    dr2["ErrMark"] = 1;
                                    dr2["ErrMsg"] += "箱子长度为空;";
                                }
                                if (dr2["Width"].ToString() == "")
                                {
                                    dr2["ErrMark"] = 1;
                                    dr2["ErrMsg"] += "箱子宽度为空;";
                                }
                                if (dr2["Weight"].ToString() == "")
                                {
                                    dr2["ErrMark"] = 1;
                                    dr2["ErrMsg"] += "箱子重量为空;";
                                }
                                dr2["ErrMsg"] = dr2["ErrMsg"].ToString().TrimEnd(';');
                                //加入到错误列表
                                dt3.Rows.Add(dr2.ItemArray);
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            }
            #endregion

            //表一
            ds.Tables.Add(dt);
            //表二
            ds.Tables.Add(dt2);
            //表三
            ds.Tables.Add(dt3);
            //返回结果集
            return ds;
        }
    }
}
