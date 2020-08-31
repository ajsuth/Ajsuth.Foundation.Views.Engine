// <copyright file="KnownCommonActionsPolicy.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2020
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ajsuth.Foundation.Views.Engine.Policies
{
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// Defines the known common actions policy
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.Policy" />
    public class KnownCommonActionsPolicy : Policy
    {
        public KnownCommonActionsPolicy()
        {
            Add = nameof(Add);
            Edit = nameof(Edit);
            View = nameof(View);
        }

        public string Add { get; set; }

        public string Edit { get; set; }

        public string View { get; set; }
    }
}