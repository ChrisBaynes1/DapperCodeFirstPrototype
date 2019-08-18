using System;
using Translator.Core.Attributes;

namespace CallingApp.Data.Entities
{
    [TableAlias("contact")]
    public class Contact
    {
        [PrimaryKey]
        public long Id { get; set; }

        [Required]
        [ForeignKey(typeof(Person))]
        public long PersonId { get; set; }

        [Required]
        [ForeignKey(typeof(ContactType))]
        public int ContactTypeId { get; set; }

        [Required]
        [Capacity(255)]
        public string Value { get; set; }

        [Default]
        public DateTime CreatedOn { get; set; }

    }
}