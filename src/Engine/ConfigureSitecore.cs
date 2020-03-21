// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSitecore.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2020
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ajsuth.Foundation.Views.Engine
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.EntityViews;
    using Sitecore.Commerce.Plugin.Catalog;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;

    /// <summary>
    /// The configure sitecore class.
    /// </summary>
    public class ConfigureSitecore : IConfigureSitecore
    {
        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(config => config
                .ConfigurePipeline<IGetEntityViewPipeline>(pipeline => pipeline
                    .Add<Pipelines.Blocks.AddRedirectPolicyBlock>().Before<IFormatEntityViewPipeline>()
                )

                .ConfigurePipeline<ICreateSellableItemVariationPipeline>(pipeline => pipeline
                    .Add<Pipelines.Blocks.AddPipelineArgumentToContextBlock>().Before<CreateSellableItemVariationBlock>()
                    .Add<Pipelines.Blocks.AddVariantModelBlock>().After<CreateSellableItemVariationBlock>()
                )
            );

            services.RegisterAllCommands(assembly);
        }
    }
}