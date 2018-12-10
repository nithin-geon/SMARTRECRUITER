using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicket.Business
{
    public class MyResponse<T>
    {
        public int HttpStatusCode { get; set; }
        public int StatusCode { get; set; }
        public int ResultCount { get; set; }
        public string Message { get; set; }
        public string ExMessge { get; set; }
        public List<T> resultList;
        public MyResponse()
        {

            resultList = new List<T>();

        }

    }
}
