using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;

namespace Project1.Test
{
    internal static class StoreConnections
    {
        internal static IStoreEvents CreateMemoryConnection()
        {
            return Wireup.Init()
                        .UsingInMemoryPersistence()
                        .InitializeStorageEngine()
                        .Build();
        }

        internal static IStoreEvents CreateLocalDbConnection()
        {
            return Wireup.Init()
                        .LogToOutputWindow()
                        .UsingInMemoryPersistence()
                        .UsingSqlPersistence("LocalDbWriteStore")
                        .WithDialect(new MsSqlDialect())
                        .EnlistInAmbientTransaction()
                        .InitializeStorageEngine()
                        .UsingJsonSerialization()
                        //.UsingSynchronousDispatchScheduler()
                        .Build();
        }
    }
}
