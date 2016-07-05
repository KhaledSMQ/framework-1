﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 08/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Extensions;
using Framework.Factory.Patterns;
using Framework.Web.Config;
using Framework.Web.Config.Routing;
using Framework.Web.Model.Routing;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;

namespace Framework.Web.API
{
    public class SrvRouting : ACommon, IRouting
    {
        //
        // CONSTANTS
        //

        public const string DEFAULT_PAGE_ROUTE_BASE_NAME = "_PageRoute_";
        public const string DEFAULT_HTTP_ROUTE_BASE_NAME = "_HttpRoute_";
        public const string DEFAULT_HTTP_ROUTE_BASE_URL = "_api";

        //
        // PROPERTIES
        //

        public string HttpRouteBaseUrl { get; set; }

        public string HttpRouteBaseName { get; set; }

        public string PageRouteBaseName { get; set; }

        public IDictionary<string, HttpRoute> HttpRoutes { get; set; }

        public IDictionary<string, PageRoute> PageRoutes { get; set; }

        //
        // INIT
        // 

        public override void Init()
        {
            base.Init();
            __InitDefaults();
            __InitInMemoryStorage();
            __InitConfig();
        }

        private void __InitDefaults()
        {
            HttpRouteBaseUrl = DEFAULT_HTTP_ROUTE_BASE_URL;
            HttpRouteBaseName = DEFAULT_HTTP_ROUTE_BASE_NAME;
            PageRouteBaseName = DEFAULT_PAGE_ROUTE_BASE_NAME;
        }

        private void __InitInMemoryStorage()
        {
            HttpRoutes = new SortedDictionary<string, HttpRoute>();
            PageRoutes = new SortedDictionary<string, PageRoute>();
        }

        private void __InitConfig()
        {
            //
            // Load from configuration settings.
            //

            WebConfiguration config = (WebConfiguration)System.Configuration.ConfigurationManager.GetSection(Config.Constants.SECTION);
            if (null != config)
            {
                if (null != config.Routing)
                {
                    //
                    // Page routes.
                    //

                    config.Routing.Pages.Apply<PageRouteElement>(elm => { Add(new PageRoute(elm.Name, elm.FriendlyUrl, elm.Location)); });

                    //
                    // Http routes.
                    //

                    config.Routing.Http.Apply<HttpRouteElement>(elm => { Add(new HttpRoute(elm.Name, elm.Template)); });

                    //
                    // Http base route url.
                    //

                    HttpRouteBaseUrl = config.Routing.HttpRouteBaseUrl;
                }
            }
        }

        //
        // Add a list of page routes to configuration.
        // @param lst The list of routes.
        //

        public void Add(IEnumerable<PageRoute> lst)
        {
            lst.Apply(Add);
        }

        //
        // Add a new page route to configuration.
        // @param route The route to add.
        //

        public void Add(PageRoute route)
        {
            if (null != route)
            {
                route.Name = route.Name.isNullOrEmpty() ? PageRouteBaseName + PageRoutes.Count : route.Name;

                if (!PageRoutes.ContainsKey(route.Name))
                {
                    PageRoutes.Add(route.Name, route);
                }
                else
                {
                    throw new Exception(string.Format("{0}: Page route with name '{1}' was already defined!", Lib.DEFAULT_ERROR_MSG_PREFIX, route.Name));
                }
            }
            else
            {
                throw new Exception(string.Format("{0}: Page route object is null or invalid!", Lib.DEFAULT_ERROR_MSG_PREFIX));
            }
        }

        //
        // Add a list of http routes to configuration.
        // @param lst The list of routes.
        //

        public void Add(IEnumerable<HttpRoute> lst)
        {
            lst.Apply(Add);
        }

        //
        // Add a new http route to configuration.
        // @param route The route to add.
        //

        public void Add(HttpRoute route)
        {
            if (null != route)
            {
                route.Name = route.Name.isNullOrEmpty() ? HttpRouteBaseName + HttpRoutes.Count : route.Name;

                if (!HttpRoutes.ContainsKey(route.Name))
                {
                    HttpRoutes.Add(route.Name, route);
                }
                else
                {
                    throw new Exception(string.Format("{0}: Http route with name '{1}' was already defined!", Lib.DEFAULT_ERROR_MSG_PREFIX, route.Name));
                }
            }
            else
            {
                throw new Exception("Http route object is null or invalid!");
            }
        }

        //
        // Method to register all routes, http 
        // and page routes.
        //

        public void RegisterRoutes()
        {
            //
            // Register http routes.
            //

            string baseUrl = HttpRouteBaseUrl.isNullOrEmpty() ? string.Empty : HttpRouteBaseUrl + "/";

            HttpRoutes.Values.Apply(route =>
            {
                RouteTable.Routes.MapHttpRoute(route.Name, string.Concat(baseUrl, route.Template), new { id = RouteParameter.Optional });
            });

            //
            // Register page routes.
            //

            PageRoutes.Values.Apply(route =>
            {
                RouteTable.Routes.MapPageRoute(route.Name, route.FriendlyUrl, route.Location);
            });
        }
    }
}
