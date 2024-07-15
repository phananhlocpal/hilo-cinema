using RabbitMQ.CommandBus;
using RabbitMQ.Events.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.RabbitMq
{
    public interface IEventBus
    {
        void Publish(IntergrationEvent @event);

        void Subscribe<T, TH>()
            where T : IntergrationEvent
            where TH : IIntergrationEventHandler<T>;

        void Unsubscribe<T, TH>()
            where TH : IIntergrationEventHandler<T>
            where T : IntergrationEvent;
    }
}
