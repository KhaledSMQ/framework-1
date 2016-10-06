// ============================================================================
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
