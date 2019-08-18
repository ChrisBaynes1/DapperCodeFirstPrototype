using System;
using System.Linq;

namespace Translator.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKey : Attribute
    {
        private readonly string _tableAlias;
        private readonly string _field;

        public ForeignKey(Type type)
        {
            TableAlias alias = type.GetCustomAttributes(typeof(TableAlias), false).FirstOrDefault() as TableAlias;
            _tableAlias = alias != null ? alias.Name : type.Name;
            _field = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(PrimaryKey), false).Any()).FirstOrDefault().Name ?? string.Empty;
        }

        public string TableAlias => _tableAlias;
        public string Field => _field;
    }
}
