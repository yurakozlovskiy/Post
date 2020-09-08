using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace Post.Menus
{
    public static class PeopleMenu
    {
        public static void Show(ORM orm)
        {
            bool check = true;

            while (check == true)
            {
                Console.WriteLine("\nWhat operation do you want to do in People?:\n" + "1.Add\n" + "2.Update\n" + "3.Remove\n" + "4.GetAll\n" + "<-Back\n");
                Console.Write(">>");
                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "Add":
                            Add(orm);
                            Console.WriteLine("\nYou add a row successfully!");
                            break;
                        case "Update":
                            Update(orm);
                            Console.WriteLine("\nYou update a row succesfully!");
                            break;
                        case "Remove":
                            Remove(orm);
                            Console.WriteLine("\nYou remove the row successfully!");
                            break;
                        case "GetAll":
                            GetAll(orm);
                            break;
                        case "Back":
                            check = false;
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Add(ORM orm)
        {
            Console.Write("\nFirstName: ");
            string fn = Console.ReadLine();
            Console.Write("LastName: ");
            string ln = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("PhoneNumber: ");
            string pn = Console.ReadLine();
            Console.Write("Email: ");
            string em = Console.ReadLine();

            orm.Add(new People
            {
                FirstName = fn,
                LastName = ln,
                Age = age,
                PhoneNumber = pn,
                Email = em
            });
        }

        public static void Update(ORM orm)
        {
            bool checkUpdate = true;
            while (checkUpdate == true)
            {
                Console.Write("\nEnter the id you want to update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id == 0)
                    checkUpdate = false;
                var people = orm.GetAllPeople().Where(x => x.Id == id).FirstOrDefault();

                Console.WriteLine("\nChoose the column you want to change:\n" + "1.FirstName\n" + "2.LastName\n" + "3.Age\n" + "4.PhoneNumber\n"+"5.Email\n"+"<-Back\n");
                Console.Write(">>");
                string choiceUpdate = Console.ReadLine();
                try
                {
                    switch (choiceUpdate)
                    {
                        case "FirstName":
                            Console.Write("\nUpdate FirstName: ");
                            string fn = Console.ReadLine();

                            orm.Update(new People
                            {
                                Id = people.Id,
                                FirstName = fn,
                                LastName = people.LastName,
                                Age = people.Age,
                                PhoneNumber = people.PhoneNumber,
                                Email = people.Email
  
                            });
                            break;
                        case "LastName":
                            Console.Write("\nUpdate LastName: ");
                            string ln = Console.ReadLine();

                            orm.Update(new People
                            {
                                Id = people.Id,
                                FirstName = people.FirstName,
                                LastName = ln,
                                Age = people.Age,
                                PhoneNumber = people.PhoneNumber,
                                Email = people.Email
                            });
                            break;
                        case "Age":
                            Console.Write("\nUpdate Age: ");
                            int age = Convert.ToInt32(Console.ReadLine());

                            orm.Update(new People
                            {
                                Id = people.Id,
                                FirstName = people.FirstName,
                                LastName = people.LastName,
                                Age = age,
                                PhoneNumber = people.PhoneNumber,
                                Email = people.Email
                            });
                            break;
                        case "PhoneNumber":
                            Console.Write("\nUpdate PhoneNumber: ");
                            string pn = Console.ReadLine();

                            orm.Update(new People
                            {
                                Id = people.Id,
                                FirstName = people.FirstName,
                                LastName = people.LastName,
                                Age = people.Age,
                                PhoneNumber = pn,
                                Email = people.Email
                            });
                            break;
                        case "Email":
                            Console.Write("\nUpdate Email: ");
                            string em = Console.ReadLine();

                            orm.Update(new People
                            {
                                Id = people.Id,
                                FirstName = people.FirstName,
                                LastName = people.LastName,
                                Age = people.Age,
                                PhoneNumber = people.PhoneNumber,
                                Email = em
                            });
                            break;
                        case "Back":
                            checkUpdate = false;
                            break;
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Remove(ORM orm)
        {
            Console.Write("\nEnter the id you want to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());

            orm.Remove(new People
            {
                Id = id
            });
            
        }

        public static void GetAll(ORM ado)
        {
            Console.WriteLine();
            foreach(var p in ado.GetAllPeople())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",p.Id, p.FirstName, p.LastName, p.Age, p.PhoneNumber, p.Email);
            }
        }
    }
}
