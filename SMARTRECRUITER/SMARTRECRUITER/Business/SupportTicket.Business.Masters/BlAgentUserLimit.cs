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
    public class BlAgentUserLimit : IAgentUserLimit
    {
        private byte _UserAction;
        private long _ID_AgentUserLimit;
        private int _FK_CompanyMaster;
        private int _AgentLimit;
        private int _UserLimit;
        private long _UserCode;
        private DateTime _UserDate;
        private Boolean _Cancelled;
        private long _CancelledUser;
        private DateTime _CancelledOn;
        private long _FK_Company;
        private Int32 _PageIndex;
        private Int32 _PageSize;
        private string _CompName;

       

        public BlAgentUserLimit()
        {
            Initialize();
        }

        public void Initialize()
        {
            _UserAction = 1;

            _FK_Company = 1;
            _UserCode = 0;
            _PageIndex = 1;
            _PageSize = 10;
            _AgentLimit = 0 ;
            _UserLimit = 0;
            _ID_AgentUserLimit = 0;
            _CompName = string.Empty;

        }
        public string CompName
        {
            get { return _CompName; }
            set { _CompName = value; }
        }
        public byte UserAction
        {
            get { return _UserAction; }
            set { _UserAction = value; }
        }
        public long MasterID
        {
            get { return _ID_AgentUserLimit; }
            set { _ID_AgentUserLimit = value; }
        }

        public int FK_CompanyMaster
        {
            get { return _FK_CompanyMaster; }
            set { _FK_CompanyMaster = value; }
        }


        public int AgentLimit
        {
            get { return _AgentLimit; }
            set { _AgentLimit = value; }
        }
        public int UserLimit
        {
            get { return _UserLimit; }
            set { _UserLimit = value; }

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
            DalAgentUserLimit dalAgentUserLimit = new DalAgentUserLimit();
            status = 0;
            try
            {
                _UserAction = 1;
                status = dalAgentUserLimit.UpdateAgentUserLimit(this);
                dalAgentUserLimit = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public long UpdateData()
        {
            DalAgentUserLimit dalAgentUserLimit = new DalAgentUserLimit();
            long status;
            status = 0;
            try
            {
                _UserAction = 2;
                status = dalAgentUserLimit.UpdateAgentUserLimit(this);
                dalAgentUserLimit = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }

        public DataTable SelectAllData()
        {
            DataTable dtbl = new DataTable();
            DalAgentUserLimit dalAgentUserLimit = new DalAgentUserLimit();
            dtbl = dalAgentUserLimit.SelectAllAgentUserLimit(this);
            dalAgentUserLimit = null;
            return dtbl;
        }
        public long DeleteData()
        {
            _UserAction = 3;
            DalAgentUserLimit dalAgentUserLimit = new DalAgentUserLimit();
            long status;
            status = 0;
            try
            {
                status = dalAgentUserLimit.DeleteAgentUserLimit(this);
                dalAgentUserLimit = null;
            }
            catch (Exception ex)
            {

            }
            return status;
        }
    }
}
