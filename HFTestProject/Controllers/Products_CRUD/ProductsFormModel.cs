using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HFTestProject.Controllers.Products_CRUD
{
    public class ProductsFormModel
    {
        [DisplayName("產品編號")]
        public string ProductID { get; set; }
        [DisplayName("產品名稱")]
        [Required]
        public string ProductName { get; set; }
        [DisplayName("供應商")]
        [Required]
        public string SupplierID { get; set; }
        [DisplayName("類別")]
        [Required]
        public string CategoryID { get; set; }
        [DisplayName("每單位數量")]
        public string QuantityPerUnit { get; set; }
        [DisplayName("單價")]
        public Nullable<decimal> UnitPrice { get; set; }
        [DisplayName("庫存量")]
        public Nullable<short> UnitsInStock { get; set; }
        [DisplayName("受訂量")]
        public Nullable<short> UnitsOnOrder { get; set; }
        [DisplayName("再訂貨點")]
        public Nullable<short> ReorderLevel { get; set; }
        [DisplayName("停產否")]
        [Required]
        public string Discontinued { get; set; }

    }
}