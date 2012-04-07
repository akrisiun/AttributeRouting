﻿using System;
using System.Web;
using System.Web.Routing;
using AttributeRouting.Framework.Factories;
using AttributeRouting.Web.Framework;
using AttributeRouting.Web.Framework.Factories;

namespace AttributeRouting.Web {
    public abstract class WebAttributeRoutingConfiguration<TController, TParameter>
        : AttributeRoutingConfiguration<IRouteConstraint, TController, AttributeRoute<TController, TParameter>, TParameter, HttpContextBase, RouteData>
    {
        private readonly IConstraintFactory<IRouteConstraint> _constraintFactory;

        protected WebAttributeRoutingConfiguration(Func<IRouteHandler> handlerFactory) {
            RouteHandlerFactory = handlerFactory;

            _constraintFactory = new ConstraintFactory();
        }

        /// <summary>
        /// Constraint factory
        /// </summary>
        public override IConstraintFactory<IRouteConstraint> ConstraintFactory {
            get { return _constraintFactory; }
        }

        public Func<IRouteHandler> RouteHandlerFactory { get; set; }

        /// <summary>
        /// Specifies a function that returns an alternate route handler.
        /// By default, the route handler is the default handler for the namespace type (Mvc, Http).
        /// </summary>
        /// <example>
        /// <code>
        /// routes.MapAttributeRoutes(config =>
        /// {
        ///    config.ScanAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        ///    config.UseRouteHandler(() => new MyOtherLibrary.Mvc.CustomRouteHandler());
        ///    // default:  config.UseRouteHandler(() => new System.Web.Mvc.MvcRouteHandler());
        /// });
        /// 
        /// routes.MapHttpAttributeRoutes(config =>
        /// {
        ///    config.ScanAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        ///    config.UseRouteHandler(() => new MyOtherLibrary.WebApi.CustomRouteHandler());
        ///    // default:  config.UseRouteHandler(() => System.Web.Http.WebHost.HttpControllerRouteHandler.Instance());
        /// });        
        /// </code>
        /// </example>
        /// <param name="routeHandlerFactory"></param>
        public void UseRouteHandler(Func<IRouteHandler> routeHandlerFactory) {
            RouteHandlerFactory = routeHandlerFactory;
        }
    }
}