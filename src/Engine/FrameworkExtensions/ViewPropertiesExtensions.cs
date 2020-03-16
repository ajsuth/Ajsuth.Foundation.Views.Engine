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
    }
}
