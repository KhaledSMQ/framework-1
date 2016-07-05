﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 08/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System.Collections.Generic;
using Framework.Factory.Patterns;
using Framework.Web.Model.Routing;

namespace Framework.Web.API
{
    public interface IRouting : ICommon
    {
        //
        // Add a list of page routes to configuration.
        // @param lst The list of routes.
        //

        void Add(IEnumerable<PageRoute> lst);

        //
        // Add a new page route to configuration.
        // @param route The route to add.
        //

        void Add(PageRoute route);

        //
        // Add a list of http routes to configuration.
        // @param lst The list of routes.
        //

        void Add(IEnumerable<HttpRoute> lst);

        //
        // Add a new http route to configuration.
        // @param route The route to add.
        //

        void Add(HttpRoute route);

        //
        // Register all routes.
        // Include page and http routes.
        //

        void RegisterRoutes();
    }
}
