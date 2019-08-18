using System;

namespace Translator.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {
        private readonly bool _hasAutoIncrement;

        public PrimaryKey(bool hasAutoIncrement = true)
        {
            _hasAutoIncrement = hasAutoIncrement;
        }

        public bool AutoIncrement => _hasAutoIncrement;
    }
}
