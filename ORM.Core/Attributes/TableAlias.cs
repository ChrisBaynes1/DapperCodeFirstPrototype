using System;

namespace Translator.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAlias : Attribute
    {
        private readonly string _name;

        public TableAlias(string name)
        {
            _name = name;
        }

        public string Name => _name;

    }
}
