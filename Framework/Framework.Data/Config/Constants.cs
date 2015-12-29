// ============================================================================
// Project: Framework
// Name/Class: Manager
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime data store implementation.
// ============================================================================

using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Xml;

namespace Framework.Data.Config
{
    public static class Constants
    {
        public const string SECTION = "frameworkDataStore";
        public const string CLUSTERS = "clusters";
        public const string ENTITIES = "entities";
        public const string CONTEXT = "context";
        public const string MODELS = "models";
        public const string NAME = "name";
        public const string DESCRIPTION = "description";
        public const string TYPE = "type";
        public const string VALUE = "value";
        public const string SETTINGS = "settings";
    }
}
