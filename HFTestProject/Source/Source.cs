using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFTestProject.Source
{
    public class Source
    {
        public static SelectList DiscontinuedList()
        {
            List<SelectListItem> Discontinued_list = new List<SelectListItem>();

            Discontinued_list.AddRange(new[]{
                new SelectListItem() { Text = "Y  停產", Value = "True", Selected = false },
                new SelectListItem() { Text = "N  正常", Value = "False", Selected = false }
            });

            return new SelectList(Discontinued_list);
        }
    }
}