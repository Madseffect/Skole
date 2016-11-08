using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace RESTConsumer
{
    class Program
    {
        private static string uri = "http://localhost:9596/CustomerService.svc/customers/";
        private static async Task<IList<Customer>> GetCustomersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri);
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }

        private static async Task<Customer> GetSpecifiedCustomer(int id)
        {
            using (HttpClient client= new HttpClient())
            {
                string content = await client.GetStringAsync(uri+id);
                Customer customer = JsonConvert.DeserializeObject<Customer>(content);
                return customer;

            }
        }

        private static async Task<HttpResponseMessage> DeleteSpecifiedCustomer(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage content = await client.DeleteAsync(uri + id);
                return content;

            }
        }

        private static async Task<HttpResponseMessage> PostCustomer(int id, string firstname, string lastname, int year)
        {
            Customer customer = new Customer(id,firstname,lastname,year);
            string customer1 = JsonConvert.SerializeObject(customer);
            using (HttpClient client= new HttpClient())
            {

                HttpResponseMessage content = await client.PostAsJsonAsync(uri, customer1);
              
                return content;
            }
        }

        
        
  
        static void Main(string[] args)
        {
            ////GET ALL CUSTOMERS
            //IList<Customer> customers = GetCustomersAsync().Result;
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer);
            //}

            //GET SPECIFIED CUSTOMER
            //Console.WriteLine("enter id for customer");
            //Customer customer1 = GetSpecifiedCustomer(int.Parse(Console.ReadLine())).Result;
            //Console.WriteLine(customer1);

            //DELETE SPECIFIED CUSTOMER
            //Console.WriteLine("enter id for customer to delete");
            //var response = DeleteSpecifiedCustomer(int.Parse(Console.ReadLine()));
            //Console.WriteLine(response);

            //Task.Delay(500);
            //IList<Customer> customers = GetCustomersAsync().Result;
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer);
            //}

            //POST SPECIFIED CUSTOMER

            //Console.WriteLine("Create new customer first write id:");
            //int id= Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Firstname:");
            //string fname = Console.ReadLine();

            //Console.WriteLine("Lastname:");
            //string lname = Console.ReadLine();

            //Console.WriteLine("Year");
            //int year = Int32.Parse(Console.ReadLine());

            //var response= PostCustomer(id, fname, lname, year).Result;
            //Console.WriteLine(response);

            //Task.Delay(500);
            //IList<Customer> customers = GetCustomersAsync().Result;
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer);
            //}

            //PUT SPECIFIED CUSTOMER
            IList<Customer> customers = GetCustomersAsync().Result;
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("enter ID for customer to edit: ");
            int tempInt=Int32.Parse(Console.ReadLine());
            Customer tempCustomer = GetSpecifiedCustomer(tempInt).Result;
            var deleteCust = DeleteSpecifiedCustomer(tempInt);
            Console.WriteLine(deleteCust);
            

            Console.WriteLine("Do you wanna change firstname from "+tempCustomer.FirstName + " to another?(y/n)");
            string tempInput = Console.ReadLine();
            switch (tempInput.ToLower())
            {
                case "y":
                    Console.WriteLine("Enter new name:");
                    tempCustomer.FirstName = Console.ReadLine();
                    break;
                case "n":
                    break;
            }
            Console.WriteLine("Do you wanna change lasttname from " + tempCustomer.LastName + " to another?(y/n)");
            tempInput = Console.ReadLine();
            switch (tempInput.ToLower())
            {
                case "y":
                    Console.WriteLine("Enter new name:");
                    tempCustomer.LastName = Console.ReadLine();
                    break;
                case "n":
                    break;
            }

            Console.WriteLine("Do you wanna change year from " + tempCustomer.Year + " to another?(y/n)");
            tempInput = Console.ReadLine();
            switch (tempInput.ToLower())
            {
                case "y":
                    Console.WriteLine("Enter new year:");
                    tempCustomer.Year = Int32.Parse(Console.ReadLine());
                    break;
                case "n":
                    break;
            }

            var updateCust=PostCustomer(tempCustomer.ID, tempCustomer.FirstName, tempCustomer.LastName,
                tempCustomer.Year).Result;
            Console.WriteLine(updateCust);

            Task.Delay(500);

            IList<Customer> customersAgain = GetCustomersAsync().Result;
            foreach (var customer in customersAgain)
            {
                Console.WriteLine(customer);
            }






        }
    }
}

    


