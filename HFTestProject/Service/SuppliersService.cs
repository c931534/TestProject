using HFTestProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFTestProject.Service
{
    public class SuppliersService
    {
        private SuppliersRepo suppliersRepo = new SuppliersRepo();

        public IDictionary<string, string> AutoSupplierID(string supplierid)
        {
            return suppliersRepo.AutoSupplierID(supplierid);
        }
    }
}