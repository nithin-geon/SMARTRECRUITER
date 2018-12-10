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
    public class BlWorkFlow : IWorkFlow
    {
        private byte _UserAction;
        private long _ID_WorkFlow;
        private string _WorkFlowCode;
        private string _WorkFlowName;
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


        public BlWorkFlow()
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
            _WorkFlowCode = string.Empty;
            _WorkFlowName = string.Empty;
            _ID_WorkFlow = 0;
            _Active = 0;

        }

        public byte UserAction
        {
            get { return _UserAction; }
            set { _UserAction = value; }
        }
        public long MasterID
        {
            get { return _ID_WorkFlow; }
            set { _ID_WorkFlow = value; }
        }
        public string WorkFlowCode
        {
            get { return _WorkFlowCode; }
            set { _WorkFlowCode = value; }
        }
        public string WorkFlowName
        {
            get { return _WorkFlowName; }
            set { _WorkFlowName = value; }

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
            DalWorkFlow dalWorkFlow = new DalWorkFlow();
            status = 0;
            try
            {
                _UserAction = 1;
                status = dalWorkFlow.UpdateWorkFlow(this);
                dalWorkFlow = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public long UpdateData()
        {
            DalWorkFlow dalWorkFlow = new DalWorkFlow();
            long status;
            status = 0;
            try
            {
                _UserAction = 2;
                status = dalWorkFlow.UpdateWorkFlow(this);
                dalWorkFlow = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }

        public DataTable SelectAllData()
        {
            DataTable dtbl = new DataTable();
            DalWorkFlow dalWorkFlow = new DalWorkFlow();
            dtbl = dalWorkFlow.SelectAllWorkFlow(this);
            dalWorkFlow = null;
            return dtbl;
        }
        public long DeleteData()
        {
            _UserAction = 3;
            DalWorkFlow dalWorkFlow = new DalWorkFlow();
            long status;
            status = 0;
            try
            {
                status = dalWorkFlow.DeleteWorkFlow(this);
                dalWorkFlow = null;
            }
            catch (Exception ex)
            {

            }
            return status;
        }
    }
}
