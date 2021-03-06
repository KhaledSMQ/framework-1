﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace Framework.Forms.Model.Template
{
    public class FormSetting
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        //
        // CONSTRUCTORS
        // 

        public FormSetting()
        {
            Name = string.Empty;
            Description = string.Empty;
            Value = string.Empty;
        }
    }
}
