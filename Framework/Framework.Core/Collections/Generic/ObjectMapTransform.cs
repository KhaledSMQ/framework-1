// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Implements a type mapping dictionary. 
//              Mapping a namespace and name combination to a generic 
//              function transformation.
// ============================================================================

using System;
using Framework.Core.Patterns;

namespace Framework.Core.Objects
{
    public class ObjectMapTransform<I, O> : ObjectMap<Func<IObjectMapTransform<I, O>, object, I, O>>, IObjectMapTransform<I, O>
    {
        //
        // Default constructor, initialize object mapper.
        //

        public ObjectMapTransform() : base() { }

        //
        // Method to call the transformation handler stored in this map.
        // Search the map to find the corresponding namespace and name
        // values, then apply the handler to the input value. if handler is not
        // found, then throw an exception.
        //

        public O Call(string namespc, string name, object context, I value)
        {
            // 
            // Fetch handler, execute it and return output.
            //

            return GetRequired(namespc, name)(this, context, value);
        }

        //
        // Method to call the transformation handler stored in this map.
        // Search the map to find the corresponding namespace and name
        // values, then apply the handler to the input value. if handler is not
        // found, then throw an exception. Uses DefaultNamespace.
        //

        public O Call(string name, object context, I value)
        {
            // 
            // Fetch handler, execute it and return output.
            //

            return Call(DefaultNamespace, context, value);
        }

        //
        // Method to call the transformation handler stored in this map.
        // Search the map to find the corresponding namespace and name
        // values, then apply the handler to the input value. if handler is not
        // found, then throw an exception.
        //

        public O Call(string namespc, string name, I value)
        {
            return Call(namespc, name, null, value);
        }

        //
        // Method to call the transformation handler stored in this map.
        // Search the map to find the corresponding namespace and name
        // values, then apply the handler to the input value. if handler is not
        // found, then throw an exception. Uses DefaultNamespace.
        //

        public O Call(string name, I value)
        {
            return Call(DefaultNamespace, name, null, value);
        }

        //
        // Method that tries to call a certain handler in this map.
        // If handler is found, then it is executed and the result
        // is placed in the returned argument, if not then nothing
        // is done and the method returns false.
        //

        public bool TryCall(string namespc, string name, object context, I value, out O obj)
        {
            obj = default(O);
            bool retValue = true;

            // 
            // Search map for the handler
            //

            if (ContainsKey(GetKey(namespc, name)))
            {
                obj = Call(namespc, name, context, value);
            }
            else
            {
                // 
                // No method found, return false
                //

                retValue = false;
            }

            return retValue;
        }

        //
        // Method that tries to call a certain handler in this map.
        // If handler is found, then it is executed and the result
        // is placed in the returned argument, if not then nothing
        // is done and the method returns false. Uses DefaultNamespace.
        //

        public bool TryCall(string name, object context, I value, out O obj)
        {
            return TryCall(DefaultNamespace, name, context, value, out obj);
        }

        //
        // Method that tries to call a certain handler in this map.
        // If handler is found, then it is executed and the result
        // is placed in the returned argument, if not then nothing
        // is done and the method returns false.
        //

        public bool TryCall(string namespc, string name, I value, out O obj)
        {
            return TryCall(namespc, name, null, value, out obj);
        }

        //
        // Method that tries to call a certain handler in this map.
        // If handler is found, then it is executed and the result
        // is placed in the returned argument, if not then nothing
        // is done and the method returns false. Uses DefaultNamespace.
        //

        public bool TryCall(string name, I value, out O obj)
        {
            return TryCall(DefaultNamespace, name, value, out obj);
        }
    }
}
