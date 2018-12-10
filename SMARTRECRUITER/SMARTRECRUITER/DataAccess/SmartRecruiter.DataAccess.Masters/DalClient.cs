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
    public class DalClient
    {
        public Int32 UpdateClient(IClient iclient)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proClientUpdate";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@UserAction", DbType.Byte, iclient.UserAction);
            db.AddInParameter(dbCommand, "@ID_Client", DbType.String, iclient.MasterID);
            db.AddInParameter(dbCommand, "@CliCode", DbType.String, iclient.CliCode);
            db.AddInParameter(dbCommand, "@CliShortName", DbType.String, iclient.CliShortName);
            db.AddInParameter(dbCommand, "@CliName", DbType.String, iclient.CliName);
            db.AddInParameter(dbCommand, "@CliAddress1", DbType.String, iclient.CliAddress1);
            db.AddInParameter(dbCommand, "@CliAddress2", DbType.String, iclient.CliAddress2);
            db.AddInParameter(dbCommand, "@CliAddress3", DbType.String, iclient.CliAddress3);
            db.AddInParameter(dbCommand, "@CliEmail", DbType.String, iclient.CliEmail);
            db.AddInParameter(dbCommand, "@CliMob", DbType.String, iclient.CliMob);
            db.AddInParameter(dbCommand, "@CliPhone", DbType.String, iclient.CliPhone);
            db.AddInParameter(dbCommand, "@FK_Reseller", DbType.Int64, iclient.FK_Reseller);
            db.AddInParameter(dbCommand, "@FK_SubscriptionPlan", DbType.Int64, iclient.FK_SubscriptionPlan);
            db.AddInParameter(dbCommand, "@Active", DbType.Byte, iclient.Active); 
            db.AddInParameter(dbCommand, "@SortOrder", DbType.Int64, iclient.SortOrder);
            db.AddInParameter(dbCommand, "@UserCode", DbType.Int64, iclient.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iclient.FK_Company);
            db.AddInParameter(dbCommand, "@XMLProduct", DbType.String, iclient.XMLProduct);            
            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                return 0;
            }
        }
        public DataSet SelectAllClient(IClient iclient)
        {
            
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proClientSelect";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_Client", DbType.String, iclient.MasterID);
            db.AddInParameter(dbCommand, "@CliCode", DbType.String, iclient.CliCode);
            db.AddInParameter(dbCommand, "@CliName", DbType.String, iclient.CliName);
            db.AddInParameter(dbCommand, "@ResName", DbType.String, iclient.ResName);
            db.AddInParameter(dbCommand, "@PageIndex", DbType.Int32, iclient.PageIndex);
            db.AddInParameter(dbCommand, "@PageSize", DbType.Int32, iclient.PageSize);
            db.AddInParameter(dbCommand, "@UserCode", DbType.Int64, iclient.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iclient.FK_Company);
            try
            {
                DataSet dstblProduct = new DataSet();
                dstblProduct = db.ExecuteDataSet(dbCommand);
                return dstblProduct;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public int DeleteClient(IClient iclient)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proClientDelete";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_Client", DbType.Int64, iclient.MasterID);
            db.AddInParameter(dbCommand, "@CancelledUser", DbType.Int64, iclient.UserCode);
            db.AddInParameter(dbCommand, "@UserCode", DbType.Int64, iclient.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iclient.FK_Company);

            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                //UpdateErrorLog(iProduct, e);
                throw e;
            }
        }
    }
}
