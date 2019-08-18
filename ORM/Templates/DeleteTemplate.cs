using System;
using System.Linq;
using Translator.Core.Models;
using Translator.Core.Services;

namespace Translator.MySql.Templates
{
    public class DeleteTemplate : IQueryTemplate
    {
        public string Build(ITableMap table)
        {
            if (table.PrimaryKeys.Any())
            {
                var condition = string.Join(" AND ", table.PrimaryKeys.Select(p => $"`{p}` = @{p}"));

                return $@"DELETE FROM {table.TableName} WHERE {condition};";
            }
            else
            {
                throw new InvalidOperationException($"No primary key defined for {table.TableName}");
            }
        }
    }
}
