using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompany.Menu
{
    public class PersonMenu
    {
        private IPersonDal dal;

        public PersonMenu(IPersonDal dal) {
            this.dal = dal;
        }

        public void menu()
        {
            listOfFunction();
            int step;
            bool flag = true;
            while (flag)
            {
                try
                {
                    step = Convert.ToInt32(Console.ReadLine());
                    switch (step)
                    {
                        case 1:
                            creating();
                            listOfFunction();
                            break;
                        case 2:
                            deleting();
                            listOfFunction();
                            break;
                        case 3:
                            updating();
                            listOfFunction();
                            break;
                        case 4:
                       
                            showAll();
                            listOfFunction();
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
            Console.WriteLine("Input FirstName: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Input LastName: ");
            string lName = Console.ReadLine();
            Console.WriteLine("Input Gender(Man->1, Woman->0): ");
            bool gender = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Input Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Input Phone(10 digits): ");
            string phone = Console.ReadLine();
            Console.WriteLine("Input BankCard(16 digits): ");
            string str = Console.ReadLine();
            byte[] card = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                card[i] = Convert.ToByte(str[i]);
            }

            PersonDTO p = new PersonDTO
            {
                FirstName = fName,
                LastName = lName,
                Gender = gender,
                Address = address,
                Phone = phone,
                BankCard = card,
                RowInsertTime = DateTime.UtcNow,
                RowUpdateTime = DateTime.UtcNow
            };
            p = dal.CreatePerson(p);
            Console.WriteLine($"New person ID: {p.PersonID}");
            showAll();
        }

        private void deleting()
        {
            Console.WriteLine("Input PersonID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting person ID: {id}");
            dal.DeletePerson(id);
            showAll();
        }

        private void updating()
        {
            Console.WriteLine("Input PersonID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            PersonDTO p = dal.GetPersonById(id);

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nPress number:\n\t1. to change FirstName;" +
                    "\n\t2. to change LasttName;\n\t3. to change Gender;\n\t4. to change Addres;" +
                    "\n\t5. to change Phone;\n\t6. to change BankCard;\n\t0.Exit\n");
                try
                {
                    int step = Convert.ToInt32(Console.ReadLine());
                    if (step == 0) flag = false;
                    switch (step)
                    {
                        case 1:
                            Console.WriteLine("Input new FirstName: ");
                            string fName = Console.ReadLine();
                            p.FirstName = fName;
                            break;
                        case 2:
                            Console.WriteLine("Input new LastName: ");
                            string lName = Console.ReadLine();
                            p.LastName = lName;
                            break;
                        case 3:
                            Console.WriteLine("Input new Gender(Man->1, Woman->0): ");
                            bool gender = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                            p.Gender = gender;
                            break;
                        case 4:
                            Console.WriteLine("Input new Address: ");
                            string address = Console.ReadLine();
                            p.Address = address;
                            break;
                        case 5:
                            Console.WriteLine("Input new Phone: ");
                            string phone = Console.ReadLine();
                            p.Phone = phone;
                            break;
                        case 6:
                            Console.WriteLine("Input new BankCard(16 digits): ");
                            string str = Console.ReadLine();
                            byte[] card = new byte[str.Length];
                            for (int i = 0; i < str.Length; i++)
                            {
                                card[i] = Convert.ToByte(str[i]);
                            }
                            p.BankCard = card;
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

            p.RowUpdateTime = DateTime.UtcNow;
            
            p = dal.UpdatePerson(p);
            Console.WriteLine($"Person ID: {p.PersonID}");
            showAll();
        }

        private void showAll()
        {
            Console.WriteLine("\n\tTable -> Person");
            Console.WriteLine($"{"ID"}\t{"FullName"}\t{"Gender"}" +
                $"\t{"Adress"}\t\t\t{"Phone"}\t\t{"BankCard"}\t{"RowInsertTime"}\t\t{"RowUpdateTime"}");
            foreach (var p in dal.GetAllPersons())
            {
                Console.WriteLine("{0}\t{1} {2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}",
                                         p.PersonID, p.FirstName, p.LastName, p.Gender, p.Address,
                                         p.Phone, converte(p.BankCard), p.RowInsertTime, p.RowUpdateTime);
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
            Console.WriteLine("\t\t\t<PersonMenu>");
            Console.WriteLine("\t1. To CREATE a new person");
            Console.WriteLine("\t2. To DELETE person.");
            Console.WriteLine("\t3. To UPDATE person.");
            Console.WriteLine("\t4. To get all people.");
            Console.WriteLine("\t0. Exit.");
        }

    }
}
