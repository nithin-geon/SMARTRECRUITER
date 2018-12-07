using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SupportTicket.Business;
using SupportTicket.Interface;

using SupportTicket.Business.Masters;
using SupportTicket.Interface.Masters;
using System.Text;
using System.Configuration;
using SupportTicket.Filters;

namespace SupportTicket.Controllers
{
    [CheckSessionTimeOut]
    public class CompanyController : Controller
    {
        //
        // GET: /Masters/
        public CompanyController()
        {
            ViewBag.api_url = ConfigurationManager.AppSettings["api-url"];
        }
        public ActionResult Index()
        {
            return View();
        }
        #region Company Controller
        public ActionResult Company()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }
        [HttpPost]
        public ActionResult UpdateCompany(BlCompany ObjBlCompany)
        {
            ObjBlCompany.UserCode = Convert.ToInt64(Session["ID_Agent"]);
            ObjBlCompany.FK_Company = Convert.ToInt64(Session["ID_Company"]);
            long statusCode = 0;
            if (ObjBlCompany.MasterID == 0)
            {
                statusCode = ObjBlCompany.InsertData();
            }
            else
            {
                statusCode = ObjBlCompany.UpdateData();
            }

            return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
        }       
        [HttpGet]
        public JsonResult SelectCompanyAll(string PageIndex = "1",string SearchItem = "")
        {
            try
            {            
                DataTable dtbl = new DataTable();
                BlCompany blCompany = new BlCompany();
                blCompany.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                blCompany.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blCompany.PageIndex = Convert.ToInt32(PageIndex);
                blCompany.CompanyCode = SearchItem;
                blCompany.CompanyName = SearchItem;
                blCompany.CompanyEmail = SearchItem;
                dtbl = blCompany.SelectAllData();
                return Json(Converttojson(dtbl), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ///
                return Json(ex);
            }

        }

        [HttpGet]
        public JsonResult DeleteCompany(Int64 ID_Company)
        {
            try
            {
                long statusCode = 0;
                BlCompany blCompany = new BlCompany();
                blCompany.MasterID = ID_Company;
                blCompany.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blCompany.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                statusCode = blCompany.DeleteData();
                return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        [HttpGet]
        public JsonResult FillCompany(Int64 ID_Company)
        {
            try
            {

                DataTable dtbl = new DataTable();
                BlCompany blCompany = new BlCompany();
                blCompany.MasterID = ID_Company;
                blCompany.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blCompany.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                dtbl = blCompany.SelectAllData();
                return Json(Converttojson(dtbl), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        public string Converttojson(DataTable table)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in table.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);

        }     
        #endregion




    }
}
