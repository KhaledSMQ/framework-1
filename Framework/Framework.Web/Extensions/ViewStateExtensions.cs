// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 08/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System.Web.UI;

namespace Framework.Web.Extensions
{
    public static class ViewStateExtensions
    {
        //
        // Set the value of a viewstate property.
        //

        public static void Set<T>(this StateBag vs, string property, T value)
        {
            vs[property] = value;
        }

        //
        // Get the value of a viewstate property 
        //

        public static T Get<T>(this StateBag vs, string property, T dftValue)
        {
            object value = vs[property];
            if (null == value)
            {
                return dftValue;
            }
            else
            {
                return (T)value;
            }
        }
    }
}
