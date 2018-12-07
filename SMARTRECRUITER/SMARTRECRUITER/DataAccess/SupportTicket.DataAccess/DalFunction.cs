using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using SupportTicket.Interface;
using SupportTicket.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections;

namespace SupportTicket.DataAccess
{
    public class DalFunction
    {
        //DataTable
        public DataTable GetDataTable(IPopulate ipopulate)
        {
            DataTable dt = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "ProCmnGetRecords";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "TableName", DbType.String, ipopulate.TableName);
            db.AddInParameter(dbCommand, "ListFields", DbType.String, ipopulate.ListFields);
            db.AddInParameter(dbCommand, "SortField", DbType.String, ipopulate.SortFields);
            db.AddInParameter(dbCommand, "Criteria", DbType.String, ipopulate.Criteria);
            DataSet ds = new DataSet();
            try
            {

                ds = db.ExecuteDataSet(dbCommand);
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return dt;
            }
            catch (Exception e)
            {
                string errdetails = "exec ProCmnGetRecords '" + ipopulate.TableName + "','"
                                       + ipopulate.ListFields + ((ipopulate.ListFields.Length <= 0) ? "" : "," + ipopulate.ValueFields) + "','"
                                       + ipopulate.SortFields + "','" + ipopulate.Criteria + "'";
            }

            return ds.Tables[0];
        }
        public ArrayList GetArrayList(IPopulate ipopulate)
        {
            ArrayList arlist = new ArrayList();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "ProCmnGetRecords";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "TableName", DbType.String, ipopulate.TableName);
            db.AddInParameter(dbCommand, "ListFields", DbType.String, ipopulate.ListFields);
            db.AddInParameter(dbCommand, "SortField", DbType.String, ipopulate.SortFields);
            db.AddInParameter(dbCommand, "Criteria", DbType.String, ipopulate.Criteria);

            try
            {
                DataSet ds = new DataSet();
                ds = db.ExecuteDataSet(dbCommand);
                IDataReader datareader = ds.Tables[0].CreateDataReader();
                ds = null;
                while (datareader.Read())
                {
                    for (int i = 0; i < datareader.FieldCount; i++)
                    {
                        arlist.Add(datareader.GetValue(i));
                    }

                }
                datareader = null;
            }
            catch (Exception e)
            {
                string errdetails = "exec ProCmnGetRecords '" + ipopulate.TableName + "','"
                                       + ipopulate.ListFields + ((ipopulate.ListFields.Length <= 0) ? "" : "," + ipopulate.ValueFields) + "','"
                                       + ipopulate.SortFields + "','" + ipopulate.Criteria + "'";
                //UpdateErrorLog(ipopulate, errdetails, e);
                errdetails = null;
                throw;
            }
            return arlist;
        }

    }
    
}
