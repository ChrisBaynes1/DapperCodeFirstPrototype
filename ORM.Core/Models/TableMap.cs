using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Translator.Core.Attributes;

namespace Translator.Core.Models
{
    public class TableMap<T> : ITableMap
    {
        private readonly string _tableName;
        private readonly IEnumerable<Field> _fields;

        private static ITableMap _instance;
        private static readonly object _lock = new object();

        public static ITableMap Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TableMap<T>();
                        }
                    }
                }
                return _instance;
            }
        }

        private TableMap()
        {
            Type type = Type;
            _tableName = GetTableAlias(type);
            _fields = GetFields(type);
        }

        private string GetTableAlias(Type type)
        {
            return ((TableAlias)type.GetCustomAttributes(false).Where(a => a.GetType() == typeof(TableAlias)).FirstOrDefault())?.Name ?? type.Name;
        }

        private IEnumerable<Field> GetFields(Type type)
        {
            return type.GetProperties().Select(p => new Field(p));
        }

        public string TableName => _tableName;

        public IEnumerable<Field> Fields => _fields;

        public string[] PrimaryKeys => _fields.Where(f => f.IsPrimaryKey).Select(f => f.Name).ToArray();

        public Type Type => typeof(T);

        public override string ToString()
        {
            return TableName;
        }
    }
}
