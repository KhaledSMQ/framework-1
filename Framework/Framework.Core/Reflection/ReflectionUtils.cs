// ============================================================================
// Project: Framework
// Name/Class: ReflectionUtils
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Helper methods for reflection on instances.
// ============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using Framework.Core.Extensions;
using Framework.Core.Helpers;

namespace Framework.Core.Reflection
{
    public static class ReflectionUtils
    {
        //
        // Get the property value.
        // Take a generic object and a property name and return the vlaue
        // for the property.  Returns the value for the given property name.
        // 

        public static object GetPropertyValue(object obj, string propName)
        {
            //
            // Verify inputs arguments.
            //

            Guard.IsNotNull(obj, "Must provide object to get it's property.");
            Guard.IsTrue(!string.IsNullOrEmpty(propName), "Must provide property name to get property value.");

            //
            // Trim the property name.
            // Just in case.
            //

            propName = propName.Trim();

            //
            // Return the property value.
            //

            PropertyInfo property = obj.GetType().GetProperty(propName);

            return property.IsNotNull() ? property.GetValue(obj, null) : null;
        }

        //
        // Get all the property values found in a list of names.
        // Take a list of property names and return their values.
        // The order of the return list os the same as the order
        // specified.
        //

        public static IList<object> GetPropertyValues(object obj, IList<string> properties)
        {
            IList<object> propertyValues = new List<object>();

            foreach (string property in properties)
            {
                PropertyInfo propInfo = obj.GetType().GetProperty(property);
                object val = propInfo.GetValue(obj, null);
                propertyValues.Add(val);
            }

            return propertyValues;
        }

        //
        // Get all the property values found in a string of property names.
        // The property names are delimited by a specific caracter.
        // The order of the return list os the same as the order specified.
        //

        public static IList<PropertyInfo> GetProperties(object obj, string propsDelimited)
        {
            return GetProperties(obj.GetType(), propsDelimited.Split(','));
        }


        //
        // Get property information for a type.
        //

        public static IList<PropertyInfo> GetProperties(Type type, string[] props)
        {
            PropertyInfo[] allProps = type.GetProperties();
            List<PropertyInfo> propToGet = new List<PropertyInfo>();
            IDictionary<string, string> propsMap = props.ToDictionary<string>();

            foreach (PropertyInfo prop in allProps)
            {
                if (propsMap.ContainsKey(prop.Name))
                    propToGet.Add(prop);
            }

            return propToGet;
        }


        /// <summary>
        /// Get all the properties.
        /// </summary>
        /// <param name="type">Type whose property names to retrieve.</param>
        /// <param name="props">Array with property names to look for.</param>
        /// <param name="flags">Flags to use when searching for properties.</param>
        /// <returns>List with property information of found properties.</returns>
        public static IList<PropertyInfo> GetProperties(Type type, string[] props, BindingFlags flags)
        {
            PropertyInfo[] allProps = type.GetProperties(flags);
            List<PropertyInfo> propToGet = new List<PropertyInfo>();
            IDictionary<string, string> propsMap = props.ToDictionary<string>();
            foreach (PropertyInfo prop in allProps)
            {
                if (propsMap.ContainsKey(prop.Name))
                    propToGet.Add(prop);
            }
            return propToGet;
        }


        /// <summary>
        /// Gets the property value safely, without throwing an exception.
        /// If an exception is caught, null is returned.
        /// </summary>
        /// <param name="obj">Object to look into.</param>
        /// <param name="propInfo">Information of property to retrieve.</param>
        /// <returns>Retrieved property value.</returns>
        public static object GetPropertyValueSafely(object obj, PropertyInfo propInfo)
        {
            Guard.IsNotNull(obj, "Must provide object to get it's property.");
            if (propInfo == null) return null;

            object result = null;
            try
            {
                result = propInfo.GetValue(obj, null);
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }


        /// <summary>
        /// Gets all the properties of an object.
        /// </summary>
        /// <param name="obj">Object to look into.</param>
        /// <param name="criteria">Matching criteria.</param>
        /// <returns>List with information of matched properties.</returns>
        public static IList<PropertyInfo> GetAllProperties(object obj, Predicate<PropertyInfo> criteria)
        {
            if (obj == null) { return null; }
            return GetProperties(obj.GetType(), criteria);
        }


        /// <summary>
        /// Get the properties of a type.
        /// </summary>
        /// <param name="type">Type to look into.</param>
        /// <param name="criteria">Matching criteria.</param>
        /// <returns>List of information of matched properties.</returns>
        public static IList<PropertyInfo> GetProperties(Type type, Predicate<PropertyInfo> criteria)
        {
            IList<PropertyInfo> allProperties = new List<PropertyInfo>();
            PropertyInfo[] properties = type.GetProperties();
            if (properties == null || properties.Length == 0) { return null; }

            // Now check for all writeable properties.
            foreach (PropertyInfo property in properties)
            {
                // Only include writable properties and ones that are not in the exclude list.
                bool okToAdd = (criteria == null) ? true : criteria(property);
                if (okToAdd)
                {
                    allProperties.Add(property);
                }
            }
            return allProperties;
        }


        /// <summary>
        /// Gets all the writable properties of an object.
        /// </summary>
        /// <param name="obj">Object to look into.</param>
        /// <param name="propsToExclude">Dictionary with properties to exclude.</param>
        /// <returns>List with information of matched properties.</returns>
        public static IList<PropertyInfo> GetWritableProperties(object obj, StringDictionary propsToExclude)
        {
            IList<PropertyInfo> props = ReflectionUtils.GetWritableProperties(obj.GetType(),
                 delegate(PropertyInfo property)
                 {
                     bool okToAdd = propsToExclude == null ? property.CanWrite : (property.CanWrite && !propsToExclude.ContainsKey(property.Name));
                     return okToAdd;
                 });
            return props;
        }


        /// <summary>
        /// Gets all the properties of a type.
        /// </summary>
        /// <param name="propsToExclude">Dictionary with properties to exclude.</param>
        /// <param name="typ">Type to look into.</param>
        /// <returns>List with information of matched properties.</returns>
        public static IList<PropertyInfo> GetProperties(StringDictionary propsToExclude, Type typ)
        {
            IList<PropertyInfo> props = ReflectionUtils.GetWritableProperties(typ,
                 delegate(PropertyInfo property)
                 {
                     bool okToAdd = propsToExclude == null ? true : (!propsToExclude.ContainsKey(property.Name));
                     return okToAdd;
                 });
            return props;
        }


        /// <summary>
        /// Gets all the properties of the object as dictionary of property names to propertyInfo.
        /// </summary>
        /// <param name="obj">Object to look into.</param>
        /// <param name="criteria">Matching criteria.</param>
        /// <returns>Dictionary with property name and information of matched properties.</returns>
        public static IDictionary<string, PropertyInfo> GetPropertiesAsMap(object obj, Predicate<PropertyInfo> criteria)
        {
            IList<PropertyInfo> matchedProps = GetProperties(obj.GetType(), criteria);
            IDictionary<string, PropertyInfo> props = new Dictionary<string, PropertyInfo>();

            // Now check for all writeable properties.
            foreach (PropertyInfo prop in matchedProps)
            {
                props.Add(prop.Name, prop);
            }
            return props;
        }


        /// <summary>
        /// Get all the properties.
        /// </summary>
        /// <param name="type">Type to look into.</param>
        /// <param name="flags">Flags to use when looking for properties.</param>
        /// <param name="isCaseSensitive">True to use the property name in the
        /// dictionary with its lower-cased value.</param>
        /// <returns>Dictionary with property name and information of found properties.</returns>
        public static IDictionary<string, PropertyInfo> GetPropertiesAsMap(Type type, BindingFlags flags, bool isCaseSensitive)
        {
            PropertyInfo[] allProps = type.GetProperties(flags);
            IDictionary<string, PropertyInfo> propsMap = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo prop in allProps)
            {
                if (isCaseSensitive)
                    propsMap[prop.Name] = prop;
                else
                    propsMap[prop.Name.Trim().ToLower()] = prop;
            }

            return propsMap;
        }


        /// <summary>
        /// Get all the properties.
        /// </summary>
        /// <typeparam name="T">Type to look into.</typeparam>
        /// <param name="flags">Flags to use when looking for properties.</param>
        /// <param name="isCaseSensitive">True to use the property name in the
        /// dictionary with its lower-cased value.</param>
        /// <returns>Dictionary with property name and information of found properties.</returns>
        public static IDictionary<string, PropertyInfo> GetPropertiesAsMap<T>(BindingFlags flags, bool isCaseSensitive)
        {
            Type type = typeof(T);
            return GetPropertiesAsMap(type, flags, isCaseSensitive);
        }


        /// <summary>
        /// Get the propertyInfo of the specified property name.
        /// </summary>
        /// <param name="type">Type to look into.</param>
        /// <param name="propertyName">Name of property.</param>
        /// <returns>Information of property.</returns>
        public static PropertyInfo GetProperty(Type type, string propertyName)
        {
            IList<PropertyInfo> props = GetProperties(type,
                delegate(PropertyInfo property)
                {
                    return property.Name == propertyName;
                });
            return props[0];
        }


        /// <summary>
        /// Gets a list of all the writable properties of the class associated with the object.
        /// </summary>
        /// <param name="type">Type to look into.</param>
        /// <param name="criteria">Matching criteria.</param>
        /// <remarks>This method does not take into account, security, generics, etc.
        /// It only checks whether or not the property can be written to.</remarks>
        /// <returns>List with information of matching properties.</returns>
        public static IList<PropertyInfo> GetWritableProperties(Type type, Predicate<PropertyInfo> criteria)
        {
            IList<PropertyInfo> props = ReflectionUtils.GetProperties(type,
                 delegate(PropertyInfo property)
                 {
                     // Now determine if it can be added based on criteria.
                     bool okToAdd = (criteria == null) ? property.CanWrite : (property.CanWrite && criteria(property));
                     return okToAdd;
                 });
            return props;
        }



        /// <summary>
        /// Invokes the method on the object provided.
        /// </summary>
        /// <param name="obj">The object containing the method to invoke</param>
        /// <param name="methodName">arguments to the method.</param>
        /// <param name="parameters">Parameters to pass when invoking the method.</param>
        public static object InvokeMethod(object obj, string methodName, object[] parameters)
        {
            Guard.IsNotNull(methodName, "Method name not provided.");
            Guard.IsNotNull(obj, "Can not invoke method on null object");

            methodName = methodName.Trim();

            // Validate.
            if (string.IsNullOrEmpty(methodName)) { throw new ArgumentException("Method name not provided."); }

            MethodInfo method = obj.GetType().GetMethod(methodName);
            object output = method.Invoke(obj, parameters);
            return output;
        }


        /// <summary>
        /// Copies the property value from the source to destination.
        /// </summary>
        /// <param name="source">Source object.</param>
        /// <param name="destination">Destination object.</param>
        /// <param name="prop">Information of property whose value
        /// is to be copied from the source to the target object.</param>
        public static void CopyPropertyValue(object source, object destination, PropertyInfo prop)
        {
            object val = prop.GetValue(source, null);
            prop.SetValue(destination, val, null);
        }


        public static bool IsVirtual(this PropertyInfo propertyInfo)
        {
            Guard.ArgumentNotNull(propertyInfo, "propertyInfo");

            MethodInfo m = propertyInfo.GetGetMethod();
            if (m.IsNotNull() && m.IsVirtual)
                return true;

            m = propertyInfo.GetSetMethod();
            if (m.IsNotNull() && m.IsVirtual)
                return true;

            return false;
        }

        public static Type GetObjectType(object v)
        {
            return (v.IsNotNull()) ? v.GetType() : null;
        }

        public static string GetTypeName(Type t, FormatterAssemblyStyle assemblyFormat)
        {
            return GetTypeName(t, assemblyFormat, null);
        }

        public static string GetTypeName(Type t, FormatterAssemblyStyle assemblyFormat, SerializationBinder binder)
        {
            string fullyQualifiedTypeName;
            // #if !(NET20 || NET35)
            /**
            if (binder.IsNotNull())
            {
                string assemblyName, typeName;
                binder.BindToName(t, out assemblyName, out typeName);
                fullyQualifiedTypeName = typeName + (assemblyName == null ? "" : ", " + assemblyName);
            }
            else
            {
                fullyQualifiedTypeName = t.AssemblyQualifiedName;
            }**/
            // #else
            fullyQualifiedTypeName = t.AssemblyQualifiedName;
            //#endif

            switch (assemblyFormat)
            {
                case FormatterAssemblyStyle.Simple:
                    return RemoveAssemblyDetails(fullyQualifiedTypeName);
                case FormatterAssemblyStyle.Full:
                    return t.AssemblyQualifiedName;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string RemoveAssemblyDetails(string fullyQualifiedTypeName)
        {
            StringBuilder builder = new StringBuilder();

            // loop through the type name and filter out qualified assembly details from nested type names
            bool writingAssemblyName = false;
            bool skippingAssemblyDetails = false;
            for (int i = 0; i < fullyQualifiedTypeName.Length; i++)
            {
                char current = fullyQualifiedTypeName[i];
                switch (current)
                {
                    case '[':
                        writingAssemblyName = false;
                        skippingAssemblyDetails = false;
                        builder.Append(current);
                        break;
                    case ']':
                        writingAssemblyName = false;
                        skippingAssemblyDetails = false;
                        builder.Append(current);
                        break;
                    case ',':
                        if (!writingAssemblyName)
                        {
                            writingAssemblyName = true;
                            builder.Append(current);
                        }
                        else
                        {
                            skippingAssemblyDetails = true;
                        }
                        break;
                    default:
                        if (!skippingAssemblyDetails)
                            builder.Append(current);
                        break;
                }
            }

            return builder.ToString();
        }

        public static bool IsInstantiatableType(Type t)
        {
            Guard.ArgumentNotNull(t, "t");

            if (t.IsAbstract || t.IsInterface || t.IsArray || t.IsGenericTypeDefinition || t == typeof(void))
                return false;

            if (!HasDefaultConstructor(t))
                return false;

            return true;
        }

        public static bool HasDefaultConstructor(Type t)
        {
            return HasDefaultConstructor(t, false);
        }

        public static bool HasDefaultConstructor(Type t, bool nonPublic)
        {
            Guard.ArgumentNotNull(t, "t");

            if (t.IsValueType)
                return true;

            return (GetDefaultConstructor(t, nonPublic).IsNotNull());
        }

        public static ConstructorInfo GetDefaultConstructor(Type t)
        {
            return GetDefaultConstructor(t, false);
        }

        public static ConstructorInfo GetDefaultConstructor(Type t, bool nonPublic)
        {
            BindingFlags accessModifier = BindingFlags.Public;

            if (nonPublic)
                accessModifier = accessModifier | BindingFlags.NonPublic;

            return t.GetConstructor(accessModifier | BindingFlags.Instance, null, new Type[0], null);
        }

        public static bool IsNullable(Type t)
        {
            Guard.ArgumentNotNull(t, "t");

            if (t.IsValueType)
                return IsNullableType(t);

            return true;
        }

        public static bool IsNullableType(Type t)
        {
            Guard.ArgumentNotNull(t, "t");

            return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public static Type EnsureNotNullableType(Type t)
        {
            return (IsNullableType(t))
              ? Nullable.GetUnderlyingType(t)
              : t;
        }

        public static bool ImplementsGenericDefinition(Type type, Type genericInterfaceDefinition)
        {
            Type implementingType;
            return ImplementsGenericDefinition(type, genericInterfaceDefinition, out implementingType);
        }

        public static bool ImplementsGenericDefinition(Type type, Type genericInterfaceDefinition, out Type implementingType)
        {
            Guard.ArgumentNotNull(type, "type");
            Guard.ArgumentNotNull(genericInterfaceDefinition, "genericInterfaceDefinition");

            if (!genericInterfaceDefinition.IsInterface || !genericInterfaceDefinition.IsGenericTypeDefinition)
                throw new ArgumentNullException("'{0}' is not a generic interface definition.".FormatWith(CultureInfo.InvariantCulture, genericInterfaceDefinition));

            if (type.IsInterface)
            {
                if (type.IsGenericType)
                {
                    Type interfaceDefinition = type.GetGenericTypeDefinition();

                    if (genericInterfaceDefinition == interfaceDefinition)
                    {
                        implementingType = type;
                        return true;
                    }
                }
            }

            foreach (Type i in type.GetInterfaces())
            {
                if (i.IsGenericType)
                {
                    Type interfaceDefinition = i.GetGenericTypeDefinition();

                    if (genericInterfaceDefinition == interfaceDefinition)
                    {
                        implementingType = i;
                        return true;
                    }
                }
            }

            implementingType = null;
            return false;
        }

        public static bool AssignableToTypeName(this Type type, string fullTypeName, out Type match)
        {
            Type current = type;

            while (current.IsNotNull())
            {
                if (string.Equals(current.FullName, fullTypeName, StringComparison.Ordinal))
                {
                    match = current;
                    return true;
                }

                current = current.BaseType;
            }

            foreach (Type i in type.GetInterfaces())
            {
                if (string.Equals(i.Name, fullTypeName, StringComparison.Ordinal))
                {
                    match = type;
                    return true;
                }
            }

            match = null;
            return false;
        }

        public static bool AssignableToTypeName(this Type type, string fullTypeName)
        {
            Type match;
            return type.AssignableToTypeName(fullTypeName, out match);
        }

        public static bool InheritsGenericDefinition(Type type, Type genericClassDefinition)
        {
            Type implementingType;
            return InheritsGenericDefinition(type, genericClassDefinition, out implementingType);
        }

        public static bool InheritsGenericDefinition(Type type, Type genericClassDefinition, out Type implementingType)
        {
            Guard.ArgumentNotNull(type, "type");
            Guard.ArgumentNotNull(genericClassDefinition, "genericClassDefinition");

            if (!genericClassDefinition.IsClass || !genericClassDefinition.IsGenericTypeDefinition)
                throw new ArgumentNullException("'{0}' is not a generic class definition.".FormatWith(CultureInfo.InvariantCulture, genericClassDefinition));

            return InheritsGenericDefinitionInternal(type, genericClassDefinition, out implementingType);
        }

        private static bool InheritsGenericDefinitionInternal(Type currentType, Type genericClassDefinition, out Type implementingType)
        {
            if (currentType.IsGenericType)
            {
                Type currentGenericClassDefinition = currentType.GetGenericTypeDefinition();

                if (genericClassDefinition == currentGenericClassDefinition)
                {
                    implementingType = currentType;
                    return true;
                }
            }

            if (currentType.BaseType == null)
            {
                implementingType = null;
                return false;
            }

            return InheritsGenericDefinitionInternal(currentType.BaseType, genericClassDefinition, out implementingType);
        }

        /// <summary>
        /// Gets the type of the typed collection's items.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The type of the typed collection's items.</returns>
        public static Type GetCollectionItemType(Type type)
        {
            Guard.ArgumentNotNull(type, "type");
            Type genericListType;

            if (type.IsArray)
            {
                return type.GetElementType();
            }
            else if (ImplementsGenericDefinition(type, typeof(IEnumerable<>), out genericListType))
            {
                if (genericListType.IsGenericTypeDefinition)
                    throw new Exception("Type {0} is not a collection.".FormatWith(CultureInfo.InvariantCulture, type));

                return genericListType.GetGenericArguments()[0];
            }
            else if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                return null;
            }
            else
            {
                throw new Exception("Type {0} is not a collection.".FormatWith(CultureInfo.InvariantCulture, type));
            }
        }

        public static void GetDictionaryKeyValueTypes(Type dictionaryType, out Type keyType, out Type valueType)
        {
            Guard.ArgumentNotNull(dictionaryType, "type");

            Type genericDictionaryType;
            if (ImplementsGenericDefinition(dictionaryType, typeof(IDictionary<,>), out genericDictionaryType))
            {
                if (genericDictionaryType.IsGenericTypeDefinition)
                    throw new Exception("Type {0} is not a dictionary.".FormatWith(CultureInfo.InvariantCulture, dictionaryType));

                Type[] dictionaryGenericArguments = genericDictionaryType.GetGenericArguments();

                keyType = dictionaryGenericArguments[0];
                valueType = dictionaryGenericArguments[1];
                return;
            }
            else if (typeof(IDictionary).IsAssignableFrom(dictionaryType))
            {
                keyType = null;
                valueType = null;
                return;
            }
            else
            {
                throw new Exception("Type {0} is not a dictionary.".FormatWith(CultureInfo.InvariantCulture, dictionaryType));
            }
        }

        public static Type GetDictionaryValueType(Type dictionaryType)
        {
            Type keyType;
            Type valueType;
            GetDictionaryKeyValueTypes(dictionaryType, out keyType, out valueType);

            return valueType;
        }

        public static Type GetDictionaryKeyType(Type dictionaryType)
        {
            Type keyType;
            Type valueType;
            GetDictionaryKeyValueTypes(dictionaryType, out keyType, out valueType);

            return keyType;
        }

        /// <summary>
        /// Gets the member's underlying type.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>The underlying type of the member.</returns>
        public static Type GetMemberUnderlyingType(MemberInfo member)
        {
            Guard.ArgumentNotNull(member, "member");

            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                case MemberTypes.Event:
                    return ((EventInfo)member).EventHandlerType;
                default:
                    throw new ArgumentException("MemberInfo must be of type FieldInfo, PropertyInfo or EventInfo", "member");
            }
        }

        /// <summary>
        /// Determines whether the member is an indexed property.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>
        /// 	<c>true</c> if the member is an indexed property; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsIndexedProperty(MemberInfo member)
        {
            Guard.ArgumentNotNull(member, "member");

            PropertyInfo propertyInfo = member as PropertyInfo;

            if (propertyInfo.IsNotNull())
                return IsIndexedProperty(propertyInfo);
            else
                return false;
        }

        /// <summary>
        /// Determines whether the property is an indexed property.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns>
        /// 	<c>true</c> if the property is an indexed property; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsIndexedProperty(PropertyInfo property)
        {
            Guard.ArgumentNotNull(property, "property");

            return (property.GetIndexParameters().Length > 0);
        }

        /// <summary>
        /// Gets the member's value on the object.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <param name="target">The target object.</param>
        /// <returns>The member's value on the object.</returns>
        public static object GetMemberValue(MemberInfo member, object target)
        {
            Guard.ArgumentNotNull(member, "member");
            Guard.ArgumentNotNull(target, "target");

            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).GetValue(target);
                case MemberTypes.Property:
                    try
                    {
                        return ((PropertyInfo)member).GetValue(target, null);
                    }
                    catch (TargetParameterCountException e)
                    {
                        throw new ArgumentException("MemberInfo '{0}' has index parameters".FormatWith(CultureInfo.InvariantCulture, member.Name), e);
                    }
                default:
                    throw new ArgumentException("MemberInfo '{0}' is not of type FieldInfo or PropertyInfo".FormatWith(CultureInfo.InvariantCulture, CultureInfo.InvariantCulture, member.Name), "member");
            }
        }

        /// <summary>
        /// Sets the member's value on the target object.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <param name="target">The target.</param>
        /// <param name="value">The value.</param>
        public static void SetMemberValue(MemberInfo member, object target, object value)
        {
            Guard.ArgumentNotNull(member, "member");
            Guard.ArgumentNotNull(target, "target");

            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    ((FieldInfo)member).SetValue(target, value);
                    break;
                case MemberTypes.Property:
                    ((PropertyInfo)member).SetValue(target, value, null);
                    break;
                default:
                    throw new ArgumentException("MemberInfo '{0}' must be of type FieldInfo or PropertyInfo".FormatWith(CultureInfo.InvariantCulture, member.Name), "member");
            }
        }

        /// <summary>
        /// Determines whether the specified MemberInfo can be read.
        /// </summary>
        /// <param name="member">The MemberInfo to determine whether can be read.</param>
        /// /// <param name="nonPublic">if set to <c>true</c> then allow the member to be gotten non-publicly.</param>
        /// <returns>
        /// 	<c>true</c> if the specified MemberInfo can be read; otherwise, <c>false</c>.
        /// </returns>
        public static bool CanReadMemberValue(MemberInfo member, bool nonPublic)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    FieldInfo fieldInfo = (FieldInfo)member;

                    if (nonPublic)
                        return true;
                    else if (fieldInfo.IsPublic)
                        return true;
                    return false;
                case MemberTypes.Property:
                    PropertyInfo propertyInfo = (PropertyInfo)member;

                    if (!propertyInfo.CanRead)
                        return false;
                    if (nonPublic)
                        return true;
                    return (propertyInfo.GetGetMethod(nonPublic).IsNotNull());
                default:
                    return false;
            }
        }

        /// <summary>
        /// Determines whether the specified MemberInfo can be set.
        /// </summary>
        /// <param name="member">The MemberInfo to determine whether can be set.</param>
        /// <param name="nonPublic">if set to <c>true</c> then allow the member to be set non-publicly.</param>
        /// <param name="canSetReadOnly">if set to <c>true</c> then allow the member to be set if read-only.</param>
        /// <returns>
        /// 	<c>true</c> if the specified MemberInfo can be set; otherwise, <c>false</c>.
        /// </returns>
        public static bool CanSetMemberValue(MemberInfo member, bool nonPublic, bool canSetReadOnly)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    FieldInfo fieldInfo = (FieldInfo)member;

                    if (fieldInfo.IsInitOnly && !canSetReadOnly)
                        return false;
                    if (nonPublic)
                        return true;
                    else if (fieldInfo.IsPublic)
                        return true;
                    return false;
                case MemberTypes.Property:
                    PropertyInfo propertyInfo = (PropertyInfo)member;

                    if (!propertyInfo.CanWrite)
                        return false;
                    if (nonPublic)
                        return true;
                    return (propertyInfo.GetSetMethod(nonPublic) != null);
                default:
                    return false;
            }
        }

        public static List<MemberInfo> GetFieldsAndProperties(Type type, BindingFlags bindingAttr)
        {
            List<MemberInfo> targetMembers = new List<MemberInfo>();

            // TODO: Fix this
            // targetMembers.AddRange<FieldInfo>(GetFields(type, bindingAttr));
            // targetMembers.AddRange<PropertyInfo>(GetProperties(type, bindingAttr));

            // for some reason .NET returns multiple members when overriding a generic member on a base class
            // http://forums.msdn.microsoft.com/en-US/netfxbcl/thread/b5abbfee-e292-4a64-8907-4e3f0fb90cd9/
            // filter members to only return the override on the topmost class
            // update: I think this is fixed in .NET 3.5 SP1 - leave this in for now...
            List<MemberInfo> distinctMembers = new List<MemberInfo>(targetMembers.Count);

            var groupedMembers = targetMembers.GroupBy(m => m.Name).Select(g => new { Count = g.Count(), Members = g.Cast<MemberInfo>() });
            foreach (var groupedMember in groupedMembers)
            {
                if (groupedMember.Count == 1)
                {
                    distinctMembers.Add(groupedMember.Members.First());
                }
                else
                {
                    var members = groupedMember.Members.Where(m => !IsOverridenGenericMember(m, bindingAttr) || m.Name == "ItemVal");

                    distinctMembers.AddRange(members);
                }
            }

            return distinctMembers;
        }

        private static bool IsOverridenGenericMember(MemberInfo memberInfo, BindingFlags bindingAttr)
        {
            if (memberInfo.MemberType != MemberTypes.Field && memberInfo.MemberType != MemberTypes.Property)
                throw new ArgumentException("Member must be a field or property.");

            Type declaringType = memberInfo.DeclaringType;
            if (!declaringType.IsGenericType)
                return false;
            Type genericTypeDefinition = declaringType.GetGenericTypeDefinition();
            if (genericTypeDefinition == null)
                return false;
            MemberInfo[] members = genericTypeDefinition.GetMember(memberInfo.Name, bindingAttr);
            if (members.Length == 0)
                return false;
            Type memberUnderlyingType = GetMemberUnderlyingType(members[0]);
            if (!memberUnderlyingType.IsGenericParameter)
                return false;

            return true;
        }

        public static T GetAttribute<T>(ICustomAttributeProvider attributeProvider) where T : Attribute
        {
            return GetAttribute<T>(attributeProvider, true);
        }

        public static T GetAttribute<T>(ICustomAttributeProvider attributeProvider, bool inherit) where T : Attribute
        {
            T[] attributes = GetAttributes<T>(attributeProvider, inherit);

            return attributes.SingleOrDefault();
        }

        public static T[] GetAttributes<T>(ICustomAttributeProvider attributeProvider, bool inherit) where T : Attribute
        {
            Guard.ArgumentNotNull(attributeProvider, "attributeProvider");

            // http://hyperthink.net/blog/getcustomattributes-gotcha/
            // ICustomAttributeProvider doesn't do inheritance

            if (attributeProvider is Type)
                return (T[])((Type)attributeProvider).GetCustomAttributes(typeof(T), inherit);

            if (attributeProvider is Assembly)
                return (T[])Attribute.GetCustomAttributes((Assembly)attributeProvider, typeof(T), inherit);

            if (attributeProvider is MemberInfo)
                return (T[])Attribute.GetCustomAttributes((MemberInfo)attributeProvider, typeof(T), inherit);

            if (attributeProvider is System.Reflection.Module)
                return (T[])Attribute.GetCustomAttributes((System.Reflection.Module)attributeProvider, typeof(T), inherit);

            if (attributeProvider is ParameterInfo)
                return (T[])Attribute.GetCustomAttributes((ParameterInfo)attributeProvider, typeof(T), inherit);

            return (T[])attributeProvider.GetCustomAttributes(typeof(T), inherit);
        }

        public static Type MakeGenericType(Type genericTypeDefinition, params Type[] innerTypes)
        {
            Guard.ArgumentNotNull(genericTypeDefinition, "genericTypeDefinition");
            Guard.ArgumentNotNullOrEmpty<Type>(innerTypes, "innerTypes");
            Guard.ArgumentConditionTrue(genericTypeDefinition.IsGenericTypeDefinition, "genericTypeDefinition", "Type {0} is not a generic type definition.".FormatWith(CultureInfo.InvariantCulture, genericTypeDefinition));

            return genericTypeDefinition.MakeGenericType(innerTypes);
        }

        public static object CreateGeneric(Type genericTypeDefinition, Type innerType, params object[] args)
        {
            return CreateGeneric(genericTypeDefinition, new[] { innerType }, args);
        }

        public static object CreateGeneric(Type genericTypeDefinition, IList<Type> innerTypes, params object[] args)
        {
            return CreateGeneric(genericTypeDefinition, innerTypes, (t, a) => CreateInstance(t, a.ToArray()), args);
        }

        public static object CreateGeneric(Type genericTypeDefinition, IList<Type> innerTypes, Func<Type, IList<object>, object> instanceCreator, params object[] args)
        {
            Guard.ArgumentNotNull(genericTypeDefinition, "genericTypeDefinition");
            Guard.ArgumentNotNullOrEmpty(innerTypes, "innerTypes");
            Guard.ArgumentNotNull(instanceCreator, "createInstance");

            Type specificType = MakeGenericType(genericTypeDefinition, innerTypes.ToArray());

            return instanceCreator(specificType, args);
        }

        public static object CreateInstance(Type type, params object[] args)
        {
            Guard.ArgumentNotNull(type, "type");

#if !PocketPC
            return System.Activator.CreateInstance(type, args);
#else
       // CF doesn't have a Activator.CreateInstance overload that takes args
       // lame

       if (type.IsValueType && CollectionUtils.IsNullOrEmpty<object>(args))
         return Activator.CreateInstance(type);

       ConstructorInfo[] constructors = type.GetConstructors();
       ConstructorInfo match = constructors.Where(c =>
         {
           ParameterInfo[] parameters = c.GetParameters();
           if (parameters.Length != args.Length)
             return false;

           for (int i = 0; i < parameters.Length; i++)
           {
             ParameterInfo parameter = parameters[i];
             object value = args[i];

             if (!IsCompatibleValue(value, parameter.ParameterType))
               return false;
           }

           return true;
         }).FirstOrDefault();

       if (match == null)
         throw new Exception("Could not create '{0}' with given parameters.".FormatWith(CultureInfo.InvariantCulture, type));

       return match.Invoke(args);
#endif
        }

        public static void SplitFullyQualifiedTypeName(string fullyQualifiedTypeName, out string typeName, out string assemblyName)
        {
            int? assemblyDelimiterIndex = GetAssemblyDelimiterIndex(fullyQualifiedTypeName);

            if (assemblyDelimiterIndex != null)
            {
                typeName = fullyQualifiedTypeName.Substring(0, assemblyDelimiterIndex.Value).Trim();
                assemblyName = fullyQualifiedTypeName.Substring(assemblyDelimiterIndex.Value + 1, fullyQualifiedTypeName.Length - assemblyDelimiterIndex.Value - 1).Trim();
            }
            else
            {
                typeName = fullyQualifiedTypeName;
                assemblyName = null;
            }

        }

        private static int? GetAssemblyDelimiterIndex(string fullyQualifiedTypeName)
        {
            // we need to get the first comma following all surrounded in brackets because of generic types
            // e.g. System.Collections.Generic.Dictionary`2[[System.String, mscorlib,Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
            int scope = 0;
            for (int i = 0; i < fullyQualifiedTypeName.Length; i++)
            {
                char current = fullyQualifiedTypeName[i];
                switch (current)
                {
                    case '[':
                        scope++;
                        break;
                    case ']':
                        scope--;
                        break;
                    case ',':
                        if (scope == 0)
                            return i;
                        break;
                }
            }

            return null;
        }

        public static MemberInfo GetMemberInfoFromType(Type targetType, MemberInfo memberInfo)
        {
            const BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            switch (memberInfo.MemberType)
            {
                case MemberTypes.Property:
                    PropertyInfo propertyInfo = (PropertyInfo)memberInfo;

                    Type[] types = propertyInfo.GetIndexParameters().Select(p => p.ParameterType).ToArray();

                    return targetType.GetProperty(propertyInfo.Name, bindingAttr, null, propertyInfo.PropertyType, types, null);
                default:
                    return targetType.GetMember(memberInfo.Name, memberInfo.MemberType, bindingAttr).SingleOrDefault();
            }
        }

        public static IEnumerable<FieldInfo> GetFields(Type targetType, BindingFlags bindingAttr)
        {
            Guard.ArgumentNotNull(targetType, "targetType");

            List<MemberInfo> fieldInfos = new List<MemberInfo>(targetType.GetFields(bindingAttr));
            // Type.GetFields doesn't return inherited private fields
            // manually find private fields from base class
            GetChildPrivateFields(fieldInfos, targetType, bindingAttr);

            return fieldInfos.Cast<FieldInfo>();
        }

        private static void GetChildPrivateFields(IList<MemberInfo> initialFields, Type targetType, BindingFlags bindingAttr)
        {
            // fix weirdness with private FieldInfos only being returned for the current Type
            // find base type fields and add them to result
            if ((bindingAttr & BindingFlags.NonPublic) != 0)
            {
                // modify flags to not search for public fields
                BindingFlags nonPublicBindingAttr = bindingAttr.RemoveFlag(BindingFlags.Public);

                while ((targetType = targetType.BaseType) != null)
                {
                    // filter out protected fields
                    IEnumerable<MemberInfo> childPrivateFields =
                      targetType.GetFields(nonPublicBindingAttr).Where(f => f.IsPrivate).Cast<MemberInfo>();

                    // TODO: Remove thos ToList with an extension
                    initialFields.AddRange(childPrivateFields);
                }
            }
        }

        public static IEnumerable<PropertyInfo> GetProperties(Type targetType, BindingFlags bindingAttr)
        {
            Guard.ArgumentNotNull(targetType, "targetType");

            List<PropertyInfo> propertyInfos = new List<PropertyInfo>(targetType.GetProperties(bindingAttr));
            GetChildPrivateProperties(propertyInfos, targetType, bindingAttr);

            // a base class private getter/setter will be inaccessable unless the property was gotten from the base class
            for (int i = 0; i < propertyInfos.Count; i++)
            {
                PropertyInfo member = propertyInfos[i];
                if (member.DeclaringType != targetType)
                {
                    PropertyInfo declaredMember = (PropertyInfo)GetMemberInfoFromType(member.DeclaringType, member);
                    propertyInfos[i] = declaredMember;
                }
            }

            return propertyInfos;
        }

        public static BindingFlags RemoveFlag(this BindingFlags bindingAttr, BindingFlags flag)
        {
            return ((bindingAttr & flag) == flag)
              ? bindingAttr ^ flag
              : bindingAttr;
        }

        private static void GetChildPrivateProperties(IList<PropertyInfo> initialProperties, Type targetType, BindingFlags bindingAttr)
        {
            // fix weirdness with private PropertyInfos only being returned for the current Type
            // find base type properties and add them to result
            if ((bindingAttr & BindingFlags.NonPublic) != 0)
            {
                // modify flags to not search for public fields
                BindingFlags nonPublicBindingAttr = bindingAttr.RemoveFlag(BindingFlags.Public);

                while ((targetType = targetType.BaseType) != null)
                {
                    foreach (PropertyInfo propertyInfo in targetType.GetProperties(nonPublicBindingAttr))
                    {
                        PropertyInfo nonPublicProperty = propertyInfo;

                        // have to test on name rather than reference because instances are different
                        // depending on the type that GetProperties was called on
                        int index = initialProperties.IndexOf(p => p.Name == nonPublicProperty.Name);
                        if (index == -1)
                        {
                            initialProperties.Add(nonPublicProperty);
                        }
                        else
                        {
                            // replace nonpublic properties for a child, but gotten from
                            // the parent with the one from the child
                            // the property gotten from the child will have access to private getter/setter
                            initialProperties[index] = nonPublicProperty;
                        }
                    }
                }
            }
        }
    }
}


