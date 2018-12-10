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
    public class StatusController : Controller
    {
        //
        // GET: /Masters/
        public StatusController()
        {

            ViewBag.api_url = ConfigurationManager.AppSettings["api-url"];


        }
        public ActionResult Index()
        {
            return View();
        }

        #region Status Controller
        public ActionResult Status()
        {

            ViewBag.Message = "Your app description page.";
            return View();
        }
        [HttpPost]
        public ActionResult UpdateStatus(BlStatus ObjBlStatus)
        {
            ObjBlStatus.UserCode = Convert.ToInt64(Session["ID_Agent"]);
            ObjBlStatus.FK_Company = Convert.ToInt64(Session["ID_Company"]);
            long statusCode = 0;
            if (ObjBlStatus.MasterID == 0)
            {
                statusCode = ObjBlStatus.InsertData();
            }
            else
            {
                statusCode = ObjBlStatus.UpdateData();
            }

            return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
        }       
        [HttpGet]
        public JsonResult SelectStatusAll(string PageIndex = "1", string SearchItem = "")
        {
            try
            {
                
                int statusCode = 1;
                DataTable dtbl = new DataTable();
                BlStatus blStatus = new BlStatus();
                blStatus.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blStatus.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                blStatus.StatusCode = SearchItem;
                blStatus.StatusName = SearchItem;
                blStatus.PageIndex = Convert.ToInt32(PageIndex);
                dtbl = blStatus.SelectAllData();
                return Json(Converttojson(dtbl), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ///
                return Json(ex);
            }

        }

        [HttpGet]
        public JsonResult DeleteStatus(Int64 ID_Status)
        {
            try
            {
                long statusCode = 0;
                BlStatus blStatus = new BlStatus();
                blStatus.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blStatus.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                blStatus.MasterID = ID_Status;
                statusCode = blStatus.DeleteData();
                return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        [HttpGet]
        public JsonResult FillStatus(Int64 ID_Status)
        {
            try
            {

                DataTable dtbl = new DataTable();
                BlStatus blStatus = new BlStatus();
                blStatus.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blStatus.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                blStatus.MasterID = ID_Status;
                dtbl = blStatus.SelectAllData();
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
