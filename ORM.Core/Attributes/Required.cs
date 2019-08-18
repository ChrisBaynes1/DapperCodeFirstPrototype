using System;

namespace Translator.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        public Required()
        {
        }
    }
}
