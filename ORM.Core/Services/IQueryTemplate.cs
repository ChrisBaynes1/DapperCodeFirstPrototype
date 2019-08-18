using Translator.Core.Models;

namespace Translator.Core.Services
{
    public interface IQueryTemplate
    {
        string Build(ITableMap table);
    }
}
