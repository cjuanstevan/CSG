﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.persistence
{
    class DAOFactory
    {
        private static readonly IArticleDAO articleDAO = new ArticleDAO();
        private static readonly ICategoryDAO categoryDAO = new CategoryDAO();
        private static readonly IClientDAO clientDAO = new ClientDAO();
        private static readonly ICotization_refactionFKDAO cotization_RefactionFKDAO = new Cotization_refactionFKDAO();
        private static readonly ICotization_serviceFKDAO cotization_ServiceFKDAO = new Cotization_serviceFKDAO();
        private static readonly ICotizationDAO cotizationDAO = new CotizationDAO();
        private static readonly IDashboardDAO dashboardDAO = new DashboardDAO();
        private static readonly IDepartmentDAO departmentDAO = new DepartmentDAO();
        private static readonly IMunicipalityDAO municipalityDAO = new MunicipalityDAO();
        private static readonly IOrder_articleFKDAO order_ArticleFKDAO = new Order_articleFKDAO();
        private static readonly IOrderDAO orderDAO = new OrderDAO();
        private static readonly IRefactionDAO refactionDAO = new RefactionDAO();
        private static readonly IServiceDAO serviceDAO = new ServiceDAO();
        private static readonly ITaxDAO taxDAO = new TaxDAO();
        private static readonly ITechnicianDAO technicianDAO = new TechnicianDAO();
        private static readonly IUserDAO userDAO = new UserDAO();

        public static IArticleDAO GetArticleDAO()
        {
            return articleDAO;
        }
        public static ICategoryDAO GetCategoryDAO()
        {
            return categoryDAO;
        }
        public static IClientDAO GetClientDAO()
        {
            return clientDAO;
        }
        public static ICotization_refactionFKDAO GetCotization_RefactionFKDAO()
        {
            return cotization_RefactionFKDAO;
        }
        public static ICotization_serviceFKDAO GetCotization_ServiceFKDAO()
        {
            return cotization_ServiceFKDAO;
        }
        public static ICotizationDAO GetCotizationDAO()
        {
            return cotizationDAO;
        }
        public static IDashboardDAO GetDashboardDAO()
        {
            return dashboardDAO;
        }
        public static IDepartmentDAO GetDepartmentDAO()
        {
            return departmentDAO;
        }
        public static IMunicipalityDAO GetMunicipalityDAO()
        {
            return municipalityDAO;
        }
        public static IOrder_articleFKDAO GetOrder_ArticleFKDAO()
        {
            return order_ArticleFKDAO;
        }
        public static IOrderDAO GetOrderDAO()
        {
            return orderDAO;
        }
        public static IRefactionDAO GetRefactionDAO()
        {
            return refactionDAO;
        }
        public static IServiceDAO GetServiceDAO()
        {
            return serviceDAO;
        }
        public static ITaxDAO GetTaxDAO()
        {
            return taxDAO;
        }
        public static ITechnicianDAO GetTechnicianDAO()
        {
            return technicianDAO;
        }
        public static IUserDAO GetUserDAO()
        {
            return userDAO;
        }
    }
}
