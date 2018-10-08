using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HFTestProject.Models;
using HFTestProject.Service;

namespace HFTestProject.Controllers.Products_CRUD
{
    public class ProductsController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        private ProductsService productsService = new ProductsService();
        private CategoriesService categoriesService = new CategoriesService();
        private SuppliersService suppliersService = new SuppliersService();

        #region 查詢

        // GET: Products
        public ActionResult Index()
        {
            var model = new ProductsViewModel
            {
                SearchParameter = new ProductsSearchModel(),
                Products_list = productsService.IndexDefault().ToList(),
                CategoryID_List = categoriesService.CategoriesList(),
                Discontinued_List = Source.Source.DiscontinuedList()
            };

            return View(model);
        }

        // POST: Products
        [HttpPost]
        public ActionResult Index(ProductsViewModel model)
        {
            List<ProductsViewList> query;

            if (model.SearchParameter.ProductID != null ||
                model.SearchParameter.ProductName != null ||
                model.SearchParameter.SupplierID != null ||
                model.SearchParameter.CategoryID != null ||
                model.SearchParameter.Discontinued != null)
            {
                query = productsService.FindList(
                    model.SearchParameter.ProductID,
                    model.SearchParameter.ProductName,
                    model.SearchParameter.SupplierID,
                    model.SearchParameter.CategoryID,
                    model.SearchParameter.Discontinued).ToList();
            }
            else
            {
                query = productsService.IndexDefault().ToList();
            }

            var result = new ProductsViewModel
            {
                SearchParameter = model.SearchParameter,
                Products_list = query,
                CategoryID_List = categoriesService.CategoriesList(),
                Discontinued_List = Source.Source.DiscontinuedList()
            };

            return View(result);

        }

        #endregion

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create()
        {
            ViewBag.Suppliers_list = suppliersService.SuppliersList();
            ViewBag.Categories_list = categoriesService.CategoriesList();
            ViewBag.Discontinued_list = Source.Source.DiscontinuedList();

            //Create
            ProductsFormModel product_create = new ProductsFormModel();

            product_create.Discontinued = "False";

            ViewBag.Header = "新增";

            return View("CreateEdit", product_create);

        }

        // POST: Products/Edit
        [HttpPost]
        public ActionResult Edit(string productid)
        {
            ViewBag.Suppliers_list = suppliersService.SuppliersList();
            ViewBag.Categories_list = categoriesService.CategoriesList();
            ViewBag.Discontinued_list = Source.Source.DiscontinuedList();

            Models.Products products = productsService.SelectByID(productid);

            if (products == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductsFormModel products_edit = ModelToFormmodel(products);

                ViewBag.Header = "修改";
                return View("CreateEdit", products_edit);
            }

        }

        // POST: Products/Detail
        [HttpPost]
        public ActionResult Detail(string productid)
        {
            ViewBag.Suppliers_list = suppliersService.SuppliersList();
            ViewBag.Categories_list = categoriesService.CategoriesList();
            ViewBag.Discontinued_list = Source.Source.DiscontinuedList();

            Models.Products products = productsService.SelectByID(productid);

            if (products == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductsFormModel products_detail = ModelToFormmodel(products);

                ViewBag.Header = "明細";
                return View("CreateEdit", products_detail);
            }

        }

        // POST: Products/CreateEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,"+
                                                       "UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")]
                                                        ProductsFormModel products)
        {
            if (ModelState.IsValid)
            {
                if (products.ProductID == null)
                {
                    products.ProductID = productsService.newProductID();
                }

                Models.Products existing = productsService.SelectByID(products.ProductID);
                Models.Products model_products = FormmodelToModel(products);

                if (existing == null)
                {
                    productsService.Create(model_products);
                    productsService.Save();

                    return Content(@"<script>
                                      alert('新增成功，該產品編號為 [ " + products.ProductID + @" ]，返回查詢頁面');
                                      window.location = '/Products/Index';
                             </script>");
                }
                else
                {
                    productsService.Edit(model_products);
                    productsService.Save();
                    return Content(@"<script>
                                      alert('產品編號 [ " + products.ProductID + @" ] 修改成功，返回查詢頁面');
                                      window.location = '/Products/Index';
                             </script>");
                }
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                productsService.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Model ←→ Formmodel

        //物件 Formmodel 轉 物件 Model
        public Products FormmodelToModel(ProductsFormModel products)
        {
            Products model_products = new Products();

            model_products.ProductID = Convert.ToInt32(products.ProductID);
            model_products.ProductName = products.ProductName;
            model_products.SupplierID = Convert.ToInt32(products.SupplierID);
            model_products.CategoryID = Convert.ToInt32(products.CategoryID);
            model_products.QuantityPerUnit = products.QuantityPerUnit;
            model_products.UnitPrice = products.UnitPrice;
            model_products.UnitsInStock = products.UnitsInStock;
            model_products.UnitsOnOrder = products.UnitsOnOrder;
            model_products.ReorderLevel = products.ReorderLevel;
            model_products.Discontinued = Convert.ToBoolean(products.Discontinued);

            return model_products;
        }

        //物件 Model 轉 物件 Formmodel
        public ProductsFormModel ModelToFormmodel(Products model_products)
        {
            ProductsFormModel products = new ProductsFormModel();

            products.ProductID = model_products.ProductID.ToString();
            products.ProductName = model_products.ProductName;
            products.SupplierID = model_products.SupplierID.ToString();
            products.CategoryID = model_products.CategoryID.ToString();
            products.QuantityPerUnit = model_products.QuantityPerUnit;
            products.UnitPrice = model_products.UnitPrice;
            products.UnitsInStock = model_products.UnitsInStock;
            products.UnitsOnOrder = model_products.UnitsOnOrder;
            products.ReorderLevel = model_products.ReorderLevel;
            products.Discontinued = model_products.Discontinued.ToString();

            return products;
        }

        #endregion
    }
}
