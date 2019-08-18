using Translator.Core.Attributes;

namespace CallingApp.Data.Entities
{
    [TableAlias("contact_type")]
    public class ContactType
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Capacity(50)]
        [Required]
        public string Value { get; set; }
    }
}
