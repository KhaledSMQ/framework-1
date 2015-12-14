// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// =========================================================================

using System.Linq;
using Framework.Core.Patterns;

namespace Framework.CMS.Api.Query
{
    public static class Filter
    {
        //
        // By ID.
        //

        public static IQueryable<T> ByID<T>(this IQueryable<T> queryable, int id) where T : class, IID<int>
        {
            return queryable.Where(c => c.ID == id);
        }

        //
        // By Ref.
        //

        public static IQueryable<T> ByRef<T>(this IQueryable<T> queryable, string reff) where T : class, IRef<string>
        {
            return queryable.Where(c => c.Ref == reff);
        }

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
