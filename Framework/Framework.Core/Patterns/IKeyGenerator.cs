// ============================================================================
// Project: Framework
// Name/Class: IKeyGenerator
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that generate keys.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IKeyGenerator<T>
    {
        //
        // Method to generate a new key.
        //

        T GetKey();

        //
        // Method to return the next key, without generating it.
        //

        T NextKey();

        //
        // Method to reset the key generator. 
        //

        void Reset();
    }
}
