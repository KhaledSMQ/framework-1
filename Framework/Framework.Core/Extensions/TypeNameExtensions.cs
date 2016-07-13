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
    public static class TypeNameExtensions
    {
        //
        // By TypeName.
        //

        public static IQueryable<T> ByTypeName<T>(this IQueryable<T> queryable, string typeName) where T : class, ITypeName<string>
        {
            return queryable.Where(c => c.TypeName.Equals(typeName));
        }
    }
}
