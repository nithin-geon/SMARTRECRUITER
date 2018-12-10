using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportTicket.Interface;

namespace SupportTicket.DataAccess
{
    public class DalReportData
    {
        public DataSet GetReportDataSource(IReportData IReportData)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "proCmnReportData";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@SubModule", DbType.String, IReportData.SubModule);
            db.AddInParameter(dbCommand, "@Id", DbType.String, IReportData.ID);
            db.AddInParameter(dbCommand, "@SubID", DbType.String, IReportData.SubID);
            db.AddInParameter(dbCommand, "@FromDate", DbType.Date, IReportData.FromDate);
            db.AddInParameter(dbCommand, "@ToDate", DbType.Date, IReportData.ToDate);
            db.AddInParameter(dbCommand, "@FromStore", DbType.Int64, IReportData.FromStore);

            db.AddInParameter(dbCommand, "@FK_CategoryFirst", DbType.Int64, IReportData.FK_CategoryFirst);
            db.AddInParameter(dbCommand, "@FK_Items", DbType.Int64, IReportData.FK_Items);
            db.AddInParameter(dbCommand, "@FK_Store", DbType.Int64, IReportData.FK_Store);
            db.AddInParameter(dbCommand, "@FK_Client", DbType.Int64, IReportData.FK_Client);
            db.AddInParameter(dbCommand, "@Usercode", DbType.String, IReportData.UserCode);
            db.AddInParameter(dbCommand, "@XmlData", DbType.String, IReportData.XmlData);
            db.AddInParameter(dbCommand, "@FinYear", DbType.Int16, IReportData.FinYear);
            db.AddInParameter(dbCommand, "@Critrea1", DbType.String, IReportData.Critrea1);
            db.AddInParameter(dbCommand, "@Critrea2", DbType.String, IReportData.Critrea2);

            db.AddInParameter(dbCommand, "@ToStore", DbType.Int64, IReportData.ToStore);
            db.AddInParameter(dbCommand, "@FK_Supplier", DbType.Int64, IReportData.FK_Supplier);
            db.AddInParameter(dbCommand, "@FK_Customer", DbType.Int64, IReportData.FK_Customer);
            db.AddInParameter(dbCommand, "@FK_Salesman", DbType.Int64, IReportData.FK_Salesman);
            db.AddInParameter(dbCommand, "@PaymentMode", DbType.Byte, IReportData.PaymentMode);
            db.AddInParameter(dbCommand, "@FK_AccountHead", DbType.Int64, IReportData.FK_AccountHead);
            db.AddInParameter(dbCommand, "@FK_AccountSubHead", DbType.Int64, IReportData.FK_AccountSubHead);
            db.AddInParameter(dbCommand, "@AsonDate", DbType.Date, IReportData.AsonDate);
            db.AddInParameter(dbCommand, "@FK_AccountGroup", DbType.Int64, IReportData.FK_AccountGroup);
            db.AddInParameter(dbCommand, "@FK_AccountSubGroup", DbType.Int64, IReportData.FK_AccountSubGroup);
            db.AddInParameter(dbCommand, "@IssueMode", DbType.Byte, IReportData.IssueMode);
            db.AddInParameter(dbCommand, "@FK_Users", DbType.Int64, IReportData.FK_Users);
            db.AddInParameter(dbCommand, "@FK_Counter", DbType.Int64, IReportData.FK_Counter);
            db.AddInParameter(dbCommand, "@FK_Shift", DbType.Int64, IReportData.FK_Shift);
            db.AddInParameter(dbCommand, "@FK_CustomerGroup", DbType.Int64, IReportData.FK_CustomerGroup);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }
        }
        public DataTable GetDashBoardGraphDataSource(IReportData IReportData)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataTable ds = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "proRptDashBoard";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@SubID", DbType.String, IReportData.SubID);
            db.AddInParameter(dbCommand, "@FromDate", DbType.Date, IReportData.FromDate);
            db.AddInParameter(dbCommand, "@EndDate", DbType.Date, IReportData.ToDate);
            db.AddInParameter(dbCommand, "@FK_Client", DbType.Int64, IReportData.FK_Client);
            db.AddInParameter(dbCommand, "@FK_Store", DbType.Int64, IReportData.FK_Store);
            db.AddInParameter(dbCommand, "@Period", DbType.Byte, IReportData.Period);
            try
            {
                ds = db.ExecuteDataSet(dbCommand).Tables[0];
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }
        }
        public DataTable GetAdminDashBoard(IReportData IReportData)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataTable ds = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "proRptAdminDashBoard";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@SubID", DbType.String, IReportData.SubID);
            db.AddInParameter(dbCommand, "@FromDate", DbType.Date, IReportData.FromDate);
            db.AddInParameter(dbCommand, "@EndDate", DbType.Date, IReportData.ToDate);
            db.AddInParameter(dbCommand, "@FK_Client", DbType.Int64, IReportData.FK_Client);
            db.AddInParameter(dbCommand, "@FK_Store", DbType.Int64, IReportData.FK_Store);
            db.AddInParameter(dbCommand, "@Period", DbType.Byte, IReportData.Period);
            try
            {
                ds = db.ExecuteDataSet(dbCommand).Tables[0];
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }
        }
        public DataSet GetComparableGraph(IReportData IReportData)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "proRptAdminDashBoardComparisonal";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@SubID", DbType.String, IReportData.SubID);
            db.AddInParameter(dbCommand, "@FromDate", DbType.Date, IReportData.FromDate);
            db.AddInParameter(dbCommand, "@EndDate", DbType.Date, IReportData.ToDate);
            db.AddInParameter(dbCommand, "@FK_Client", DbType.Int64, IReportData.FK_Client);
           // db.AddInParameter(dbCommand, "@FK_Store", DbType.Int64, IReportData.FK_Store);
            db.AddInParameter(dbCommand, "@CompareFrom", DbType.Date, IReportData.CompareDateFrom);
            db.AddInParameter(dbCommand, "@CompareTo", DbType.Date, IReportData.CompareDateTo);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }
        }
        public DataSet GetStockTransferRequestReportData(long StatusId)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "ProRptGetStockTransferRequest";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_IndentRequest", DbType.Int64, StatusId);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }

        }

        public DataSet RepaymentReportData(long StatusId)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "ProRptGetRepayment";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@FK_CustomerRePayment", DbType.Int64, StatusId);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }

        }

        public DataSet StockTransferIssueReceipt(long StatusId)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "ProStockTransferIssueReceipt";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@FK_Indent", DbType.Int64, StatusId);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }

        }

        public DataSet GetPurchaseReportData(long StatusId)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "ProRptIndentReceiptprint";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_Indent", DbType.Int64, StatusId);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }

        }
        public DataSet GetPurchaseRecieptDataSource(long StatusId)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "ProRptPurchaseReceiptprint";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_Purchase", DbType.Int64, StatusId);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }

        }

        public DataSet GetPurchaseOrderDataSource(long StatusId)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "ProPurchaseOrderPrint";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_PurchaseOrder", DbType.Int64, StatusId);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }

        }


        public DataSet GetSalesReturnDataSource(long StatusId)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "ProSalesReturnPrint";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_SalesReturn", DbType.Int64, StatusId);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }

        }

        public DataSet GetPurchaseReturnDataSource(long StatusId)
        {
            string sqlCommand = "";
            DbCommand dbCommand;
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            sqlCommand = "ProPurchaseReturnprint";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ID_PurchaseReturn", DbType.Int64, StatusId);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (SqlException e)
            {
                throw;
            }

        }
        public DataTable SelectTitle()
        {
            DataTable dtblusers = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("SUPPORTTICKETS");
            string sqlCommand = "proSettingsSelect";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@Module", DbType.String, "MAS");
            db.AddInParameter(dbCommand, "@SubModule", DbType.String, "COM");
            db.AddInParameter(dbCommand, "@FK_Client", DbType.Int32, 1);
            try
            {
                dtblusers = db.ExecuteDataSet(dbCommand).Tables[0];
                return dtblusers;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }

}
