using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.report
{
    class SystemSupportReport : MasterReportServer
    {
        public SystemSupportReport()
        {
            Route = @"C:\Reporte\";
            DbUser = "erpadmin";
            DbPass = "exerpadmin";
            Server = "DESKTOP-0FO6JF8\\SQLEXPRESS";
            Database = "csg";
        }
    }
}
