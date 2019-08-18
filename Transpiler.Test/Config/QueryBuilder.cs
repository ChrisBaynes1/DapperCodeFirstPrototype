using System;
using Transpiler.Core.Constants;
using Transpiler.Core.Models;
using Transpiler.Core.Services;
using Unity;

namespace Transpiler.Test
{
    internal class QueryBuilder : IQueryBuilder
    {
        private readonly IUnityContainer _container;

        public QueryBuilder(IUnityContainer container)
        {
            _container = container;
        }

        public string Resolve(QueryTemplateOption option, ITableMap table)
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
