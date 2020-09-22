// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalizeEntityViewBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2020
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ajsuth.Foundation.Views.Engine.Pipelines.Blocks
{
    using System.Linq;
    using System.Threading.Tasks;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.EntityViews;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines a block which localizes an EntityView.
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.PipelineBlock{Sitecore.Commerce.EntityViews.EntityView,
    ///         Sitecore.Commerce.EntityViews.EntityView, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName(Engine.ViewsConstants.Pipelines.Blocks.LocalizeEntityView)]
    public class LocalizeEntityViewBlock : AsyncPipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        private readonly CommerceCommander Commander;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizeEntityViewBlock"/> class.
        /// </summary>
        /// <param name="commander">The commerce commander.</param>
        public LocalizeEntityViewBlock(CommerceCommander commander)
        {
            Commander = commander;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="arg">The entity view.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        /// The <see cref="EntityView" />.
        /// </returns>
        public override async Task<EntityView> RunAsync(EntityView arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{Name}: The entityView cannot be null.");

            await LocalizeEntityView(arg, context).ConfigureAwait(false);

            return arg;
        }

        /// <summary>
        /// Localizes the entity view.
        /// </summary>
        /// <param name="entityView">The entity view.</param>
        /// <param name="context">The context.</param>
        /// <returns>a <see cref="Task"/></returns>
        private async Task LocalizeEntityView(EntityView entityView, CommercePipelineExecutionContext context)
        {
            foreach (var property in entityView.Properties.Where(p => !string.IsNullOrEmpty(p.Name)).ToList())
            {
                var policy = property.Policies.FirstOrDefault(p => p.PolicyId == "Description");
                if (policy != null)
                {
                    property.Policies.Remove(policy);
                }

                policy = new Policy { PolicyId = "Description" };
                
                var descriptionTerm = await Commander.Pipeline<IGetEntityViewLocalizedTermPipeline>()
                    .RunAsync(new ViewLocalizedTermArgument(property.Name.Replace(".", string.Empty), "ViewPropertyName"), context)
                    .ConfigureAwait(false);

                if (descriptionTerm == null)
                {
                    continue;
                }

                policy.Models.Add(new Model() { Name = descriptionTerm?.Description ?? string.Empty });

                property.Policies.Add(policy);
            }
        }
    }
}
