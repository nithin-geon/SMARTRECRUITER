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
    public class BlProduct : IProduct
    {
        private byte _UserAction;
        private long _ID_Product;
        private string _ProdCode;
        private string _ProdName;
        private long _FK_DefaultDepartment;
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


        public BlProduct()
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
            _ProdCode = string.Empty;
            _ProdName = string.Empty;
            _ID_Product = 0;
            _Active = 0;
        }

        public byte UserAction
        {
            get { return _UserAction; }
            set { _UserAction = value; }
        }
        public long MasterID
        {
            get { return _ID_Product; }
            set { _ID_Product = value; }
        }
        public string ProdCode
        {
            get { return _ProdCode; }
            set { _ProdCode = value; }
        }
        public string ProdName
        {
            get { return _ProdName; }
            set { _ProdName = value; }
        }
        public long FK_DefaultDepartment
        {
            get { return _FK_DefaultDepartment; }
            set { _FK_DefaultDepartment = value; }
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
            DalProduct dalProduct = new DalProduct();
            status = 0;
            try
            {
                _UserAction = 1;
                status = dalProduct.UpdateProduct(this);
                dalProduct = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public long UpdateData()
        {
            DalProduct dalProduct = new DalProduct();
            long status;
            status = 0;
            try
            {
                _UserAction = 2;
                status = dalProduct.UpdateProduct(this);
                dalProduct = null;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        //public long DeleteData()
        //{
        //    DalProduct dalProduct = new DalProduct();
        //    long status;
        //    status = 0;
        //    try
        //    {
        //        status = dalProduct.DeleteProduct(this);
        //        dalProduct = null;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return status;
        //}
        //public void SelectData()
        //{
        //    DalProduct dalProduct = new DalProduct();
        //    IProduct iProduct;
        //    iProduct = (IProduct)dalProduct.SelectProduct(this);
        //    //_ShortName = iProduct.ShortName;
        //    //_Name = iProduct.Name;
        //    //_Address1 = iProduct.Address1;
        //    //_Address2 = iProduct.Address2;
        //    //_Address3 = iProduct.Address3;
        //    //_Active = iProduct.Active;
        //    dalProduct = null;
        //}
        public DataTable SelectAllData()
        {
            DataTable dtbl = new DataTable();
            DalProduct dalProduct = new DalProduct();
            dtbl = dalProduct.SelectAllProduct(this);
            dalProduct = null;
            return dtbl;
        }
        public long DeleteData()
        {
            _UserAction = 3;
            DalProduct dalProduct = new DalProduct();
            long status;
            status = 0;
            try
            {
                status = dalProduct.DeleteProduct(this);
                dalProduct = null;
            }
            catch (Exception ex)
            {

            }
            return status;
        }
    }
}
