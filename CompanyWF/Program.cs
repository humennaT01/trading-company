using CompanyWF.AppSettings;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.Util.Internal;
using System.ComponentModel;
using AutoMapper;
using Unity;
using DALEF.Concrete;
using DAL.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.Concrete;

namespace CompanyWF
{
    static class Program
    {
        public static AppDataManager SettingsManager;
        public static UnityContainer Container;
        public static long Id;
        public static long RoleId;
        public static long PersonId; 

        [STAThread]
        static void Main(string[] args)
        {
            ConfigureUnity();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SettingsManager = new AppDataManager();
            LoginForm lf = Container.Resolve<LoginForm>();
            lf.ShowDialog();
            if (lf.DialogResult == DialogResult.OK)
            {
                Id = lf.GetId();
                RoleId = lf.GetRoleId();
                PersonId = lf.GetPersonId();
                Application.Run(Container.Resolve<MainForm>());
            }
            else
            {
                Application.Exit();
            }
            Application.Exit();
        }

        public static void ConfigureUnity()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(UserDalEf).Assembly);
                });

            Container = new UnityContainer();
            Container.RegisterInstance<IMapper>(config.CreateMapper());
            Container.RegisterType<IPersonDal, PersonDalEf>()
                     .RegisterType<IUserDal, UserDalEf>()
                     .RegisterType<IRoleDal, RoleDalEf>()
                     .RegisterType<IAuthManager, AuthManager>()
                     .RegisterType<IAdminManager, AdminManager>();
            
        }
    }
}



//oLichka23
//olichka1998 - password


// bestMan01
//aaa888ooo - password