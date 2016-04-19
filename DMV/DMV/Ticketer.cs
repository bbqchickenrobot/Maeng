using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMV
{
    // static classes will only have one instantiation per program/process
    public static class Ticketer
    {
        private static uint _count = 0;

        public static uint TicketNumber
        {
            get { return _count; }
            private set { _count = value; }
        }

        static Ticketer() { Console.WriteLine($"New ticketer created"); }

        // syntax shortcut... so I dn't have to write out full method
        public static uint GetCount() => _count;

        public static uint GetNewTicketNumber() => ++_count;

        public static uint AddTicketCount(uint count) => _count += count;

        public static void DecreaseCount(uint count)
        {
            var result = (int)_count - count;
            if (result < 0)
            {
                _count = 0;
                return;
            }

            _count -= count;
        }

        public static Client CreateNewTicket(string name)
        {
            return new Client(name, ++_count);
        }
    }


}
