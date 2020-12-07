using AutoMapper;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DALEF.Interfaces;
using DALEF.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace WebApplication.App_Start
{
    public class UnityConfig
    {
        public static void RegisterUnity()
        {
            var container = new UnityContainer();
            MapperConfiguration config = new MapperConfiguration(
                   cfg =>
                   {
                       cfg.AddMaps(typeof(UserDalEf).Assembly);
                   });
            container.RegisterInstance<IMapper>(config.CreateMapper());

            container.RegisterType<IPersonDal, PersonDalEf>()
                         .RegisterType<IUserDal, UserDalEf>()
                         .RegisterType<IRoleDal, RoleDalEf>()
                         .RegisterType<IAuthManager, AuthManager>()
                         .RegisterType<IAdminManager, AdminManager>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}