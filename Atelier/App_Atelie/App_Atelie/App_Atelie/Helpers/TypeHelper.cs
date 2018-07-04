using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using EN = System.Enum;

namespace App_Atelie.Helpers
{
    public static class TypeHelper
    {
        #region Methods

        public static string GetDescription(this EN element)
        {
            Type type = element.GetType();

            MemberInfo[] memberInfo = type.GetMember(element.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                    return ((DescriptionAttribute)attributes[0]).Description;
                attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                if (attributes != null && attributes.Length > 0)
                    return ((DisplayAttribute)attributes[0]).GetDescription();
            }

            return element.ToString();
        }

        public static string GetDescription(this FieldInfo element)
        {
            object[] attributes = element.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return ((DescriptionAttribute)attributes[0]).Description;
            attributes = element.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return ((DisplayAttribute)attributes[0]).GetDescription();

            return element.ToString();
        }

        public static string GetDescription(this Type type)
        {
            object[] attributes = type.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return ((DescriptionAttribute)attributes[0]).Description;
            attributes = type.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return ((DisplayAttribute)attributes[0]).GetDescription();

            return type.ToString();
        }

        public static T GetEnumByInteger<T>(int Itgr)
            where T : struct
        {
            Type enumType = typeof(T);
            string enumValue = EN.GetName(enumType, Itgr);
            T value;
            EN.TryParse(enumValue, out value);
            return value;
        }

        public static bool IsAnonymous(Type CheckingType)
        {
            bool isAnonymous;
            if (CheckingType != null)
            {
                bool hasCompilerGeneratedAttribute = (CheckingType.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false).Any());
                bool nameContainsAnonymousType = CheckingType.FullName.Contains("AnonymousType");
                isAnonymous = (hasCompilerGeneratedAttribute && nameContainsAnonymousType);
            }
            else
                isAnonymous = false;
            return isAnonymous;
        }

        public static bool IsCollectionType(Type InstanceType)
        {
            return ((InstanceType != null) && ((!InstanceType.Equals(typeof(string))) && typeof(IEnumerable).IsAssignableFrom(InstanceType)));
        }

        public static bool IsDate(ref DateTime Date, object Value, CultureInfo Culture)
        {
            bool isDate = false;
            if (Culture != null)
                isDate = DateTime.TryParse((Value ?? string.Empty).ToString(), Culture.DateTimeFormat, DateTimeStyles.AdjustToUniversal, out Date);
            return isDate;
        }

        public static bool IsEnum(object Value)
        {
            return ((Value != null) && Value.GetType().IsEnum);
        }

        public static bool IsEnumType(Type EnumType)
        {
            return ((EnumType != null) && EnumType.IsEnum);
        }

        public static bool IsNullable(Type NullableType)
        {
            return ((NullableType != null) && NullableType.IsGenericType && (NullableType.GetGenericTypeDefinition() == typeof(Nullable<>)));
        }

        public static bool IsNumeric(ref decimal Number, object Value, CultureInfo Culture)
        {
            bool isNumeric = false;
            if (Culture != null)
                isNumeric = decimal.TryParse((Value ?? string.Empty).ToString(), NumberStyles.AllowDecimalPoint, Culture, out Number);
            return isNumeric;
        }
        #endregion Methods
    }
}
