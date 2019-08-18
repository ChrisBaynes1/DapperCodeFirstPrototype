using System.Linq;
using Translator.Core.Models;
using Translator.Core.Services;

namespace Translator.MySql.Templates
{
    public class UpdateTemplate : IQueryTemplate
    {
        public string Build(ITableMap table)
        {
            var fields = table.Fields.Where(f => !f.Ignore);
            var primaryKeys = table.Fields.Where(f => f.IsPrimaryKey);
            var values = string.Join(", ", fields.Select(f => $"`{f}` = @{f}"));
            var condition = string.Join(" AND ", primaryKeys.Select(p => $"`{p}` = @{p}"));

            return $@"UPDATE `{table.TableName}`
                      SET 
                        {values}
                      WHERE 
                        {condition};";
        }
    }
}
