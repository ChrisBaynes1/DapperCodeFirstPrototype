using System.Linq;
using Translator.Core.Models;
using Translator.Core.Services;

namespace Translator.MySql.Templates
{
    public class FindSingleTemplate : IQueryTemplate
    {
        public string Build(ITableMap table)
        {
            var primaryKeys = table.Fields.Where(f => f.IsPrimaryKey);
            var condition = string.Join(" AND ", primaryKeys.Select(p => $"`{p}` = @{p}"));
            return $"SELECT * FROM `{table.TableName}` WHERE {condition} LIMIT 1;";
        }
    }
}
