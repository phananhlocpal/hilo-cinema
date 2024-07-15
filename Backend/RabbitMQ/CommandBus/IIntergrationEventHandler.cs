using RabbitMQ.Events.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.CommandBus
{
    public interface IIntergrationEventHandler<in T> where T : IntergrationEvent
    {
        Task Handle(T @event);
    }

    public interface IIntergrationEventHandler
    {

    }
}
