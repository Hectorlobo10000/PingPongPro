using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace PingPongPro.Data
{
    public class IdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.Assigned();
        }
    }
}