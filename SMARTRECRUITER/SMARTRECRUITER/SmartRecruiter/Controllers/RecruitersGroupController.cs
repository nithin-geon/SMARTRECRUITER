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
    public class RecruitersGroupController : Controller
    {
        //
        // GET: /RecruitersGroup/

        public ActionResult RecruitersGroup()
        {
            return View();
        }


        public RecruitersGroupController()
        {

            ViewBag.api_url = ConfigurationManager.AppSettings["api-url"];


        }



        [HttpPost]
        public ActionResult UpdateAgentGroup(BlAgentGroup ObjBlAgentGroup)
        {

            long statusCode = 0;
            ObjBlAgentGroup.UserCode = Convert.ToInt64(Session["ID_Agent"]);
            ObjBlAgentGroup.FK_Company = Convert.ToInt64(Session["ID_Company"]);
            if (ObjBlAgentGroup.MasterID == 0)
            {
                statusCode = ObjBlAgentGroup.InsertData();
            }
            else
            {
                statusCode = ObjBlAgentGroup.UpdateData();
            }

            return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult SelectAgentGroupAll(string PageIndex = "1", string SearchItem = "")
        {
            try
            {

                int statusCode = 1;
                DataTable dtbl = new DataTable();
                BlAgentGroup blAgentGroup = new BlAgentGroup();
                blAgentGroup.PageIndex = Convert.ToInt32(PageIndex);
                blAgentGroup.FK_Company = Convert.ToInt64(Session["ID_Company"]);

                blAgentGroup.AgentGroupCode = SearchItem;
                blAgentGroup.AgentGroupName = SearchItem;

                dtbl = blAgentGroup.SelectAllData();
                return Json(Converttojson(dtbl), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ///
                return Json(ex);
            }

        }


        [HttpGet]
        public JsonResult DeleteAgentGroup(Int64 ID_AgentGroup)
        {
            try
            {
                long statusCode = 0;
                BlAgentGroup blAgentGroup = new BlAgentGroup();
                blAgentGroup.MasterID = ID_AgentGroup;
                blAgentGroup.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blAgentGroup.FK_Company = Convert.ToInt64(Session["ID_Company"]);

                statusCode = blAgentGroup.DeleteData();
                return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        [HttpGet]
        public JsonResult FillAgentGroup(Int64 ID_AgentGroup)
        {
            try
            {

                DataTable dtbl = new DataTable();
                BlAgentGroup blAgentGroup = new BlAgentGroup();
                blAgentGroup.MasterID = ID_AgentGroup;
                blAgentGroup.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blAgentGroup.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                dtbl = blAgentGroup.SelectAllData();
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
