using System.Linq;
using Translator.Core.Models;
using Translator.Core.Services;

namespace Translator.MySql.Templates
{
    public class InitTableTemplate : IQueryTemplate
    {
        private readonly IFieldTranslatorService _Translator;

        public InitTableTemplate(IFieldTranslatorService Translator)
        {
            _Translator = Translator;
        }

        public string Build(ITableMap table)
        {
            var fields = table.Fields.Select(f => $"`{f}` {_Translator.GetDataType(f)} {_Translator.GetRequired(f)} {_Translator.GetDefaultValue(f)} {_Translator.GetUnique(f)}");
            string content = string.Join(", ", fields);

            const string foreignKeyTemplate = @"ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY ({2}) REFERENCES {3}({4});";
            string foreignKeyConstraints = string.Join("", table.Fields.Where(f => f.IsForeignKey).Select(f => string.Format(foreignKeyTemplate, table.TableName, $"fk_{table.TableName}_{f.ForeignKey.TableAlias}", f.Name, f.ForeignKey.TableAlias, f.ForeignKey.Field)));

            string query = $@"CREATE TABLE IF NOT EXISTS {table} ({content}) ENGINE=INNODB; {foreignKeyConstraints}";
            return query;
        }
    }
}
