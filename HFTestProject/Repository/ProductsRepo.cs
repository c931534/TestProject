using HFTestProject.Controllers.Products_CRUD;
using HFTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFTestProject.Repository
{
    public class ProductsRepo
    {
        NorthwindEntities dc = new NorthwindEntities();

        #region 查詢

        public IEnumerable<ProductsViewList> SelectAll()
        {
            var query = (from products in dc.Products
                         join categories in dc.Categories
                         on products.CategoryID equals categories.CategoryID
                         join supplier in dc.Suppliers
                         on products.SupplierID equals supplier.SupplierID
                         select new ProductsViewList
                         {
                             ProductID = products.ProductID,
                             ProductName = products.ProductName,
                             SupplierID = products.SupplierID,
                             CompanyName = supplier.CompanyName,
                             CategoryID = products.CategoryID,
                             CategoryName = categories.CategoryName,
                             QuantityPerUnit = products.QuantityPerUnit,
                             UnitPrice = products.UnitPrice,
                             UnitsInStock = products.UnitsInStock,
                             UnitsOnOrder = products.UnitsOnOrder,
                             ReorderLevel = products.ReorderLevel,
                             Discontinued = products.Discontinued
                         });
            query = query.OrderBy(x => x.ProductID);
            return query;
        }

        public IEnumerable<ProductsViewList> IndexDefault()
        {
            var query = (from products in dc.Products
                         join categories in dc.Categories
                         on products.CategoryID equals categories.CategoryID
                         join supplier in dc.Suppliers
                         on products.SupplierID equals supplier.SupplierID
                         select new ProductsViewList
                         {
                             ProductID = products.ProductID,
                             ProductName = products.ProductName,
                             SupplierID = products.SupplierID,
                             CompanyName = supplier.CompanyName,
                             CategoryID = products.CategoryID,
                             CategoryName = categories.CategoryName,
                             QuantityPerUnit = products.QuantityPerUnit,
                             UnitPrice = products.UnitPrice,
                             UnitsInStock = products.UnitsInStock,
                             UnitsOnOrder = products.UnitsOnOrder,
                             ReorderLevel = products.ReorderLevel,
                             Discontinued = products.Discontinued
                         });

            query = query.Where(x => x.ProductName == null).OrderBy(x => x.ProductID);

            return query;
        }

        public IEnumerable<ProductsViewList> FindList(string productid,
                                           string productname,
                                           string supplierid,
                                           string categoryid,
                                           string discontinued)
        {

            var query = (from products in dc.Products
                         join categories in dc.Categories
                         on products.CategoryID equals categories.CategoryID
                         join supplier in dc.Suppliers
                         on products.SupplierID equals supplier.SupplierID
                         select new ProductsViewList
                         {
                             ProductID = products.ProductID,
                             ProductName = products.ProductName,
                             SupplierID = products.SupplierID,
                             CompanyName = supplier.CompanyName,
                             CategoryID = products.CategoryID,
                             CategoryName = categories.CategoryName,
                             QuantityPerUnit = products.QuantityPerUnit,
                             UnitPrice = products.UnitPrice,
                             UnitsInStock = products.UnitsInStock,
                             UnitsOnOrder = products.UnitsOnOrder,
                             ReorderLevel = products.ReorderLevel,
                             Discontinued = products.Discontinued});

            if (!string.IsNullOrWhiteSpace(productid))
            {
                query = query.Where(
                    x => x.ProductID.ToString().Contains(productid));
            }

            if (!string.IsNullOrWhiteSpace(productname))
            {
                query = query.Where(
                    x => x.ProductName.Contains(productname));
            }

            if (!string.IsNullOrWhiteSpace(supplierid))
            {
                query = query.Where(
                    x => x.SupplierID.ToString().Contains(supplierid));
            }

            if (!string.IsNullOrWhiteSpace(categoryid))
            {
                query = query.Where(
                    x => x.CategoryID.ToString().Equals(categoryid));
            }

            if (!string.IsNullOrWhiteSpace(discontinued))
            {
                query = query.Where(
                    x => x.Discontinued.ToString().Equals(discontinued));
            }

            query = query.OrderBy(x => x.ProductID);

            return (query);

        }

        #endregion

        #region AutoComplete

        public IDictionary<string, string> AutoProductID(string productid)
        {
            return dc.Products.Where(
                c => c.ProductID.ToString().Contains(productid)).
                ToDictionary(c => c.ProductID.ToString(), c => c.ProductName);
        }

        public IDictionary<string, string> AutoProductName(string productname)
        {
            return dc.Products.Where(
                c => c.ProductName.StartsWith(productname)).
                ToDictionary(c => c.ProductID.ToString(), c => c.ProductName);
        }

        #endregion
    }
}