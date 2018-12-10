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
    public class DalTeam
    {
        public Int32 UpdateTeam(ITeam iTeam)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proTeamUpdate";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@UserAction", DbType.Byte, iTeam.UserAction);
            db.AddInParameter(dbCommand, "@ID_Team", DbType.String, iTeam.MasterID);
            db.AddInParameter(dbCommand, "@TeamCode", DbType.String, iTeam.TeamCode);
            db.AddInParameter(dbCommand, "@TeamName", DbType.String, iTeam.TeamName);            
            db.AddInParameter(dbCommand, "@SortOrder", DbType.Int64, iTeam.SortOrder);
            db.AddInParameter(dbCommand, "@UserCode", DbType.Int64, iTeam.UserCode);                  
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iTeam.FK_Company);
            db.AddInParameter(dbCommand, "@Active", DbType.Int64, iTeam.Active);
            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                return 0;
            }
        }
        public DataTable SelectAllTeam(ITeam iTeam)
        {
            DataTable dtblTeam = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proTeamSelect";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_Team", DbType.String, iTeam.MasterID);
            db.AddInParameter(dbCommand, "@TeamCode", DbType.String, iTeam.TeamCode);
            db.AddInParameter(dbCommand, "@TeamName", DbType.String, iTeam.TeamName);
            db.AddInParameter(dbCommand, "@PageIndex", DbType.Int32, iTeam.PageIndex);
            db.AddInParameter(dbCommand, "@PageSize", DbType.Int32, iTeam.PageSize);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iTeam.FK_Company);
            try
            {
                dtblTeam = db.ExecuteDataSet(dbCommand).Tables[0];
                return dtblTeam;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public int DeleteTeam(ITeam iTeam)
        {
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proTeamDelete";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_Team", DbType.Int64, iTeam.MasterID);
            db.AddInParameter(dbCommand, "@CancelledUser", DbType.Int64, iTeam.UserCode);
            db.AddInParameter(dbCommand, "@FK_Company", DbType.Int64, iTeam.FK_Company);
            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (SqlException e)
            {
                //UpdateErrorLog(iTeam, e);
                throw e;
            }
        }
       
    }
}
