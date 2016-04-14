using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Utility.Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Core.Utility.SqlHelper
{
    public static class SpExecution
    {
        public static DataSet ExecuteDataset(string spName, params SqlParameter[] commandParameters)
        {
            string connectString = ConfigurationManager.ConnectionStrings["FrogTMSEntities"].ConnectionString;
            //return Core.Utility.Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(connectString, spName, parameterValues);
                //public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
            DataSet ds = Core.Utility.Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(connectString, CommandType.StoredProcedure, spName, commandParameters);
            return ds;
        }
    }
}
