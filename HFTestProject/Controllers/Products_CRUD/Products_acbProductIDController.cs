using HFTestProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HFTestProject.Controllers.Products_CRUD
{
    public class Products_acbProductIDController : ApiController
    {
        private ProductsService productsService = new ProductsService();

        public IDictionary<string, string> Get(string id)
        {
            return productsService.AutoProductID(id);
        }
    }
}
