using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportTicket.Interface.Masters;
using SupportTicket.DataAccess.Masters;
using System.Data;

namespace SupportTicket.Business.Masters
{
    public class BlDepartment:IDepartment
    {
        private byte _UserAction;
        private long _ID_Department;
        private string _DepCode;
        private string _DepName;
        private long _SortOrder;
        private long _UserCode;
        private DateTime _UserDate;
        private Boolean _Cancelled;
        private long _CancelledUser;
        private DateTime _CancelledOn;
        private long _FK_Company;
        private Int32 _PageIndex;
        private Int32 _PageSize;
        private string _Search;
        private byte _Active;


        public BlDepartment()
        {
            Initialize();
        }

        public void Initialize()
        {
            _UserAction = 1;

            _FK_Company = 1;
            _UserCode =0;
            _PageIndex = 1;
            _PageSize = 10;
            _DepCode = string.Empty;
            _DepName = string.Empty;
            _ID_Department = 0;
            _Search = string.Empty;
            _Active = 0;
        }

        public byte UserAction
        {
            get { return _UserAction; }
            set { _UserAction = value; }
        }
        public long MasterID
        {
            get { return _ID_Department; }
            set { _ID_Department = value; }
        }
        public string DepCode
        {
            get { return _DepCode; }
            set { _DepCode = value; }
        }
        public string DepName
        {
            get { return _DepName; }
            set { _DepName = value; }
        }
        public byte Active
        {
            get { return _Active; }
            set { _Active = value; }
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
        public string Search
        {
            get { return _Search; }
            set { _Search = value; }
        }
        public long InsertData()
        {
            long status;
            DalDepartment daldepartment = new DalDepartment();
            status = 0;
            try
            {
                _UserAction = 1;
                status = daldepartment.UpdateDepartment(this);
                daldepartment = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public long UpdateData()
        {
            DalDepartment daldepartment = new DalDepartment();
            long status;
            status = 0;
            try
            {
                _UserAction = 2;
                status = daldepartment.UpdateDepartment(this);
                daldepartment = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public DataTable SelectAllData()
        {
            DataTable dtbl = new DataTable();
            DalDepartment daldepartment = new DalDepartment();
            dtbl = daldepartment.SelectAllDepartment(this);
            daldepartment = null;
            return dtbl;
        }
        public long DeleteData()
        {
            _UserAction = 3;
            DalDepartment daldepartment = new DalDepartment();
            long status;
            status = 0;
            try
            {
                status = daldepartment.DeleteDepartment(this);
                daldepartment = null;
            }
            catch (Exception ex)
            {

            }
            return status;
        }
    }
}
