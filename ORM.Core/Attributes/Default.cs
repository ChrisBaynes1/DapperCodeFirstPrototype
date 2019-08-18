using System;

namespace Translator.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Default : Attribute
    {
        public Default()
        {
        }
    }
}
