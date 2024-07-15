using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.RabbitMq
{
    public interface IRabbitMqPersitentConnection
    {
        bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}
