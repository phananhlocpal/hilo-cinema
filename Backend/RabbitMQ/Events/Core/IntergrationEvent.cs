using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Events.Core
{
    public class IntergrationEvent
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime DateCreated { get; private set; } = DateTime.Now;
    }
}
