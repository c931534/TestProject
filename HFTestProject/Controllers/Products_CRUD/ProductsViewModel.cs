using HFTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFTestProject.Controllers.Products_CRUD
{
    public class ProductsViewModel
    {
        public ProductsSearchModel SearchParameter { get; set; }

        public List<ProductsViewList> Products_list { get; set; }

        public SelectList CategoryID_List { get; set; }

        public SelectList Discontinued_List { get; set; }
    }
}