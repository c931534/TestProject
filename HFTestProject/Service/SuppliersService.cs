using HFTestProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFTestProject.Service
{
    public class SuppliersService
    {
        private SuppliersRepo suppliersRepo = new SuppliersRepo();

        public SelectList SuppliersList()
        {
            var query = suppliersRepo.SelectAll();

            List<SelectListItem> Suppliers_list = new List<SelectListItem>();

            foreach (var Suppliers in query)
            {
                Suppliers_list.Add(new SelectListItem()
                {
                    Text = Suppliers.SupplierID + " " + Suppliers.CompanyName,
                    Value = Suppliers.SupplierID.ToString(),
                    Selected = false
                });
            }

            return new SelectList(Suppliers_list);

        }

        public IDictionary<string, string> AutoSupplierID(string supplierid)
        {
            return suppliersRepo.AutoSupplierID(supplierid);
        }
    }
}