// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddVariantModelBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2020
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ajsuth.Foundation.Views.Engine.Pipelines.Blocks
{
    using System.Threading.Tasks;
    using Ajsuth.Foundation.Views.Engine.Models;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.Catalog;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines the add variant model to context block.
    /// </summary>
    [PipelineDisplayName(ViewsConstants.Pipelines.Blocks.AddVariantModel)]
    public class AddVariantModelBlock : PipelineBlock<SellableItem, SellableItem, CommercePipelineExecutionContext>
    {
        private readonly CommerceCommander _commerceCommander;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddVariantModelBlock"/> class.
        /// </summary>
        /// <param name="commerceCommander">The commerce commander.</param>
        public AddVariantModelBlock(CommerceCommander commerceCommander)
        {
            this._commerceCommander = commerceCommander;
        }

        /// <summary>
        /// Executes the pipeline block.
        /// </summary>
        /// <param name="arg">The entity view.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override async Task<SellableItem> Run(SellableItem arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{Name}: The argument cannot be null");

            var enablementPolicy = context.GetPolicy<Policies.ViewFeatureEnablementPolicy>();
            if (!enablementPolicy.RedirectOnCreate)
            {
                return await Task.FromResult(arg).ConfigureAwait(false);
            }

            var pipelineArgument = context.CommerceContext.GetObject<CreateSellableItemVariationtArgument>();
            
            context.CommerceContext.AddModel(new VariantAdded(pipelineArgument.VariantId) { Name = pipelineArgument.VariantName });

            return await Task.FromResult(arg).ConfigureAwait(false);
        }
    }
}