﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 4/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace Framework.Core.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ServicePropertyAttribute : System.Attribute
    {
        //
        // Name for service property.
        // This is the user defined property and not
        // the actual name of the property in the service 
        // implementation.
        //

        public string Name { get; set; }

        //
        // Define whether this property is required by
        // the service. If the property is requiredand 
        // its not found then the service cannot be 
        // instantiated/used.
        //

        public bool Required { get; set; }

        //
        // CONSTRUCTOR
        // Define the default values for the definition
        // of the service property.
        //

        public ServicePropertyAttribute()
        {
            Required = false;
        }
    }
}
