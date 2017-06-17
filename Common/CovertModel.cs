using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CovertModel
    {
        public static List<T> TableToList<T>(DataTable dt)
        {
            List<T> list=new List<T>();
            Type type = typeof(T);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    PropertyInfo[] info= type.GetProperties();
                    T entity = Activator.CreateInstance<T>();
                    foreach(PropertyInfo p in info)
                    {
                        if (!dt.Columns.Contains(p.Name) ||dr[p.Name] == null||dr[p.Name]==DBNull.Value)
                        {
                            continue;
                        }
                        object obj = Convert.ChangeType(dr[p.Name], p.PropertyType);
                        p.SetValue(entity, obj, null);
                    }
                    list.Add(entity);
                }
            }
            return list;
        }
        public static DataTable ListToTable<T>(List<T> list)
        {
            DataTable dt = new DataTable();
            if (list != null && list.Count > 0)
            {
               
                Type type = typeof(T);
                PropertyInfo[] info = type.GetProperties();
                foreach(PropertyInfo p in info)
                {
                    dt.Columns.Add(p.Name, p.PropertyType);
                }
                foreach(T t in list)
                {
                    DataRow dr = dt.NewRow();
                    foreach (PropertyInfo p in info)
                    {
                        dr[p.Name] = p.GetValue(t);
                    }
                   
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        public static string ModelToJson<T>(T t)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            if (t != null)
            {
                Type type = typeof(T);
                PropertyInfo[] info = type.GetProperties();
                foreach (PropertyInfo p in info)
                {
                    sb.AppendFormat("{0}:{1}," ,p.Name, p.GetValue(t));
                    
                }
                sb.Length = sb.Length - 1;
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
