using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicket.Interface.Masters
{
    public interface IAgentUserLimit : ICommon
    {
        int FK_CompanyMaster { get; set; }
        int UserLimit { get; set; }
        int AgentLimit { get; set; }
        string CompName { get; set; }
     
    }
}
