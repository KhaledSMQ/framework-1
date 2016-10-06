// ============================================================================
// Project: Framework
// Name/Class: IObjectMap
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for mappings objects.
// ============================================================================ 

using System;

namespace Framework.Core.Patterns
{
    public interface IObjectMapTransform<I, O> : IObjectMap<Func<IObjectMapTransform<I, O>, object, I, O>>
    {
        //
        // Method to call the transformation handler stored in this map.
        // Search the map to find the corresponding namespace and name
        // values, then apply the handler to the input value. if handler is not
        // found, then throw an exception.
        //

        O Call(string namespc, string name, object context, I value);

        //
        // Method to call the transformation handler stored in this map.
        // Search the map to find the corresponding namespace and name
        // values, then apply the handler to the input value. if handler is not
        // found, then throw an exception.
        //

        O Call(string namespc, string name, I value);

        //
        // Method that tries to call a certain handler in this map.
        // If handler is found, then it is executed and the result
        // is placed in the returned argument, if not then nothing
        // is done and the method returns false.
        //

        bool TryCall(string namespc, string name, object context, I value, out O obj);

        //
        // Method that tries to call a certain handler in this map.
        // If handler is found, then it is executed and the result
        // is placed in the returned argument, if not then nothing
        // is done and the method returns false.
        //

        bool TryCall(string namespc, string name, I value, out O obj);
    }
}
