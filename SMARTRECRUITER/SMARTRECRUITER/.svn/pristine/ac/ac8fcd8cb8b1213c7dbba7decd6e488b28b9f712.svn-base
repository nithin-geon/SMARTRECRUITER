using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportTicket.Interface;
using System.Data;
using System.Collections;
using SupportTicket.DataAccess;

namespace SupportTicket.Business
{
   public class BlPopulate:IPopulate
    {
        private string _TableName;
        private string _ListFields;
        private string _ListFields2;
        private string _ValueFields;
        private string _ValueFields2;
        private string _SortFields;
        private string _Criteria;
        private string _UpdateField;
        private string _UpdateValue;
        private string _GroupBy;
        private string _Criteria2;

        public string Criteria2
        {
            get { return _Criteria2; }
            set { _Criteria2 = value; }
        }

        public string GroupBy
        {
            get { return _GroupBy; }
            set { _GroupBy = value; }
        }
        private int _PageSize;

        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }
        private int _PageIndex;

        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        public BlPopulate()
        {
            Initialize();
        }
        public void Initialize()
        {
            _TableName = string.Empty;
            _ListFields = string.Empty;
            _ListFields2 = string.Empty;
            _ValueFields = string.Empty;
            _ValueFields2 = string.Empty;
            _SortFields = string.Empty;
            _Criteria = string.Empty;
            _UpdateField = string.Empty;
            _UpdateValue = string.Empty;
            _GroupBy = "";
            _PageIndex = 1;
            _PageSize = 10;
            Criteria2 = string.Empty;
        }

        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        public string ValueFields2
        {
            get { return _ValueFields2; }
            set { _ValueFields2 = value; }
        }

        public string ListFields2
        {
            get { return _ListFields2; }
            set { _ListFields2 = value; }
        }

        public string ListFields
        {
            get { return _ListFields; }
            set { _ListFields = value; }
        }


        public string ValueFields
        {
            get { return _ValueFields; }
            set { _ValueFields = value; }
        }


        public string SortFields
        {
            get { return _SortFields; }
            set { _SortFields = value; }
        }


        public string Criteria
        {
            get { return _Criteria; }
            set { _Criteria = value; }
        }

        public string UpdateField
        {
            get { return _UpdateField; }
            set { _UpdateField = value; }
        }
        public string UpdateValue
        {
            get { return _UpdateValue; }
            set { _UpdateValue = value; }
        }

        public DataTable PopulateData()
        {
            DalPopulate dalpopulate = new DalPopulate();
            try
            {
                return dalpopulate.PopulateData(this);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public DataTable PopulateDataTwoFields()
        {
            DalPopulate dalpopulate = new DalPopulate();
            try
            {
                return dalpopulate.PopulateDataTwoFields(this);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public DataTable PopulateGrid()
        {
            DalPopulate dalpopulate = new DalPopulate();
            try
            {
                return dalpopulate.PopulateGrid(this);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
