using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace Post.Menus
{
    public static class CarsMenu
    {
        public static void Show(ORM orm)
        {
            bool check = true;

            while (check == true)
            {
                Console.WriteLine("\nWhat operation do you want to do in Cars?:\n" + "1.Add\n" + "2.Update\n" + "3.Remove\n" + "4.GetAll\n" + "<-Back\n");
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
            Console.Write("\nBrand: ");
            string br = Console.ReadLine();
            Console.Write("Number: ");
            string n = Console.ReadLine();
            Console.Write("Year: ");
            DateTime year = Convert.ToDateTime(Console.ReadLine());


            orm.Add(new Cars
            {
               Brand = br,
               Number = n,
               Year = year
            });
        }

        public static void Update(ORM orm)
        {
            bool checkUpdate = true;
            while(checkUpdate == true)
            {
                Console.Write("\nEnter the id you want to update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id == 0)
                    checkUpdate = false;
                var car = orm.GetAllCars().Where(x => x.Id == id).FirstOrDefault();

                Console.WriteLine("\nChoose the column you want to change:\n" + "1.Brand\n" + "2.Number\n" + "3.Year\n" + "<-Back\n");
                Console.Write(">>");
                string choiceUpdate = Console.ReadLine();
                try
                {
                    switch (choiceUpdate)
                    {
                        case "Brand":
                            Console.Write("\nUpdate Brand: ");
                            string br = Console.ReadLine();

                            orm.Update(new Cars
                            {
                                Id = car.Id,
                                Brand = br,
                                Number = car.Number,
                                Year = car.Year
                            });
                            break;
                        case "Number":
                            Console.Write("\nUpdate Number: ");
                            string n = Console.ReadLine();

                            orm.Update(new Cars
                            {
                                Id = car.Id,
                                Brand = car.Brand,
                                Number = n,
                                Year = car.Year
                            });
                            break;
                        case "Year":
                            Console.Write("\nUpdate Year: ");
                            var year = Convert.ToDateTime(Console.ReadLine());

                            orm.Update(new Cars
                            {
                                Id = car.Id,
                                Brand = car.Brand,
                                Number = car.Number,
                                Year = year
                            });
                            break;
                        case "Back":
                            checkUpdate = false;
                            break;
                    }


                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Remove(ORM orm)
        {
            Console.Write("\nEnter the id you want to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());

            orm.Remove(new Cars 
            {
                Id = id
            });

        }

        public static void GetAll(ORM orm)
        {
            Console.WriteLine();
            foreach(var car in orm.GetAllCars())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}",car.Id, car.Brand, car.Number, car.Year);
            }
        }

        
    }
}
