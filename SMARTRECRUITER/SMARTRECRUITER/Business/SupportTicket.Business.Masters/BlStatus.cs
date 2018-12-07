using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Threading.Tasks;
using SupportTicket.DataAccess.Masters;
using SupportTicket.Interface.Masters;

namespace SupportTicket.Business.Masters
{
    public class BlStatus : IStatus
    {
        private byte _UserAction;
        private long _ID_Status;
        private string _StatusCode;
        private string _StatusName;        
        private long _SortOrder;
        private long _UserCode;
        private DateTime _UserDate;
        private Boolean _Cancelled;
        private long _CancelledUser;
        private DateTime _CancelledOn;
        private long _FK_Company;
        private Int32 _PageIndex;
        private Int32 _PageSize;
        private byte _Active;

        public BlStatus()
        {
            Initialize();
        }

        public void Initialize()
        {
            _UserAction = 1;
            _Active = 1;
            _FK_Company = 1;
            _UserCode =0;
            _PageIndex = 1;
            _PageSize = 10;
            _StatusCode= string.Empty;
            _StatusName = string.Empty;
            _ID_Status = 0;           
        }
        public byte Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public byte UserAction
        {
            get { return _UserAction; }
            set { _UserAction = value; }
        }
        public long MasterID
        {
            get { return _ID_Status; }
            set { _ID_Status = value; }
        }
        public string StatusCode
        {
            get { return _StatusCode; }
            set { _StatusCode = value; }
        }
        public string StatusName
        {
            get { return _StatusName; }
            set { _StatusName = value; }
        }        
        public long SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }
        public long UserCode
        {
            get { return _UserCode; }
            set { _UserCode = value; }
        }
        public DateTime UserDate
        {
            get { return _UserDate; }
            set { _UserDate = value; }
        }
        public Boolean Cancelled
        {
            get { return _Cancelled; }
            set { _Cancelled = value; }
        }
        public long CancelledUser
        {
            get { return _CancelledUser; }
            set { _CancelledUser = value; }
        }
        public DateTime CancelledOn
        {
            get { return _CancelledOn; }
            set { _CancelledOn = value; }
        }
        public long FK_Company
        {
            get { return _FK_Company; }
            set { _FK_Company = value; }
        }
        public Int32 PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }
        public Int32 PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }


        public long InsertData()
        {
            long status;
            DalStatus dalStatus = new DalStatus();
            status = 0;
            try
            {
                _UserAction = 1;
                status = dalStatus.UpdateStatus(this);
                dalStatus = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public long UpdateData()
        {
            DalStatus dalStatus = new DalStatus();
            long status;
            status = 0;
            try
            {
                _UserAction = 2;
                status = dalStatus.UpdateStatus(this);
                dalStatus = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        //public long DeleteData()
        //{
        //    DalStatus dalStatus = new DalStatus();
        //    long status;
        //    status = 0;
        //    try
        //    {
        //        status = dalStatus.DeleteStatus(this);
        //        dalStatus = null;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return status;
        //}
        //public void SelectData()
        //{
        //    DalStatus dalStatus = new DalStatus();
        //    IStatus iStatus;
        //    iStatus = (IStatus)dalStatus.SelectStatus(this);
        //    //_ShortName = iStatus.ShortName;
        //    //_Name = iStatus.Name;
        //    //_Address1 = iStatus.Address1;
        //    //_Address2 = iStatus.Address2;
        //    //_Address3 = iStatus.Address3;
        //    //_Active = iStatus.Active;
        //    dalStatus = null;
        //}
        public DataTable SelectAllData()
        {
            DataTable dtbl = new DataTable();
            DalStatus dalStatus = new DalStatus();
            dtbl = dalStatus.SelectAllStatus(this);
            dalStatus = null;
            return dtbl;
        }
        public long DeleteData()
        {
            _UserAction = 3;
            DalStatus dalStatus = new DalStatus();
            long status;
            status = 0;
            try
            {
                status = dalStatus.DeleteStatus(this);
                dalStatus = null;
            }
            catch (Exception ex)
            {

            }
            return status;
        }
    }
}
