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
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult Index()
        {
            return View();
        }

        public SettingsController()
        {

            ViewBag.api_url = ConfigurationManager.AppSettings["api-url"];

        }

        #region Settings Controller
        public ActionResult Settings()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSettings(BlSettings ObjBlSettings)
        {
            ObjBlSettings.UserCode = Convert.ToInt64(Session["ID_Agent"]);
            ObjBlSettings.FK_Company = Convert.ToInt64(Session["ID_Company"]);
            long statusCode = 0;
            if (ObjBlSettings.MasterID == 0)
            {
                SaveData("GEN", "TKT", "AUTO", ObjBlSettings.AutoGen == true ? "1" : "0", 1);
                statusCode = SaveData("GEN", "TKT", "PRF", ObjBlSettings.Prefix, 2);
            }
            else
            {
                //statusCode = ObjBlSettings.UpdateData();
            }

            return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateSettingsAutoclose(BlSettings ObjBlSettings)
        {
            ObjBlSettings.UserCode = Convert.ToInt64(Session["ID_Agent"]);
            ObjBlSettings.FK_Company = Convert.ToInt64(Session["ID_Company"]);
            long statusCode = 0;
            if (ObjBlSettings.MasterID == 0)
            {

                statusCode = SaveData("GEN", "TKT", "ACL", ObjBlSettings.AutocloseDays,3);
            }
            else
            {
                //statusCode = ObjBlSettings.UpdateData();
            }

            return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
        }


        protected long SaveData(string Module, string SubModule, string Name, string Value, byte DeleteFlag)
        {
            BlSettings ObjBlSettings = new BlSettings();
            long statusCode = 0;
            ObjBlSettings.Module = Module;
            ObjBlSettings.SubModule = SubModule;
            ObjBlSettings.DeleteFlag = DeleteFlag;
            ObjBlSettings.Name = Name;
            ObjBlSettings.Value = Value;
            ObjBlSettings.FK_Company = Convert.ToInt64(Session["ID_Company"]);
            ObjBlSettings.UserCode = Convert.ToInt64(Session["ID_Agent"]);
            statusCode = ObjBlSettings.UpdateData();
            ObjBlSettings = null;
            return statusCode;
        }


        [HttpGet]
        public JsonResult FillSettings(string Module = "", string SubModule = "")
        {
            try
            {

                int statusCode = 1;

                DataTable dtbl = new DataTable();

                BlSettings ObjBlSettings = new BlSettings();
                ObjBlSettings.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                ObjBlSettings.FK_Company = Convert.ToInt64(Session["ID_Company"]);

                ObjBlSettings.Module = "GEN";
                ObjBlSettings.SubModule = "TKT";
                dtbl = ObjBlSettings.SelectAllData();

                //ObjBlSettings.AutoGen = Convert.ToBoolean(dtbl.Rows[0]["Value"].ToString());
               // ObjBlSettings.Prefix = dtbl.Rows[1]["Value"].ToString();

                return Json(Converttojson(dtbl), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ///
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
