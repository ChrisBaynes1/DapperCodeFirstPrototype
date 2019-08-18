using System;
using Translator.Core.Models;
using Translator.Core.Services;

namespace Translator.MySql
{
    public class FieldTranslatorService : IFieldTranslatorService
    {
        public string GetDataType(Field field)
        {
            string type = field.Type.ToString();

            if (type == "System.Guid")
            {
                return "UNIQUEIDENIFIER";
            }

            if (type == "System.String")
            {
                return $"VARCHAR({field.Capacity?.Max ?? 50})";
            }

            else if (type == "System.Int32" | field.Type.BaseType.Name == "Enum")
            {
                return "INT";
            }

            else if (type == "System.Decimal" | type == "System.Point" | type == "System.Float" | type == "System.Double")
            {
                return $"DECIMAL({field.Capacity?.Min ?? 16},{field.Capacity?.Max ?? 2})";
            }

            else if (type == "System.DateTime")
            {
                return "DATETIME";
            }

            else if (type == "System.Boolean")
            {
                return "BIT";
            }

            else if (type == "System.Int64")
            {
                return "BIGINT";
            }

            throw new InvalidCastException($"The data type for [{type}] could not be transpiled.");
        }

        public string GetDefaultValue(Field field)
        {
            if (field.IsPrimaryKey)
            {
                if (field.PrimaryKey.AutoIncrement)
                {
                    return "PRIMARY KEY AUTO_INCREMENT";
                }
            }

            else if (field.Default != null)
            {
                Type type = field.Type;

                if (type == typeof(DateTime))
                {
                    return "DEFAULT NOW()";
                }
            }

            return string.Empty;
        }

        public string GetRequired(Field field)
        {
            if (field.Required | field.IsPrimaryKey | field.IsForeignKey)
            {
                return "NOT NULL";
            }
            return "NULL";
        }

        public string GetUnique(Field field)
        {
            return field.IsUnique ? "UNIQUE" : string.Empty;
        }
    }
}
