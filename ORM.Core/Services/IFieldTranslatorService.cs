using Translator.Core.Models;

namespace Translator.Core.Services
{
    public interface IFieldTranslatorService
    {
        string GetDataType(Field field);
        string GetDefaultValue(Field field);
        string GetRequired(Field field);
        string GetUnique(Field field);
    }
}
