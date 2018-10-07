using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HFTestProject.Controllers.Products_CRUD
{
    public class ProductsSearchModel
    {
        [DisplayName("產品編號")]
        public string ProductID { get; set; }
        [DisplayName("產品名稱")]
        public string ProductName { get; set; }
        [DisplayName("供應商編號")]
        public string SupplierID { get; set; }
        [DisplayName("類別編號")]
        public string CategoryID { get; set; }
        [DisplayName("停產否")]
        public string Discontinued { get; set; }
    }
}