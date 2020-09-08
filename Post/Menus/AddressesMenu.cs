using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace Post.Menus
{
    public static class AddressesMenu
    {
        public static void Show(ORM orm)
        {
            bool check = true;

            while (check == true)
            {
                Console.WriteLine("\nWhat operation do you want to do in Addresses?:\n" + "1.Add\n" + "2.Update\n" + "3.Remove\n" + "4.GetAll\n" + "<-Back\n");
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
            Console.Write("\nCountry: ");
            string country = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("Oblast: ");
            string oblast = Console.ReadLine();
            Console.Write("Region: ");
            string region = Console.ReadLine();
            Console.Write("Street: ");
            string street = Console.ReadLine();
            Console.WriteLine("House: ");
            int house = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Flat: ");
            int flat = Convert.ToInt32(Console.ReadLine());

            orm.Add(new Addresses
            {
                Country = country,
                City = city,
                Oblast = oblast,
                Region = region,
                Street = street,
                House = house,
                Flat = flat
      
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
                var address = orm.GetAllAddresses().Where(x => x.Id == id).FirstOrDefault();

                Console.WriteLine("\nChoose the column you want to change:\n" + "1.Country\n" + "2.City\n" + "3.Oblast\n" + "4.Region\n" + "5.Street\n" + "6.House\n"+"7.Flat"+"<-Back\n");
                Console.Write(">>");
                string choiceUpdate = Console.ReadLine();
                try
                {
                    switch (choiceUpdate)
                    {
                        case "Country":
                            Console.Write("\nUpdate Country: ");
                            string country = Console.ReadLine();

                            orm.Update(new Addresses
                            {
                                Id = address.Id,
                                Country = country,
                                City = address.City,
                                Oblast = address.Oblast,
                                Region = address.Region,
                                Street = address.Street,
                                House = address.House,
                                Flat = address.Flat
                            });
                            break;
                        case "City":
                            Console.Write("\nUpdate City: ");
                            string city = Console.ReadLine();

                            orm.Update(new Addresses
                            {
                                Id = address.Id,
                                Country = address.Country,
                                City = city,
                                Oblast = address.Oblast,
                                Region = address.Region,
                                Street = address.Street,
                                House = address.House,
                                Flat = address.Flat
                            });
                            break;
                        case "Oblast":
                            Console.Write("\nUpdate Oblast: ");
                            string oblast = Console.ReadLine();

                            orm.Update(new Addresses
                            {
                                Id = address.Id,
                                Country = address.Country,
                                City = address.City,
                                Oblast = oblast,
                                Region = address.Region,
                                Street = address.Street,
                                House = address.House,
                                Flat = address.Flat
                            });
                            break;
                        case "Region":
                            Console.Write("\nUpdate Region: ");
                            string region = Console.ReadLine();

                            orm.Update(new Addresses
                            {
                                Id = address.Id,
                                Country = address.Country,
                                City = address.City,
                                Oblast = address.Oblast,
                                Region = region,
                                Street = address.Street,
                                House = address.House,
                                Flat = address.Flat
                            });
                            break;
                        case "Street":
                            Console.Write("\nUpdate Street: ");
                            string street = Console.ReadLine();

                            orm.Update(new Addresses
                            {
                                Id = address.Id,
                                Country = address.Country,
                                City = address.City,
                                Oblast = address.Oblast,
                                Region = address.Region,
                                Street = street,
                                House = address.House,
                                Flat = address.Flat
                            });
                            break;
                        case "House":
                            Console.Write("\nUpdate House: ");
                            int house = Convert.ToInt32(Console.ReadLine());

                            orm.Update(new Addresses
                            {
                                Id = address.Id,
                                Country = address.Country,
                                City = address.City,
                                Oblast = address.Oblast,
                                Region = address.Region,
                                Street = address.Street,
                                House = house,
                                Flat = address.Flat
                            });
                            break;
                        case "Flat":
                            Console.Write("\nUpdate Flat: ");
                            int flat = Convert.ToInt32(Console.ReadLine());

                            orm.Update(new Addresses
                            {
                                Id = address.Id,
                                Country = address.Country,
                                City = address.City,
                                Oblast = address.Oblast,
                                Region = address.Region,
                                Street = address.Street,
                                House = address.House,
                                Flat = flat
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

            orm.Remove(new Addresses
            {
                Id = id
            });

        }

        public static void GetAll(ORM orm)
        {
            Console.WriteLine();
            foreach (var a in orm.GetAllAddresses())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", a.Id, a.Country, a.City, a.Oblast, a.Region, a.Street, a.House, a.Flat );
            }
        }
    }
}
