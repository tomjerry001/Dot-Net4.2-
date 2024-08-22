using Inventory_Management_System.Model;
using Inventory_Management_System.Repository;
using Inventory_Management_System.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IInventoryService inventoryService = new InventoryServiceImp(new InventoryRepositoryImpl());

            //Menu Driven   
            bool exit = false;
            while (true)
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Inventory");
                Console.WriteLine("2. Update Inventory");
                Console.WriteLine("3. Get Inventory by code");
                Console.WriteLine("4. Get All Inventory");
                Console.WriteLine("5. Delete Inventory");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await AddEmployee(inventoryService);
                        break;
                    case "2":
                        //  await AddEmployee(employeeService);
                        break;
                    case "3":
                        // await AddEmployee(employeeService);
                        break;
                    case "5":
                        //await AddEmployee(employeeService);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice , please Try again");
                        break;
                }

            }
        }

        private static async Task AddEmployee(IInventoryService inventoryService)
        {
            var inventory = new Inventory();

            Console.Write("Enter Product Name: ");
            inventory.ProductName = Console.ReadLine();

            //EmpName
            Console.Write("Enter Category: ");
            inventory.Category = Console.ReadLine();

            //Dept Code
            Console.Write("Enter Quantity: ");
            inventory.Quantity = int.Parse(Console.ReadLine()); 

            //LocCode
            Console.Write("Enter Location Code: ");
            inventory.UnitPrice = int.Parse(Console.ReadLine());    

            //Call Insert from Employee Service
            await inventoryService.AddInventoryAsync(inventory);    
            Console.WriteLine("Inventory Added Sucessfully");
        }
    }
}
    
