// ============================================================================
// Project: Framework
// Name/Class: IThing
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Thing behaviour class.
// ============================================================================

using System;
using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    public interface IThing : IDictionary<string, object>, IXmlReady, IXmlReadyParameterized
    {
        //
        // GET (generic information about ITEM)
        // 

        IEnumerable<string> Names { get; }

        new IEnumerable<object> Values { get; }

        //
        // GET/SET PROPERTIES (based on NAME)
        //

        object GetProperty(string name);

        object GetOptionalProperty(string name, object dftValue);

        O GetProperty<O>(string name, Func<object, object, O> converter);

        O GetOptionalProperty<O>(string name, Func<object, object, O> converter, object dftValue);

        void SetProperty(string name, object value);

        void UpdateOrAddProperty(string name, object value);
    }
}
