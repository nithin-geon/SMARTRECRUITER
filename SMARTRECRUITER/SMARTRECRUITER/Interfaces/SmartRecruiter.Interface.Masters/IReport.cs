using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicket.Interface.Masters
{
    public interface IReport : ICommon
    {
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        Int64 FK_Client { get; set; }
        Int64 FK_Product { get; set; }
        Int64 FK_Agent { get; set; }
        Int16 Status { get; set; }
        string Search { get; set; }
    }
}
