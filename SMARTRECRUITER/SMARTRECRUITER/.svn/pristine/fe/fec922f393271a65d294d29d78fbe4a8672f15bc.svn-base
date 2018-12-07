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
    public class DalWorkFlow
    {
        public Int32 UpdateWorkFlow(IWorkFlow iWorkFlow)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proWorkFlowUpdate";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@UserAction", DbType.Byte, iWorkFlow.UserAction);
            db.AddInParameter(dbCommand, "@Active", DbType.Byte, iWorkFlow.Active);
            db.AddInParameter(dbCommand, "@ID_WorkFlow", DbType.String, iWorkFlow.MasterID);
            db.AddInParameter(dbCommand, "@WFCode", DbType.String, iWorkFlow.WorkFlowCode);
            db.AddInParameter(dbCommand, "@WFName", DbType.String, iWorkFlow.WorkFlowName);
            db.AddInParameter(dbCommand, "@SortOrder", DbType.Int64, iWorkFlow.SortOrder);
            db.AddInParameter(dbCommand, "@UserCode", DbType.Int64, iWorkFlow.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iWorkFlow.FK_Company);
            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                return 0;
            }
        }
        public DataTable SelectAllWorkFlow(IWorkFlow iWorkFlow)
        {
            DataTable dtblWorkFlow = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proWorkFlowSelect";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_WorkFlow", DbType.String, iWorkFlow.MasterID);
            db.AddInParameter(dbCommand, "@WFCode", DbType.String, iWorkFlow.WorkFlowCode);
            db.AddInParameter(dbCommand, "@WFName", DbType.String, iWorkFlow.WorkFlowName);
            db.AddInParameter(dbCommand, "@PageIndex", DbType.Int32, iWorkFlow.PageIndex);
            db.AddInParameter(dbCommand, "@PageSize", DbType.Int32, iWorkFlow.PageSize);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iWorkFlow.FK_Company);
            try
            {
                dtblWorkFlow = db.ExecuteDataSet(dbCommand).Tables[0];
                return dtblWorkFlow;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public int DeleteWorkFlow(IWorkFlow iWorkFlow)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proWorkFlowDelete";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_WorkFlow", DbType.Int64, iWorkFlow.MasterID);
            db.AddInParameter(dbCommand, "@CancelledUser", DbType.Int64, iWorkFlow.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iWorkFlow.FK_Company);

            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                //UpdateErrorLog(iWorkFlow, e);
                throw e;
            }
        }

    }
}
