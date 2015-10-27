using System;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

namespace ChickenScratch.Util.Extensions
{
    public static class EnumExtension
    {
        public static T ToEnum<T>(String @string)
        {
            if (string.IsNullOrEmpty(@string))
            {
                throw new ArgumentException("Argument null or empty");
            }
            if (@string.Length > 1)
            {
                throw new ArgumentException("Argument length greater than one");
            }

            return (T)Enum.ToObject(typeof(T), @string[0]);
        }

        public static string GetDescription<T>(this object enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0 && attrs.Where(t => t.GetType() == typeof(DescriptionAttribute)).FirstOrDefault() != null)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs.Where(t => t.GetType() == typeof(DescriptionAttribute)).FirstOrDefault()).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

        public static T ToEnumValue<T>(this String enumerationDescription) where T : struct
        {
            Type type = typeof(T);

            if (!type.IsEnum)
                throw new ArgumentException("ToEnumValue<T>(): Must be of enum type", "T");

            foreach (object val in System.Enum.GetValues(type))
                if (val.GetDescription<T>() == enumerationDescription)
                    return (T)val;

            throw new ArgumentException("ToEnumValue<T>(): Invalid description for enum " + type.Name, "enumerationDescription");
        }

        /// <summary>
        /// Gets the value of the <see cref="T:System.ComponentModel.DescriptionAttribute"/> on an struct, including enums.  
        /// </summary>
        /// <typeparam name="T">The type of the struct.</typeparam>
        /// <param name="enumerationValue">A value of type <see cref="T:System.Enum"/></param>
        /// <returns>If the struct has a Description attribute, this method returns the description.  Otherwise it just calls ToString() on the struct.</returns>
        /// <remarks>Based on http://stackoverflow.com/questions/479410/enum-tostring/479417#479417, but useful for any struct.</remarks>
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            return enumerationValue.GetType().GetMember(enumerationValue.ToString())
                    .SelectMany(mi => mi.GetCustomAttributes<DescriptionAttribute>(false),
                        (mi, ca) => ca.Description)
                    .FirstOrDefault() ?? enumerationValue.ToString();
        }
    }
}
