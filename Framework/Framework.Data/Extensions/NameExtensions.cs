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
    public static class NameExtensions
    {
        //
        // By Name.
        //

        public static IQueryable<T> ByName<T>(this IQueryable<T> queryable, string name) where T : class, IName<string>
        {
            return queryable.Where(c => c.Name.Equals(name));
        }
    }
}
