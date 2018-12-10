using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicket.Interface.Masters
{
    public interface ITopic : ICommon
    {
       
        string TopicCode { get; set; }
        string TopicName { get; set; }
        long SortOrder { get; set; }
        byte Active { get; set; }
    }
}
