using AutoMapper;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DALEF.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace CompanyWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        public static UnityContainer Container;
        public static long Id;
        public static long RoleId;
        public static long PersonId;

        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            base.OnStartup(e);
            RegisterUnity();
            RegisterAutoMapper();

            LoginWindow lw = Container.Resolve<LoginWindow>();
            lw.ShowDialog();
            if (lw.DialogResult == true)
            {
                MainWindow ml = Container.Resolve<MainWindow>();
                Current.MainWindow = ml;
                ml.ShowDialog();
            }
            else
            {
                Current.Shutdown();
            }

        }

        private void RegisterAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
               cfg =>
               {
                   cfg.AddMaps(typeof(UserDalEf).Assembly);
               });
            Container.RegisterInstance(config.CreateMapper());
        }
        private static void RegisterUnity()
        {
            Container = new UnityContainer();
            Container.RegisterType<IPersonDal, PersonDalEf>()
                     .RegisterType<IUserDal, UserDalEf>()
                     .RegisterType<IRoleDal, RoleDalEf>()
                     .RegisterType<IAuthManager, AuthManager>()
                     .RegisterType<IAdminManager, AdminManager>();
        }

    }
}
