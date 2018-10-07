using HFTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFTestProject.Repository
{
    public class CategoriesRepo
    {
        NorthwindEntities dc = new NorthwindEntities();

        public IEnumerable<Categories> SelectAll()
        {
            return dc.Categories;
        }
    }
}