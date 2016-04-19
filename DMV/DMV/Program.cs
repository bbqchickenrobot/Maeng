using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMV
{
    class Program
    {
        static void Main(string[] args)
        {
            // generate some random ticketws.. not assigned to a client/customer
            for (var i = 0; i < 25; i++)
                Console.WriteLine($"Generated ticket #: {Ticketer.GetNewTicketNumber()}");

            // create a new individual customer
            PrintBlankLine();
            var customer = new Client("Kate Beckinsale", Ticketer.GetNewTicketNumber());
            Console.WriteLine($"New customer: {customer.ToString()}");
            PrintBlankLine();

            // this is just a function generated inline - it's not attached to a class, it gets the current ticket count
            Action CountStatus = () =>
            {
                Console.WriteLine($"The current count is {Ticketer.GetCount()}");
                PrintBlankLine();
            };
            CountStatus();

            // generate a new list of clients that walked in... .simuilates a line
            var clients = GenerateClientList(10);

            PrintClientList(clients);

            // reset ticket counter
            CountStatus();
            Ticketer.DecreaseCount(2000);
            CountStatus();

            Console.WriteLine("The count should now be reset to zero.  Ticket numbers should start at 1 again");
            var newClients = GenerateClientList(5);
            PrintClientList(newClients);

            PrintBlankLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static void PrintBlankLine() => Console.WriteLine("");

        static void PrintClientList(List<Client> clients)
        {
            PrintBlankLine();
            Console.WriteLine("Printing client list....");
            Console.WriteLine($"There are {clients.Count} total clients waiting in line.");
            foreach (var client in clients)
                Console.WriteLine(client.ToString());
            if (clients.Count < 1)
                Console.WriteLine("There are no clients... time to take a break!");
            PrintBlankLine();
        }

        static List<Client> GenerateClientList(uint count = 0)
        {
            var clients = new List<Client>();
            for (var i = 0; i < count; i++)
                clients.Add(Ticketer.CreateNewTicket($"Client #{i + 1}"));
            return clients;
        }
    }
}
