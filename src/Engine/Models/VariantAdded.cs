// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariantAdded.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2020
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ajsuth.Foundation.Views.Engine.Models
{
    using Sitecore.Commerce.Core;

    /// <summary>
    /// Defines the price snapshot added model.
    /// </summary>
    /// <seealso cref="Sitecore.Commerce.Core.Model" />
    public class VariantAdded : Model
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SellableItemVariantAdded"/> class.
        /// </summary>
        /// <param name="variantId">The variant identifier.</param>
        public VariantAdded(string variantId)
        {
            VariantId = variantId;
        }

        /// <summary>
        /// Gets or sets the variant identifier.
        /// </summary>
        /// <value>
        /// The variant identifier.
        /// </value>
        public string VariantId { get; set; }
    }
}
