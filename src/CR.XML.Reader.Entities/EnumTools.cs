using System.Reflection;
using System.Xml.Serialization;

namespace CR.XML.Reader.Entities;

public static class EnumTools
{
    public static string GetXmlAttributeValue<T> (T EnumVal)
    {
        if (EnumVal is null)
            throw new ArgumentNullException("Invalid Enum Value");

        Type type = EnumVal.GetType();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        FieldInfo info = type.GetField(Enum.GetName(typeof(T), EnumVal));

        var attr = info.GetCustomAttributes(typeof(XmlEnumAttribute), false);

        if (attr.Count() > 0)
        {
            XmlEnumAttribute att = (XmlEnumAttribute)attr[0];
            return att.Name;
        }

#pragma warning restore CS8602 // Dereference of a possibly null reference.
        return EnumVal.ToString();
    }
}
