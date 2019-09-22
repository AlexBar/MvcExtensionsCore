#region Copyright
// Copyright (c) 2009 - 2013, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, hazzik <hazzik@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System;
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Routing;

    /// <summary>
    /// Extensions for <see cref="ModelMetadataItemBuilder{TValue}"/> which add RenderAction methods.
    /// </summary>
    public static class ModelMetadataItemBuilderRenderActionExtensions
    {
        /// <summary>
        /// Marks the value to render partial action.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="action">The child action which should be rendered.</param>
        /// <typeparam name="TModel">Type of the model.</typeparam>
        /// <returns></returns>
        [NotNull]
        public static ModelMetadataItemBuilder<TModel> RenderAction<TModel>([NotNull] this ModelMetadataItemBuilder<TModel> self, Func<IHtmlHelper, IHtmlContent> action)
        {
            self.Template("RenderAction");

            self.AddAction(
                m =>
                {
                    var settings = m.GetAdditionalSettingOrCreateNew<RenderActionSetting>();
                    settings.Action = action;
                });

            return self;
        }

        /// <summary>
        /// Marks the value to render partial action.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <typeparam name="TModel">Type of the model.</typeparam>
        /// <returns></returns>
        [NotNull]
        public static ModelMetadataItemBuilder<TModel> RenderViewComponent<TModel>([NotNull] this ModelMetadataItemBuilder<TModel> self, Type componentType, IDictionary<string, object> componentParams)
        {
            self.Template("RenderAction");

            self.AddAction(
                m =>
                {
                    var settings = m.GetAdditionalSettingOrCreateNew<RenderActionSetting>();
                    settings.ViewComponentType = componentType;
                    settings.ViewComponentParams = componentParams;
                });

            return self;
        }

        /// <summary>
        /// Marks the value to render partial action.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="actionName">The name of the action which should be rendered.</param>
        /// <typeparam name="TModel">Type of the model.</typeparam>
        /// <returns></returns>
        [NotNull]
        public static ModelMetadataItemBuilder<TModel> RenderAction<TModel>([NotNull] this ModelMetadataItemBuilder<TModel> self, [AspMvcAction]string actionName)
        {
            throw new NotImplementedException();
            //return RenderAction(self, html => html.Action(actionName));
        }

        /// <summary>
        /// Marks the value to render partial action.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="actionName">The name of the action which should be rendered.</param>
        /// <param name="controllerName">The name of the controller that contains the action.</param>
        /// <typeparam name="TModel">Type of the model.</typeparam>
        /// <returns></returns>
        [NotNull]
        public static ModelMetadataItemBuilder<TModel> RenderAction<TModel>([NotNull] this ModelMetadataItemBuilder<TModel> self, [AspMvcAction]string actionName, [AspMvcController]string controllerName)
        {
            throw new NotImplementedException();
            //return RenderAction(self, html => html.Action(actionName, controllerName));
        }

        /// <summary>
        /// Marks the value to render partial action.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="actionName">The name of the action which should be rendered.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. You can use <paramref name="routeValues"/> to provide the parameters that are bound to the action method parameters. The <paramref name="routeValues"/> parameter is merged with the original route values and overrides them.</param>
        /// <typeparam name="TModel">Type of the model.</typeparam>
        /// <returns></returns>
        [NotNull]
        public static ModelMetadataItemBuilder<TModel> RenderAction<TModel>([NotNull] this ModelMetadataItemBuilder<TModel> self, [AspMvcAction]string actionName, object routeValues)
        {
            throw new NotImplementedException();
            //return RenderAction(self, html => html.Action(actionName, new RouteValueDictionary(routeValues)));
        }

        /// <summary>
        /// Marks the value to render partial action.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="actionName">The name of the action which should be rendered.</param>
        /// <param name="controllerName">The name of the controller that contains the action.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. You can use <paramref name="routeValues"/> to provide the parameters that are bound to the action method parameters. The <paramref name="routeValues"/> parameter is merged with the original route values and overrides them.</param>
        /// <typeparam name="TModel">Type of the model.</typeparam>
        /// <returns></returns>
        [NotNull]
        public static ModelMetadataItemBuilder<TModel> RenderAction<TModel>([NotNull] this ModelMetadataItemBuilder<TModel> self, [AspMvcAction]string actionName, [AspMvcController]string controllerName, object routeValues)
        {
            throw new NotImplementedException();
            //return RenderAction(self, html => html.Action(actionName, controllerName, new RouteValueDictionary(routeValues)));
        }

        /// <summary>
        /// Marks the value to render partial action.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="actionName">The name of the action which should be rendered.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use <paramref name="routeValues"/> to provide the parameters that are bound to the action method parameters. The <paramref name="routeValues"/> parameter is merged with the original route values and overrides them.</param>
        /// <typeparam name="TModel">Type of the model.</typeparam>
        /// <returns></returns>
        [NotNull]
        public static ModelMetadataItemBuilder<TModel> RenderAction<TModel>([NotNull] this ModelMetadataItemBuilder<TModel> self, [AspMvcAction]string actionName, RouteValueDictionary routeValues)
        {
            throw new NotImplementedException();
            //return RenderAction(self, html => html.Action(actionName, new RouteValueDictionary(routeValues)));
        }

        /// <summary>
        /// Marks the value to render partial action.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="actionName">The name of the action which should be rendered.</param>
        /// <param name="controllerName">The name of the controller that contains the action.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use <paramref name="routeValues"/> to provide the parameters that are bound to the action method parameters. The <paramref name="routeValues"/> parameter is merged with the original route values and overrides them.</param>
        /// <typeparam name="TModel">Type of the model.</typeparam>
        /// <returns></returns>
        [NotNull]
        public static ModelMetadataItemBuilder<TModel> RenderAction<TModel>([NotNull] this ModelMetadataItemBuilder<TModel> self, [AspMvcAction]string actionName, [AspMvcController]string controllerName, RouteValueDictionary routeValues)
        {
            throw new NotImplementedException();
            //return RenderAction(self, html => html.Action(actionName, controllerName, new RouteValueDictionary(routeValues)));
        }
    }
}