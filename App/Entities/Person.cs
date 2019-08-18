using System;
using Translator.Core.Attributes;

namespace CallingApp.Data.Entities
{
    [TableAlias("person")]
    public class Person
    {
        [PrimaryKey]
        public long Id { get; set; }

        [Capacity(30)]
        [Required]
        public string FirstName { get; set; }

        [Capacity(30)]
        [Required]
        public string LastName { get; set; }

        [Capacity(15)]
        [Required]
        [Unique]
        public string IdNumber { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Default]
        public DateTime CreatedOn { get; set; }

    }
}
