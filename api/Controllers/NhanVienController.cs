using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Quanlicaan.api.Controllers
{
    public class NhanVienController : ApiController
    {
        public string Get()
        {
            return "Welcome to Web API";
        }
        public List<string> Get(int id)
        {
            return new List<string>
            {
                "data1", "data2"
            };  
        }
    }
}
