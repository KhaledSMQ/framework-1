// ============================================================================
// Project: Framework
// Name/Class: ViewStateExtensions
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 29/July/2013
// Company: Coop4Creativity
// Description: Extensions methods for ASP.NET Viewstate
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
