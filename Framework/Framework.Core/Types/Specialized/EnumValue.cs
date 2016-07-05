// ============================================================================
// Project: Framework
// Name/Class: EnumValue
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Description class for enumeration values.
// ============================================================================

namespace Framework.Core.Types.Specialized
{
    public class EnumValue<T> where T : struct
    {
        //
        // PROPERTIES
        //

        public string Name { get { return _Name; } }
        public T Value { get { return _Value; } }

        //
        // CONSTRUCTORS
        //

        public EnumValue(string name, T value)
        {
            _Name = name;
            _Value = value;
        }

        //
        // PRIVATE PROPERTIES
        //

        private readonly string _Name;
        private readonly T _Value;
    }
}