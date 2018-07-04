using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace App_Atelie.Helpers
{
    public static class ReflectionHelper
    {
        public static T GetAttribute<T>(PropertyInfo Property) where T : Attribute
        {
            T attribute;
            if (Property != null)
                attribute = ((T)Property.GetCustomAttribute(typeof(T)));
            else
                attribute = null;
            return attribute;
        }

        public static T GetAttribute<T>(Type ObjectType) where T : Attribute
        {
            T attribute;
            if (ObjectType != null)
                attribute = ((T)ObjectType.GetCustomAttribute(typeof(T)));
            else
                attribute = null;
            return attribute;
        }

        public static T GetAttribute<T>(Type ObjectType, string PropertyName) where T : Attribute
        {
            T attribute;
            PropertyInfo property = GetProperty(ObjectType, PropertyName);
            if (property != null)
                attribute = GetAttribute<T>(property);
            else
                attribute = null;
            return attribute;
        }

        public static PropertyInfo[] GetObjectProperties(object Instance)
        {
            PropertyInfo[] properties;
            if (Instance != null)
            {
                if (Instance is Dictionary<string, object>)
                    properties = new PropertyInfo[] { };
                else
                    properties = Instance.GetType().GetProperties();
            }
            else
                properties = ((PropertyInfo[])Array.CreateInstance(typeof(PropertyInfo), 0));
            return properties;
        }

        public static PropertyInfo[] GetProperties<T>()
        {
            return typeof(T).GetProperties();
        }

        public static PropertyInfo GetProperty<T>(string PropertyName)
        {
            if (string.IsNullOrWhiteSpace(PropertyName))
                PropertyName = string.Empty;
            return GetProperty(typeof(T), PropertyName);
        }

        public static PropertyInfo GetProperty(Type ObjectType, string PropertyName)
        {
            PropertyInfo property;
            if (ObjectType != null)
                property = ObjectType.GetProperty(PropertyName);
            else
                property = null;
            return property;
        }

        public static PropertyInfo GetProperty<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            MemberExpression member = expression.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "A Expressão '{0}' se refere a um método, não a uma propriedade.",
                    expression.ToString()));

            PropertyInfo property = member.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException(string.Format(
                    "A Empressão '{0}' se refere a um campo, não a uma propriedade.",
                    expression.ToString()));

            return property;
        }

        public static object GetPropertyValue(PropertyInfo Property, object Instance)
        {
            object value;
            if ((Property != null) && (Instance != null) && (Instance.GetType().GetProperty(Property.Name) != null))
            {
                try { value = Property.GetValue(Instance, null); }
                catch { value = null; }
            }
            else
                value = null;
            return value;
        }

        public static T GetPropertyValue<T>(PropertyInfo Property, object Instance)
        {
            T value;
            if ((Property != null) && (Instance != null))
            {
                object propertyValue = Property.GetValue(Instance, null);
                Type convertingType = typeof(T);
                if (!convertingType.Equals(typeof(object)))
                    value = ((T)Convert.ChangeType(propertyValue, convertingType));
                else
                    value = ((T)propertyValue);
            }
            else
                value = default(T);
            return value;
        }

        public static Type GetTypeFromFullName(string FullName)
        {
            Type type;
            if (!string.IsNullOrWhiteSpace(FullName))
            {
                string[] names = FullName.Split('.');
                if (names.Length > 0) Array.Resize<string>(ref names, (names.Length - 1));

                try
                {
                    Assembly assembly = LoadAssembly(string.Join(".", names));
                    type = assembly.GetType(FullName);
                }
                catch { type = null; }
            }
            else
                type = null;
            return type;
        }

        public static PropertyInfo[] GetTypeProperties(Type Type)
        {
            PropertyInfo[] properties;
            if (Type != null)
                properties = Type.GetProperties();
            else
                properties = ((PropertyInfo[])Array.CreateInstance(typeof(PropertyInfo), 0));
            return properties;
        }

        public static bool HasAttribute<T>(PropertyInfo Property) where T : Attribute
        {
            return (GetAttribute<T>(Property) != null);
        }

        public static bool HasAttribute<T>(Type ObjectType) where T : Attribute
        {
            return (GetAttribute<T>(ObjectType) != null);
        }

        public static T Instantiate<T>(object[] Parameters = null)
        {
            return ((T)Instantiate(typeof(T), Parameters));
        }

        public static object Instantiate(Type InstantiatingType, object[] Parameters = null)
        {
            object instance;
            if (InstantiatingType != null)
            {
                if (TypeHelper.IsAnonymous(InstantiatingType))
                    instance = InstantiateAnonymousType(InstantiatingType, Parameters);
                else
                    instance = Activator.CreateInstance(InstantiatingType, Parameters);
            }
            else
                instance = null;
            return instance;
        }

        private static object InstantiateAnonymousType(Type InstantiatingType, object[] Parameters = null)
        {
            object instance;
            if (InstantiatingType != null)
                instance = FormatterServices.GetUninitializedObject(InstantiatingType);
            else
                instance = null;
            return instance;
        }

        public static Assembly LoadAssembly(string AssemblyName)
        {
            Assembly assembly;
            if (!string.IsNullOrWhiteSpace(AssemblyName))
            {
                try { assembly = Assembly.Load(AssemblyName); }
                catch { assembly = null; }
            }
            else
                assembly = null;
            return assembly;
        }

        public static void SetPropertyValue(string PropertyName, object Instance, object Value)
        {
            PropertyInfo prop = GetProperty(Instance.GetType(), PropertyName);
            SetPropertyValue(prop.Name, Instance, Value);
        }
    }
}
