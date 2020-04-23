using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.persistence;
using CSG.model;

namespace CSG.logic
{
    class BulkLoadLog
    {
        public string BulkLoadArticle(List<Article> articles)
        {
           return DAOFactory.GetArticleDAO().BulkLoad(articles);
        }
        public string BulkLoadClient(List<Client> clients)
        {
            return DAOFactory.GetClientDAO().BulkLoad(clients);
        }

        public string BulkLoadRefaction(List<Refaction> refactions)
        {
            return DAOFactory.GetRefactionDAO().BulkLoad(refactions);
        }

        public string BulkLoadService(List<Service> services)
        {
            return DAOFactory.GetServiceDAO().BulkLoad(services);
        }

        public string BulkLoadTechnician(List<Technician> technicians)
        {
            return DAOFactory.GetTechnicianDAO().BulkLoad(technicians);
        }
    }
}
