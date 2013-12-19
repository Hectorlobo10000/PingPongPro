using AcklenAvenue.Data.NHibernate;
using Autofac;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using PingPongPro.Data;

namespace PinPongPro.Presentation.Infrastructure
{
    public class DbConfiguration : IBootstrapperTask
    {
        readonly ContainerBuilder _container;

        public DbConfiguration(ContainerBuilder container)
        {
            _container = container;
        }

        public void Run()
        {
            MsSqlConfiguration databaseConfiguration = MsSqlConfiguration.MsSql2008.ShowSql().
                   ConnectionString(x => x.FromConnectionStringWithKey("PingPongPro"));

           
                _container.Register(c => { return c.Resolve<ISessionFactory>().OpenSession(); }).As
                    <ISession>()
                    .InstancePerLifetimeScope()
                    .OnActivating(c =>
                    {
                        if (!c.Instance.Transaction.IsActive)
                            c.Instance.BeginTransaction();
                    }
                    )
                    .OnRelease(c =>
                    {
                        if (c.Transaction.IsActive)
                        {
                            c.Transaction.Commit();
                        }
                        c.Dispose();
                    });


                _container.Register(c =>
                                   new SessionFactoryBuilder(new MappingScheme(), databaseConfiguration).
                                       Build())
                    .SingleInstance()
                    .As<ISessionFactory>();
         
            
        }
    }
}