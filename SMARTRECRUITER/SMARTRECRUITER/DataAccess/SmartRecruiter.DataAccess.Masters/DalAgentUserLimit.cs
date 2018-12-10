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
    public class DalAgentUserLimit
    {
        public Int32 UpdateAgentUserLimit(IAgentUserLimit iAgentUserLimit)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proAgentUserLimitUpdate";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@UserAction", DbType.Byte, iAgentUserLimit.UserAction);
            db.AddInParameter(dbCommand, "@ID_AgentUserLimit", DbType.String, iAgentUserLimit.MasterID);
            db.AddInParameter(dbCommand, "@FK_CompanyMaster", DbType.String, iAgentUserLimit.FK_CompanyMaster);
            db.AddInParameter(dbCommand, "@AgentLimit", DbType.String, iAgentUserLimit.AgentLimit);
            db.AddInParameter(dbCommand, "@UserLimit", DbType.String, iAgentUserLimit.UserLimit);
            db.AddInParameter(dbCommand, "@UserCode", DbType.Int64, iAgentUserLimit.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iAgentUserLimit.FK_Company);
            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                return 0;
            }
        }
        public DataTable SelectAllAgentUserLimit(IAgentUserLimit iAgentUserLimit)
        {
            DataTable dtblAgentUserLimit = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proAgentUserLimitSelect";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_AgentUserLimit", DbType.String, iAgentUserLimit.MasterID);
            db.AddInParameter(dbCommand, "@CompName", DbType.String, iAgentUserLimit.CompName);
            db.AddInParameter(dbCommand, "@PageIndex", DbType.Int32, iAgentUserLimit.PageIndex);
            db.AddInParameter(dbCommand, "@PageSize", DbType.Int32, iAgentUserLimit.PageSize);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iAgentUserLimit.FK_Company);
            try
            {
                dtblAgentUserLimit = db.ExecuteDataSet(dbCommand).Tables[0];
                return dtblAgentUserLimit;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public int DeleteAgentUserLimit(IAgentUserLimit iAgentUserLimit)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proAgentUserLimitDelete";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_AgentUserLimit", DbType.Int64, iAgentUserLimit.MasterID);
            db.AddInParameter(dbCommand, "@CancelledUser", DbType.Int64, iAgentUserLimit.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iAgentUserLimit.FK_Company);

            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                //UpdateErrorLog(iAgentUserLimit, e);
                throw e;
            }
        }

    }
}
