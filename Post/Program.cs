using System;
using DB;
using System.Configuration;
using System.Data.SqlClient;
using Repositories.ConcreteFactories;
using Post.Menus;



namespace Post
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ORM entity = new ORM(new EntityFactory());

            ORM ado = new ORM(new AdoFactory());

            

            bool check = true;



            //Console.WriteLine("Instruction: The first word letter should be big!\n\n");
            while (check == true)
            {

                Console.WriteLine("What orm do you want to use?:\n" + "1.Ado\n" + "2.Entity\n" + "--Exit\n");
                Console.Write(">>");
                string choice = Console.ReadLine();
                try
                {
                    if (choice == "Ado")
                        Menu(ado);
                    if (choice == "Entity")
                        Menu(entity);
                    if (choice == "Exit")
                        check = false;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



            }

        }

        public static void Menu(ORM orm)
        {
            bool check = true;
           
            while(check == true)
            {
                Console.WriteLine("Choose the table: \n"+ "1.Addresses\n"+ "2.Cars\n" + "3.DeliveryStatus\n"+"4.People\n"+ "5.Types\n"+ "<- Back\n");
                Console.Write(">>");
                string choice = Console.ReadLine();
                try
                {
                    switch(choice)
                    {
                        case "Addresses":
                            AddressesMenu.Show(orm);
                            break;
                        case "Cars":
                            CarsMenu.Show(orm);
                            break;
                        case "DeliveryStatus":
                            StatusMenu.Show(orm);
                            break;
                        case "People":
                            PeopleMenu.Show(orm);
                            break;
                        case "Types":
                            TypesMenu.Show(orm);
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


      


    }
}
