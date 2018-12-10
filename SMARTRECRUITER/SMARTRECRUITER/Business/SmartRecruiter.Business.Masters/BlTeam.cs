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
    public class BlTeam : ITeam
    {
        private byte _UserAction;
        private long _ID_Team;
        private string _TeamCode;
        private string _TeamName;        
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

        public BlTeam()
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
            _TeamCode= string.Empty;
            _TeamName = string.Empty;
            _ID_Team = 0;           
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
            get { return _ID_Team; }
            set { _ID_Team = value; }
        }
        public string TeamCode
        {
            get { return _TeamCode; }
            set { _TeamCode = value; }
        }
        public string TeamName
        {
            get { return _TeamName; }
            set { _TeamName = value; }
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
            DalTeam dalTeam = new DalTeam();
            status = 0;
            try
            {
                _UserAction = 1;
                status = dalTeam.UpdateTeam(this);
                dalTeam = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public long UpdateData()
        {
            DalTeam dalTeam = new DalTeam();
            long status;
            status = 0;
            try
            {
                _UserAction = 2;
                status = dalTeam.UpdateTeam(this);
                dalTeam = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        //public long DeleteData()
        //{
        //    DalTeam dalTeam = new DalTeam();
        //    long status;
        //    status = 0;
        //    try
        //    {
        //        status = dalTeam.DeleteTeam(this);
        //        dalTeam = null;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return status;
        //}
        //public void SelectData()
        //{
        //    DalTeam dalTeam = new DalTeam();
        //    ITeam iTeam;
        //    iTeam = (ITeam)dalTeam.SelectTeam(this);
        //    //_ShortName = iTeam.ShortName;
        //    //_Name = iTeam.Name;
        //    //_Address1 = iTeam.Address1;
        //    //_Address2 = iTeam.Address2;
        //    //_Address3 = iTeam.Address3;
        //    //_Active = iTeam.Active;
        //    dalTeam = null;
        //}
        public DataTable SelectAllData()
        {
            DataTable dtbl = new DataTable();
            DalTeam dalTeam = new DalTeam();
            dtbl = dalTeam.SelectAllTeam(this);
            dalTeam = null;
            return dtbl;
        }
        public long DeleteData()
        {
            _UserAction = 3;
            DalTeam dalTeam = new DalTeam();
            long status;
            status = 0;
            try
            {
                status = dalTeam.DeleteTeam(this);
                dalTeam = null;
            }
            catch (Exception ex)
            {

            }
            return status;
        }
    }
}
