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
    public class DalSubscriptionPlan
    {
        public Int32 UpdateSubscriptionPlan(ISubscriptionPlan isubscriptionplan)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proSubscriptionPlanUpdate";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@UserAction", DbType.Byte, isubscriptionplan.UserAction);
            db.AddInParameter(dbCommand, "@Active", DbType.Byte, isubscriptionplan.Active);
            db.AddInParameter(dbCommand, "@ID_SubscriptionPlan", DbType.String, isubscriptionplan.MasterID);
            db.AddInParameter(dbCommand, "@SubscriptionPlanCode", DbType.String, isubscriptionplan.SubscriptionPlanCode);
            db.AddInParameter(dbCommand, "@SubscriptionPlanName", DbType.String, isubscriptionplan.SubscriptionPlanName);
            db.AddInParameter(dbCommand, "@SubscriptionPlanHours", DbType.String, isubscriptionplan.SubscriptionPlanHours);
            db.AddInParameter(dbCommand, "@SortOrder", DbType.Int64, isubscriptionplan.SortOrder);
            db.AddInParameter(dbCommand, "@UserCode", DbType.Int64, isubscriptionplan.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, isubscriptionplan.FK_Company);
            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                return 0;
            }
        }
        public DataTable SelectAllSubscriptionPlan(ISubscriptionPlan isubscriptionplan)
        {
            DataTable dtblSubscriptionPlan = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proSubscriptionPlanSelect";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_SubscriptionPlan", DbType.String, isubscriptionplan.MasterID);
            db.AddInParameter(dbCommand, "@SubscriptionPlanCode", DbType.String, isubscriptionplan.SubscriptionPlanCode);
            db.AddInParameter(dbCommand, "@SubscriptionPlanName", DbType.String, isubscriptionplan.SubscriptionPlanName);
            db.AddInParameter(dbCommand, "@PageIndex", DbType.Int32, isubscriptionplan.PageIndex);
            db.AddInParameter(dbCommand, "@PageSize", DbType.Int32, isubscriptionplan.PageSize);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, isubscriptionplan.FK_Company);
            try
            {
                dtblSubscriptionPlan = db.ExecuteDataSet(dbCommand).Tables[0];
                return dtblSubscriptionPlan;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public int DeleteSubscriptionPlan(ISubscriptionPlan isubscriptionplan)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proSubscriptionPlanDelete";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_subscriptionplan", DbType.Int64, isubscriptionplan.MasterID);
            db.AddInParameter(dbCommand, "@CancelledUser", DbType.Int64, isubscriptionplan.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, isubscriptionplan.FK_Company);

            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                //UpdateErrorLog(iTopic, e);
                throw e;
            }
        }

    }
}
