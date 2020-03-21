﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddRedirectPolicyBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2020
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ajsuth.Foundation.Views.Engine.Pipelines.Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.EntityViews;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines the get sellable item view block.
    /// </summary>
    public class AddRedirectPolicyBlock : PipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        private readonly CommerceCommander _commerceCommander;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddRedirectPolicyBlock"/> class.
        /// </summary>
        /// <param name="commerceCommander">The commerce commander.</param>
        public AddRedirectPolicyBlock(CommerceCommander commerceCommander)
        {
            this._commerceCommander = commerceCommander;
        }

        /// <summary>
        /// Executes the pipeline block.
        /// </summary>
        /// <param name="arg">The entity view.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override async Task<EntityView> Run(EntityView arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{Name}: The argument cannot be null");
            
            var request = context.CommerceContext.GetObject<EntityViewArgument>();
            var enablementPolicy = context.GetPolicy<Policies.ViewFeatureEnablementPolicy>();
            if (!enablementPolicy.RedirectOnCreate ||
                string.IsNullOrEmpty(request?.ViewName) ||
                string.IsNullOrEmpty(request?.ForAction) ||
                !IsAddEntityView(request))
            {
                return await Task.FromResult(arg).ConfigureAwait(false);
            }

            arg.Policies.Add(new Policy { PolicyId = "RedirectPolicy" });

            return await Task.FromResult(arg).ConfigureAwait(false);
        }

        protected bool IsAddEntityView(EntityViewArgument request)
        {
            var entityList = new List<string>()
            {
                "AddCatalog",
                "AddCategory",
                "AddSellableItem",
                "AddInventorySet",
                "AddPriceBook",
                "AddPriceCard",
                "AddPromotionBook",
                "AddPromotion"
            };

            return request.ViewName.Equals("Details", StringComparison.OrdinalIgnoreCase) &&
                entityList.Contains(request.ForAction);
        }
    }
}