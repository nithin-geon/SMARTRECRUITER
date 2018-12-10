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
using System.Web.Helpers;


namespace SupportTicket.Controllers
{
    [CheckSessionTimeOut]
    public class UsersController : Controller
    {
     
        public UsersController()
        {

            ViewBag.api_url = ConfigurationManager.AppSettings["api-url"];


        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);
                    _ext = _ext.ToLower();
                    if (_ext == ".jpg" || _ext == ".jpeg" || _ext == ".gif" || _ext == ".bmp" || _ext == ".png" || _ext == ".jpe" || _ext == ".jfif" || _ext == ".tif" || _ext == ".tiff")
                    {
                        _imgname = Guid.NewGuid().ToString();
                        var _comPath = Server.MapPath("../UploadedImages/UserUpload/User_") + DateTime.Now.Ticks.ToString() + fileName;
                        string sikdj = DateTime.Now.Ticks.ToString();
                        _imgname = "User_" + DateTime.Now.Ticks.ToString() + fileName;
                        ViewBag.Msg = _comPath;
                        var path = _comPath;

                        // Saving Image in Original Mode
                        pic.SaveAs(path);

                        // resizing image
                        MemoryStream ms = new MemoryStream();
                        WebImage img = new WebImage(_comPath);

                        if (img.Width > 200)
                            img.Resize(200, 200);
                        img.Save(_comPath);
                        // end resize
                    }
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateUser(BlUser ObjBlUser)
        {
            ObjBlUser.UserCode = Convert.ToInt64(Session["ID_Agent"]);
            ObjBlUser.FK_Company = Convert.ToInt64(Session["ID_Company"]);

            BlFunction blfunctions = new BlFunction();
            string AgentPassword = "";
            AgentPassword = blfunctions.EncryptAgent(Convert.ToString(ObjBlUser.UsPassword.Trim()));
            ObjBlUser.UsPassword = AgentPassword;
            blfunctions = null;

            long statusCode = 0;
            if (ObjBlUser.MasterID == 0)
            {
                statusCode = ObjBlUser.InsertData();
            }
            else
            {
                statusCode = ObjBlUser.UpdateData();
            }

            ObjBlUser = null;
            return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult SelectUserAll(string PageIndex = "1", string SearchItem = "")
        {
            try
            {

                int statusCode = 1;
                DataTable dtbl = new DataTable();
                BlUser blUser = new BlUser();
                blUser.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blUser.FK_Company = Convert.ToInt64(Session["ID_Company"]);

                blUser.UsCode = SearchItem;
                blUser.UsName = SearchItem;
                blUser.Usemail = SearchItem;

                blUser.PageIndex = Convert.ToInt32(PageIndex);
                dtbl = blUser.SelectAllData();

                return Json(Converttojson(dtbl), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ///
                return Json(ex);
            }

        }

        [HttpGet]
        public JsonResult DeleteUser(Int64 ID_User)
        {
            try
            {
                long statusCode = 0;
                BlUser blUser = new BlUser();
                blUser.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blUser.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                blUser.MasterID = ID_User;
                statusCode = blUser.DeleteData();
                return Json(new { statusCode = "" + statusCode + "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        [HttpGet]
        public JsonResult FillUser(Int64 ID_User)
        {
            try
            {

                DataTable dtbl = new DataTable();
                BlUser blUser = new BlUser();
                blUser.UserCode = Convert.ToInt64(Session["ID_Agent"]);
                blUser.FK_Company = Convert.ToInt64(Session["ID_Company"]);
                blUser.MasterID = ID_User;
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


        [HttpPost]
        public JsonResult ClientDropDownFill()
        {
            try
            {

                int statusCode = 1;
                BlPopulate blpopulate = new BlPopulate();
                blpopulate.TableName = "Client";
                blpopulate.ListFields = "CliName";
                blpopulate.ValueFields = "ID_Client";
                blpopulate.ListFields2 = "CliShortName";
                blpopulate.SortFields = "CliName,ID_Client";
                blpopulate.Criteria = "Cancelled=0 AND Active=1  AND FK_Company=" + Session["ID_Company"].ToString();
                DataTable dt = new DataTable();
                dt = blpopulate.PopulateDataTwoFields();
                return Json(Converttojson(dt), JsonRequestBehavior.AllowGet);

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
