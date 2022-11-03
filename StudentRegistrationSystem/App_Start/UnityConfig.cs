using ClassLibrary2.DataAccessLayer;
using RepositoryLibrary.DataAccessLayer;
using RepositoryLibrary.HelperFunctions;
using ServiceLibrary.Business_Logic;
using ServiceLibrary.BusinessLogic.Validation;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;



namespace StudentRegistrationSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            // container.RegisterType<IStudentBL, StudentBL>();
            container.RegisterType<IDatabaseHelper, DatabaseHelper>();
            container.RegisterType<ISqlDatabaseHelper, SqlDatabaseHelper>();
            container.RegisterType<IDatabaseConnection, DatabaseConnection>();
            container.RegisterType<IStudentDAL, StudentDAL>();
            container.RegisterType<IUserDAL, UserDAL>();
            container.RegisterType<IAddressDAL, AddressDAL>();
            container.RegisterType<IStudentBL, StudentBL>();
            container.RegisterType<IStudentManagement, StudentManagement>();
            container.RegisterType<IUserBL, UserBL>();
            container.RegisterType<IValidation, Validation>();
            container.RegisterType<IUserManagement, UserManagement>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}