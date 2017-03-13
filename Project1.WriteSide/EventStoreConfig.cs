using MassTransit;
using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;
using Ninject;

namespace Project1.WriteSide
{
    public static class EventStoreConfig
    {
        public static IStoreEvents Create(IBusControl bus)
        {
            var store = Wireup.Init()
                .LogToOutputWindow()
                .UsingSqlPersistence("LocalDb")
                .WithDialect(new MsSqlDialect())
                .EnlistInAmbientTransaction()
                .InitializeStorageEngine()
                .UsingJsonSerialization()
                .UsingSynchronousDispatchScheduler()
                .DispatchTo(new InternalDispatcher(new EventPublisher(bus)))
                .Build();
            return store;
        }
    }
}