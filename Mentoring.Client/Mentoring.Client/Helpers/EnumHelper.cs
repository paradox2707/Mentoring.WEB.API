using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Mentoring.Client.Helpers
{
    static class EnumHelper
    {
        public static string GetDescription(this Enum enumeration)
        {
            DescriptionAttribute attribute = 
                enumeration
                .GetType()
                .GetMember(enumeration.ToString())
                .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .SingleOrDefault();

            if (attribute == null)
                throw new Exception("Doesn`t have description attribute");

            return attribute.Description;
        }
    }
}
