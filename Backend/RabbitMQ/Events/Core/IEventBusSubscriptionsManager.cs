using RabbitMQ.Abstractions;
using RabbitMQ.CommandBus;
using RabbitMQ.Events.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Events.Core
{
    public interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }

        event EventHandler<string> OnEventRemoved;
        void AddSubscription<T, TH>()
           where T : IntergrationEvent
           where TH : IIntergrationEventHandler<T>;

        void AddSubscription(string eventName, Type typeEvent, Type typeHandler);

        void RemoveSubscription<T, TH>()
            where TH : IIntergrationEventHandler<T>
             where T : IntergrationEvent;

        bool HasSubscriptionsForEvent<T>() where T : IntergrationEvent;

        bool HasSubscriptionsForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        void Clear();

        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntergrationEvent;

        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

        string GetEventKey<T>();
    }
}