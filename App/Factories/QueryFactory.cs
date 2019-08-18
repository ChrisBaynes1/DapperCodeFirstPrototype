using System;
using Translator.Core.Constants;
using Translator.Core.Factories;
using Translator.Core.Models;
using Translator.Core.Services;
using Unity;

namespace CallingApp.Data.Factories
{
    public class QueryFactory : IQueryFactory
    {
        private readonly IUnityContainer _container;

        public QueryFactory(IUnityContainer container)
        {
            _container = container;
        }

        public string Build(QueryTemplateOption option, ITableMap table)
        {
                IQueryTemplate template = _container.Resolve<IQueryTemplate>(option.ToString());

                if (template != null)
                {
                    return template.Build(table);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
    }
}
