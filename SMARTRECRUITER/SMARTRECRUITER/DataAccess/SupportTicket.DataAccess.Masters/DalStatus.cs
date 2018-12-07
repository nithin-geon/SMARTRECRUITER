using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SupportTicket.Interface.Masters;

namespace SupportTicket.DataAccess.Masters
{
    public class DalStatus
    {
        public Int32 UpdateStatus(IStatus iStatus)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proStatusUpdate";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@UserAction", DbType.Byte, iStatus.UserAction);
            db.AddInParameter(dbCommand, "@ID_Status", DbType.String, iStatus.MasterID);
            db.AddInParameter(dbCommand, "@StatusCode", DbType.String, iStatus.StatusCode);
            db.AddInParameter(dbCommand, "@StatusName", DbType.String, iStatus.StatusName);            
            db.AddInParameter(dbCommand, "@SortOrder", DbType.Int64, iStatus.SortOrder);
            db.AddInParameter(dbCommand, "@UserCode", DbType.Int64, iStatus.UserCode);                  
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iStatus.FK_Company);
            db.AddInParameter(dbCommand, "@Active", DbType.Int64, iStatus.Active);
            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                return 0;
            }
        }
        public DataTable SelectAllStatus(IStatus iStatus)
        {
            DataTable dtblStatus = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proStatusSelect";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_Status", DbType.String, iStatus.MasterID);
            db.AddInParameter(dbCommand, "@StatusCode", DbType.String, iStatus.StatusCode);
            db.AddInParameter(dbCommand, "@StatusName", DbType.String, iStatus.StatusName);
            db.AddInParameter(dbCommand, "@PageIndex", DbType.Int32, iStatus.PageIndex);
            db.AddInParameter(dbCommand, "@PageSize", DbType.Int32, iStatus.PageSize);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iStatus.FK_Company);
            try
            {
                dtblStatus = db.ExecuteDataSet(dbCommand).Tables[0];
                return dtblStatus;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public int DeleteStatus(IStatus iStatus)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proStatusDelete";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_Status", DbType.Int64, iStatus.MasterID);
            db.AddInParameter(dbCommand, "@CancelledUser", DbType.Int64, iStatus.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iStatus.FK_Company);
            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                //UpdateErrorLog(iStatus, e);
                throw e;
            }
        }
       
    }
}
