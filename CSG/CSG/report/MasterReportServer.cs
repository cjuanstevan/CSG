using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.report
{
    public abstract class MasterReportServer
    {
        protected string Route { get; set; }
        protected string DbUser { get; set; }
        protected string DbPass { get; set; }
        protected string Server { get; set; }
        protected string Database { get; set; }


        public ReportDocument GetReportOrderCreate(string number)
        {
            ReportDocument report = new ReportDocument();
            try
            {
                report.Load(Route + "REPORTE_ORDEN_SERVICIO.rpt");
                report.SetDatabaseLogon(DbUser, DbPass, Server, Database);
                report.SetParameterValue("@ORDEN", number);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return report;
        }
    }
}
