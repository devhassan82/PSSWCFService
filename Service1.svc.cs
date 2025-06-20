using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PSSWCFService.App_Code;


namespace PSSWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public DataSet GetData(string BusinessID, string FilterText1, string FilterText2)
        {
            DataSet _objDs = new DataSet();
            DBLayer _objdbLayer = new DBLayer();

            SqlParameter[] Params = new SqlParameter[3];
            Params[0] = new SqlParameter("@BusinessID", SqlDbType.Int, 4);
            Params[0].Value = BusinessID;
            Params[1] = new SqlParameter("@FilterText1", SqlDbType.NVarChar, 800);
            Params[1].Value = FilterText1;
            Params[2] = new SqlParameter("@FilterText2", SqlDbType.NVarChar, 800);
            Params[2].Value = FilterText2;

            try
            {
                _objDs = _objdbLayer.GetData(Params);
                return _objDs;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _objdbLayer = null;
                _objDs = null;
            }
        }
        public string UploadEmployeePerformanceIU(string xmlString, ref string Success, ref string ErrorMsg)
        {
            string result = "";
            DBLayer _objdbLayer = new DBLayer();
            clsPerformance obj = (clsPerformance)Util.DeserializeObject(xmlString, typeof(clsPerformance));


            SqlParameter[] Params = new SqlParameter[5];
            Params[0] = new SqlParameter("@YearID", SqlDbType.Int, 8);
            Params[0].Value = obj.YearID;
            Params[1] = new SqlParameter("@MonthID ", SqlDbType.Int, 8);
            Params[1].Value = obj.MonthID;
            SqlParameter p = new SqlParameter("@Performance", obj.DataTable_EmpPerformance);
            Params[2] = p;
            Params[3] = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
            Params[3].Value = obj.CreatedBy;
            Params[4] = new SqlParameter("@Success", SqlDbType.Int, 4);
            Params[4].Value = 0;
            Params[4].Direction = ParameterDirection.Output;
            try
            {
                result = _objdbLayer.UploadEmployeePerformanceIU(Params, ref Success);
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.ToString();
                //ErrorResult = ErrorLogIU("Service", "ContractIU", ex.ToString(), UserID);
            }
            finally
            {
                _objdbLayer = null;
            }
            return result;
        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
