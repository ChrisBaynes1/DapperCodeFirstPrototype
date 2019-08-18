using Translator.Core.Constants;
using Translator.Core.Models;

namespace Translator.Core.Factories
{
    public interface IQueryFactory
    {
        string Build(QueryTemplateOption option, ITableMap table);
    }
}
