// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// =========================================================================

using Framework.Core.Patterns;
using System.Linq;

namespace Framework.Core.Extensions
{
    public static class VisibleExtensions
    {
        //
        // By Visiblity.
        //

        public static IQueryable<T> Visible<T>(this IQueryable<T> queryable) where T : class, IVisible
        {
            return queryable.Visibility<T>(TypeOfVisibility.ACTIVE);
        }

        public static IQueryable<T> Visibility<T>(this IQueryable<T> queryable, TypeOfVisibility state) where T : class, IVisible
        {
            return queryable.Where(c => c.Visibility == state);
        }
    }
}
