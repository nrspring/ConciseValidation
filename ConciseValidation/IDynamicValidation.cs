using System.Runtime.InteropServices.ComTypes;

namespace ConciseValidation
{
    public interface IDynamicValidation
    {
        object GetPropertyValue(string propertyName);
    }
}