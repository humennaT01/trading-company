using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompany.Menu
{
    public class UserMenu
    {
        private IUserDal dal;

        public UserMenu(IUserDal dal) {
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
            Console.WriteLine("Input Login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Input Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Input Password: ");
            string str = Console.ReadLine();
            byte[] password = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                password[i] = Convert.ToByte(str[i]);
            }
            Console.WriteLine("Input Status(Active -> 0, Blocked -> 1): ");
            bool status = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Input PersonID: ");
            int personId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input RoleID: ");
            int roleId = Convert.ToInt32(Console.ReadLine());

            UserDTO u = new UserDTO
            {
                Login = login,
                Email = email,
                Password = password,
                Status = status,
                PersonID = personId,
                RoleID = roleId,
                RowInsertTime = DateTime.UtcNow,
                RowUpdateTime = DateTime.UtcNow
            };
            u = dal.CreateUser(u);
            Console.WriteLine($"New user ID: {u.RoleID}");
            showAll();
        }

        private void deleting()
        {
            Console.WriteLine("Input UserID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting user ID: {id}");
            dal.DeleteUser(id);
            showAll();
        }

        private void updating()
        {
            Console.WriteLine("Input UserID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            UserDTO u = dal.GetUserById(id);

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nPress number:\n\t1. to change Login;" +
                    "\n\t2. to change Email;\n\t3. to change Password;\n\t4. to change Status;" +
                    "\n\t5. to change PersonID;\n\t6. to change RoleID;\n\t0.Exit\n");
                try
                {
                    int step = Convert.ToInt32(Console.ReadLine());
                    if (step == 0) flag = false;
                    switch (step)
                    {
                        case 1:
                            Console.WriteLine("Input new Login: ");
                            string login = Console.ReadLine();
                            u.Login = login;
                            break;
                        case 2:
                            Console.WriteLine("Input new Email: ");
                            string email = Console.ReadLine();
                            u.Email = email;
                            break;
                        case 3:
                            Console.WriteLine("Input new Password: ");
                            string str = Console.ReadLine();
                            byte[] password = new byte[str.Length];
                            for (int i = 0; i < str.Length; i++)
                            {
                                password[i] = Convert.ToByte(str[i]);
                            }
                            u.Password = password;
                            break;
                        case 4:
                            Console.WriteLine("Input new Status(Active -> 0, Blocked -> 1): ");
                            bool status = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                            u.Status = status;
                            break;
                        case 5:
                            Console.WriteLine("Input new PersonID: ");
                            int personId = Convert.ToInt32(Console.ReadLine());
                            u.PersonID = personId;
                            break;
                        case 6:
                            Console.WriteLine("Input new RoleID: ");
                            int roleId = Convert.ToInt32(Console.ReadLine());
                            u.RoleID = roleId;
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

            u.RowUpdateTime = DateTime.UtcNow;

            u = dal.UpdateUser(u);
            Console.WriteLine($"User ID: {u.UserID}");
            showAll();
        }

        private void showAll()
        {
            Console.WriteLine("\n\tTable -> User");
            Console.WriteLine($"{"ID"}\t{"Login"}\t{"Email"}\t\t\t\t{"Password"}\t{"Status"}" +
                $"\t{"PersonId"}\t{"RoleId"}\t{"RowInsertTime"}\t{"RowUpdateTime"}");
            foreach (var u in dal.GetAllUser())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}",
                        u.UserID, u.Login, u.Email, converte(u.Password), u.Status, u.PersonID,
                        u.RoleID, u.RowInsertTime, u.RowUpdateTime);
            }
            Console.WriteLine("\n");
        }

        private String converte(byte[] data)
        {
            string str = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != 0)
                {
                    str += Convert.ToString(Convert.ToChar(data[i]));
                }
            }
            return str;
        }

        private void listOfFunction()
        {
            Console.WriteLine("\t\t\t<UserMenu>");
            Console.WriteLine("\t1. To CREATE a new user");
            Console.WriteLine("\t2. To DELETE user.");
            Console.WriteLine("\t3. To UPDATE user.");
            Console.WriteLine("\t4. To get all users.");
            Console.WriteLine("\t0. Exit.");
        }

    }
}
