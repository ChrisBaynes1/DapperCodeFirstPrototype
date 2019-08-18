using System;
using System.Reflection;
using Translator.Core.Attributes;

namespace Translator.Core.Models
{
    public class Field
    {
        public Field(PropertyInfo propertyInfo)
        {
            Name = propertyInfo.Name;
            Type = propertyInfo.PropertyType;
            PrimaryKey = (PrimaryKey)propertyInfo.GetCustomAttribute(typeof(PrimaryKey));
            Required = propertyInfo.GetCustomAttribute(typeof(Required)) != null;
            Default = (Default)propertyInfo.GetCustomAttribute(typeof(Default));
            Capacity = (Capacity)propertyInfo.GetCustomAttribute(typeof(Capacity));
            ForeignKey = (ForeignKey)propertyInfo.GetCustomAttribute(typeof(ForeignKey));
            IsUnique = (Unique)propertyInfo.GetCustomAttribute(typeof(Unique)) != null;
        }

        public string Name { get; }
        public string Parent { get; set; }
        public Type Type { get; }
        public PrimaryKey PrimaryKey { get; }
        public ForeignKey ForeignKey { get; }
        public bool IsPrimaryKey => PrimaryKey != null;
        public bool IsForeignKey => ForeignKey != null;
        public bool Required { get; }
        public Default Default { get; }
        public Capacity Capacity { get; }
        public bool IsUnique { get; }

        public bool Ignore => PrimaryKey?.AutoIncrement ?? false | Type.Namespace.Contains("Collections.Generic");

        public override string ToString()
        {
            return Name;
        }
    }
}
