// ============================================================================
// Project: Framework
// Name/Class: Utils
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Utils methods for enumerations.
// ============================================================================

using Framework.Core.Collections.Specialized;
using Framework.Core.Error;
using Framework.Core.Extensions;
using Framework.Core.Types.Specialized;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Framework.Core.Helpers
{
    public static class EnumHelper
    {
        //
        // If a particular enum type if defined as a set of flags,
        // this method will retrieve a list of those values.
        // @param value A value of type enum with the Flags attribute.
        // @return The list of flags for the enumeration type.
        //

        public static IList<T> GetListOfFlags<T>(T value) where T : struct
        {
            IList<T> selectedFlagsValues = null;
            Type enumType = typeof(T);

            if (enumType.IsDefined(typeof(FlagsAttribute), false))
            {
                Type underlyingType = Enum.GetUnderlyingType(value.GetType());

                ulong num = Convert.ToUInt64(value, CultureInfo.InvariantCulture);
                EnumCollection<ulong> enumNameValues = GetCollectionOfNamesAndValues<T>();
                selectedFlagsValues = new List<T>();

                foreach (EnumValue<ulong> enumNameValue in enumNameValues)
                {
                    if ((num & enumNameValue.Value) == enumNameValue.Value && enumNameValue.Value != 0)
                    {
                        selectedFlagsValues.Add((T)Convert.ChangeType(enumNameValue.Value, underlyingType, CultureInfo.CurrentCulture));
                    }
                }

                if (selectedFlagsValues.Count == 0 && enumNameValues.SingleOrDefault(v => v.Value == 0) != null)
                {
                    selectedFlagsValues.Add(default(T));
                }
            }
            else
            {
                Throw.WithMessage(Lib.DEFAULT_ERROR_MSG_PREFIX, "Enum type {0} is not a set of flags.", enumType);
            }

            return selectedFlagsValues;
        }

        //
        // Gets a dictionary of the names and values of an Enum type.
        // Returns a collection of names and values for the supplied
        // enumeration typed argument.
        //

        public static EnumCollection<ulong> GetCollectionOfNamesAndValues<T>() where T : struct
        {
            return GetCollectionOfNamesAndValues<ulong>(typeof(T));
        }

        //
        // Gets a dictionary of the names and values of an Enum type.
        // @param enumType The CLR type definition for the enumeration.
        // @return The collection of names and values for that type.
        //

        public static EnumCollection<TUnderlyingType> GetCollectionOfNamesAndValues<TUnderlyingType>(Type enumType) where TUnderlyingType : struct
        {
            //
            // Basic checks for input parameter.
            //

            Guard.ArgumentNotNull(enumType, "enumType");
            Guard.ArgumentTypeIsEnum(enumType, "enumType");

            IList<object> enumValues = GetListOfValues(enumType);
            IList<string> enumNames = GetListOfNames(enumType);

            EnumCollection<TUnderlyingType> nameValues = new EnumCollection<TUnderlyingType>();

            GetListOfValues(enumType).Apply((value, index) =>
            {
                try
                {
                    EnumValue<TUnderlyingType> enumValue = new EnumValue<TUnderlyingType>(enumNames[index], (TUnderlyingType)Convert.ChangeType(value, typeof(TUnderlyingType), CultureInfo.CurrentCulture));
                    nameValues.Add(enumValue);
                }
                catch (OverflowException)
                {
                    Throw.WithMessage(
                        Lib.DEFAULT_ERROR_MSG_PREFIX,
                        "Value from enum with the underlying type of {0} cannot be added to dictionary with a value type of {1}. Value was too large: {2}",
                        Enum.GetUnderlyingType(enumType), typeof(TUnderlyingType), Convert.ToUInt64(value, CultureInfo.InvariantCulture));
                }
            });

            return nameValues;
        }

        //
        // Based on an enumeration CLR type, return the list of values defined.
        // @param enumType The CLR enum type.
        // @return The list of values as defined by that types.
        //

        public static IList<object> GetListOfValues(Type enumType)
        {
            return GetListOfFields(enumType).Map(new List<object>(), field => field.GetValue(enumType));
        }

        //
        // Based on an enumeration CLR type, return the list of names defined.
        // @param enumType The CLR enum type.
        // @return The list of names as defined by that types.
        //

        public static IList<string> GetListOfNames(Type enumType)
        {
            return GetListOfFields(enumType).Select(field => field.Name).ToList();
        }

        //
        // Based on an enumeration CLR type, return the list of fields.
        // @param enumType The CLR enum type.
        // @return The list of field as defined by that types.
        //

        public static IList<FieldInfo> GetListOfFields(Type enumType)
        {
            Guard.ArgumentTypeIsEnum(enumType, "enumType");
            return enumType.GetFields().Where(field => field.IsLiteral).ToList();
        }
    }
}