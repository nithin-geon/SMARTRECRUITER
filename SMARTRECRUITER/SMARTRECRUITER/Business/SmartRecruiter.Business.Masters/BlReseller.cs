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
    public class BlReseller:IReseller
    {
        private byte _UserAction;
        private long _ID_Reseller;
        private string _ResCode;
        private string _ResName;
        private string _ResAddress1;
        private string _ResAddress2;
        private string _ResEmail;
        private string _ResMob;
        private string _ResPhone;
        private byte _Active;
        private long _SortOrder;
        private long _UserCode;
        private DateTime _UserDate;
        private Boolean _Cancelled;
        private long _CancelledUser;
        private DateTime _CancelledOn;
        private long _FK_Company;
        private Int32 _PageIndex;
        private Int32 _PageSize;


        public BlReseller()
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
            _ResCode = string.Empty;
            _ResName = string.Empty;
            _ResAddress1 = string.Empty;
            _ResAddress2 = string.Empty;
            _ResEmail = string.Empty;
            _ResMob = string.Empty;
            _ResPhone = string.Empty;
            _Active = 0;
            _ID_Reseller = 0;
        }

        public byte UserAction
        {
            get { return _UserAction; }
            set { _UserAction = value; }
        }
        public long MasterID
        {
            get { return _ID_Reseller; }
            set { _ID_Reseller = value; }
        }
        public string ResCode
        {
            get { return _ResCode; }
            set { _ResCode = value; }
        }
        public string ResName
        {
            get { return _ResName; }
            set { _ResName = value; }
        }
        public string ResAddress1
        {
            get { return _ResAddress1; }
            set { _ResAddress1 = value; }
        }
        public string ResAddress2
        {
            get { return _ResAddress2; }
            set { _ResAddress2 = value; }
        }
        public string ResEmail
        {
            get { return _ResEmail; }
            set { _ResEmail = value; }
        }
        public string ResMob
        {
            get { return _ResMob; }
            set { _ResMob = value; }
        }
        public string ResPhone
        {
            get { return _ResPhone; }
            set { _ResPhone = value; }
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
        public long InsertData()
        {
            long status;
            DalReseller dalreseller = new DalReseller();
            status = 0;
            try
            {
                _UserAction = 1;
                status = dalreseller.UpdateReseller(this);
                dalreseller = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public long UpdateData()
        {
            DalReseller dalreseller = new DalReseller();
            long status;
            status = 0;
            try
            {
                _UserAction = 2;
                status = dalreseller.UpdateReseller(this);
                dalreseller = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public DataTable SelectAllData()
        {
            DataTable dtbl = new DataTable();
            DalReseller dalreseller = new DalReseller();
            dtbl = dalreseller.SelectAllReseller(this);
            dalreseller = null;
            return dtbl;
        }
        public long DeleteData()
        {
            _UserAction = 3;
            DalReseller dalreseller = new DalReseller();
            long status;
            status = 0;
            try
            {
                status = dalreseller.DeleteReseller(this);
                dalreseller = null;
            }
            catch (Exception ex)
            {

            }
            return status;
        }
    }
}
