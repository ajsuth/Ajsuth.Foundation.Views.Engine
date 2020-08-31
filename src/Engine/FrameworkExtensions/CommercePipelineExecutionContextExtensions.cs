//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CommercePipelineExecutionContextExtensions.cs" company="Sitecore Corporation">
//    Copyright (c) Sitecore Corporation 1999-2020
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Ajsuth.Foundation.Views.Engine.FrameworkExtensions
{
    using Sitecore.Commerce.Core;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for the <see cref="CommercePipelineExecutionContext"/> type.
    /// </summary>
    public static class CommercePipelineExecutionContextExtensions
    {
        /// <summary>
        /// Configures a CommerceContext to include the target policy with target value. Intended for usage for UI Types of EntityLink, ItemLink, and SubItemLink.
        /// </summary>
        /// <param name="instance">The view property.</param>
        /// <param name="target">The target attribute value specifies where to open the linked document.</param>
        /// <returns></returns>
        public static async Task AddInvalidPropertyValidationError(this CommercePipelineExecutionContext context, string propertyName)
        {
            await context.CommerceContext.AddMessage(
                context.GetPolicy<KnownResultCodes>().ValidationError,
                "InvalidOrMissingPropertyValue",
                new object[] { propertyName },
                $"Invalid or missing value for property '{propertyName}'.").ConfigureAwait(false);
        }
        
    }
}
