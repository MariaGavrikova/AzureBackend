using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendService.App_Start
{
    public static class SecretValues
    {
        public static string ConnectionString
        {
            get
            {
                return HttpContext.Current.Application["ConnectionString"] as string;
            }
            set
            {
                HttpContext.Current.Application["ConnectionString"] = value;
            }
        }
    }
}