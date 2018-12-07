﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicket.Interface
{
    public interface ICommon
    {
        byte UserAction { get; set; }
        long MasterID { get; set; }
        long UserCode { get; set; }
        DateTime UserDate { get; set; }
        Boolean Cancelled { get; set; }
        Int64 CancelledUser { get; set; }
        DateTime CancelledOn { get; set; }
        long FK_Company { get; set; }
        Int32 PageIndex { get; set; }
        Int32 PageSize { get; set; }
    }
}
