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
    public class BlSettings : ISettings
    {
        private byte _UserAction;
        private long _ID_Settings;
        private string _Module;
        private string _SubModule;
        private string _Name;
        private string _Value;
        private long _SortOrder;
        private long _UserCode;
        private DateTime _UserDate;
        private Boolean _Cancelled;
        private long _CancelledUser;
        private DateTime _CancelledOn;
        private long _FK_Company;
        private bool _AutoGen;
        private byte _DeleteFlag;
        private string _Prefix;
        private string _AutocloseDays;

       

        public BlSettings()
        {
            Initialize();
        }

        public void Initialize()
        {
            _UserAction = 1;
            _FK_Company = 1;
            _UserCode =0;
            _Module= string.Empty;
            _SubModule = string.Empty;
            _Name = string.Empty;
            _Value = string.Empty;
            _ID_Settings = 0;
            _AutoGen = false;
            _DeleteFlag = 1;
            Prefix = string.Empty;
            _AutocloseDays = string.Empty;

        }

        public string Prefix
        {
            get { return _Prefix; }
            set { _Prefix = value; }
        }

        public byte DeleteFlag
        {
            get { return _DeleteFlag; }
            set { _DeleteFlag = value; }
        }
        public string AutocloseDays
        {
            get { return _AutocloseDays; }
            set { _AutocloseDays = value; }
        }
        public bool AutoGen
        {
            get { return _AutoGen; }
            set { _AutoGen = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        } 
        public byte UserAction
        {
            get { return _UserAction; }
            set { _UserAction = value; }
        }
        public long MasterID
        {
            get { return _ID_Settings; }
            set { _ID_Settings = value; }
        }
        public string Module
        {
            get { return _Module; }
            set { _Module = value; }
        }
        public string SubModule
        {
            get { return _SubModule; }
            set { _SubModule = value; }
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


        public long InsertData()
        {
            long status;
            DalSettings dalSettings = new DalSettings();
            status = 0;
            try
            {
                _UserAction = 1;
                status = dalSettings.UpdateSettings(this);
                dalSettings = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public long UpdateData()
        {
            DalSettings dalSettings = new DalSettings();
            long status;
            status = 0;
            try
            {
                _UserAction = 2;
                status = dalSettings.UpdateSettings(this);
                dalSettings = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public DataTable SelectAllData()
        {
            DataTable dtbl = new DataTable();
            DalSettings dalSettings = new DalSettings();
            dtbl = dalSettings.SelectAllSettings(this);
            dalSettings = null;
            return dtbl;
        }
        public long DeleteData()
        {
            _UserAction = 3;
            DalSettings dalSettings = new DalSettings();
            long status;
            status = 0;
            try
            {
                status = dalSettings.DeleteSettings(this);
                dalSettings = null;
            }
            catch (Exception ex)
            {

            }
            return status;
        }
    }
}
