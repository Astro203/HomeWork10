using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10
{
    struct Message
    {
        public string FirstName { get; set; }

        public string Msg { get; set; }

        public DateTime Time { get; set; }

        public long Id { get; set; }

        public Message(string FirstName, string Msg, DateTime Time, long Id)
        {
            this.FirstName = FirstName;
            this.Msg = Msg;
            this.Time = Time;
            this.Id = Id;
        }
    }
}
