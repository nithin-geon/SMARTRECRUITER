using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportTicket.Interface.Masters;
using SupportTicket.DataAccess.Masters;
using System.Data;
using System.Collections;

namespace SupportTicket.Business.Masters
{
    public class BlPage:IPages
    {
        private byte _UserAction;
        private long _ID_Pages;
        private long _FK_PageModule;
        private string _ControllerName;
        private string _PageName;
        private string _Url;
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


        public BlPage()
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
            _Active = 0;
            _PageName = string.Empty;
            _Url = string.Empty;
            _ControllerName = string.Empty;
            _ID_Pages = 0;
            _FK_PageModule = 0;
        }

        public byte UserAction
        {
            get { return _UserAction; }
            set { _UserAction = value; }
        }
        public long MasterID
        {
            get { return _ID_Pages; }
            set { _ID_Pages = value; }
        }
        public string PageName
        {
            get { return _PageName; }
            set { _PageName = value; }
        }
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        public string ControllerName
        {
            get { return _ControllerName; }
            set { _ControllerName = value; }
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
        public long FK_PageModule
        {
            get { return _FK_PageModule; }
            set { _FK_PageModule = value; }
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
        //public long InsertData()
        //{
        //    long status;
        //    DalReseller dalreseller = new DalReseller();
        //    status = 0;
        //    try
        //    {
        //        _UserAction = 1;
        //        status = dalreseller.UpdateReseller(this);
        //        dalreseller = null;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return status;
        //}
        //public long UpdateData()
        //{
        //    DalReseller dalreseller = new DalReseller();
        //    long status;
        //    status = 0;
        //    try
        //    {
        //        _UserAction = 2;
        //        status = dalreseller.UpdateReseller(this);
        //        dalreseller = null;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return status;
        //}
        //public long DeleteData()
        //{
        //    _UserAction = 3;
        //    DalReseller dalreseller = new DalReseller();
        //    long status;
        //    status = 0;
        //    try
        //    {
        //        status = dalreseller.DeleteReseller(this);
        //        dalreseller = null;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return status;
        //}
        //public ArrayList SelectAllPages()
        //{
        //    DalPages dalPage = new DalPages();
        //    try
        //    {

        //        return dalPage.SelectAllPages(this);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        dalPage = null;
        //    }
        //}
        public DataTable FillModules()
        {
            DataTable dtbl = new DataTable();
            DalPages dalmenu = new DalPages();
            dtbl = dalmenu.FillModules();
            dalmenu = null;
            return dtbl;
        }
        public DataTable FillPages()
        {
            DataTable dtbl = new DataTable();
            DalPages dalmenu = new DalPages(); 
            dtbl = dalmenu.FillPages(this);
            dalmenu = null;
            return dtbl;
        }
    }
}
