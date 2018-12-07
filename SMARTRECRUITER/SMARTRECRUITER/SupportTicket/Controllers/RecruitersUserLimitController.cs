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
using SupportTicket.Models;
using SupportTicket.Filters;
using System.IO;
using System.Net;
using System.Web.Helpers;


namespace SupportTicket.Controllers
{
     [CheckSessionTimeOut]
    public class RecruitersUserLimitController : Controller
    {
        //
        // GET: /RecruitersUserLimit/

        public RecruitersUserLimitController()
        {

            ViewBag.api_url = ConfigurationManager.AppSettings["api-url"];


        }



        public ActionResult RecruitersUserLimit()
        {
            return View();
        }


        [HttpPost]
        public JsonResult CompanyDropDownFill()
        {
            try
            {

                int statusCode = 1;
                BlPopulate blpopulate = new BlPopulate();
                blpopulate.TableName = "Company";
                blpopulate.ListFields = "CompName";
                blpopulate.ValueFields = "ID_Company";
                blpopulate.SortFields = "CompName,ID_Company";
                blpopulate.Criteria = "Cancelled=0 ";
                //AND FK_Company=" + Session["ID_Company"].ToString();
                DataTable dt = new DataTable();
                dt = blpopulate.PopulateData();
                return Json(Converttojson(dt), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ///
                return Json(ex);
            }

        }




        [HttpPost]
        public ActionResult UpdateAgentUserLimit(BlAgentUserLimit ObjBlAgentUserLimit)
        {

            long statusCode = 0;
            ObjBlAgentUserLimit.UserCode = Convert.ToInt64(Session["ID_Agent"]);
            ObjBlAgentUserLimit.FK_Company = Convert.ToInt64(Session["ID_Company"]);
            if (ObjBlAgentUserLimit.MasterID == 0)
            {
                statusCode = ObjBlAgentUserLimit.InsertData();
            }
            else
            {
                statusCode = ObjBlAgentUserLimit.UpdateData();
            }

            return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult SelectAgentUserLimitAll(string PageIndex = "1", string SearchItem = "")
        {
            try
            {

                int statusCode = 1;
                DataTable dtbl = new DataTable();
                BlAgentUserLimit blAgentUserLimit = new BlAgentUserLimit();
                blAgentUserLimit.PageIndex = Convert.ToInt32(PageIndex);
                blAgentUserLimit.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                blAgentUserLimit.CompName = SearchItem;
                //blAgentUserLimit.FK_CompanyMaster = SearchItem;
                //blAgentUserLimit.AgentUserLimitName = SearchItem;

                dtbl = blAgentUserLimit.SelectAllData();
                return Json(Converttojson(dtbl), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ///
                return Json(ex);
            }

        }


        [HttpGet]
        public JsonResult DeleteAgentUserLimit(Int64 ID_AgentUserLimit)
        {
            try
            {
                long statusCode = 0;
                BlAgentUserLimit blAgentUserLimit = new BlAgentUserLimit();
                blAgentUserLimit.MasterID = ID_AgentUserLimit;
                blAgentUserLimit.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blAgentUserLimit.FK_Company = Convert.ToInt64(Session["ID_Company"]);

                statusCode = blAgentUserLimit.DeleteData();
                return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        [HttpGet]
        public JsonResult FillAgentUserLimit(Int64 ID_AgentUserLimit)
        {
            try
            {

                DataTable dtbl = new DataTable();
                BlAgentUserLimit blAgentUserLimit = new BlAgentUserLimit();
                blAgentUserLimit.MasterID = ID_AgentUserLimit;
                blAgentUserLimit.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blAgentUserLimit.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                dtbl = blAgentUserLimit.SelectAllData();
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







    }
}


