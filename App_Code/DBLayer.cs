using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PSSWCFService.App_Code
{
    public class DBLayer
    {
        string SqlCon = WebConfigurationManager.AppSettings["ConnectionString"];
        public DataSet GetData(SqlParameter[] Params)
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlCon, CommandType.StoredProcedure, "sp_GetData", Params);
            return ds;
        }
        public string UploadEmployeePerformanceIU(SqlParameter[] Params, ref string Success)
        {
            int retval = 0;
            retval = SqlHelper.ExecuteNonQuery(SqlCon, CommandType.StoredProcedure, "sp_UploadEmployeePerformanceIU", Params);
            Success = Params[4].Value.ToString();
            return retval.ToString();
        }
        public string ErrorLogIU(SqlParameter[] Params)
        {
            int retval = 0;
            retval = SqlHelper.ExecuteNonQuery(SqlCon, CommandType.StoredProcedure, "sp_ErrorLogIU", Params);
            return retval.ToString();
        }
    }
}