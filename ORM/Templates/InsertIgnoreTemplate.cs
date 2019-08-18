using Translator.Core.Services;
using Translator.Core.Models;
using System.Linq;

namespace Translator.MySql.Templates
{
    public class InsertIgnoreTemplate : IQueryTemplate
    {
        public string Build(ITableMap table)
        {
            var fields = table.Fields.Where(f => !f.Ignore);
            var columns = string.Join(", ", fields.Select(f => $"`{f}`"));
            var data = string.Join(", ", fields.Select(f => $"@{f}"));

            return $@"INSERT IGNORE INTO {table.TableName} 
                     ({columns}) 
                     VALUES
                     ({data});";
        }
    }
}
