// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// =========================================================================

using Framework.Core.Patterns;
using System.Linq;

namespace Framework.Data.Extensions
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
