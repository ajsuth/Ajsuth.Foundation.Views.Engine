//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ViewPropertiesExtensions.cs" company="Sitecore Corporation">
//    Copyright (c) Sitecore Corporation 1999-2020
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Ajsuth.Foundation.Views.Engine.FrameworkExtensions
{
    using System.Collections.Generic;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.EntityViews;

    /// <summary>
    /// Extension methods for the <see cref="ViewProperty"/> type.
    /// </summary>
    public static class ViewPropertiesExtensions
    {
        /// <summary>
        /// Configures a ViewProperty to include the target policy with target value. Intended for usage for UI Types of EntityLink, ItemLink, and SubItemLink.
        /// </summary>
        /// <param name="instance">The view property.</param>
        /// <param name="target">The target attribute value specifies where to open the linked document.</param>
        /// <returns></returns>
        public static void SetTargetPolicy(this ViewProperty instance, string target)
        {
            if (instance == null)
            {
                return;
            }

            instance.Policies.Add(new Policy
            {
                PolicyId = ViewsConstants.ViewProperty.Policies.Target,
                Models = new List<Model>
                    {
                        new Model
                        {
                            Name = target
                        }
                    }
            });
        }

        /// <summary>
        /// Configures a ViewProperty to include the target policy with target value. Intended for usage for UI Types of EntityLink, ItemLink, and SubItemLink.
        /// Applies the default target value "_blank" to open the linked document in a new window or tab.
        /// </summary>
        /// <param name="instance">The view property.</param>
        /// <returns></returns>
        public static void SetTargetPolicy(this ViewProperty instance)
        {
            instance.SetTargetPolicy(ViewsConstants.ViewProperty.Targets.Blank);
        }

        /// <summary>
        /// Configures a ViewProperty's UiType and policies to support the custom entity link.
        /// </summary>
        /// <param name="instance">The view property.</param>
        /// <param name="entityVersion">The entity version.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns></returns>
        public static void SetCustomEntityLink(this ViewProperty instance, int? entityVersion = null, string entityId = null)
        {
            if (instance == null)
            {
                return;
            }

            instance.UiType = ViewsConstants.ViewProperty.UiTypes.CustomEntityLink;

            if (entityVersion != null)
            {
                instance.Policies.Add(
                new Policy
                {
                    PolicyId = ViewsConstants.ViewProperty.Policies.EntityVersion,
                    Models = new List<Model>
                    {
                        new Model { Name = entityVersion.ToString() }
                    }
                });
            }

            if (!string.IsNullOrWhiteSpace(entityId))
            {
                instance.Policies.Add(
                new Policy
                {
                    PolicyId = ViewsConstants.ViewProperty.Policies.EntityId,
                    Models = new List<Model>()
                    {
                        new Model { Name = entityId }
                    }
                });
            }
        }

        /// <summary>
        /// Configures a ViewProperty's UiType and policies to support the custom item link.
        /// </summary>
        /// <param name="instance">The view property.</param>
        /// <param name="viewName">The entity view name.</param>
        /// <param name="entityVersion">The entity version.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <returns></returns>
        public static void SetCustomItemLink(this ViewProperty instance, string viewName = null, int? entityVersion = null, string entityId = null, string itemId = null)
        {
            if (string.IsNullOrWhiteSpace(entityId) || string.IsNullOrWhiteSpace(itemId))
            {
                instance.SetCustomItemLink(viewName, entityVersion, null);
            }
            else
            {
                instance.SetCustomItemLink(viewName, entityVersion, $"{entityId}|{itemId}");
            }
        }

        /// <summary>
        /// Configures a ViewProperty's UiType and policies to support the custom item link.
        /// </summary>
        /// <param name="instance">The view property.</param>
        /// <param name="viewName">The entity view name.</param>
        /// <param name="entityVersion">The entity version.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <returns></returns>
        public static void SetCustomItemLink(this ViewProperty instance, string viewName, int? entityVersion, string itemId)
        {
            if (instance == null)
            {
                return;
            }

            instance.UiType = ViewsConstants.ViewProperty.UiTypes.CustomItemLink;
            
            if (!string.IsNullOrWhiteSpace(viewName))
            {
                instance.Policies.Add(
                new Policy
                {
                    PolicyId = ViewsConstants.ViewProperty.Policies.ViewName,
                    Models = new List<Model>
                    {
                        new Model { Name = viewName }
                    }
                });
            }

            if (entityVersion != null)
            {
                instance.Policies.Add(
                new Policy
                {
                    PolicyId = ViewsConstants.ViewProperty.Policies.EntityVersion,
                    Models = new List<Model>
                    {
                        new Model { Name = entityVersion.ToString() }
                    }
                });
            }

            if (!string.IsNullOrWhiteSpace(itemId))
            {
                instance.Policies.Add(
                new Policy
                {
                    PolicyId = ViewsConstants.ViewProperty.Policies.ItemId,
                    Models = new List<Model>
                    {
                        new Model { Name = itemId }
                    }
                });
            }
        }

    }
}
