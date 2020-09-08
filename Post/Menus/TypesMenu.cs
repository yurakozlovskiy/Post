using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace Post.Menus
{
    public static class TypesMenu
    {
        public static void Show(ORM orm)
        {
            bool check = true;

            while (check == true)
            {
                Console.WriteLine("\nWhat operation do you want to do in Types?:\n" + "1.Add\n" + "2.Update\n" + "3.Remove\n" + "4.GetAll\n" + "<-Back\n");
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
            Console.Write("\nName: ");
            string name = Console.ReadLine();

            orm.Add(new Types
            {
                Name = name
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
                var type = orm.GetAllTypes().Where(x => x.Id == id).FirstOrDefault();

                Console.WriteLine("\nChoose the column you want to change:\n" + "1.Name\n" + "<-Back\n");
                Console.Write(">>");
                string choiceUpdate = Console.ReadLine();
                try
                {
                    switch (choiceUpdate)
                    {
                        case "Name":
                            Console.Write("\nUpdate Name: ");
                            string name = Console.ReadLine();

                            orm.Update(new Types
                            {
                                Id = type.Id,
                                Name = name

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

            orm.Remove(new Types
            {
                Id = id
            });

        }

        public static void GetAll(ORM ado)
        {
            Console.WriteLine();
            foreach (var t in ado.GetAllTypes())
            {
                Console.WriteLine("{0}\t{1}", t.Id, t.Name);
            }
        }
    }
}
