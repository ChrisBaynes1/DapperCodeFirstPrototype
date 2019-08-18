using Translator.Core.Attributes;

namespace CallingApp.Data.Entities
{
    [TableAlias("location")]
    public class Location
    {
        [PrimaryKey]
        public long Id { get; set; }



    }
}
