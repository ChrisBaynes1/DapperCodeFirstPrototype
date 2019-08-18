using System.Linq;
using Translator.Core.Models;
using Translator.Core.Services;

namespace Translator.MySql.Templates
{
    public class ReplaceTemplate : IQueryTemplate
    {
        public string Build(ITableMap table)
        {
            var fields = table.Fields;
            var columns = string.Join(", ", fields.Select(f => $"`{f}`"));
            var data = string.Join(", ", fields.Select(f => $"@{f}"));

            return $@"REPLACE INTO {table.TableName} 
                     ({columns}) 
                     VALUES
                     ({data});";
        }
    }
}
