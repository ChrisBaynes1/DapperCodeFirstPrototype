using System;
using System.Drawing;

namespace Translator.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Capacity : Attribute
    {
        private readonly Point _capacity;

        public Capacity(int max)
        {
            _capacity = new Point(0, max);
        }

        public Capacity(int min, int max)
        {
            _capacity = new Point(min, max);
        }

        public int Min => _capacity.X;
        public int Max => _capacity.Y;
    }
}
