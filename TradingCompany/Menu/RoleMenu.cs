using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompany.Menu
{
    public class RoleMenu
    {
        private IRoleDal dal;
        
        public RoleMenu(IRoleDal dal) {
            this.dal = dal;
        }

        public void menu()
        {
            int step;
            bool flag = true;
            while (flag)
            {
                listOfFunction();
                try
                {
                    step = Convert.ToInt32(Console.ReadLine());
                    switch (step)
                    {
                        case 1:
                            creating();
                            break;
                        case 2:
                            deleting();
                            break;
                        case 3:
                            updating();
                            break;
                        case 4:
                            showAll();
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

        private void creating()
        {
            Console.WriteLine("Input RoleName: ");
            string roleName = Console.ReadLine();

            RoleDTO r = new RoleDTO
            {
                RoleName = roleName,
                RowInsertTime = DateTime.UtcNow,
            };
            r = dal.CreateRole(r);
            Console.WriteLine($"New user ID: {r.RoleID}");
            showAll();
        }

        private void deleting()
        {
            Console.WriteLine("Input RoleID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting role ID: {id}");
            dal.DeleteRole(id);
            showAll();
        }

        private void updating()
        {
            Console.WriteLine("Input RoleID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("You can change only roleName!\nInput new RoleName:");
            string roleName = Console.ReadLine();

            RoleDTO r = dal.GetRoleById(id);

            r.RoleName = roleName;
            r = dal.UpdateRole(r);
            Console.WriteLine($"Role ID: {r.RoleID}");
            showAll();
        }

        private void showAll()
        {
            Console.WriteLine("\n\tTable -> Role");
            Console.WriteLine($"{"-RoleID-"}\t{"-RoleName-"}\t{"-RowInsertTime-"}");
            foreach (var role in dal.GetAllRole())
            {
                Console.WriteLine("     {0}     \t{1}\t\t{2}",
                        role.RoleID, role.RoleName, role.RowInsertTime);
            }
            Console.WriteLine("\n");
        }

        private void listOfFunction()
        {
            Console.WriteLine("\t\t\t<RoleMenu>");
            Console.WriteLine("\t1. To CREATE a new role");
            Console.WriteLine("\t2. To DELETE role.");
            Console.WriteLine("\t3. To UPDATE role.");
            Console.WriteLine("\t4. To get all roles.");
            Console.WriteLine("\t0. Exit.");
        }

    }
}
