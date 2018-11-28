using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Gadi.Business;
using Gadi.Business.Interfaces;
using Gadi.Data;
using Gadi.Data.Interfaces;
using Gadi.Data.Models;
using Gadi.Data.Services;
using Configuration.Interface;
using Configuration.Core;
using Gadi.Business.Services;
using Microsoft.AspNet.Identity;
using Gadi.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Gadi.Controllers;

namespace Gadi.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            container.AddNewExtension<Interception>();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here     
            container.RegisterType<HttpContextBase>(new PerRequestLifetimeManager(), new InjectionFactory(_ => new HttpContextWrapper(HttpContext.Current)));
            container.RegisterType<HttpRequestBase>(new PerRequestLifetimeManager(), new InjectionFactory(_ => new HttpRequestWrapper(HttpContext.Current.Request)));

            // Register everything in these namespaces based on convention:
            var conventionBasedMappings = new[]
            {
                "Gadi.Data.Services",
                "Gadi.Data.Interfaces",
                "Gadi.Business.Services",
                "Gadi.Business.Interfaces"
            };

            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(tt => conventionBasedMappings.Any(n => n == tt.Namespace)),
                WithMappings.FromMatchingInterface,
                WithName.Default
            );

            container.RegisterType<IDatabaseFactory<GadiDatabase>, GadiDatabaseFactory>(
                new InjectionConstructor(
                    new InjectionParameter<string>(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString())
                 ));

            container.RegisterType<DbContext, GadiDatabase>();
            //container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ICacheProvider, MemoryCacheProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<IGenericDataService<DbContext>, EntityFrameworkGenericDataService>();
            container.RegisterType<IConfigurationManager, ConfigurationManagerAdapter>();


            container.RegisterInstance(MappingsConfig.Initialize(), new ContainerControlledLifetimeManager());
            ////  container.RegisterInstance(LoggingConfig.Initialize(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(), ConfigurationManager.AppSettings["serilog:write-to:MSSqlServer.tableName"]), new ContainerControlledLifetimeManager());
            //container.RegisterType<DbContext, GadiDatabase>();
            //container.RegisterType<IGenericDataService<DbContext>, EntityFrameworkGenericDataService>();
            //container.RegisterType<ICacheProvider, MemoryCacheProvider>();
            //container.RegisterType<IConfigurationManager, ConfigurationManagerAdapter>();
            //container.RegisterType<IAuthorizationService, DefaultAuthorizationService>();
            //container.RegisterType<IAuthorizationPolicyProvider, DefaultAuthorizationPolicyProvider>();
            // container.RegisterType<IClientsAccessService, ClientsAccessService>();
            // API Clients
            container.RegisterType<IDocumentsBusinessService, DocumentBusinessService>();
            container.RegisterType<IPdfService, PdfService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRazorService, RazorService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITemplateBusinessService, TemplateBusinessService>(new ContainerControlledLifetimeManager());
            //container.RegisterType<ITemplateServiceRestClient, TemplateServiceRestClient>(
            //    new InjectionConstructor(
            //        new InjectionParameter<ICacheProvider>(container.Resolve<ICacheProvider>()),
            //        new InjectionParameter<Uri>(new Uri(ConfigurationManager.AppSettings["TemplateRESTApiAddress"])),
            //        new InjectionParameter<string>(ConfigurationManager.AppSettings["TemplateRESTUsername"]),
            //        new InjectionParameter<string>(ConfigurationManager.AppSettings["TemplateRESTPassword"])
            //    ));



            //container.RegisterType<Business.EmailServiceReference.IEmailService, Business.EmailServiceReference.EmailServiceClient>(
            //    new InjectionConstructor(
            //        new InjectionParameter<string>("BasicHttpBinding_IEmailService")
            //    ));

            //container.RegisterType<IEmailService, EmailBusinessService>();

            //Currently distance calculation will be base on Minimum distance
            //container.RegisterType<IGoogleDistanceMatrixApiBusinessService, GoogleDistanceMatrixApiBusinessService>(
            //    new InjectionConstructor(
            //        new InjectionParameter<IRestHttpClient>(new RestHttpClient(new HttpClient
            //        {
            //            BaseAddress = new Uri(ConfigurationManager.AppSettings["GoogleApiDistanceMatrixBaseUrl"]),
            //            Timeout = new TimeSpan(0, 1, 0),
            //            DefaultRequestHeaders = { Accept = { MediaTypeWithQualityHeaderValue.Parse("application/json") } }

            //        })),
            //        new InjectionParameter<IGoogleDistanceMatrixConfiguration>(new GoogleDistanceMatrixConfiguration
            //        {
            //            ApiKey = ConfigurationManager.AppSettings["GoogleApiDistanceMatrixKey"],
            //            BaseUrl = ConfigurationManager.AppSettings["GoogleApiDistanceMatrixBaseUrl"],
            //            DistanceSelector = doubles => doubles.Min() * 0.000621371192237, //Conversion to miles
            //            Mode = "driving",
            //            Units = "metric"

            //        })
            //        )
            //    );

            // Register everything in these namespaces based on convention:




            container.RegisterType<ICurrentUserResolver, OwinUserResolver>();

            // SignalR Hubs
            //container.RegisterType<ISummaryHub, SummaryHub>(new ContainerControlledLifetimeManager());

            // MediatR    
            //container.AddMediator(new List<Assembly> { typeof(MappingsConfig).Assembly, typeof(Business.App_Start.MappingsConfig).Assembly });

            // 3rd Party 
            //container.RegisterType<ICsvFactory, CsvFactory>(new ContainerControlledLifetimeManager());
        }
    }
}
