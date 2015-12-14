// ============================================================================
// Project: Framework
// Name/Class: IHasLocale
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Pattern for items that are localized.
// ============================================================================

namespace Framework.Core.Patterns
{
    public interface ILocale<T>
    {
        T Locale { get; set; }
    }
}
