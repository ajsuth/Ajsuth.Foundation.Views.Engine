// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPipelineArgumentToContextBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2020
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ajsuth.Foundation.Views.Engine.Pipelines.Blocks
{
    using System.Threading.Tasks;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines the add pipeline argument to context block.
    /// </summary>
    [PipelineDisplayName(ViewsConstants.Pipelines.Blocks.AddPipelineArgumentToContext)]
    public class AddPipelineArgumentToContextBlock : PipelineBlock<PipelineArgument, PipelineArgument, CommercePipelineExecutionContext>
    {
        private readonly CommerceCommander _commerceCommander;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddRedirectPolicyBlock"/> class.
        /// </summary>
        /// <param name="commerceCommander">The commerce commander.</param>
        public AddPipelineArgumentToContextBlock(CommerceCommander commerceCommander)
        {
            this._commerceCommander = commerceCommander;
        }

        /// <summary>
        /// Executes the pipeline block.
        /// </summary>
        /// <param name="arg">The entity view.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override async Task<PipelineArgument> Run(PipelineArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{Name}: The argument cannot be null");

            var enablementPolicy = context.GetPolicy<Policies.ViewFeatureEnablementPolicy>();
            if (!enablementPolicy.RedirectOnCreate)
            {
                return await Task.FromResult(arg).ConfigureAwait(false);
            }

            context.CommerceContext.AddObject(arg);

            return await Task.FromResult(arg).ConfigureAwait(false);
        }
    }
}