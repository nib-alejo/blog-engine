using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums;

namespace Common
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumAttribute : Attribute
    {
        public EnumAttribute(string id)
        {
            Id = Guid.Parse(id);
        }
        public EnumAttribute(string id, string description)
        {
            Id = Guid.Parse(id);
            Description = description;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }



    }

    public class Enums
    {
        public enum Property
        {
            Id,
            Description
        }

        public enum BlogState
        {
            [Enum(id: "47963E91-6B59-4BBA-9861-25DA0257E4B0", description: "In creation")]
            InCreation,

            [Enum(id: "A69053BE-6343-4EF3-82A9-56A1E4EFBA1D", description: "Pending to check")]
            PendingToCheck,

            [Enum(id: "A079C8CE-408A-4623-AF75-FA2D889EBCAC", description: "Approved")]
            Approved,

            [Enum(id: "7F883E29-50B3-4A3C-91C5-FFB740103AA9", description: "Rejected")]
            Rejected
        }

        public enum Action
        {
            Approve,
            Reject
        }
    }

    public static class Enumerators
    {
        public static string GetValueByProperty(this Enum enumValue, Property property)
        {
            string value = null;

            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (Attribute.IsDefined(fieldInfo, typeof(EnumAttribute)))
            {
                EnumAttribute enumAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(EnumAttribute)) as EnumAttribute;
                Type type = enumAttribute.GetType();
                PropertyInfo propertyInfo = type.GetProperty(property.ToString());

                if (propertyInfo != null)
                {
                    value = propertyInfo.GetValue(enumAttribute).ToString();
                }
            }

            return value;
        }
    }
}
