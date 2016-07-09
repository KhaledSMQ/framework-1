// ============================================================================
// Project: Framework
// Name/Class: ILocale
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for items that are localized.
// ============================================================================

namespace Framework.Core.Patterns
{
    public interface ILocale<T>
    {
        T Locale { get; set; }
    }
}
