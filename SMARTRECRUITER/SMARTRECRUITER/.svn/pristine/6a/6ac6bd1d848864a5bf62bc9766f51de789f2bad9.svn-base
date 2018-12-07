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
    public class WorkFlowController : Controller
    {
        //
        // GET: /WorkFlow/


         public WorkFlowController()
        {

            ViewBag.api_url = ConfigurationManager.AppSettings["api-url"];
             

        }

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult WorkFlow()
        {
            return View();
        }




        [HttpPost]
        public ActionResult UpdateWorkFlow(BlWorkFlow ObjBlWorkFlow)
        {

            long statusCode = 0;
            ObjBlWorkFlow.UserCode = Convert.ToInt64(Session["ID_Agent"]);
            ObjBlWorkFlow.FK_Company = Convert.ToInt64(Session["ID_Company"]);
            if (ObjBlWorkFlow.MasterID == 0)
            {
                statusCode = ObjBlWorkFlow.InsertData();
            }
            else
            {
                statusCode = ObjBlWorkFlow.UpdateData();
            }

            return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult SelectWorkFlowAll(string PageIndex = "1", string SearchItem = "")
        {
            try
            {

                int statusCode = 1;
                DataTable dtbl = new DataTable();
                BlWorkFlow blWorkFlow = new BlWorkFlow();
                blWorkFlow.PageIndex = Convert.ToInt32(PageIndex);
                blWorkFlow.FK_Company = Convert.ToInt64(Session["ID_Company"]);

                blWorkFlow.WorkFlowCode = SearchItem;
                blWorkFlow.WorkFlowName = SearchItem;

                dtbl = blWorkFlow.SelectAllData();
                return Json(Converttojson(dtbl), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ///
                return Json(ex);
            }

        }


        [HttpGet]
        public JsonResult DeleteWorkFlow(Int64 ID_WorkFlow)
        {
            try
            {
                long statusCode = 0;
                BlWorkFlow blWorkFlow = new BlWorkFlow();
                blWorkFlow.MasterID = ID_WorkFlow;
                blWorkFlow.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blWorkFlow.FK_Company = Convert.ToInt64(Session["ID_Company"]);

                statusCode = blWorkFlow.DeleteData();
                return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        [HttpGet]
        public JsonResult FillWorkFlow(Int64 ID_WorkFlow)
        {
            try
            {

                DataTable dtbl = new DataTable();
                BlWorkFlow blWorkFlow = new BlWorkFlow();
                blWorkFlow.MasterID = ID_WorkFlow;
                blWorkFlow.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blWorkFlow.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                dtbl = blWorkFlow.SelectAllData();
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





