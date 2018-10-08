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

        #region 查詢

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

        #endregion

        #region 新增/修改

        public void Create(Products products)
        {
            productsRepo.Create(products);
        }

        public void Edit(Products products)
        {
            productsRepo.Edit(products);
        }

        public Products SelectByID(string productid)
        {
            return productsRepo.SelectByID(productid);
        }

        public string newProductID()
        {
            string a = productsRepo.newProductID();

            if (a == null || a == "")
            {
                return ("1");
            }
            else
            {
                return (Convert.ToDecimal(a) + 1).ToString();
            }
        }

        #endregion

        public void Save()
        {
            productsRepo.Save();
        }

        public void Dispose()
        {
            productsRepo.Dispose();
        }

        #region AutoComplete

        public IDictionary<string, string> AutoProductID(string productid)
        {
            return productsRepo.AutoProductID(productid);
        }

        public IDictionary<string, string> AutoProductName(string productname)
        {
            return productsRepo.AutoProductName(productname);
        }

        public IDictionary<string, string> AutoQuantityPerUnit(string quantityperunit)
        {
            return productsRepo.AutoQuantityPerUnit(quantityperunit);
        }

        #endregion

    }
}