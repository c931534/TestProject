using HFTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFTestProject.Repository
{
    public class SuppliersRepo
    {
        NorthwindEntities dc = new NorthwindEntities();

        public IEnumerable<Suppliers> SelectAll()
        {
            return dc.Suppliers;
        }

        public IDictionary<string, string> AutoSupplierID(string supplierid)
        {
            return dc.Suppliers.Where(
                c => c.SupplierID.ToString().Contains(supplierid)).
                ToDictionary(c => c.SupplierID.ToString(), c => c.CompanyName);
        }
    }
}