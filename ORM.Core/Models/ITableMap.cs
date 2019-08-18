using System;
using System.Collections.Generic;

namespace Translator.Core.Models
{
    public interface ITableMap
    {
        string TableName { get; }
        Type Type { get; }
        IEnumerable<Field> Fields { get; }
        string[] PrimaryKeys { get; }
    }
}
