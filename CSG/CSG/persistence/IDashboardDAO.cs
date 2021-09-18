using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.persistence
{
    interface IDashboardDAO
    {
        string[] DashboardData();
        string[] Dashboard_Order();

        string[,] Dashboard_OrderArticleTop3();
        string[,] Dashboard_CategoryXarticle();
    }
}
