using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupportTicket.Filters;
using System.Data;
using SupportTicket.Business.Masters;
using SupportTicket.Business;


namespace SupportTicket.Controllers
{
    [CheckSessionTimeOutUser]
    public class UserDashboardController : Controller
    {
        //
        // GET: /UserDashboard/
        public UserDashboardController()
        {
            ViewBag.api_url = System.Configuration.ConfigurationManager.AppSettings["api-url"];
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserDashboard()
        {
            
            ViewBag.lastname = "Nithin Das h";
            return View();
        }



        public ActionResult UserChangePassword()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UpdateUserChangePassword(BlUser ObjBlUser)
        {
            ObjBlUser.UserCode = Convert.ToInt64(Session["ID_Users"]);
            ObjBlUser.FK_Company = Convert.ToInt64(Session["ID_Company"]);
            ObjBlUser.MasterID = Convert.ToInt64(Session["ID_Users"]);

            BlFunction blfunctions = new BlFunction();
            string CurrentPassword = "";
            CurrentPassword = blfunctions.EncryptAgent(Convert.ToString(ObjBlUser.CurrentPassword.Trim()));
            ObjBlUser.CurrentPassword = CurrentPassword;

            string UserPassword = "";
            UserPassword = blfunctions.EncryptAgent(Convert.ToString(ObjBlUser.UsPassword.Trim()));
            ObjBlUser.UsPassword = UserPassword;

            blfunctions = null;

            long statusCode = 0;
            if (ObjBlUser.MasterID == 0)
            {
                statusCode = ObjBlUser.ChangePassword();
            }
            else
            {
                statusCode = ObjBlUser.ChangePassword();
            }

            ObjBlUser = null;
            return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult FillUserChangePassword()
        {
            try
            {

                DataTable dtbl = new DataTable();
                BlUser blUser = new BlUser();
                blUser.UserCode = Convert.ToInt64(Session["ID_Users"]);
                blUser.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                blUser.MasterID = Convert.ToInt64(Session["ID_Users"]);
                dtbl = blUser.SelectAllData();

                BlFunction blfunctions = new BlFunction();
                dtbl.Rows[0][6] = blfunctions.DecryptAgent(Convert.ToString(dtbl.Rows[0][6].ToString()));
                blfunctions = null;

                return Json(Converttojson(dtbl), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]
        public JsonResult SelectUserDashBoard()
        {
            try
            {

                int statusCode = 1;
                DataTable dtbl = new DataTable();
                BlUser blUser = new BlUser();
                blUser.UserCode = Convert.ToInt64(Session["ID_Users"]);
                blUser.FK_Company = Convert.ToInt64(Session["ID_Company"]);

                dtbl = blUser.SelectUserDashBoard();

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
     

    }
}
