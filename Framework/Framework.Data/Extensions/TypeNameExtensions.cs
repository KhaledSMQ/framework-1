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
    public static class TypeNameExtensions
    {
        //
        // By Name.
        //

        public static IQueryable<T> ByName<T>(this IQueryable<T> queryable, string typeName) where T : class, ITypeName<string>
        {
            return queryable.Where(c => c.TypeName.Equals(typeName));
        }
    }
}
