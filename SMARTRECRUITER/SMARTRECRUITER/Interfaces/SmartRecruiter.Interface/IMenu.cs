using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicket.Interface
{
   public interface IMenu
    {
       long ID_PageModule { get; set; }
       string ModuleName { get; set; }
       long ID_Pages { get; set; }
       string PageName { get; set; }
       string Url { get; set; }
       long UserCode  { get; set; }
       long FK_Company  { get; set; }
       Boolean Cancelled { get; set; }
       long MasterID { get; set; }
       Int32 PageIndex { get; set; }
       Int32 PageSize { get; set; }
       long FK_DropDownAgent { get; set; }
    }
}
