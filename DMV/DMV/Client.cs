using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMV
{
    public class Client
    {
        public string Name { get; protected set; }
        public uint TicketNumber { get; protected set; }

        // constructtor with a default parameter for ticketNo parameter equal to 0
        public Client(string name = "", uint ticketNo = 0)
        {
            this.Name = name;
            this.TicketNumber = ticketNo;
            Console.WriteLine($"New Client Created | {ToString()}");
        }

        public void GetTicket() => TicketNumber = Ticketer.GetNewTicketNumber();

        public override string ToString() => $"Client Info -> Name: {Name} | Ticket #: {TicketNumber}";
    }
}
