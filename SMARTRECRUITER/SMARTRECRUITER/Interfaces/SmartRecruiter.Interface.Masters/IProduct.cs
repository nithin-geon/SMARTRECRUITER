using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SupportTicket.Interface.Masters
{
    public interface IProduct:ICommon
    {
        string ProdCode { get; set; }
        string ProdName { get; set; }
        long FK_DefaultDepartment { get; set; }
        byte Active { get; set; }
        long SortOrder { get; set; }
    }
}
