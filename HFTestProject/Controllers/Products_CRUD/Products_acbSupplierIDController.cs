using HFTestProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HFTestProject.Controllers.Products_CRUD
{
    public class Products_acbSupplierIDController : ApiController
    {
        private SuppliersService suppliersService = new SuppliersService();

        public IDictionary<string, string> Get(string id)
        {
            return suppliersService.AutoSupplierID(id);
        }
    }
}
