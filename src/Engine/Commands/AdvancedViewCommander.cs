using Ajsuth.Foundation.Views.Engine.Policies;
using Newtonsoft.Json;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ajsuth.Foundation.Views.Engine.Commands
{
    public class AdvancedViewCommander : ViewCommander
    {
        public AdvancedViewCommander(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        protected string GetAction(CommerceContext commerceContext, EntityView entityView = null)
        {
            return entityView?.Action ?? CurrentEntityViewArgument(commerceContext)?.ForAction;
        }

        protected string GetViewName(CommerceContext commerceContext, EntityView entityView = null)
        {
            return entityView?.Name ?? CurrentEntityViewArgument(commerceContext)?.ViewName;
        }

        public virtual bool IsValidView(CommerceContext commerceContext, List<string> validViewNames, EntityView entityView = null)
        {
            var entityViewName = GetViewName(commerceContext, entityView);

            if (string.IsNullOrEmpty(entityViewName))
            {
                return false;
            }

            return validViewNames.Where(view => view.Equals(entityViewName, StringComparison.OrdinalIgnoreCase)).Any();
        }

        public virtual bool IsView(CommerceContext commerceContext, string viewName, EntityView entityView = null)
        {
            var entityViewName = GetViewName(commerceContext, entityView);

            return !string.IsNullOrWhiteSpace(entityViewName) && entityViewName.Equals(viewName, StringComparison.OrdinalIgnoreCase);
        }

        public virtual bool IsAction(CommerceContext commerceContext, string actionName, EntityView entityView = null)
        {
            var action = GetAction(commerceContext, entityView);

            return !string.IsNullOrWhiteSpace(action) && action.Equals(actionName, StringComparison.OrdinalIgnoreCase);
        }

        public virtual bool IsAddAction(CommerceContext commerceContext, EntityView entityView = null)
        {
            var action = GetAction(commerceContext, entityView);
            var actionsPolicy = commerceContext.GetPolicy<KnownCommonActionsPolicy>();

            return !string.IsNullOrWhiteSpace(action) && action.Equals(actionsPolicy.Add, StringComparison.OrdinalIgnoreCase);
        }

        public virtual bool IsEditAction(CommerceContext commerceContext, EntityView entityView = null)
        {
            var action = GetAction(commerceContext, entityView);
            var actionsPolicy = commerceContext.GetPolicy<KnownCommonActionsPolicy>();

            return !string.IsNullOrWhiteSpace(action) && action.Equals(actionsPolicy.Edit, StringComparison.OrdinalIgnoreCase);
        }

        public virtual bool IsViewAction(CommerceContext commerceContext, EntityView entityView = null)
        {
            var action = GetAction(commerceContext, entityView);
            
            return string.IsNullOrWhiteSpace(action);
        }

        public virtual string[] GetTagsValue(CommerceContext commerceContext, EntityView entityView, string propertyName)
        {
            var tagProperty = entityView.GetProperty(propertyName);
            if (tagProperty.UiType != "Tags")
            {
                //TODO: Insert valiation error Invalid UI Type
                return Array.Empty<string>();
            }
            var tagValues = tagProperty != null ? JsonConvert.DeserializeObject<string[]>(tagProperty.Value) : Array.Empty<string>();

            return tagValues;
        }
    }
}
