using HFTestProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFTestProject.Service
{
    public class CategoriesService
    {
        private CategoriesRepo categoriesRepo = new CategoriesRepo();

        public SelectList CategoriesList()
        {
            var query = categoriesRepo.SelectAll();

            List<SelectListItem> Categories_list = new List<SelectListItem>();

            foreach (var Categories in query)
            {
                Categories_list.Add(new SelectListItem()
                {
                    Text = Categories.CategoryID + " " + Categories.CategoryName,
                    Value = Categories.CategoryID.ToString(),
                    Selected = false
                });
            }

            return new SelectList(Categories_list);

        }
    }
}