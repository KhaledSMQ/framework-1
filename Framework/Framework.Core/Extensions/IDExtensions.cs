﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// =========================================================================

using Framework.Core.Patterns;
using System.Linq;

namespace Framework.Core.Extensions
{
    public static class IDExtensions
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
    }
}
