using AutoMapper;
using DALEF.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.Menu;

namespace TradingCompany
{
    public class MainMenu
    {
        public MainMenu() { }

        public void startWork()
        {
            Console.WriteLine("\t\t\t~START~");
            menuForTables();
            int step; 
            bool flag = true;
            IMapper mapper = SetupMapper();
            while (flag)
            {
                try
                {
                    step = Convert.ToInt32(Console.ReadLine());
                    switch (step)
                    {
                        case 1:
                            UserMenu u = new UserMenu(new UserDalEf(mapper));
                            u.menu();
                            menuForTables();
                            break;
                        case 2:
                            PersonMenu p = new PersonMenu(new PersonDalEf(mapper));
                            p.menu();
                            menuForTables();
                            break;
                        case 3:
                            RoleMenu r = new RoleMenu(new RoleDalEf(mapper));
                            r.menu();
                            menuForTables();
                            break;
                        case 0:
                            flag = false;
                            break;
                        default:
                            throw new Exception("You've inputed wrong data.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("Try again, or input 0 to exit.");
                }
            }
        }

        private void menuForTables()
        {
            Console.WriteLine("\t\t\t<MainMenu>");
            Console.WriteLine("\t1. To work with table User.");
            Console.WriteLine("\t2. To work with table Person.");
            Console.WriteLine("\t3. To work with table Role.");
            Console.WriteLine("\t0. Exit.");
        }


        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(RoleDalEf).Assembly)
                );
            return conf.CreateMapper();
        }
    }
}
