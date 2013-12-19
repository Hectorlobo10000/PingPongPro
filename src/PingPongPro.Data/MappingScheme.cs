using System;
using AcklenAvenue.Data;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using PingPongPro.Domain;

namespace PingPongPro.Data
{
    public class MappingScheme : IDatabaseMappingScheme<MappingConfiguration>
    {
        #region IDatabaseMappingScheme<MappingConfiguration> Members

        public Action<MappingConfiguration> Mappings
        {
            get
            {
                var autoPersistenceModel = AutoMap.Assemblies(typeof (IEntity).Assembly)
                                                                   .Where(t => typeof (IEntity).IsAssignableFrom(t))
                                                                   .Conventions.Add(new IdConvention())
                                                                   .Conventions.Add(DefaultCascade.All());

                return x => x.AutoMappings.Add(autoPersistenceModel);
            }
        }

        #endregion
    }
}