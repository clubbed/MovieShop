using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShop.ViewModels.Admin.Dashboard
{
    public class DashboardIndexViewModel
    {
        public int MovieCount { get; set; }

        public int UserCount { get; set; }

        public int RentCount { get; set; }
    }
}