using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerShopContracts.BuisnessLogicContracts;
using ComputerShopContracts.StorageContracts;
using ComputerShopBuisnessLogic.BuisnessLogic;
using ComputerShopListImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace ComputerShopView.Programs
{
    public static class Program
    {
        
            private static IUnityContainer container = null;
            public static IUnityContainer Container { get { if (container == null) { container = BuildUnityContainer(); } return container; } }
            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(Container.Resolve<FormGlav>());
            }

            private static IUnityContainer BuildUnityContainer()
            {
                var currentContainer = new UnityContainer();
                currentContainer.RegisterType<IComplectStorage,
                ComplectStorage>(new HierarchicalLifetimeManager());
                currentContainer.RegisterType<IZakupkaStorage, ZakupkaStorage>(new
                HierarchicalLifetimeManager());
                currentContainer.RegisterType<ISborkaStorage, SborkaStorage>(new
                HierarchicalLifetimeManager());
                currentContainer.RegisterType<IComplectLogic, ComplectLogic>(new
                HierarchicalLifetimeManager());
                currentContainer.RegisterType<IZakupkaLogic, ZakupkaLogic>(new
                HierarchicalLifetimeManager());
                currentContainer.RegisterType<ISborkaLogic, SborkaLogic>(new
                HierarchicalLifetimeManager());
                return currentContainer;
            }

    }
}

