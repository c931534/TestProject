using HFTestProject.Controllers.Products_CRUD;
using HFTestProject.Models;
using HFTestProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFTestProject.Service
{
    public class ProductsService
    {
        private ProductsRepo productsRepo = new ProductsRepo();

        public IEnumerable<ProductsViewList> SelectAll()
        {
            return productsRepo.SelectAll();
        }

        public IEnumerable<ProductsViewList> IndexDefault()
        {
            return productsRepo.IndexDefault();
        }

        public IEnumerable<ProductsViewList> FindList(string productid, string productname, string supplierid, string categoryid, string discontinued)
        {
            return productsRepo.FindList(productid, productname, supplierid, categoryid, discontinued);
        }

        public IDictionary<string, string> AutoProductID(string productid)
        {
            return productsRepo.AutoProductID(productid);
        }

        public IDictionary<string, string> AutoProductName(string productname)
        {
            return productsRepo.AutoProductName(productname);
        }
    }
}